using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer
{
    class Song
    {
        public string Name { get; set; }
        public string Album { get; set; }
        public string Artist { get; set; }
        public string Url { get { return GetURL(); } set { SetURL(value); } }

        private string url;

        public Song(string name, string album, string artist)
        {
            Name = name;
            Album = album;
            Artist = artist;
            url = "";
        }

        private string GetURL()
        {
            if (url == "")
            {
                url = "http://imegumii.nl/music/Old%20Music/Pre-Parade%20-%20Toradora.mp3";
            }

            return url;
        }

        private void SetURL(string str)
        {
            url = str;
        }
    }
}
