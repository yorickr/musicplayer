﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer
{
    public class Main
    {
        public APIHandler api;
        public MainForm form;
        public NetworkHandler nw;
        public AudioHandler audio;

        private SongsTable table;

        public Main(NetworkHandler nw, APIHandler api, MainForm form)
        {
            this.nw = nw;
            this.api = api;
            this.form = form;
            form.main = this;

            audio = new AudioHandler();
            table = new SongsTable();
            form.SongsTableView.DataSource = table;
            form.SongsTableView.Columns[3].Visible = false;
            Populate();
        }

        private void Populate()
        {
            form.AlbumListView.Items.Add("Alle albums");
            foreach (Album a in this.api.GetAlbums())
            {
                form.AlbumListView.Items.Add(a.albumnaam);

            }
            form.ArtistListBox.Items.Add("Alle artiesten");
            foreach (Artist a in this.api.GetArtists())
            {
                form.ArtistListBox.Items.Add(a.naam);

            }
        }

        public void ArtistFilter(string artist)
        {
            table.Clear();
            api.GetSongsByArtist(artist).ForEach(s =>
            {
                table.Add(s);
            });
        }

        public void AlbumFilter(string album)
        {
            table.Clear();
            api.GetSongsByAlbum(album).ForEach(s =>
            {
                table.Add(s);
            });
        }
    }

}


