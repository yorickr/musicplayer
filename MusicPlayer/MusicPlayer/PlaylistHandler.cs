using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MusicPlayer
{
    public class PlaylistHandler
    {
        private List<Playlist> playlists;
        private APIHandler api;
        private readonly string basedir = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\.mpplaylists\\";
        public PlaylistHandler(APIHandler api)
        {
            this.playlists = new List<Playlist>();
            this.api = api;
            Populate();
        }

        private void Populate()
        {
            try {
                Directory.GetFiles(basedir).ToList().ForEach(f =>
                {
                    if (f.EndsWith(".txt"))
                    {
                        playlists.Add(new Playlist(Path.GetFileName(f.Replace(".txt","")) ,basedir, api));
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
            playlists.Add(new Playlist(name, basedir, api));
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
            return playlists;
        }
    }
}