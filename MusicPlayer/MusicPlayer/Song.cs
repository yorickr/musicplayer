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

        public Song(string name, string album, string artist)
        {
            Name = name;
            Album = album;
            Artist = artist;
        }
    }
}
