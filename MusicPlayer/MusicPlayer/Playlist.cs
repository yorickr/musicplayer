using System;
using System.Collections.Generic;
using System.IO;

namespace MusicPlayer
{
    public class Playlist
    {
        public string name { get; }
        private string basedir;
        public List<Song> songs; 
        public Playlist(string name, string basedir)
        {
            this.songs = new List<Song>();
            this.name = name;
            this.basedir = basedir;
        }

        public void AddSong(Song s)
        {
            this.songs.Add(s);
        }

        public void WriteToFile()
        {
            using (StreamWriter stw = new StreamWriter(basedir + name + ".txt"))
            {
                this.songs.ForEach(s =>
                {
                    stw.WriteLine(s.ToString());
                });
            }
        }
    }
}