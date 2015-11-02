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
        public string Genre { get; set; }
        public string Url { get { return GetURL(); } set { SetURL(value); } }
        public int Seconds { get; set; }

        private APIHandler api;

        private string url;

        public Song(string songid, string name, string album, string artist, string genre, int seconds, APIHandler api)
        {
            SongID = songid;
            Name = name;
            Album = album;
            Artist = artist;
            Seconds = seconds;
            Genre = genre;

            this.api = api;

            url = "";
        }

        protected virtual string GetURL()
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

        public override string ToString()
        {
            return $"{this.SongID}|{this.Name}|{this.Album}|{this.Artist}|{this.Genre}|{this.Seconds}";
        }

        public override bool Equals(System.Object obj)
        {
            // If parameter is null return false.
            if (obj == null)
            {
                return false;
            }

            // If parameter cannot be cast to Point return false.
            Song s = obj as Song;
            if ((System.Object)s == null)
            {
                return false;
            }

            // Return true if the fields match:
            return (s.Name == Name) && (s.SongID == SongID);
        }

        public override int GetHashCode()
        {
            return int.Parse(this.SongID);
        }
    }
}
