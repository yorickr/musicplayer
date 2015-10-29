using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer
{
    public class Song
    {
        public string SongID { get; set; }
        public string Name { get; set; }
        public string Album { get; set; }
        public string Artist { get; set; }
        public string Url { get { return GetURL(); } set { SetURL(value); } }

        private APIHandler api;

        private string url;

        public Song(string songid, string name, string album, string artist, APIHandler api)
        {
            SongID = songid;
            Name = name;
            Album = album;
            Artist = artist;

            this.api = api;

            url = "";
        }

        private string GetURL()
        {
            if (url == "")
            {
                url = api.GetSongURLByID(SongID);
            }

            return url;
        }

        private void SetURL(string str)
        {
            url = str;
        }
    }
}
