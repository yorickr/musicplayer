using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MusicPlayer;
using Newtonsoft.Json.Linq;

namespace MusicPlayer
{
    internal class APIHandler
    {
        private NetworkHandler nw;

        public APIHandler(NetworkHandler nw)
        {
            this.nw = nw;
        }

        public string GetSongURLByID(string id)
        {
            JObject o = nw.SendString("getsongbyid?id=" + id);
            if (o["result"].ToString() == "OK") {
                return o["songurl"].ToString();
            }
            return o["errormsg"].ToString();
            
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
    }
}
