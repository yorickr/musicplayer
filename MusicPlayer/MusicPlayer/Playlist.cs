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
        public string server;

        private APIHandler api;
        public Playlist(string name, string basedir, string server, APIHandler api)
        {
            this.songs = new List<Song>();
            this.name = name;
            this.api = api;
            this.basedir = basedir;
            this.server = server;
            this.ReadFromFile();
        }

        public void AddSong(Song s)
        {
            this.songs.Add(s);
        }

        public List<Song> GetSongs()
        {
            return songs;
        } 

        public void ReadFromFile()
        {
            try {
                using (StreamReader str = new StreamReader(basedir + name + ".txt"))
                {
                    server = str.ReadLine();

                    string readline;
                    while ((readline = str.ReadLine()) != null)
                    {
                        string[] songsvalues = readline.Split('|');

                        songs.Add(new Song(songsvalues[0], songsvalues[1], songsvalues[2], songsvalues[3], songsvalues[4], Int32.Parse(songsvalues[5]), api));
                    }
                }
            }
            catch (FileNotFoundException)
            {
                FileStream fs = new FileStream(basedir + name + ".txt", FileMode.CreateNew);
                fs.Close();
                File.WriteAllText(basedir + name + ".txt", server);
                ReadFromFile();
            }
            
        }

        public void WriteToFile()
        {
            using (StreamWriter stw = new StreamWriter(basedir + name + ".txt"))
            {
                stw.WriteLine(server.ToString());

                this.songs.ForEach(s =>
                {
                    stw.WriteLine(s.ToString());
                });
                stw.Flush();
            }
        }

        public void Delete()
        {
            try {
                System.IO.File.Move(basedir + name + ".txt", basedir + name + ".txt.old");
            }
            catch(Exception)
            {
                //Already removed.
            }
        }

        internal void RemoveSong(Song s)
        {
            this.songs.Remove(s);
        }
    }
}