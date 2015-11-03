import json

from yjdaemon.Database import Database as db
import configparser
import string
"""
Add a key to the validAPIcalls dictionary, with a corresponding function
Function should return jsonified data, so that it can then be passed on to the client.
example:

Add this to the dictionary
"getsongs": calls.getsongs

then implement this function
@staticmethod
    def getsongs():
        return calls.jsonify({"song": song})

And the jsonified data will be returned to the client.

Every function MUST return jsonified data!

"""


class calls:
    @staticmethod
    def APIcall(sanitizedpath):
        if sanitizedpath in validAPIcalls:
            return validAPIcalls[sanitizedpath]
        else:
            return None

    @staticmethod
    def getfromrawjson(data, param):
        return calls.dejsonify(data)[param]

    @staticmethod
    def jsonify(data):
        return json.dumps(data, sort_keys=True, indent=4).encode("utf-8")

    @staticmethod
    def dejsonify(rawdata):
        return json.loads(rawdata.decode("utf-8"))

    @staticmethod
    def getallsongs(args):
        return calls.jsonify({"songs": db.executequerystatic("SELECT * FROM tracks;"), "args": args , "result": "OK"})

    @staticmethod
    def getartists(args):
        return calls.jsonify({"artists": db.executequerystatic("SELECT artistName FROM tracks GROUP BY artistName;"), "args": args, "result" : "OK"})

    @staticmethod
    def getalbums(args):
        return calls.jsonify({"albums": db.executequerystatic("SELECT albumName FROM tracks GROUP BY albumName;"), "args": args, "result":"OK"})

    @staticmethod
    def getgenres(args):
        return calls.jsonify({"genres": db.executequerystatic("SELECT genre FROM tracks GROUP BY genre;"), "args": args, "result":"OK"})

    @staticmethod
    def getyears(args):
        return calls.jsonify({"years": db.executequerystatic("SELECT year FROM tracks GROUP BY year;"), "args": args, "result":"OK"})

    @staticmethod
    def getalbumnames(args):
        return calls.jsonify({"albumnames": db.executequerystatic("SELECT albumName FROM tracks GROUP BY albumName;"), "args": args})

    @staticmethod
    def search(args):
        data = args.split("&")
        genquery="""
        SELECT $ident FROM tracks WHERE LCASE(trackName) LIKE LCASE(\"%$trackname%\") $orgenre LCASE(genre) LIKE LCASE(\"%$genre%\") $oralbum LCASE(albumName) LIKE LCASE(\"%$album%\") $orartist LCASE(artistName) LIKE LCASE(\"%$artistname%\") $end;
        """
        query="""
        SELECT $ident FROM tracks WHERE ($or1 OR $or2 OR  $or3 ) $and1 $and2 $and3 $end;
        """
        test = string.Template(query)
        genqueryres = ""
        arguments = []
        general = ""
        for entry in data:
            values = entry.split("=")
            values[1] = values[1].replace("%20"," ")
            if values[0] == "q":
                general = values[1]
                continue
            if values[1]:
                arguments.append(values)
        print(arguments)
        finalstring = "" + genquery
        for arg in arguments:
            if arg[0] == "artist":
                finalstring = string.Template(finalstring).safe_substitute(artistname=arg[1], orartist="AND")
                test = string.Template(test.safe_substitute(and1="AND LCASE(artistName) LIKE LCASE(\"%"+ arg[1] +"%\")"))
            elif arg[0] == "genre":
                finalstring = string.Template(finalstring).safe_substitute(genre=arg[1],orgenre="AND")
                test = string.Template(test.safe_substitute(and2="AND LCASE(genre) LIKE LCASE(\"%"+ arg[1] +"%\")"))
            elif arg[0] == "album":
                finalstring = string.Template(finalstring).safe_substitute(album=arg[1],oralbum="AND")
                test = string.Template(test.safe_substitute(and3="AND LCASE(albumName) LIKE LCASE(\"%"+ arg[1] +"%\")"))
        print(finalstring)
        finalstring = string.Template(finalstring).safe_substitute(genre=general,artistname=general,album=general,trackname=general)
        print(finalstring)
        test = test.safe_substitute( and1="", and2="",and3="",or1="LCASE(artistName) LIKE LCASE(\"%"+general+"%\")",or2="LCASE(genre) LIKE LCASE(\"%"+general+"%\")",or3="LCASE(albumName) LIKE LCASE(\"%"+general+"%\")")
        print(test)
        print(string.Template(test).safe_substitute(ident="*",end=""))
        return calls.jsonify({"result":"OK", "genres": db.executequerystatic(string.Template(test).safe_substitute(ident="genre",end="GROUP BY genre")),"artists": db.executequerystatic(string.Template(test).safe_substitute(ident="artistName",end="GROUP BY artistName")), "albums": db.executequerystatic(string.Template(test).safe_substitute(ident="albumName",end="GROUP BY albumName")), "songs" : db.executequerystatic(string.Template(test).safe_substitute(ident="*",end=""))})

    @staticmethod
    def getsongs(args):
        """Get song by album, genre, year, artist"""
        data = args.partition("?")
        splitstring = data[0].partition("=")
        name= splitstring[0]
        value = splitstring[2].replace("%20"," ")
        if name == "album":
            songs = db.executequerystatic("SELECT * FROM tracks WHERE albumName = \"" + value + "\"")
        elif name == "genre":
            songs = db.executequerystatic("SELECT * FROM tracks WHERE genre = \"" + value + "\"")
        elif name == "year":
            songs = db.executequerystatic("SELECT * FROM tracks WHERE year = \"" + value + "\"")
        elif name == "artist":
            songs = db.executequerystatic("SELECT * FROM tracks WHERE artistName = \"" + value + "\"")
        elif name == "search":
            songs = db.executequerystatic("SELECT * FROM tracks WHERE LCASE(trackName) LIKE LCASE(\"%"+ value + "%\") GROUP BY trackName")
        else:
            return calls.jsonify({"result":"NOK", "errormsg": "Not a valid argument"})
        return calls.jsonify({"result":"OK","songs":songs})

    @staticmethod
    def getsongbyid(args):
        config = configparser.ConfigParser()
        try:
            config.read("config.cfg")
            musicdir = config.get("Library","musicdir")
            port = config.get("HTTP","port")
        except:
            return calls.jsonify({"result" : "NOK" , "errormsg" : "I/O error while reading config."})
        data = args.split("&")
        splitsting = data[0].split("=")
        id = splitsting[1]
        file = db.executequerystatic(
            "SELECT SUBSTRING_INDEX(trackUrl,'" + musicdir + "',-1) as filedir FROM `tracks` WHERE id = " + id)
        try:
            url = str(file[0][0])
        except:
            return calls.jsonify({"result": "NOK", "errormsg" : "Song ID does not exist in database."})
        return calls.jsonify({"result": "OK", "songurl": "http://imegumii.nl:"+ "/music/English"+ url})

    @staticmethod
    def setsong(args, songname):
        global song
        song = songname
        return calls.jsonify({"result": "OK", "args": args})


validAPIcalls = {"getallsongs": calls.getallsongs,
                 "setsong": calls.setsong,
                 "search": calls.search,
                 "getsongs": calls.getsongs,
                 "getsongbyid": calls.getsongbyid,
                 "getartists": calls.getartists,
                 "getalbums": calls.getalbums,
                 "getgenres": calls.getgenres,
                 "getyears": calls.getyears,
                 "getalbumnames": calls.getalbumnames
                 }
