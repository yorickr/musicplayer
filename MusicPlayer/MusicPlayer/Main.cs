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
        public PlaylistHandler pl;
        public AudioHandler audio;

        private SongsTable table;

        public Main(NetworkHandler nw, APIHandler api, MainForm form, PlaylistHandler pl)
        {
            this.nw = nw;
            this.api = api;
            this.form = form;
            form.main = this;
            this.pl = pl;

            audio = new AudioHandler();
            table = new SongsTable();
            form.SongsTableView.DataSource = table;
            form.SongsTableView.Columns[5].Visible = false;
            Populate();
        }

        private void Populate()
        {
            this.api.GetAlbums().ForEach(a => form.AlbumListView.Items.Add(a.albumnaam));
            this.api.GetArtists().ForEach(a => form.ArtistListBox.Items.Add(a.naam));
            this.api.GetGenres().ForEach(g => form.GenreListBox.Items.Add(g.name));
            this.pl.GetPlaylists().ForEach(p => form.PlaylistBox.Items.Add(p.name));
        }

        public void ArtistFilter(string artist)
        {
            table.Clear();
            api.GetSongsByArtist(artist).ForEach(s =>
            {
                table.Add(s);
            });
        }

        public void GenreFilter(string genre)
        {
            table.Clear();
            api.GetSongsByGenre(genre).ForEach(s =>
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

        public static string SecondsToTimestamp(int seconds)
        {
            string str = "";

            //Hours
            str += (seconds / 3600).ToString("D2") + ":";
            seconds %= 3600;

            //Minutes
            str += (seconds / 60).ToString("D2") + ":";
            seconds %= 60;

            //Seconds
            str += seconds.ToString("D2");

            return str;
        }
    }

}


