﻿using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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
        bool draggedstarted = false;
        bool draggedcompleted = false;
        int startx = 0;
        int starty = 0;

        bool showed;

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
            showed = false;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            UpdateTimer.Start();
            main.Init();
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
                PositionTrackBar.Value = Math.Max(main.audio.Position, 0);

            //Buffer display
            if(main.audio.Buffered / 10 >= BufferBar.Minimum && main.audio.Buffered / 10 <= BufferBar.Maximum)
                BufferBar.Value = main.audio.Buffered / 10;

            //Time labels
            if (!clicked)
                LabelCurrentTime.Text = Main.SecondsToTimestamp(main.audio.CurrentTime);
            LabelTotalTime.Text = Main.SecondsToTimestamp(main.audio.TotalTime);

            //Current song label
            if (main.audio.CurrentSong == null)
                CurrentSongLabel.Text = "Not playing any songs";
            else
            {
                if (main.audio.CurrentSong.Seconds < 1)
                    PositionTrackBar.Enabled = false;
                CurrentSongLabel.Text = "Currently playing: " + main.audio.CurrentSong.Name;
            }

            //image box
            if (AlbumListView.LargeImageList != null && main.audio.CurrentSong != null)
            {
                //Console.WriteLine(AlbumListView.LargeImageList.Images["Get Wet"]);
                pictureBox1.Image = AlbumListView.LargeImageList.Images[main.audio.CurrentSong.Album];
            }

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

            if (main.nw.ip == "http://jancokock.me")
                SelectServerJancoButton.Enabled = false;
            else
                SelectServerJancoButton.Enabled = true;

            if (main.nw.ip == "http://imegumii.nl")
                SelectServerYorickButton.Enabled = false;
            else
                SelectServerYorickButton.Enabled = true;

            if (SearchSongsTextBox.Text.Length == 0)
                SearchSongsButton.Enabled = false;
            else
                SearchSongsButton.Enabled = true;

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

            if (main.audio.BState == AudioHandler.BufferState.DONE)
                SaveBufferButton.Enabled = true;
            else
                SaveBufferButton.Enabled = false;

            if (VolumeCustomTextBox.Text == "")
                VolumeCustomSetButton.Enabled = false;
            else
                VolumeCustomSetButton.Enabled = true;

            if (RadioStationTextBox.Text.Length <= 10)
                SetRadioStationButton.Enabled = false;
            else
                SetRadioStationButton.Enabled = true;

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
                if (main.audio.CurrentSong is RadioStation)
                {
                    main.currentPlayingList.Clear();
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
            }

            if (songFinished)
            {
                if (! (main.audio.CurrentSong is RadioStation) )
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
            if(main.audio.CurrentSong != null)
                LabelCurrentTime.Text = Main.SecondsToTimestamp((int)(((double)PositionTrackBar.Value / 1000) * main.audio.CurrentSong.Seconds));
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
            clicked = true;
            double dblValue;
            //dblValue = ((double)(e.X+PositionTrackBar.Location.X) / (double)(PositionTrackBar.Width + PositionTrackBar.Location.X)) * (PositionTrackBar.Maximum - PositionTrackBar.Minimum);
            dblValue = ((double)e.X / (double)PositionTrackBar.Width) * (PositionTrackBar.Maximum - PositionTrackBar.Minimum);
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
            if(main.currentPlayingList.Count >= 1 && selected >= 0)
                SongsTableView.CurrentCell = SongsTableView.Rows[selected].Cells[0];
        }

   
        private void SongsTableView_MouseDown(object sender, MouseEventArgs e)
        {
            draggedstarted = true;
            draggedcompleted = false;
            startx = e.X;
            starty = e.Y;
        }

        private void SongsTableView_MouseUp(object sender, MouseEventArgs e)
        {
            if (draggedcompleted)
            {
                Cursor.Current = Cursors.Default;
                Point point = PlaylistBox.PointToClient(Cursor.Position);
                Point point2 = AddToQueueLabel.PointToClient(Cursor.Position);
                bool queue = AddToQueueLabel.ClientRectangle.Contains(point2);
                int index = PlaylistBox.IndexFromPoint(point);
                if (index < 0 && !queue) //nope, niet op een playlist gesleept
                {
                    draggedstarted = false;
                    draggedcompleted = false;
                    return;
                }

                if (queue)
                {
                    SongsTable s = new SongsTable();
                    if (SongsTableView.SelectedRows.Count > 0)
                    {
                        var drv = SongsTableView.SelectedRows[0].DataBoundItem as DataRowView;
                        var row = drv.Row as DataRow;
                        s.ImportRow(row);
                        main.currentPlayingList.Add((s.Rows[0][5] as Song));
                        ViewCurrentPlaylistButton_Click(this, new EventArgs());
                    }
                }
                else
                {
                    Playlist currentPlaylist = main.pl.GetPlaylistByName(PlaylistBox.Items[index].ToString());
                    SongsTable s = new SongsTable();
                    if (SongsTableView.SelectedRows.Count > 0)
                    {
                        var drv = SongsTableView.SelectedRows[0].DataBoundItem as DataRowView;
                        var row = drv.Row as DataRow;
                        s.ImportRow(row);
                        currentPlaylist.AddSong((s.Rows[0][5] as Song));
                        currentPlaylist.WriteToFile();
                    }
                }

                AddToQueueLabel.Visible = false;
            }

            draggedcompleted = false;
            draggedstarted = false;
        }

        private void SongsTableView_MouseMove(object sender, MouseEventArgs e)
        {
            int deltax = Math.Abs(startx - e.X);
            int deltay = Math.Abs(starty - e.Y);

            if ((deltax > 5 || deltay > 5) && draggedstarted && !draggedcompleted)
            {
                draggedcompleted = true;
                playlistsToolStripMenuItem_Click(this, new EventArgs());
                AddToQueueLabel.Visible = true;
                Cursor.Current = Cursors.Hand;
            }
        }

        private void SelectServerJancoButton_Click(object sender, EventArgs e)
        {
            main.SwitchServer("http://jancokock.me");
        }

        private void SelectServerYorickButton_Click(object sender, EventArgs e)
        {
            main.SwitchServer("http://imegumii.nl");
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            main.audio.Play(new RadioStation("538", main.api, "http://vip-icecast.538.lw.triple-it.nl:80/RADIO538_MP3"));
        }

        private void qDanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            main.audio.Play(new RadioStation("Q-Dance", main.api, "http://stream01.platform02.true.nl:8000/qdance-hard"));
        }

        private void fMToolStripMenuItem_Click(object sender, EventArgs e)
        {
            main.audio.Play(new RadioStation("3FM", main.api, "http://icecast.omroep.nl:80/3fm-bb-mp3"));
        }

        private void slamFMToolStripMenuItem_Click(object sender, EventArgs e)
        {
            main.audio.Play(new RadioStation("Slam-FM", main.api, "http://vip-icecast.538.lw.triple-it.nl/SLAMFM_MP3"));
        }

        private void SetRadioStationButton_Click(object sender, EventArgs e)
        {
            string input = RadioStationTextBox.Text;

            if(Main.CheckURLValid(input))
            {
                main.audio.Play(new RadioStation(Main.GetDomain(input), main.api, input));       
            }

            RadioStationTextBox.Text = "";
        }

        private void SearchSongsButton_Click(object sender, EventArgs e)
        {
            if(SearchSongsTextBox.Text.Length > 0)
            {
                main.SearchFilter(SearchSongsTextBox.Text);
                SearchSongsTextBox.Text = "";
            }
        }

        private void AdvancedSearchButton_Click(object sender, EventArgs e)
        {
            AdvancedSearch av = new AdvancedSearch(main);
            av.ShowDialog();
        }

        private void resetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            main.Repopulate();
        }

        private void VolumeControl_ValueChanged(object sender, EventArgs e)
        {
            main.audio.Volume = (float)(VolumeControl.Value/100);
            VolumeCurrentLabel.Text = "Currently " + VolumeControl.Value + "%";
        }

        private void Volume100Button_Click(object sender, EventArgs e)
        {
            VolumeControl.Value = 100;
        }

        private void Volume75Button_Click(object sender, EventArgs e)
        {
            VolumeControl.Value = 75;
        }

        private void Volume50Button_Click(object sender, EventArgs e)
        {
            VolumeControl.Value = 50;
        }

        private void Volume25Button_Click(object sender, EventArgs e)
        {
            VolumeControl.Value = 25;
        }

        private void Volume0Button_Click(object sender, EventArgs e)
        {
            VolumeControl.Value = 0;
        }

        private void VolumeCustomSetButton_Click(object sender, EventArgs e)
        {
            int volume;
            bool volumeOK = int.TryParse(VolumeCustomTextBox.Text, out volume);

            if(volumeOK)
                VolumeControl.Value = Math.Max(Math.Min(volume, 100), 0);
            VolumeCustomTextBox.Text = "";
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            if(this.WindowState == FormWindowState.Minimized)
            {
                this.ShowInTaskbar = false;
                if (!showed)
                {
                    this.NotifyIcon.ShowBalloonTip(0);
                    showed = true;
                }
            }
        }

        private void NotifyIcon_Click(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.WindowState = FormWindowState.Normal;
                this.ShowInTaskbar = true;
            }
        }

        private void NotifyIcon_BalloonTipClicked(object sender, EventArgs e)
        {
            NotifyIcon_Click(sender, new MouseEventArgs(MouseButtons.Left, 1, 0, 0, 0));
        }

        private void SaveBufferButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog SaveMP3FromBuffer = new SaveFileDialog();
            SaveMP3FromBuffer.Filter = "MP3 File|*.mp3";
            SaveMP3FromBuffer.Title = "Save current song to mp3 file";
            SaveMP3FromBuffer.FileName = main.audio.CurrentSong.Name + ".mp3";

            if(SaveMP3FromBuffer.ShowDialog() != DialogResult.OK)
                return;

            // If the file name is not an empty string open it for saving.
            if (SaveMP3FromBuffer.FileName != "")
            {
                if (main.audio.SaveBufferToFile(SaveMP3FromBuffer.FileName))
                {
                    try {
                        Process.Start("explorer.exe", @"/select, " + SaveMP3FromBuffer.FileName);
                    }
                    catch(Exception)
                    {
                        MessageBox.Show("File saved.");
                    }
                }
                else
                    MessageBox.Show("Error while saving file");
            }
        }

        private void ExitNotifyIconMenuStrip_Click(object sender, EventArgs e)
        {
            ExitProgram();
        }
    }
}
