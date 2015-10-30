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
        NotificationPopup p;
        public Main main
        {
            get; set;
        }

        public MainForm()
        {
            InitializeComponent();

            PositionTrackBar.Scroll += (s, e) =>
            {
                if (clicked)
                    return;
                this.PositionTrackBar_ValueChanged();
            };
            PositionTrackBar.MouseDown += (s, e) =>
            {
                clicked = true;
            };
            PositionTrackBar.MouseUp += (s, e) =>
            {
                if (!clicked)
                    return;

                clicked = false;
                this.PositionTrackBar_ValueChanged();
            };

            p = new NotificationPopup(this);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            UpdateTimer.Start();
        }

        private void PlayButton_Click(object sender, EventArgs e)
        {
            SongsTableView_CellDoubleClick(sender, new DataGridViewCellEventArgs(0, 0));
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

            if(!clicked)
                PositionTrackBar.Value = main.audio.Position;

            LabelCurrentTime.Text = main.audio.CurrentTime;
            LabelTotalTime.Text = main.audio.TotalTime;
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
                main.AlbumFilter(AlbumListView.SelectedItems[0].Text);
        }

        private void SongsTableView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            SongsTable s = new SongsTable();
            if(SongsTableView.SelectedRows.Count > 0)
            {
                var drv = SongsTableView.SelectedRows[0].DataBoundItem as DataRowView;
                var row = drv.Row as DataRow;
                s.ImportRow(row);
                System.Console.WriteLine((s.Rows[0][3] as Song).SongID);
                main.audio.Play((s.Rows[0][3] as Song));
            }
            
        }

        private void PositionTrackBar_ValueChanged()
        {
            main.audio.Seek(PositionTrackBar.Value);
        }

        private void notifyIcon1_Click(object sender, EventArgs e)
        {
            if (p.Visible)
                p.Visible = false;
            else
                p.Visible = true;
        }
    }
}
