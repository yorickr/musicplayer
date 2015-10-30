using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
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
            Populate();
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

        public void Repopulate()
        {
            PlaylistSelectBox.Items.Clear();
            pl.GetPlaylists().ForEach(p => PlaylistSelectBox.Items.Add(p.name));
            if (PlaylistSelectBox.SelectedItem != null)
            {
                PlaylistSongContainer.Items.Clear();
                allPlaylistSongs = pl.GetPlaylistByName(PlaylistSelectBox.SelectedItem.ToString()).GetSongs();
                allPlaylistSongs.ForEach(s => PlaylistSongContainer.Items.Add(s.Name));
            }
        }

        public void Populate()
        {
            pl.GetPlaylists().ForEach(p => PlaylistSelectBox.Items.Add(p.name));
            allsongs = api.GetAllSongs();
            allsongs.ForEach(s => PlaylistSongSelector.Items.Add(s.Name));
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
            Repopulate();
        }

        private void PlaylistNewButton_Click(object sender, EventArgs e)
        {
            pl.MakeNewPlaylistByName(PlaylistNewInputfield.Text);
            Repopulate();
        }
    }
}
