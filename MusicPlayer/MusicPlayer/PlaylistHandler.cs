using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MusicPlayer
{
    public class PlaylistHandler
    {
        private List<Playlist> playlists;
        private readonly string basedir = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\.mpplaylists\\";
        public PlaylistHandler()
        {
            this.playlists = new List<Playlist>();
            Populate();
        }

        private void Populate()
        {
            try {
                Directory.GetFiles(basedir).ToList().ForEach(f =>
                {
                    if (f.EndsWith(".txt"))
                    {
                        playlists.Add(new Playlist(Path.GetFileName(f.Replace(".txt","")) ,basedir));
                    }
                });
            }
            catch (DirectoryNotFoundException)
            {
                Directory.CreateDirectory(basedir);
                Populate();
            }
            

        }

        public List<Playlist> GetPlaylists()
        {
            return playlists;
        }
    }
}