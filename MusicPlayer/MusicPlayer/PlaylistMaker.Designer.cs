using System.Windows.Forms;

namespace MusicPlayer
{
    partial class PlaylistMaker
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

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PlaylistMaker));
            this.PlaylistSelectBox = new System.Windows.Forms.ComboBox();
            this.PlaylistSongSelector = new System.Windows.Forms.ListBox();
            this.PlaylistAddSongsButton = new System.Windows.Forms.Button();
            this.PlaylistSongContainer = new System.Windows.Forms.ListBox();
            this.PlaylistNewButton = new System.Windows.Forms.Button();
            this.PlaylistNewInputfield = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.FilterTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // PlaylistSelectBox
            // 
            this.PlaylistSelectBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PlaylistSelectBox.FormattingEnabled = true;
            this.PlaylistSelectBox.Location = new System.Drawing.Point(10, 96);
            this.PlaylistSelectBox.Name = "PlaylistSelectBox";
            this.PlaylistSelectBox.Size = new System.Drawing.Size(306, 21);
            this.PlaylistSelectBox.TabIndex = 0;
            this.PlaylistSelectBox.SelectedIndexChanged += new System.EventHandler(this.PlaylistSelectBox_SelectedIndexChanged);
            // 
            // PlaylistSongSelector
            // 
            this.PlaylistSongSelector.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PlaylistSongSelector.FormattingEnabled = true;
            this.PlaylistSongSelector.Location = new System.Drawing.Point(11, 149);
            this.PlaylistSongSelector.Name = "PlaylistSongSelector";
            this.PlaylistSongSelector.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.PlaylistSongSelector.Size = new System.Drawing.Size(305, 108);
            this.PlaylistSongSelector.TabIndex = 1;
            // 
            // PlaylistAddSongsButton
            // 
            this.PlaylistAddSongsButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PlaylistAddSongsButton.Location = new System.Drawing.Point(10, 263);
            this.PlaylistAddSongsButton.Name = "PlaylistAddSongsButton";
            this.PlaylistAddSongsButton.Size = new System.Drawing.Size(306, 23);
            this.PlaylistAddSongsButton.TabIndex = 2;
            this.PlaylistAddSongsButton.Text = "Add selected to playlist";
            this.PlaylistAddSongsButton.UseVisualStyleBackColor = true;
            this.PlaylistAddSongsButton.Click += new System.EventHandler(this.PlaylistAddSongsButton_Click);
            // 
            // PlaylistSongContainer
            // 
            this.PlaylistSongContainer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PlaylistSongContainer.FormattingEnabled = true;
            this.PlaylistSongContainer.Location = new System.Drawing.Point(10, 319);
            this.PlaylistSongContainer.Name = "PlaylistSongContainer";
            this.PlaylistSongContainer.Size = new System.Drawing.Size(306, 82);
            this.PlaylistSongContainer.TabIndex = 3;
            // 
            // PlaylistNewButton
            // 
            this.PlaylistNewButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.PlaylistNewButton.Location = new System.Drawing.Point(242, 23);
            this.PlaylistNewButton.Name = "PlaylistNewButton";
            this.PlaylistNewButton.Size = new System.Drawing.Size(75, 23);
            this.PlaylistNewButton.TabIndex = 4;
            this.PlaylistNewButton.Text = "New";
            this.PlaylistNewButton.UseVisualStyleBackColor = true;
            this.PlaylistNewButton.Click += new System.EventHandler(this.PlaylistNewButton_Click);
            // 
            // PlaylistNewInputfield
            // 
            this.PlaylistNewInputfield.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PlaylistNewInputfield.Location = new System.Drawing.Point(11, 25);
            this.PlaylistNewInputfield.Name = "PlaylistNewInputfield";
            this.PlaylistNewInputfield.Size = new System.Drawing.Size(225, 20);
            this.PlaylistNewInputfield.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Create new playlist";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Edit existing playlist";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 303);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Songs in playlist";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 130);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "All songs";
            // 
            // FilterTextBox
            // 
            this.FilterTextBox.Location = new System.Drawing.Point(172, 127);
            this.FilterTextBox.Name = "FilterTextBox";
            this.FilterTextBox.Size = new System.Drawing.Size(144, 20);
            this.FilterTextBox.TabIndex = 10;
            this.FilterTextBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FilterTextBox_KeyUp);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(137, 130);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Filter";
            // 
            // PlaylistMaker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 411);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.FilterTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.PlaylistNewInputfield);
            this.Controls.Add(this.PlaylistNewButton);
            this.Controls.Add(this.PlaylistSongContainer);
            this.Controls.Add(this.PlaylistAddSongsButton);
            this.Controls.Add(this.PlaylistSongSelector);
            this.Controls.Add(this.PlaylistSelectBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(300, 425);
            this.Name = "PlaylistMaker";
            this.Text = "Create / Edit playlists";
            this.Shown += new System.EventHandler(this.PlaylistMaker_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox PlaylistSelectBox;
        private System.Windows.Forms.ListBox PlaylistSongSelector;
        private System.Windows.Forms.Button PlaylistAddSongsButton;
        private System.Windows.Forms.ListBox PlaylistSongContainer;
        private Button PlaylistNewButton;
        private TextBox PlaylistNewInputfield;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox FilterTextBox;
        private Label label5;
    }
}