using System;

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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.SongsTableView = new System.Windows.Forms.DataGridView();
            this.GenreListBox = new System.Windows.Forms.ListBox();
            this.AlbumListView = new System.Windows.Forms.ListView();
            this.ArtistListBox = new System.Windows.Forms.ListBox();
            this.MainPanel = new System.Windows.Forms.Panel();
            this.SplitContainer = new System.Windows.Forms.SplitContainer();
            this.PlaylistBox = new System.Windows.Forms.ListBox();
            this.AlbumListLabel = new System.Windows.Forms.Label();
            this.ArtistListLabel = new System.Windows.Forms.Label();
            this.GenreListLabel = new System.Windows.Forms.Label();
            this.PlaylistListLabel = new System.Windows.Forms.Label();
            this.MenuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.overviewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.playlistsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.ViewQueueButton = new System.Windows.Forms.ToolStripMenuItem();
            this.playbackToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PlayNextSongButton = new System.Windows.Forms.ToolStripMenuItem();
            this.LoopSongButton = new System.Windows.Forms.ToolStripMenuItem();
            this.ShuffleSongButton = new System.Windows.Forms.ToolStripMenuItem();
            this.playlistToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.makeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.viewPlaylistToolstripMenuButton = new System.Windows.Forms.ToolStripMenuItem();
            this.searchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SearchGenresToolStripLabel = new System.Windows.Forms.ToolStripMenuItem();
            this.SearchGenresTextBox = new System.Windows.Forms.ToolStripTextBox();
            this.ClearGenreSearchButton = new System.Windows.Forms.ToolStripMenuItem();
            this.SearchArtistToolStripLabel = new System.Windows.Forms.ToolStripMenuItem();
            this.SearchArtistsTextBox = new System.Windows.Forms.ToolStripTextBox();
            this.ClearArtistSearchButton = new System.Windows.Forms.ToolStripMenuItem();
            this.songsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SearchSongsTextBox = new System.Windows.Forms.ToolStripTextBox();
            this.SearchSongsButton = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.AdvancedSearchButton = new System.Windows.Forms.ToolStripMenuItem();
            this.serverToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SelectServerJancoButton = new System.Windows.Forms.ToolStripMenuItem();
            this.SelectServerYorickButton = new System.Windows.Forms.ToolStripMenuItem();
            this.radioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.fMToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.slamFMToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.qDanceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.customToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RadioStationTextBox = new System.Windows.Forms.ToolStripTextBox();
            this.SetRadioStationButton = new System.Windows.Forms.ToolStripMenuItem();
            this.ControlsPanel = new System.Windows.Forms.Panel();
            this.NextButton = new System.Windows.Forms.Button();
            this.PreviousButton = new System.Windows.Forms.Button();
            this.CurrentSongLabel = new System.Windows.Forms.Label();
            this.LabelTotalTime = new System.Windows.Forms.Label();
            this.LabelCurrentTime = new System.Windows.Forms.Label();
            this.PositionTrackBar = new System.Windows.Forms.TrackBar();
            this.BufferLabel = new System.Windows.Forms.Label();
            this.BufferBar = new System.Windows.Forms.ProgressBar();
            this.StopButton = new System.Windows.Forms.Button();
            this.PauseButton = new System.Windows.Forms.Button();
            this.PlayButton = new System.Windows.Forms.Button();
            this.UpdateTimer = new System.Windows.Forms.Timer(this.components);
            this.NotifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.NotifyMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.NotifyMenuStripPlayingLabel = new System.Windows.Forms.ToolStripMenuItem();
            this.NotifyMenuStripPlayingSongLabel = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.NotifyMenuStripPlayButton = new System.Windows.Forms.ToolStripMenuItem();
            this.NotifyMenuStripPauseButton = new System.Windows.Forms.ToolStripMenuItem();
            this.NotifyMenuStripStopButton = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.NotifyMenuStripNextButton = new System.Windows.Forms.ToolStripMenuItem();
            this.NotifyMenuStripPreviousButton = new System.Windows.Forms.ToolStripMenuItem();
            this.resetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.SongsTableView)).BeginInit();
            this.MainPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer)).BeginInit();
            this.SplitContainer.Panel1.SuspendLayout();
            this.SplitContainer.Panel2.SuspendLayout();
            this.SplitContainer.SuspendLayout();
            this.MenuStrip.SuspendLayout();
            this.ControlsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PositionTrackBar)).BeginInit();
            this.NotifyMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // SongsTableView
            // 
            this.SongsTableView.AllowUserToAddRows = false;
            this.SongsTableView.AllowUserToDeleteRows = false;
            this.SongsTableView.AllowUserToResizeRows = false;
            this.SongsTableView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.SongsTableView.BackgroundColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.SongsTableView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.SongsTableView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.SongsTableView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SongsTableView.Location = new System.Drawing.Point(0, 0);
            this.SongsTableView.MultiSelect = false;
            this.SongsTableView.Name = "SongsTableView";
            this.SongsTableView.ReadOnly = true;
            this.SongsTableView.RowHeadersVisible = false;
            this.SongsTableView.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.SongsTableView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.SongsTableView.Size = new System.Drawing.Size(760, 174);
            this.SongsTableView.TabIndex = 0;
            this.SongsTableView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.SongsTableView_CellDoubleClick);
            this.SongsTableView.MouseDown += new System.Windows.Forms.MouseEventHandler(this.SongsTableView_MouseDown);
            this.SongsTableView.MouseMove += new System.Windows.Forms.MouseEventHandler(this.SongsTableView_MouseMove);
            this.SongsTableView.MouseUp += new System.Windows.Forms.MouseEventHandler(this.SongsTableView_MouseUp);
            // 
            // GenreListBox
            // 
            this.GenreListBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.GenreListBox.BackColor = System.Drawing.SystemColors.Control;
            this.GenreListBox.FormattingEnabled = true;
            this.GenreListBox.Location = new System.Drawing.Point(0, 0);
            this.GenreListBox.Name = "GenreListBox";
            this.GenreListBox.Size = new System.Drawing.Size(175, 121);
            this.GenreListBox.Sorted = true;
            this.GenreListBox.TabIndex = 1;
            this.GenreListBox.SelectedIndexChanged += new System.EventHandler(this.GenreListBox_SelectedIndexChanged);
            // 
            // AlbumListView
            // 
            this.AlbumListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AlbumListView.BackColor = System.Drawing.SystemColors.Control;
            this.AlbumListView.Location = new System.Drawing.Point(362, 0);
            this.AlbumListView.MultiSelect = false;
            this.AlbumListView.Name = "AlbumListView";
            this.AlbumListView.Size = new System.Drawing.Size(398, 121);
            this.AlbumListView.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.AlbumListView.TabIndex = 2;
            this.AlbumListView.TileSize = new System.Drawing.Size(185, 30);
            this.AlbumListView.UseCompatibleStateImageBehavior = false;
            this.AlbumListView.View = System.Windows.Forms.View.Tile;
            this.AlbumListView.SelectedIndexChanged += new System.EventHandler(this.AlbumListView_SelectedIndexChanged);
            // 
            // ArtistListBox
            // 
            this.ArtistListBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.ArtistListBox.BackColor = System.Drawing.SystemColors.Control;
            this.ArtistListBox.FormattingEnabled = true;
            this.ArtistListBox.Location = new System.Drawing.Point(181, 0);
            this.ArtistListBox.Name = "ArtistListBox";
            this.ArtistListBox.Size = new System.Drawing.Size(175, 121);
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
            this.MainPanel.Controls.Add(this.SplitContainer);
            this.MainPanel.Controls.Add(this.AlbumListLabel);
            this.MainPanel.Controls.Add(this.ArtistListLabel);
            this.MainPanel.Controls.Add(this.GenreListLabel);
            this.MainPanel.Controls.Add(this.PlaylistListLabel);
            this.MainPanel.Location = new System.Drawing.Point(0, 24);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Size = new System.Drawing.Size(784, 351);
            this.MainPanel.TabIndex = 5;
            // 
            // SplitContainer
            // 
            this.SplitContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SplitContainer.Location = new System.Drawing.Point(12, 25);
            this.SplitContainer.Name = "SplitContainer";
            this.SplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // SplitContainer.Panel1
            // 
            this.SplitContainer.Panel1.Controls.Add(this.AlbumListView);
            this.SplitContainer.Panel1.Controls.Add(this.ArtistListBox);
            this.SplitContainer.Panel1.Controls.Add(this.GenreListBox);
            this.SplitContainer.Panel1.Controls.Add(this.PlaylistBox);
            // 
            // SplitContainer.Panel2
            // 
            this.SplitContainer.Panel2.Controls.Add(this.SongsTableView);
            this.SplitContainer.Size = new System.Drawing.Size(760, 313);
            this.SplitContainer.SplitterDistance = 131;
            this.SplitContainer.SplitterWidth = 8;
            this.SplitContainer.TabIndex = 9;
            // 
            // PlaylistBox
            // 
            this.PlaylistBox.BackColor = System.Drawing.SystemColors.Control;
            this.PlaylistBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PlaylistBox.FormattingEnabled = true;
            this.PlaylistBox.Location = new System.Drawing.Point(0, 0);
            this.PlaylistBox.Name = "PlaylistBox";
            this.PlaylistBox.Size = new System.Drawing.Size(760, 131);
            this.PlaylistBox.TabIndex = 4;
            this.PlaylistBox.Visible = false;
            this.PlaylistBox.SelectedIndexChanged += new System.EventHandler(this.PlaylistBox_SelectedIndexChanged);
            // 
            // AlbumListLabel
            // 
            this.AlbumListLabel.AutoSize = true;
            this.AlbumListLabel.Location = new System.Drawing.Point(371, 9);
            this.AlbumListLabel.Name = "AlbumListLabel";
            this.AlbumListLabel.Size = new System.Drawing.Size(36, 13);
            this.AlbumListLabel.TabIndex = 6;
            this.AlbumListLabel.Text = "Album";
            // 
            // ArtistListLabel
            // 
            this.ArtistListLabel.AutoSize = true;
            this.ArtistListLabel.Location = new System.Drawing.Point(190, 9);
            this.ArtistListLabel.Name = "ArtistListLabel";
            this.ArtistListLabel.Size = new System.Drawing.Size(30, 13);
            this.ArtistListLabel.TabIndex = 5;
            this.ArtistListLabel.Text = "Artist";
            // 
            // GenreListLabel
            // 
            this.GenreListLabel.AutoSize = true;
            this.GenreListLabel.Location = new System.Drawing.Point(9, 9);
            this.GenreListLabel.Name = "GenreListLabel";
            this.GenreListLabel.Size = new System.Drawing.Size(36, 13);
            this.GenreListLabel.TabIndex = 4;
            this.GenreListLabel.Text = "Genre";
            // 
            // PlaylistListLabel
            // 
            this.PlaylistListLabel.AutoSize = true;
            this.PlaylistListLabel.Location = new System.Drawing.Point(12, 9);
            this.PlaylistListLabel.Name = "PlaylistListLabel";
            this.PlaylistListLabel.Size = new System.Drawing.Size(39, 13);
            this.PlaylistListLabel.TabIndex = 7;
            this.PlaylistListLabel.Text = "Playlist";
            this.PlaylistListLabel.Visible = false;
            // 
            // MenuStrip
            // 
            this.MenuStrip.BackColor = System.Drawing.SystemColors.GrayText;
            this.MenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.playbackToolStripMenuItem,
            this.playlistToolStripMenuItem,
            this.searchToolStripMenuItem,
            this.serverToolStripMenuItem,
            this.radioToolStripMenuItem});
            this.MenuStrip.Location = new System.Drawing.Point(0, 0);
            this.MenuStrip.Name = "MenuStrip";
            this.MenuStrip.Size = new System.Drawing.Size(784, 24);
            this.MenuStrip.TabIndex = 6;
            this.MenuStrip.Text = "Menu";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(89, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(92, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.overviewToolStripMenuItem,
            this.playlistsToolStripMenuItem,
            this.toolStripSeparator4,
            this.ViewQueueButton});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // overviewToolStripMenuItem
            // 
            this.overviewToolStripMenuItem.Name = "overviewToolStripMenuItem";
            this.overviewToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.overviewToolStripMenuItem.Text = "Overview";
            this.overviewToolStripMenuItem.Click += new System.EventHandler(this.overviewToolStripMenuItem_Click);
            // 
            // playlistsToolStripMenuItem
            // 
            this.playlistsToolStripMenuItem.Name = "playlistsToolStripMenuItem";
            this.playlistsToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.playlistsToolStripMenuItem.Text = "Playlists";
            this.playlistsToolStripMenuItem.Click += new System.EventHandler(this.playlistsToolStripMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(120, 6);
            // 
            // ViewQueueButton
            // 
            this.ViewQueueButton.Name = "ViewQueueButton";
            this.ViewQueueButton.Size = new System.Drawing.Size(123, 22);
            this.ViewQueueButton.Text = "Queue";
            this.ViewQueueButton.Click += new System.EventHandler(this.ViewCurrentPlaylistButton_Click);
            // 
            // playbackToolStripMenuItem
            // 
            this.playbackToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.PlayNextSongButton,
            this.LoopSongButton,
            this.ShuffleSongButton});
            this.playbackToolStripMenuItem.Name = "playbackToolStripMenuItem";
            this.playbackToolStripMenuItem.Size = new System.Drawing.Size(66, 20);
            this.playbackToolStripMenuItem.Text = "Playback";
            // 
            // PlayNextSongButton
            // 
            this.PlayNextSongButton.Checked = true;
            this.PlayNextSongButton.CheckOnClick = true;
            this.PlayNextSongButton.CheckState = System.Windows.Forms.CheckState.Checked;
            this.PlayNextSongButton.Name = "PlayNextSongButton";
            this.PlayNextSongButton.Size = new System.Drawing.Size(123, 22);
            this.PlayNextSongButton.Text = "Play Next";
            // 
            // LoopSongButton
            // 
            this.LoopSongButton.Checked = true;
            this.LoopSongButton.CheckOnClick = true;
            this.LoopSongButton.CheckState = System.Windows.Forms.CheckState.Checked;
            this.LoopSongButton.Name = "LoopSongButton";
            this.LoopSongButton.Size = new System.Drawing.Size(123, 22);
            this.LoopSongButton.Text = "Loop";
            // 
            // ShuffleSongButton
            // 
            this.ShuffleSongButton.CheckOnClick = true;
            this.ShuffleSongButton.Enabled = false;
            this.ShuffleSongButton.Name = "ShuffleSongButton";
            this.ShuffleSongButton.Size = new System.Drawing.Size(123, 22);
            this.ShuffleSongButton.Text = "Shuffle";
            // 
            // playlistToolStripMenuItem
            // 
            this.playlistToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.makeToolStripMenuItem,
            this.toolStripSeparator6,
            this.viewPlaylistToolstripMenuButton});
            this.playlistToolStripMenuItem.Name = "playlistToolStripMenuItem";
            this.playlistToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.playlistToolStripMenuItem.Text = "Playlist";
            // 
            // makeToolStripMenuItem
            // 
            this.makeToolStripMenuItem.Name = "makeToolStripMenuItem";
            this.makeToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.makeToolStripMenuItem.Text = "Create / Edit";
            this.makeToolStripMenuItem.Click += new System.EventHandler(this.makeToolStripMenuItem_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(136, 6);
            // 
            // viewPlaylistToolstripMenuButton
            // 
            this.viewPlaylistToolstripMenuButton.Name = "viewPlaylistToolstripMenuButton";
            this.viewPlaylistToolstripMenuButton.Size = new System.Drawing.Size(139, 22);
            this.viewPlaylistToolstripMenuButton.Text = "View";
            this.viewPlaylistToolstripMenuButton.Click += new System.EventHandler(this.playlistsToolStripMenuItem_Click);
            // 
            // searchToolStripMenuItem
            // 
            this.searchToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SearchGenresToolStripLabel,
            this.SearchArtistToolStripLabel,
            this.songsToolStripMenuItem,
            this.toolStripSeparator7,
            this.AdvancedSearchButton,
            this.resetToolStripMenuItem});
            this.searchToolStripMenuItem.Name = "searchToolStripMenuItem";
            this.searchToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.searchToolStripMenuItem.Text = "Search";
            // 
            // SearchGenresToolStripLabel
            // 
            this.SearchGenresToolStripLabel.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SearchGenresTextBox,
            this.ClearGenreSearchButton});
            this.SearchGenresToolStripLabel.Name = "SearchGenresToolStripLabel";
            this.SearchGenresToolStripLabel.Size = new System.Drawing.Size(152, 22);
            this.SearchGenresToolStripLabel.Text = "Genres";
            // 
            // SearchGenresTextBox
            // 
            this.SearchGenresTextBox.Name = "SearchGenresTextBox";
            this.SearchGenresTextBox.Size = new System.Drawing.Size(100, 23);
            this.SearchGenresTextBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.SearchGenresTextBox_KeyUp);
            // 
            // ClearGenreSearchButton
            // 
            this.ClearGenreSearchButton.Enabled = false;
            this.ClearGenreSearchButton.Name = "ClearGenreSearchButton";
            this.ClearGenreSearchButton.Size = new System.Drawing.Size(160, 22);
            this.ClearGenreSearchButton.Text = "Clear Search";
            this.ClearGenreSearchButton.Click += new System.EventHandler(this.ClearGenreSearchButton_Click);
            // 
            // SearchArtistToolStripLabel
            // 
            this.SearchArtistToolStripLabel.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SearchArtistsTextBox,
            this.ClearArtistSearchButton});
            this.SearchArtistToolStripLabel.Name = "SearchArtistToolStripLabel";
            this.SearchArtistToolStripLabel.Size = new System.Drawing.Size(152, 22);
            this.SearchArtistToolStripLabel.Text = "Artists";
            // 
            // SearchArtistsTextBox
            // 
            this.SearchArtistsTextBox.Name = "SearchArtistsTextBox";
            this.SearchArtistsTextBox.Size = new System.Drawing.Size(100, 23);
            this.SearchArtistsTextBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.SearchArtistsTextBox_KeyUp);
            // 
            // ClearArtistSearchButton
            // 
            this.ClearArtistSearchButton.Enabled = false;
            this.ClearArtistSearchButton.Name = "ClearArtistSearchButton";
            this.ClearArtistSearchButton.Size = new System.Drawing.Size(160, 22);
            this.ClearArtistSearchButton.Text = "Clear Search";
            this.ClearArtistSearchButton.Click += new System.EventHandler(this.ClearArtistSearchButton_Click);
            // 
            // songsToolStripMenuItem
            // 
            this.songsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SearchSongsTextBox,
            this.SearchSongsButton});
            this.songsToolStripMenuItem.Name = "songsToolStripMenuItem";
            this.songsToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.songsToolStripMenuItem.Text = "Songs";
            // 
            // SearchSongsTextBox
            // 
            this.SearchSongsTextBox.Name = "SearchSongsTextBox";
            this.SearchSongsTextBox.Size = new System.Drawing.Size(100, 23);
            // 
            // SearchSongsButton
            // 
            this.SearchSongsButton.Enabled = false;
            this.SearchSongsButton.Name = "SearchSongsButton";
            this.SearchSongsButton.Size = new System.Drawing.Size(160, 22);
            this.SearchSongsButton.Text = "Search";
            this.SearchSongsButton.Click += new System.EventHandler(this.SearchSongsButton_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(149, 6);
            // 
            // AdvancedSearchButton
            // 
            this.AdvancedSearchButton.Name = "AdvancedSearchButton";
            this.AdvancedSearchButton.Size = new System.Drawing.Size(152, 22);
            this.AdvancedSearchButton.Text = "Advanced";
            this.AdvancedSearchButton.Click += new System.EventHandler(this.AdvancedSearchButton_Click);
            // 
            // serverToolStripMenuItem
            // 
            this.serverToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SelectServerJancoButton,
            this.SelectServerYorickButton});
            this.serverToolStripMenuItem.Name = "serverToolStripMenuItem";
            this.serverToolStripMenuItem.Size = new System.Drawing.Size(51, 20);
            this.serverToolStripMenuItem.Text = "Server";
            // 
            // SelectServerJancoButton
            // 
            this.SelectServerJancoButton.Name = "SelectServerJancoButton";
            this.SelectServerJancoButton.Size = new System.Drawing.Size(148, 22);
            this.SelectServerJancoButton.Text = "jancokock.me";
            this.SelectServerJancoButton.Click += new System.EventHandler(this.SelectServerJancoButton_Click);
            // 
            // SelectServerYorickButton
            // 
            this.SelectServerYorickButton.Name = "SelectServerYorickButton";
            this.SelectServerYorickButton.Size = new System.Drawing.Size(148, 22);
            this.SelectServerYorickButton.Text = "imegumii.nl";
            this.SelectServerYorickButton.Click += new System.EventHandler(this.SelectServerYorickButton_Click);
            // 
            // radioToolStripMenuItem
            // 
            this.radioToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2,
            this.fMToolStripMenuItem,
            this.slamFMToolStripMenuItem,
            this.qDanceToolStripMenuItem,
            this.toolStripSeparator5,
            this.customToolStripMenuItem});
            this.radioToolStripMenuItem.Name = "radioToolStripMenuItem";
            this.radioToolStripMenuItem.Size = new System.Drawing.Size(49, 20);
            this.radioToolStripMenuItem.Text = "Radio";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(122, 22);
            this.toolStripMenuItem2.Text = "538";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // fMToolStripMenuItem
            // 
            this.fMToolStripMenuItem.Name = "fMToolStripMenuItem";
            this.fMToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.fMToolStripMenuItem.Text = "3FM";
            this.fMToolStripMenuItem.Click += new System.EventHandler(this.fMToolStripMenuItem_Click);
            // 
            // slamFMToolStripMenuItem
            // 
            this.slamFMToolStripMenuItem.Name = "slamFMToolStripMenuItem";
            this.slamFMToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.slamFMToolStripMenuItem.Text = "Slam-FM";
            this.slamFMToolStripMenuItem.Click += new System.EventHandler(this.slamFMToolStripMenuItem_Click);
            // 
            // qDanceToolStripMenuItem
            // 
            this.qDanceToolStripMenuItem.Name = "qDanceToolStripMenuItem";
            this.qDanceToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.qDanceToolStripMenuItem.Text = "Q-Dance";
            this.qDanceToolStripMenuItem.Click += new System.EventHandler(this.qDanceToolStripMenuItem_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(119, 6);
            // 
            // customToolStripMenuItem
            // 
            this.customToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.RadioStationTextBox,
            this.SetRadioStationButton});
            this.customToolStripMenuItem.Name = "customToolStripMenuItem";
            this.customToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.customToolStripMenuItem.Text = "Custom";
            // 
            // RadioStationTextBox
            // 
            this.RadioStationTextBox.Name = "RadioStationTextBox";
            this.RadioStationTextBox.Size = new System.Drawing.Size(100, 23);
            // 
            // SetRadioStationButton
            // 
            this.SetRadioStationButton.Name = "SetRadioStationButton";
            this.SetRadioStationButton.Size = new System.Drawing.Size(160, 22);
            this.SetRadioStationButton.Text = "Set";
            this.SetRadioStationButton.Click += new System.EventHandler(this.SetRadioStationButton_Click);
            // 
            // ControlsPanel
            // 
            this.ControlsPanel.BackColor = System.Drawing.SystemColors.GrayText;
            this.ControlsPanel.Controls.Add(this.NextButton);
            this.ControlsPanel.Controls.Add(this.PreviousButton);
            this.ControlsPanel.Controls.Add(this.CurrentSongLabel);
            this.ControlsPanel.Controls.Add(this.LabelTotalTime);
            this.ControlsPanel.Controls.Add(this.LabelCurrentTime);
            this.ControlsPanel.Controls.Add(this.PositionTrackBar);
            this.ControlsPanel.Controls.Add(this.BufferLabel);
            this.ControlsPanel.Controls.Add(this.BufferBar);
            this.ControlsPanel.Controls.Add(this.StopButton);
            this.ControlsPanel.Controls.Add(this.PauseButton);
            this.ControlsPanel.Controls.Add(this.PlayButton);
            this.ControlsPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ControlsPanel.Location = new System.Drawing.Point(0, 378);
            this.ControlsPanel.Name = "ControlsPanel";
            this.ControlsPanel.Size = new System.Drawing.Size(784, 83);
            this.ControlsPanel.TabIndex = 4;
            // 
            // NextButton
            // 
            this.NextButton.Location = new System.Drawing.Point(214, 51);
            this.NextButton.Name = "NextButton";
            this.NextButton.Size = new System.Drawing.Size(31, 23);
            this.NextButton.TabIndex = 13;
            this.NextButton.Text = ">";
            this.NextButton.UseVisualStyleBackColor = true;
            this.NextButton.Click += new System.EventHandler(this.NextButton_Click);
            // 
            // PreviousButton
            // 
            this.PreviousButton.Location = new System.Drawing.Point(177, 51);
            this.PreviousButton.Name = "PreviousButton";
            this.PreviousButton.Size = new System.Drawing.Size(31, 23);
            this.PreviousButton.TabIndex = 12;
            this.PreviousButton.Text = "<";
            this.PreviousButton.UseVisualStyleBackColor = true;
            this.PreviousButton.Click += new System.EventHandler(this.PreviousButton_Click);
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
            // LabelTotalTime
            // 
            this.LabelTotalTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LabelTotalTime.AutoSize = true;
            this.LabelTotalTime.Location = new System.Drawing.Point(723, 26);
            this.LabelTotalTime.Name = "LabelTotalTime";
            this.LabelTotalTime.Size = new System.Drawing.Size(49, 13);
            this.LabelTotalTime.TabIndex = 9;
            this.LabelTotalTime.Text = "00:00:00";
            // 
            // LabelCurrentTime
            // 
            this.LabelCurrentTime.AutoSize = true;
            this.LabelCurrentTime.Location = new System.Drawing.Point(12, 26);
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
            this.PositionTrackBar.Maximum = 1000;
            this.PositionTrackBar.Name = "PositionTrackBar";
            this.PositionTrackBar.Size = new System.Drawing.Size(778, 45);
            this.PositionTrackBar.TabIndex = 7;
            this.PositionTrackBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.PositionTrackBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PositionTrackBar_MouseDown);
            // 
            // BufferLabel
            // 
            this.BufferLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BufferLabel.AutoSize = true;
            this.BufferLabel.Location = new System.Drawing.Point(601, 56);
            this.BufferLabel.Name = "BufferLabel";
            this.BufferLabel.Size = new System.Drawing.Size(35, 13);
            this.BufferLabel.TabIndex = 5;
            this.BufferLabel.Text = "Buffer";
            // 
            // BufferBar
            // 
            this.BufferBar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BufferBar.Location = new System.Drawing.Point(642, 51);
            this.BufferBar.Name = "BufferBar";
            this.BufferBar.Size = new System.Drawing.Size(130, 23);
            this.BufferBar.TabIndex = 3;
            // 
            // StopButton
            // 
            this.StopButton.Enabled = false;
            this.StopButton.Location = new System.Drawing.Point(122, 51);
            this.StopButton.Name = "StopButton";
            this.StopButton.Size = new System.Drawing.Size(49, 23);
            this.StopButton.TabIndex = 2;
            this.StopButton.Text = "Stop";
            this.StopButton.UseVisualStyleBackColor = true;
            this.StopButton.Click += new System.EventHandler(this.StopButton_Click);
            // 
            // PauseButton
            // 
            this.PauseButton.Enabled = false;
            this.PauseButton.Location = new System.Drawing.Point(67, 51);
            this.PauseButton.Name = "PauseButton";
            this.PauseButton.Size = new System.Drawing.Size(49, 23);
            this.PauseButton.TabIndex = 1;
            this.PauseButton.Text = "Pause";
            this.PauseButton.UseVisualStyleBackColor = true;
            this.PauseButton.Click += new System.EventHandler(this.PauseButton_Click);
            // 
            // PlayButton
            // 
            this.PlayButton.Location = new System.Drawing.Point(12, 51);
            this.PlayButton.Name = "PlayButton";
            this.PlayButton.Size = new System.Drawing.Size(49, 23);
            this.PlayButton.TabIndex = 0;
            this.PlayButton.Text = "Play";
            this.PlayButton.UseVisualStyleBackColor = true;
            this.PlayButton.Click += new System.EventHandler(this.PlayButton_Click);
            // 
            // UpdateTimer
            // 
            this.UpdateTimer.Interval = 200;
            this.UpdateTimer.Tick += new System.EventHandler(this.UpdateTimer_Tick);
            // 
            // NotifyIcon
            // 
            this.NotifyIcon.ContextMenuStrip = this.NotifyMenuStrip;
            this.NotifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("NotifyIcon.Icon")));
            this.NotifyIcon.Text = "YJMPD Music Player";
            this.NotifyIcon.Visible = true;
            this.NotifyIcon.MouseUp += new System.Windows.Forms.MouseEventHandler(this.NotifyIcon_Click);
            // 
            // NotifyMenuStrip
            // 
            this.NotifyMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NotifyMenuStripPlayingLabel,
            this.toolStripSeparator2,
            this.NotifyMenuStripPlayButton,
            this.NotifyMenuStripPauseButton,
            this.NotifyMenuStripStopButton,
            this.toolStripSeparator3,
            this.NotifyMenuStripNextButton,
            this.NotifyMenuStripPreviousButton});
            this.NotifyMenuStrip.Name = "NotifyMenuStrip";
            this.NotifyMenuStrip.Size = new System.Drawing.Size(120, 148);
            // 
            // NotifyMenuStripPlayingLabel
            // 
            this.NotifyMenuStripPlayingLabel.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NotifyMenuStripPlayingSongLabel});
            this.NotifyMenuStripPlayingLabel.Enabled = false;
            this.NotifyMenuStripPlayingLabel.Name = "NotifyMenuStripPlayingLabel";
            this.NotifyMenuStripPlayingLabel.Size = new System.Drawing.Size(119, 22);
            this.NotifyMenuStripPlayingLabel.Text = "Stopped";
            // 
            // NotifyMenuStripPlayingSongLabel
            // 
            this.NotifyMenuStripPlayingSongLabel.Enabled = false;
            this.NotifyMenuStripPlayingSongLabel.Name = "NotifyMenuStripPlayingSongLabel";
            this.NotifyMenuStripPlayingSongLabel.Size = new System.Drawing.Size(118, 22);
            this.NotifyMenuStripPlayingSongLabel.Text = "Stopped";
            this.NotifyMenuStripPlayingSongLabel.Visible = false;
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(116, 6);
            // 
            // NotifyMenuStripPlayButton
            // 
            this.NotifyMenuStripPlayButton.Name = "NotifyMenuStripPlayButton";
            this.NotifyMenuStripPlayButton.Size = new System.Drawing.Size(119, 22);
            this.NotifyMenuStripPlayButton.Text = "Play";
            this.NotifyMenuStripPlayButton.Click += new System.EventHandler(this.NotifyMenuStripPlayButton_Click);
            // 
            // NotifyMenuStripPauseButton
            // 
            this.NotifyMenuStripPauseButton.Enabled = false;
            this.NotifyMenuStripPauseButton.Name = "NotifyMenuStripPauseButton";
            this.NotifyMenuStripPauseButton.Size = new System.Drawing.Size(119, 22);
            this.NotifyMenuStripPauseButton.Text = "Pause";
            this.NotifyMenuStripPauseButton.Click += new System.EventHandler(this.NotifyMenuStripPauseButton_Click);
            // 
            // NotifyMenuStripStopButton
            // 
            this.NotifyMenuStripStopButton.Enabled = false;
            this.NotifyMenuStripStopButton.Name = "NotifyMenuStripStopButton";
            this.NotifyMenuStripStopButton.Size = new System.Drawing.Size(119, 22);
            this.NotifyMenuStripStopButton.Text = "Stop";
            this.NotifyMenuStripStopButton.Click += new System.EventHandler(this.NotifyMenuStripStopButton_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(116, 6);
            // 
            // NotifyMenuStripNextButton
            // 
            this.NotifyMenuStripNextButton.Name = "NotifyMenuStripNextButton";
            this.NotifyMenuStripNextButton.Size = new System.Drawing.Size(119, 22);
            this.NotifyMenuStripNextButton.Text = "Next";
            this.NotifyMenuStripNextButton.Click += new System.EventHandler(this.NotifyMenuStripNextButton_Click);
            // 
            // NotifyMenuStripPreviousButton
            // 
            this.NotifyMenuStripPreviousButton.Name = "NotifyMenuStripPreviousButton";
            this.NotifyMenuStripPreviousButton.Size = new System.Drawing.Size(119, 22);
            this.NotifyMenuStripPreviousButton.Text = "Previous";
            this.NotifyMenuStripPreviousButton.Click += new System.EventHandler(this.NotifyMenuStripPreviousButton_Click);
            // 
            // resetToolStripMenuItem
            // 
            this.resetToolStripMenuItem.Name = "resetToolStripMenuItem";
            this.resetToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.resetToolStripMenuItem.Text = "Reset";
            this.resetToolStripMenuItem.Click += new System.EventHandler(this.resetToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 461);
            this.Controls.Add(this.ControlsPanel);
            this.Controls.Add(this.MainPanel);
            this.Controls.Add(this.MenuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.MenuStrip;
            this.MinimumSize = new System.Drawing.Size(800, 500);
            this.Name = "MainForm";
            this.Text = "YJMPD Music Player";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.SongsTableView)).EndInit();
            this.MainPanel.ResumeLayout(false);
            this.MainPanel.PerformLayout();
            this.SplitContainer.Panel1.ResumeLayout(false);
            this.SplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer)).EndInit();
            this.SplitContainer.ResumeLayout(false);
            this.MenuStrip.ResumeLayout(false);
            this.MenuStrip.PerformLayout();
            this.ControlsPanel.ResumeLayout(false);
            this.ControlsPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PositionTrackBar)).EndInit();
            this.NotifyMenuStrip.ResumeLayout(false);
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
        private System.Windows.Forms.NotifyIcon NotifyIcon;
        private System.Windows.Forms.Label CurrentSongLabel;
        private System.Windows.Forms.Label AlbumListLabel;
        private System.Windows.Forms.Label ArtistListLabel;
        private System.Windows.Forms.Label GenreListLabel;
        private System.Windows.Forms.ToolStripMenuItem playlistsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem overviewToolStripMenuItem;
        public System.Windows.Forms.ListBox PlaylistBox;
        private System.Windows.Forms.Label PlaylistListLabel;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem playlistToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ContextMenuStrip NotifyMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem NotifyMenuStripPlayButton;
        private System.Windows.Forms.ToolStripMenuItem NotifyMenuStripPauseButton;
        private System.Windows.Forms.ToolStripMenuItem NotifyMenuStripStopButton;
        private System.Windows.Forms.ToolStripMenuItem NotifyMenuStripPlayingLabel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem NotifyMenuStripPlayingSongLabel;
        private System.Windows.Forms.SplitContainer SplitContainer;
        private System.Windows.Forms.ToolStripMenuItem makeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem searchToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SearchArtistToolStripLabel;
        private System.Windows.Forms.ToolStripTextBox SearchArtistsTextBox;
        private System.Windows.Forms.ToolStripMenuItem SearchGenresToolStripLabel;
        private System.Windows.Forms.ToolStripTextBox SearchGenresTextBox;
        private System.Windows.Forms.ToolStripMenuItem ClearArtistSearchButton;
        private System.Windows.Forms.ToolStripMenuItem ClearGenreSearchButton;
        private System.Windows.Forms.ToolStripMenuItem playbackToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ShuffleSongButton;
        private System.Windows.Forms.ToolStripMenuItem LoopSongButton;
        private System.Windows.Forms.ToolStripMenuItem PlayNextSongButton;
        private System.Windows.Forms.Button NextButton;
        private System.Windows.Forms.Button PreviousButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem NotifyMenuStripNextButton;
        private System.Windows.Forms.ToolStripMenuItem NotifyMenuStripPreviousButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem ViewQueueButton;
        private System.Windows.Forms.ToolStripMenuItem serverToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SelectServerJancoButton;
        private System.Windows.Forms.ToolStripMenuItem SelectServerYorickButton;
        private System.Windows.Forms.ToolStripMenuItem radioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem qDanceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem customToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox RadioStationTextBox;
        private System.Windows.Forms.ToolStripMenuItem SetRadioStationButton;
        private System.Windows.Forms.ToolStripMenuItem fMToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem slamFMToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripMenuItem viewPlaylistToolstripMenuButton;
        private System.Windows.Forms.ToolStripMenuItem songsToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox SearchSongsTextBox;
        private System.Windows.Forms.ToolStripMenuItem SearchSongsButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripMenuItem AdvancedSearchButton;
        private System.Windows.Forms.ToolStripMenuItem resetToolStripMenuItem;
    }
}

