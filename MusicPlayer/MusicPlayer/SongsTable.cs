﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer
{
    class SongsTable : DataTable
    {
        public SongsTable() : base()
        {
            this.Columns.Clear();
            this.Columns.Add("Naam", typeof(string));
            this.Columns.Add("Album", typeof(string));
            this.Columns.Add("Artiest", typeof(string));
        }

        public void Add(Song s)
        {
            this.Rows.Add(s.Name, s.Album, s.Artist);
        }
            
    }
}