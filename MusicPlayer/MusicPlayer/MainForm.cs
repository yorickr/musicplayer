using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace MusicPlayer
{
    public partial class MainForm : Form
    {
        bool songFinished;

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

            songFinished = false;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            UpdateTimer.Start();
        }

        private void PlayButton_Click(object sender, EventArgs e)
        {
            if (main.audio.AState == AudioHandler.AudioState.PAUSED)
                main.audio.Play(main.audio.CurrentSong);
            else
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

        public void SongFinished()
        {
            songFinished = true;
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

            if(PlayNextSongButton.Checked)
            {
                ShuffleSongButton.Enabled = true;
            }
            else
            {
                ShuffleSongButton.Enabled = false;
                ShuffleSongButton.Checked = false;
            }

            if (main.currentPlayingList.Count <= 1)
            {
                PreviousButton.Enabled = false;
                NextButton.Enabled = false;
                NotifyMenuStripPreviousButton.Enabled = false;
                NotifyMenuStripNextButton.Enabled = false;
            }
            else
            {
                NextButton.Enabled = true;
                NotifyMenuStripNextButton.Enabled = true;

                if (ShuffleSongButton.Checked)
                {
                    PreviousButton.Enabled = false;
                    NotifyMenuStripPreviousButton.Enabled = false;
                }
                else
                {
                    PreviousButton.Enabled = true;
                    NotifyMenuStripPreviousButton.Enabled = true;
                }
            }

            if (songFinished)
            {
                Thread.Sleep(20);

                if (PlayNextSongButton.Checked)
                {
                    NextButton_Click(this, new EventArgs());
                }
                else if (LoopSongButton.Checked)
                {
                    main.audio.Play(main.audio.CurrentSong);
                }

                songFinished = false;
            }
        }

        private void GenreListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (GenreListBox.SelectedItems.Count != 0)
            {
                main.GenreFilter(GenreListBox.SelectedItems[0].ToString());
                ArtistListBox.ClearSelected();
                PlaylistBox.ClearSelected();
                AlbumListView.SelectedIndices.Clear();
            }
        }

        private void PlaylistBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (PlaylistBox.SelectedItems.Count != 0)
            {
                main.PlaylistFilter(PlaylistBox.SelectedItems[0].ToString());
                GenreListBox.ClearSelected();
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
                PlaylistBox.ClearSelected();
                AlbumListView.SelectedIndices.Clear();
            }
        }

        private void AlbumListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (AlbumListView.SelectedItems.Count != 0)
            {
                main.AlbumFilter(AlbumListView.SelectedItems[0].Text);
                PlaylistBox.ClearSelected();
                ArtistListBox.ClearSelected();
                GenreListBox.ClearSelected();
            }
        }

        private void SongsTableView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                SongsTable s = new SongsTable();
                if (SongsTableView.SelectedRows.Count > 0)
                {
                    main.currentPlayingList = main.table.AsEnumerable().Select(x => x[5] as Song).ToList();

                    var drv = SongsTableView.SelectedRows[0].DataBoundItem as DataRowView;
                    var row = drv.Row as DataRow;
                    s.ImportRow(row);
                    main.audio.Play((s.Rows[0][5] as Song));
                }
            }
        }

        private void PositionTrackBar_ValueChanged()
        {
            if (!clicked)
                main.audio.Seek(PositionTrackBar.Value);

            LabelCurrentTime.Text = Main.SecondsToTimestamp((int)(((double)PositionTrackBar.Value / 1000) * main.audio.CurrentSong.Seconds));
        }

        private void NotifyIcon_Click(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                MethodInfo mi = typeof(NotifyIcon).GetMethod("ShowContextMenu", BindingFlags.Instance | BindingFlags.NonPublic);
                mi.Invoke(NotifyIcon, null);
            }
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

        private void makeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PlaylistMaker p = new PlaylistMaker(main.pl, main.api);
            p.ShowDialog();
            main.Repopulate();
        }

        private void SearchArtistsTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            main.SearchArtist(SearchArtistsTextBox.Text);
            if (SearchArtistsTextBox.Text.Length < 1)
                ClearArtistSearchButton.Enabled = false;
            else
                ClearArtistSearchButton.Enabled = true;
        }

        private void SearchGenresTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            main.SearchGenre(SearchGenresTextBox.Text);
            if (SearchGenresTextBox.Text.Length < 1)
                ClearGenreSearchButton.Enabled = false;
            else
                ClearGenreSearchButton.Enabled = true;
        }

        private void ClearArtistSearchButton_Click(object sender, EventArgs e)
        {
            main.SearchArtist("");
            SearchArtistsTextBox.Text = "";
            ClearArtistSearchButton.Enabled = false;
        }

        private void ClearGenreSearchButton_Click(object sender, EventArgs e)
        {
            main.SearchGenre("");
            SearchGenresTextBox.Text = "";
            ClearGenreSearchButton.Enabled = false;
        }

        private void PositionTrackBar_MouseDown(object sender, MouseEventArgs e)
        {
            double dblValue;
            dblValue = ((double)(e.X+PositionTrackBar.Location.X) / (double)(PositionTrackBar.Width + PositionTrackBar.Location.X)) * (PositionTrackBar.Maximum - PositionTrackBar.Minimum);
            PositionTrackBar.Value = Convert.ToInt32(dblValue);
        }

        private void PreviousButton_Click(object sender, EventArgs e)
        {
            int selected = 0;
            selected = main.currentPlayingList.IndexOf(main.audio.CurrentSong) - 1;

            if (selected < 0)
            {
                if (LoopSongButton.Checked)
                    selected = main.currentPlayingList.Count-1;
            }

            main.FilterCurrentPlaying();
            SongsTableView.CurrentCell = SongsTableView.Rows[selected].Cells[0];
            main.audio.Play(main.currentPlayingList[selected]);
        }

        private void NextButton_Click(object sender, EventArgs e)
        {
            int selected = 0;

            if (ShuffleSongButton.Checked)
            {
                Random r = new Random();
                selected = r.Next(0, main.currentPlayingList.Count);
                while (selected == main.currentPlayingList.IndexOf(main.audio.CurrentSong) && main.currentPlayingList.Count > 1)
                    selected = r.Next(0, main.currentPlayingList.Count);
            }
            else
                selected = main.currentPlayingList.IndexOf(main.audio.CurrentSong) + 1;

            if (selected >= main.currentPlayingList.Count)
            {
                if (LoopSongButton.Checked)
                    selected = 0;
                else
                {
                    songFinished = false;
                    return;
                }
            }

            main.FilterCurrentPlaying();
            SongsTableView.CurrentCell = SongsTableView.Rows[selected].Cells[0];
            main.audio.Play(main.currentPlayingList[selected]);
        }

        private void NotifyMenuStripNextButton_Click(object sender, EventArgs e)
        {
            NextButton_Click(sender, e);
        }

        private void NotifyMenuStripPreviousButton_Click(object sender, EventArgs e)
        {
            PreviousButton_Click(sender, e);
        }

        private void ViewCurrentPlaylistButton_Click(object sender, EventArgs e)
        {
            main.FilterCurrentPlaying();
            int selected = main.currentPlayingList.IndexOf(main.audio.CurrentSong);
            SongsTableView.CurrentCell = SongsTableView.Rows[selected].Cells[0];
        }
    }
}
