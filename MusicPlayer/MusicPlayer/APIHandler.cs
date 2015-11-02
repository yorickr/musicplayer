using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MusicPlayer;
using Newtonsoft.Json.Linq;
using System.IO;
using System.Drawing;

namespace MusicPlayer
{
    public class APIHandler
    {
        private NetworkHandler nw;
        private Image defaultCover;
        public APIHandler(NetworkHandler nw)
        {
            this.nw = nw;
            defaultCover = Image.FromStream(nw.downloadArtwork("default-cover.png"));
        }

        public string GetSongURLByID(string id)
        {
            JObject o = nw.SendString("getsongbyid?id=" + id);
            if (o["result"].ToString() == "OK") {
                return o["songurl"].ToString();
            }
            return o["errormsg"].ToString();
        }

        public List<Song> GetSongsByAlbum(string albumname)
        {
            return GetSongsByArgs("album=" + albumname);
        }

        public List<Song> GetSongsByArtist(string artistname)
        {
            return GetSongsByArgs("artist=" + artistname);
        }

        public List<Song> GetSongsByGenre(string genre)
        {
            return GetSongsByArgs("genre=" + genre);
        }

        public List<Song> GetSongsByYear(string year)
        {
            return GetSongsByArgs("album=" + year);
        }

        public List<Song> GetSongsBySearch(string search)
        {
            return GetSongsByArgs("search=" + search);
        }

        public List<Song> GetAllSongs()
        {
            List<Song> allsongslist = new List<Song>();
            JObject o = nw.SendString("getallsongs?");
            if (o["result"].ToString() == "OK")
            {
                dynamic songs = o["songs"];
                for (int i = 0; i < songs.Count; i++)
                {
                    allsongslist.Add(new Song(songs[i][0].ToString(), songs[i][3].ToString(), songs[i][5].ToString(), songs[i][4].ToString(), songs[i][1].ToString(), (int)songs[i][9], this));
                }
            }
            return allsongslist;

        } 

        public List<Song> GetSongsByArgs(string args)
        {
            List<Song> songslist = new List<Song>();
            JObject o = nw.SendString("getsongs?"+args);
            if (o["result"].ToString() == "OK")
            {
                dynamic songs = o["songs"];
                for (int i = 0; i < songs.Count; i++)
                {
                    if(songs[i][2].ToString().EndsWith(".mp3"))
                        songslist.Add(new Song(songs[i][0].ToString(), songs[i][3].ToString(), songs[i][5].ToString(), songs[i][4].ToString(), songs[i][1].ToString(), (int)songs[i][9], this));
                }
            }
            return songslist;
        }

        public List<Artist> GetArtists()
        {
            List<Artist> artistlist = new List<Artist>();

            JObject o = nw.SendString("getartists?id=hallo");
            if (o["result"].ToString() == "OK")
            {
                for (int i = 0; i < o["artists"].Count(); i++) {
                    artistlist.Add(new Artist(o["artists"][i][0].ToString()));
                }
            }
            return artistlist;
        }

        public Image getAlbumCover(string album)
        {
            MemoryStream stream = nw.downloadArtwork(album + ".jpg");
            if(stream != null)
            {
                return Image.FromStream(stream);
            }
            return defaultCover;
        }

        public List<Album> GetAlbums()
        {
            List<Album> albumlist = new List<Album>();

            JObject o = nw.SendString("getalbums?id=hallo");
            if (o["result"].ToString() == "OK")
            {
                for (int i = 0; i < o["albums"].Count(); i++)
                {
                    albumlist.Add(new Album(o["albums"][i][0].ToString()));
                }
            }

            return albumlist;
        }

        public List<Year> GetYears()
        {
            List<Year> yearlist = new List<Year> ();
            JObject o = nw.SendString("getyears?id=hallo");
            if (o["result"].ToString() == "OK")
            {
                for (int i = 0; i < o["years"].Count(); i++)
                {
                    yearlist.Add(new Year(o["years"][i][0].ToString()));
                }
            }
            return yearlist;
        }

        public List<Genre> GetGenres()
        {
            List<Genre> genreslist = new List<Genre>();
            JObject o = nw.SendString("getgenres?id=hallo");
            if (o["result"].ToString() == "OK")
            {
                for (int i = 0; i < o["genres"].Count(); i++)
                {
                    genreslist.Add(new Genre(o["genres"][i][0].ToString()));
                }
            }
            return genreslist;
        }
    }
}
