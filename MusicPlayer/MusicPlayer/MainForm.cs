using NAudio.Wave;
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
            //Trackbar
            if (main.audio.BState == AudioHandler.BufferState.DONE)
                PositionTrackBar.Enabled = true;
            else
                PositionTrackBar.Enabled = false;
            if (!clicked)
                PositionTrackBar.Value = main.audio.Position;

            //Buffer display
            BufferBar.Value = main.audio.Buffered / 10;

            //Time labels
            if (!clicked)
                LabelCurrentTime.Text = Main.SecondsToTimestamp(main.audio.CurrentTime);
            LabelTotalTime.Text = Main.SecondsToTimestamp(main.audio.TotalTime);

            //Current song label
            if (main.audio.CurrentSong == null)
                CurrentSongLabel.Text = "Not playing any songs";
            else
                CurrentSongLabel.Text = "Currently playing: " + main.audio.CurrentSong.Name;

            //Buttons and context menu
            if (main.audio.AState == AudioHandler.AudioState.PLAYING)
            {
                PlayButton.Enabled = false;
                NotifyMenuStripPlayButton.Enabled = false;
                NotifyMenuStripPlayingLabel.Text = "Playing";
                NotifyMenuStripPlayingLabel.Enabled = true;
                NotifyMenuStripPlayingSongLabel.Visible = true;
                NotifyMenuStripPlayingSongLabel.Text = main.audio.CurrentSong.Name;
            }
            else
            {
                PlayButton.Enabled = true;
                NotifyMenuStripPlayButton.Enabled = true;
                NotifyMenuStripPlayingSongLabel.Visible = false;
            }

            if (main.audio.AState == AudioHandler.AudioState.PAUSED)
            {
                PauseButton.Enabled = false;
                NotifyMenuStripPauseButton.Enabled = false;
                NotifyMenuStripPlayingLabel.Text = "Paused";
                NotifyMenuStripPlayingLabel.Enabled = true;
                NotifyMenuStripPlayingSongLabel.Visible = true;
                NotifyMenuStripPlayingSongLabel.Text = main.audio.CurrentSong.Name;
            }
            else
            {
                PauseButton.Enabled = true;
                NotifyMenuStripPauseButton.Enabled = true;
            }

            if (main.audio.AState == AudioHandler.AudioState.STOPPED)
            {
                StopButton.Enabled = false;
                NotifyMenuStripStopButton.Enabled = false;
                NotifyMenuStripPlayingLabel.Text = "Stopped";
                NotifyMenuStripPlayingLabel.Enabled = false;
                NotifyMenuStripPlayingSongLabel.Visible = false;
                NotifyMenuStripPlayingSongLabel.Text = "Stopped";
            }
            else
            {
                StopButton.Enabled = true;
                NotifyMenuStripStopButton.Enabled = true;
            }
        }

        private void GenreListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (GenreListBox.SelectedItems.Count != 0)
            {
                main.GenreFilter(GenreListBox.SelectedItems[0].ToString());
                ArtistListBox.ClearSelected();
                AlbumListView.SelectedIndices.Clear();
            }
        }

        private void ArtistListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ArtistListBox.SelectedItems.Count != 0)
            {
                main.ArtistFilter(ArtistListBox.SelectedItems[0].ToString());
                GenreListBox.ClearSelected();
                AlbumListView.SelectedIndices.Clear();
            }
        }

        private void AlbumListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (AlbumListView.SelectedItems.Count != 0)
            {
                main.AlbumFilter(AlbumListView.SelectedItems[0].Text);
                ArtistListBox.ClearSelected();
                GenreListBox.ClearSelected();
            }
        }

        private void SongsTableView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            SongsTable s = new SongsTable();
            if (SongsTableView.SelectedRows.Count > 0)
            {
                var drv = SongsTableView.SelectedRows[0].DataBoundItem as DataRowView;
                var row = drv.Row as DataRow;
                s.ImportRow(row);
                main.audio.Play((s.Rows[0][5] as Song));
            }

        }

        private void PositionTrackBar_ValueChanged()
        {
            if (!clicked)
                main.audio.Seek(PositionTrackBar.Value);

            LabelCurrentTime.Text = Main.SecondsToTimestamp((int)(((double)PositionTrackBar.Value / 1000) * main.audio.CurrentSong.Seconds));
        }

        private void NotifyIcon_Click(object sender, EventArgs e)
        {
            /*
            if (p.Visible)
                p.Visible = false;
            else
                p.Visible = true;
                */
        }

        private void overviewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.PlaylistBox.Visible = false;
            this.GenreListBox.Visible = true;
            this.ArtistListBox.Visible = true;
            this.AlbumListView.Visible = true;
            this.GenreListLabel.Visible = true;
            this.AlbumListLabel.Visible = true;
            this.ArtistListLabel.Visible = true;
            this.PlaylistListLabel.Visible = false;
        }

        private void playlistsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.PlaylistBox.Visible = true;
            this.GenreListBox.Visible = false;
            this.ArtistListBox.Visible = false;
            this.AlbumListView.Visible = false;
            this.GenreListLabel.Visible = false;
            this.AlbumListLabel.Visible = false;
            this.ArtistListLabel.Visible = false;
            this.PlaylistListLabel.Visible = true;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExitProgram();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            ExitProgram();
        }

        private void ExitProgram()
        {
            main.audio.AState = AudioHandler.AudioState.STOPPED;
            NotifyIcon.Visible = false;
            NotifyIcon.Icon = null;
            System.Windows.Forms.Application.Exit();
        }

        private void NotifyMenuStripPlayButton_Click(object sender, EventArgs e)
        {
            PlayButton_Click(sender, e);
        }

        private void NotifyMenuStripPauseButton_Click(object sender, EventArgs e)
        {
            PauseButton_Click(sender, e);
        }

        private void NotifyMenuStripStopButton_Click(object sender, EventArgs e)
        {
            StopButton_Click(sender, e);
        }
    }
}
