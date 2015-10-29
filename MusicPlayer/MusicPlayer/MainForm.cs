﻿using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace MusicPlayer
{
    public partial class MainForm : Form
    {
        Song testsong;

        public Main main
        {
            get; set;
        }

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            UpdateTimer.Start();
        }

        private void PlayButton_Click(object sender, EventArgs e)
        {
            if (testsong == null)
                testsong = new Song("917", "Test", "Test", "Test", main.api);

            main.audio.Play(testsong);
        }

        private void SongsTableView_SelectionChanged(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection col = SongsTableView.SelectedRows;
        }

        private void PauseButton_Click(object sender, EventArgs e)
        {
            main.audio.Pause();
        }

        private void StopButton_Click(object sender, EventArgs e)
        {
            main.audio.Stop();
        }


        private void UpdateTimer_Tick(object sender, EventArgs e)
        {
            BufferBar.Value = main.audio.Buffered;
            PositionBar.Value = main.audio.Position;
            PositionTrackBar.Value = main.audio.Position;
        }

        private void GenreListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void ArtistListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ArtistListBox.SelectedItems.Count != 0)
                main.ArtistFilter(ArtistListBox.SelectedItems[0].ToString());
        }

        private void AlbumListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(AlbumListView.SelectedItems.Count != 0)
                main.AlbumFilter(AlbumListView.SelectedItems[0].ToString());
        }

        private void SongsTableView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            main.audio.Play(SongsTableView.CurrentRow.DataBoundItem as Song);

        }

        private void PositionTrackBar_ValueChanged()
        {
            main.audio.Seek(PositionTrackBar.Value);
        }
    }
}
