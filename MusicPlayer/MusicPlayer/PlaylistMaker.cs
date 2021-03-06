﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MusicPlayer
{
    public partial class PlaylistMaker : Form
    {
        private PlaylistHandler pl;
        private APIHandler api;

        private List<Song> allPlaylistSongs;
        private List<Song> allsongs; 

        public PlaylistMaker(PlaylistHandler pl, APIHandler api)
        {
            this.pl = pl;
            this.api = api;
            this.allPlaylistSongs = new List<Song>();
            this.allsongs = new List<Song>();
            InitializeComponent();
        }

        public void PlaylistSelectBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (PlaylistSelectBox.SelectedItem != null)
            {
                PlaylistSongContainer.Items.Clear();
                allPlaylistSongs = pl.GetPlaylistByName(PlaylistSelectBox.SelectedItem.ToString()).GetSongs();
                allPlaylistSongs.ForEach(s => PlaylistSongContainer.Items.Add(s.Name));
            }
        }

        public void Repopulate(bool lastIndex)
        {
            int selection = PlaylistSelectBox.SelectedIndex;
            PlaylistSelectBox.Items.Clear();      
            pl.GetPlaylists().ForEach(p => PlaylistSelectBox.Items.Add(p.name));
            if (lastIndex)
                PlaylistSelectBox.SelectedIndex = PlaylistSelectBox.Items.Count - 1;
            else
                PlaylistSelectBox.SelectedIndex = selection;
            PlaylistSongContainer.Items.Clear();
            if (PlaylistSelectBox.SelectedItem != null)
            {
                allPlaylistSongs = pl.GetPlaylistByName(PlaylistSelectBox.SelectedItem.ToString()).GetSongs();
                allPlaylistSongs.ForEach(s => PlaylistSongContainer.Items.Add(s.Name));
            }
            else
            {
                PlaylistSelectBox.SelectedIndex = -1;
                PlaylistSelectBox.Text = "";
            }
        }

        public void Repopulate()
        {
            Repopulate(false);
        }

        public void Populate()
        {
            pl.GetPlaylists().ForEach(p => PlaylistSelectBox.Items.Add(p.name));
            if (PlaylistSelectBox.Items.Count > 0)
                PlaylistSelectBox.SelectedIndex = 0;
            allsongs = api.GetAllSongs();
            allsongs.ForEach(s => PlaylistSongSelector.Items.Add(s.Name));

            if (PlaylistSelectBox.SelectedItem != null)
            {
                allPlaylistSongs = pl.GetPlaylistByName(PlaylistSelectBox.SelectedItem.ToString()).GetSongs();
                allPlaylistSongs.ForEach(s => PlaylistSongContainer.Items.Add(s.Name));
            }
        }

        private void PlaylistAddSongsButton_Click(object sender, EventArgs e)
        {
            if (PlaylistSelectBox.SelectedItem!=null)
            {
                Playlist currentPlaylist = pl.GetPlaylistByName(PlaylistSelectBox.SelectedItem.ToString());
                foreach (string song in PlaylistSongSelector.SelectedItems)
                {
                    foreach (Song s in allsongs) {
                        if (s.Name == song)
                        {
                            currentPlaylist.AddSong(s);
                            break;
                        }
                    }
                }
                currentPlaylist.WriteToFile();
            }
            Thread.Sleep(10);
            Repopulate();
        }

        public void SearchAllSongs(string search)
        {
            PlaylistSongSelector.Items.Clear();

            if (search.Length > 1)
            {
                string sPattern = search;

                foreach (Song s in allsongs)
                {
                    if (System.Text.RegularExpressions.Regex.IsMatch(s.Name, sPattern, System.Text.RegularExpressions.RegexOptions.IgnoreCase))
                    {
                        PlaylistSongSelector.Items.Add(s.Name);
                    }
                }
            }
            else
            {
                allsongs.ForEach(s => PlaylistSongSelector.Items.Add(s.Name));
            }
        }

        private void PlaylistNewButton_Click(object sender, EventArgs e)
        {
            string name = PlaylistNewInputfield.Text;
            PlaylistNewInputfield.Text = "";
            name = name.Replace('/', '-');
            name = name.Replace('\\', '-');
            pl.MakeNewPlaylistByName(name);
            Repopulate(true);
        }

        private void PlaylistMaker_Load(object sender, EventArgs e)
        {
            Populate();
        }

        private void FilterTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            SearchAllSongs(FilterTextBox.Text);
        }

        private void PlaylistNewInputfield_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                PlaylistNewButton_Click(sender, new EventArgs());
            }
        }

        private void DeletePlaylistButton_Click(object sender, EventArgs e)
        {
            if (PlaylistSelectBox.SelectedItem != null)
                if (MessageBox.Show("Are you sure to delete " + PlaylistSelectBox.SelectedItem.ToString() + "?", "Confirm Delete!", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    pl.RemovePlaylistByName(PlaylistSelectBox.SelectedItem.ToString());
                    Repopulate(true);
                }
        }

        private void DeleteSongsButton_Click(object sender, EventArgs e)
        {
            if (PlaylistSelectBox.SelectedItem != null)
            {
                Playlist currentPlaylist = pl.GetPlaylistByName(PlaylistSelectBox.SelectedItem.ToString());
                foreach (string song in PlaylistSongSelector.SelectedItems)
                {
                    for (int i = currentPlaylist.GetSongs().Count - 1; i > 0; i--)
                    {
                        Song s = currentPlaylist.GetSongs()[i];
                        if (s.Name == song)
                        {
                            currentPlaylist.RemoveSong(s);
                            break;
                        }
                    }
                }
                currentPlaylist.WriteToFile();
            }
            Thread.Sleep(10);
            Repopulate();
        }
    }
}
