using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer
{
    public class SongsTable : DataTable
    {
        public SongsTable() : base()
        {
            this.Columns.Clear();
            this.Columns.Add("Naam", typeof(string));
            this.Columns.Add("Album", typeof(string));
            this.Columns.Add("Artiest", typeof(string));
            this.Columns.Add("Genre", typeof(string));
            this.Columns.Add("Duration", typeof(string));
            this.Columns.Add("song", typeof(Song));
        }

        public void Add(Song s)
        {
            this.Rows.Add(s.Name, s.Album, s.Artist, s.Genre, Main.SecondsToTimestamp(s.Seconds), s);
        }
            
    }
}
