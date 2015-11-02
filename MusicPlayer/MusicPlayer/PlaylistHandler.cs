using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MusicPlayer
{
    public class PlaylistHandler
    {
        private List<Playlist> playlists;
        public Main main
        {
            get; set;
        }
        private readonly string basedir = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\.mpplaylists\\";
        public PlaylistHandler()
        {
            this.playlists = new List<Playlist>();
        }

        public void Populate()
        {
            try {
                Directory.GetFiles(basedir).ToList().ForEach(f =>
                {
                    if (f.EndsWith(".txt"))
                    {
                        playlists.Add(new Playlist(Path.GetFileName(f.Replace(".txt","")) ,basedir, main.nw.ip, main.api));
                    }
                });
            }
            catch (DirectoryNotFoundException)
            {
                Directory.CreateDirectory(basedir);
                Populate();
            }
            

        }

        public void MakeNewPlaylistByName(string name)
        {
            playlists.Add(new Playlist(name, basedir, main.nw.ip, main.api));
        }

        public Playlist GetPlaylistByName(string name)
        {
            Playlist toFind = null;
            playlists.ForEach(p =>
            {
                if (p.name == name) { toFind = p; }
            });
            return toFind;
        } 

        public List<Playlist> GetPlaylists()
        {
            List<Playlist> currentPlaylists = new List<Playlist>();
            foreach(Playlist pl in playlists)
            {
                if (pl.server == main.nw.ip)
                    currentPlaylists.Add(pl);
            }
            return currentPlaylists;
        }
    }
}