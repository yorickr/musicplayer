using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MusicPlayer;
using Newtonsoft.Json.Linq;

namespace MusicPlayer
{
    public class APIHandler
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
            return null;
        }

        public List<Album> GetAlbums()
        {
            return null;
        } 
    }
}
