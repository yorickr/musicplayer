namespace MusicPlayer
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        bool clicked = false;
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.SongsTableView = new System.Windows.Forms.DataGridView();
            this.GenreListBox = new System.Windows.Forms.ListBox();
            this.AlbumListView = new System.Windows.Forms.ListView();
            this.ArtistListBox = new System.Windows.Forms.ListBox();
            this.MainPanel = new System.Windows.Forms.Panel();
            this.AlbumListLabel = new System.Windows.Forms.Label();
            this.ArtistListLabel = new System.Windows.Forms.Label();
            this.GenreListLabel = new System.Windows.Forms.Label();
            this.PlaylistBox = new System.Windows.Forms.ListBox();
            this.MenuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.playlistsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.overviewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ControlsPanel = new System.Windows.Forms.Panel();
            this.CurrentSongLabel = new System.Windows.Forms.Label();
            this.SeperatorLabel = new System.Windows.Forms.Label();
            this.LabelTotalTime = new System.Windows.Forms.Label();
            this.LabelCurrentTime = new System.Windows.Forms.Label();
            this.PositionTrackBar = new System.Windows.Forms.TrackBar();
            this.BufferLabel = new System.Windows.Forms.Label();
            this.BufferBar = new System.Windows.Forms.ProgressBar();
            this.StopButton = new System.Windows.Forms.Button();
            this.PauseButton = new System.Windows.Forms.Button();
            this.PlayButton = new System.Windows.Forms.Button();
            this.UpdateTimer = new System.Windows.Forms.Timer(this.components);
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.PlaylistListLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.SongsTableView)).BeginInit();
            this.MainPanel.SuspendLayout();
            this.MenuStrip.SuspendLayout();
            this.ControlsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PositionTrackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // SongsTableView
            // 
            this.SongsTableView.AllowUserToAddRows = false;
            this.SongsTableView.AllowUserToDeleteRows = false;
            this.SongsTableView.AllowUserToResizeRows = false;
            this.SongsTableView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SongsTableView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.SongsTableView.BackgroundColor = System.Drawing.SystemColors.Control;
            this.SongsTableView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.SongsTableView.Location = new System.Drawing.Point(12, 165);
            this.SongsTableView.MultiSelect = false;
            this.SongsTableView.Name = "SongsTableView";
            this.SongsTableView.ReadOnly = true;
            this.SongsTableView.RowHeadersVisible = false;
            this.SongsTableView.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.SongsTableView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.SongsTableView.Size = new System.Drawing.Size(760, 175);
            this.SongsTableView.TabIndex = 0;
            this.SongsTableView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.SongsTableView_CellDoubleClick);
            // 
            // GenreListBox
            // 
            this.GenreListBox.BackColor = System.Drawing.SystemColors.Control;
            this.GenreListBox.FormattingEnabled = true;
            this.GenreListBox.Location = new System.Drawing.Point(12, 25);
            this.GenreListBox.Name = "GenreListBox";
            this.GenreListBox.Size = new System.Drawing.Size(150, 134);
            this.GenreListBox.Sorted = true;
            this.GenreListBox.TabIndex = 1;
            this.GenreListBox.SelectedIndexChanged += new System.EventHandler(this.GenreListBox_SelectedIndexChanged);
            // 
            // AlbumListView
            // 
            this.AlbumListView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AlbumListView.BackColor = System.Drawing.SystemColors.Control;
            this.AlbumListView.Location = new System.Drawing.Point(324, 25);
            this.AlbumListView.Name = "AlbumListView";
            this.AlbumListView.Size = new System.Drawing.Size(448, 134);
            this.AlbumListView.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.AlbumListView.TabIndex = 2;
            this.AlbumListView.UseCompatibleStateImageBehavior = false;
            this.AlbumListView.SelectedIndexChanged += new System.EventHandler(this.AlbumListView_SelectedIndexChanged);
            // 
            // ArtistListBox
            // 
            this.ArtistListBox.BackColor = System.Drawing.SystemColors.Control;
            this.ArtistListBox.FormattingEnabled = true;
            this.ArtistListBox.Location = new System.Drawing.Point(168, 25);
            this.ArtistListBox.Name = "ArtistListBox";
            this.ArtistListBox.Size = new System.Drawing.Size(150, 134);
            this.ArtistListBox.Sorted = true;
            this.ArtistListBox.TabIndex = 3;
            this.ArtistListBox.SelectedIndexChanged += new System.EventHandler(this.ArtistListBox_SelectedIndexChanged);
            // 
            // MainPanel
            // 
            this.MainPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MainPanel.BackColor = System.Drawing.SystemColors.Window;
            this.MainPanel.Controls.Add(this.PlaylistListLabel);
            this.MainPanel.Controls.Add(this.AlbumListLabel);
            this.MainPanel.Controls.Add(this.ArtistListLabel);
            this.MainPanel.Controls.Add(this.GenreListLabel);
            this.MainPanel.Controls.Add(this.PlaylistBox);
            this.MainPanel.Controls.Add(this.GenreListBox);
            this.MainPanel.Controls.Add(this.ArtistListBox);
            this.MainPanel.Controls.Add(this.AlbumListView);
            this.MainPanel.Controls.Add(this.SongsTableView);
            this.MainPanel.Location = new System.Drawing.Point(0, 24);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Size = new System.Drawing.Size(784, 352);
            this.MainPanel.TabIndex = 5;
            // 
            // AlbumListLabel
            // 
            this.AlbumListLabel.AutoSize = true;
            this.AlbumListLabel.Location = new System.Drawing.Point(321, 9);
            this.AlbumListLabel.Name = "AlbumListLabel";
            this.AlbumListLabel.Size = new System.Drawing.Size(36, 13);
            this.AlbumListLabel.TabIndex = 6;
            this.AlbumListLabel.Text = "Album";
            // 
            // ArtistListLabel
            // 
            this.ArtistListLabel.AutoSize = true;
            this.ArtistListLabel.Location = new System.Drawing.Point(165, 9);
            this.ArtistListLabel.Name = "ArtistListLabel";
            this.ArtistListLabel.Size = new System.Drawing.Size(30, 13);
            this.ArtistListLabel.TabIndex = 5;
            this.ArtistListLabel.Text = "Artist";
            // 
            // GenreListLabel
            // 
            this.GenreListLabel.AutoSize = true;
            this.GenreListLabel.Location = new System.Drawing.Point(12, 9);
            this.GenreListLabel.Name = "GenreListLabel";
            this.GenreListLabel.Size = new System.Drawing.Size(36, 13);
            this.GenreListLabel.TabIndex = 4;
            this.GenreListLabel.Text = "Genre";
            // 
            // PlaylistBox
            // 
            this.PlaylistBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PlaylistBox.FormattingEnabled = true;
            this.PlaylistBox.Location = new System.Drawing.Point(12, 25);
            this.PlaylistBox.Name = "PlaylistBox";
            this.PlaylistBox.Size = new System.Drawing.Size(760, 134);
            this.PlaylistBox.TabIndex = 4;
            this.PlaylistBox.Visible = false;
            // 
            // MenuStrip
            // 
            this.MenuStrip.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.MenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.viewToolStripMenuItem});
            this.MenuStrip.Location = new System.Drawing.Point(0, 0);
            this.MenuStrip.Name = "MenuStrip";
            this.MenuStrip.Size = new System.Drawing.Size(784, 24);
            this.MenuStrip.TabIndex = 6;
            this.MenuStrip.Text = "Menu";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.openToolStripMenuItem.Text = "Open";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.saveToolStripMenuItem.Text = "Save";
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.playlistsToolStripMenuItem,
            this.overviewToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // playlistsToolStripMenuItem
            // 
            this.playlistsToolStripMenuItem.Name = "playlistsToolStripMenuItem";
            this.playlistsToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.playlistsToolStripMenuItem.Text = "Playlists";
            this.playlistsToolStripMenuItem.Click += new System.EventHandler(this.playlistsToolStripMenuItem_Click);
            // 
            // overviewToolStripMenuItem
            // 
            this.overviewToolStripMenuItem.Name = "overviewToolStripMenuItem";
            this.overviewToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.overviewToolStripMenuItem.Text = "Overview";
            this.overviewToolStripMenuItem.Click += new System.EventHandler(this.overviewToolStripMenuItem_Click);
            // 
            // ControlsPanel
            // 
            this.ControlsPanel.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.ControlsPanel.Controls.Add(this.CurrentSongLabel);
            this.ControlsPanel.Controls.Add(this.SeperatorLabel);
            this.ControlsPanel.Controls.Add(this.LabelTotalTime);
            this.ControlsPanel.Controls.Add(this.LabelCurrentTime);
            this.ControlsPanel.Controls.Add(this.PositionTrackBar);
            this.ControlsPanel.Controls.Add(this.BufferLabel);
            this.ControlsPanel.Controls.Add(this.BufferBar);
            this.ControlsPanel.Controls.Add(this.StopButton);
            this.ControlsPanel.Controls.Add(this.PauseButton);
            this.ControlsPanel.Controls.Add(this.PlayButton);
            this.ControlsPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ControlsPanel.Location = new System.Drawing.Point(0, 379);
            this.ControlsPanel.Name = "ControlsPanel";
            this.ControlsPanel.Size = new System.Drawing.Size(784, 83);
            this.ControlsPanel.TabIndex = 4;
            // 
            // CurrentSongLabel
            // 
            this.CurrentSongLabel.AutoSize = true;
            this.CurrentSongLabel.Location = new System.Drawing.Point(256, 56);
            this.CurrentSongLabel.Name = "CurrentSongLabel";
            this.CurrentSongLabel.Size = new System.Drawing.Size(111, 13);
            this.CurrentSongLabel.TabIndex = 11;
            this.CurrentSongLabel.Text = "Not playing any songs";
            // 
            // SeperatorLabel
            // 
            this.SeperatorLabel.AutoSize = true;
            this.SeperatorLabel.Location = new System.Drawing.Point(67, 35);
            this.SeperatorLabel.Name = "SeperatorLabel";
            this.SeperatorLabel.Size = new System.Drawing.Size(12, 13);
            this.SeperatorLabel.TabIndex = 10;
            this.SeperatorLabel.Text = "/";
            // 
            // LabelTotalTime
            // 
            this.LabelTotalTime.AutoSize = true;
            this.LabelTotalTime.Location = new System.Drawing.Point(85, 35);
            this.LabelTotalTime.Name = "LabelTotalTime";
            this.LabelTotalTime.Size = new System.Drawing.Size(49, 13);
            this.LabelTotalTime.TabIndex = 9;
            this.LabelTotalTime.Text = "00:00:00";
            // 
            // LabelCurrentTime
            // 
            this.LabelCurrentTime.AutoSize = true;
            this.LabelCurrentTime.Location = new System.Drawing.Point(12, 35);
            this.LabelCurrentTime.Name = "LabelCurrentTime";
            this.LabelCurrentTime.Size = new System.Drawing.Size(49, 13);
            this.LabelCurrentTime.TabIndex = 8;
            this.LabelCurrentTime.Text = "00:00:00";
            // 
            // PositionTrackBar
            // 
            this.PositionTrackBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PositionTrackBar.Enabled = false;
            this.PositionTrackBar.Location = new System.Drawing.Point(3, 3);
            this.PositionTrackBar.Maximum = 100;
            this.PositionTrackBar.Name = "PositionTrackBar";
            this.PositionTrackBar.Size = new System.Drawing.Size(778, 45);
            this.PositionTrackBar.TabIndex = 7;
            // 
            // BufferLabel
            // 
            this.BufferLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BufferLabel.AutoSize = true;
            this.BufferLabel.Location = new System.Drawing.Point(597, 56);
            this.BufferLabel.Name = "BufferLabel";
            this.BufferLabel.Size = new System.Drawing.Size(35, 13);
            this.BufferLabel.TabIndex = 5;
            this.BufferLabel.Text = "Buffer";
            // 
            // BufferBar
            // 
            this.BufferBar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BufferBar.Location = new System.Drawing.Point(638, 51);
            this.BufferBar.Name = "BufferBar";
            this.BufferBar.Size = new System.Drawing.Size(134, 23);
            this.BufferBar.TabIndex = 3;
            // 
            // StopButton
            // 
            this.StopButton.Location = new System.Drawing.Point(174, 51);
            this.StopButton.Name = "StopButton";
            this.StopButton.Size = new System.Drawing.Size(75, 23);
            this.StopButton.TabIndex = 2;
            this.StopButton.Text = "Stop";
            this.StopButton.UseVisualStyleBackColor = true;
            this.StopButton.Click += new System.EventHandler(this.StopButton_Click);
            // 
            // PauseButton
            // 
            this.PauseButton.Location = new System.Drawing.Point(93, 51);
            this.PauseButton.Name = "PauseButton";
            this.PauseButton.Size = new System.Drawing.Size(75, 23);
            this.PauseButton.TabIndex = 1;
            this.PauseButton.Text = "Pause";
            this.PauseButton.UseVisualStyleBackColor = true;
            this.PauseButton.Click += new System.EventHandler(this.PauseButton_Click);
            // 
            // PlayButton
            // 
            this.PlayButton.Location = new System.Drawing.Point(12, 51);
            this.PlayButton.Name = "PlayButton";
            this.PlayButton.Size = new System.Drawing.Size(75, 23);
            this.PlayButton.TabIndex = 0;
            this.PlayButton.Text = "Play";
            this.PlayButton.UseVisualStyleBackColor = true;
            this.PlayButton.Click += new System.EventHandler(this.PlayButton_Click);
            // 
            // UpdateTimer
            // 
            this.UpdateTimer.Interval = 150;
            this.UpdateTimer.Tick += new System.EventHandler(this.UpdateTimer_Tick);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.Click += new System.EventHandler(this.notifyIcon1_Click);
            // 
            // PlaylistListLabel
            // 
            this.PlaylistListLabel.AutoSize = true;
            this.PlaylistListLabel.Location = new System.Drawing.Point(12, 8);
            this.PlaylistListLabel.Name = "PlaylistListLabel";
            this.PlaylistListLabel.Size = new System.Drawing.Size(39, 13);
            this.PlaylistListLabel.TabIndex = 7;
            this.PlaylistListLabel.Text = "Playlist";
            this.PlaylistListLabel.Visible = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 462);
            this.Controls.Add(this.ControlsPanel);
            this.Controls.Add(this.MainPanel);
            this.Controls.Add(this.MenuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.MenuStrip;
            this.MinimumSize = new System.Drawing.Size(800, 500);
            this.Name = "MainForm";
            this.Text = "YJMPD Music Player";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.SongsTableView)).EndInit();
            this.MainPanel.ResumeLayout(false);
            this.MainPanel.PerformLayout();
            this.MenuStrip.ResumeLayout(false);
            this.MenuStrip.PerformLayout();
            this.ControlsPanel.ResumeLayout(false);
            this.ControlsPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PositionTrackBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.DataGridView SongsTableView;
        public System.Windows.Forms.ListBox GenreListBox;
        public System.Windows.Forms.ListView AlbumListView;
        public System.Windows.Forms.ListBox ArtistListBox;
        private System.Windows.Forms.Panel MainPanel;
        private System.Windows.Forms.MenuStrip MenuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.Panel ControlsPanel;
        private System.Windows.Forms.Button PlayButton;
        private System.Windows.Forms.Button StopButton;
        private System.Windows.Forms.Button PauseButton;
        private System.Windows.Forms.Label BufferLabel;
        private System.Windows.Forms.ProgressBar BufferBar;
        private System.Windows.Forms.Timer UpdateTimer;
        private System.Windows.Forms.TrackBar PositionTrackBar;
        private System.Windows.Forms.Label LabelTotalTime;
        private System.Windows.Forms.Label LabelCurrentTime;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.Label CurrentSongLabel;
        private System.Windows.Forms.Label SeperatorLabel;
        private System.Windows.Forms.Label AlbumListLabel;
        private System.Windows.Forms.Label ArtistListLabel;
        private System.Windows.Forms.Label GenreListLabel;
        private System.Windows.Forms.ToolStripMenuItem playlistsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem overviewToolStripMenuItem;
        public System.Windows.Forms.ListBox PlaylistBox;
        private System.Windows.Forms.Label PlaylistListLabel;
    }
}

