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
            this.PlaylistSelectBox = new System.Windows.Forms.ComboBox();
            this.PlaylistSongSelector = new System.Windows.Forms.ListBox();
            this.PlaylistAddSongsButton = new System.Windows.Forms.Button();
            this.PlaylistSongContainer = new System.Windows.Forms.ListBox();
            this.PlaylistNewButton = new System.Windows.Forms.Button();
            this.PlaylistNewInputfield = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // PlaylistSelectBox
            // 
            this.PlaylistSelectBox.FormattingEnabled = true;
            this.PlaylistSelectBox.Location = new System.Drawing.Point(12, 12);
            this.PlaylistSelectBox.Name = "PlaylistSelectBox";
            this.PlaylistSelectBox.Size = new System.Drawing.Size(354, 21);
            this.PlaylistSelectBox.TabIndex = 0;
            this.PlaylistSelectBox.SelectedIndexChanged += new System.EventHandler(this.PlaylistSelectBox_SelectedIndexChanged);
            // 
            // PlaylistSongSelector
            // 
            this.PlaylistSongSelector.FormattingEnabled = true;
            this.PlaylistSongSelector.Location = new System.Drawing.Point(13, 39);
            this.PlaylistSongSelector.Name = "PlaylistSongSelector";
            this.PlaylistSongSelector.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.PlaylistSongSelector.Size = new System.Drawing.Size(353, 160);
            this.PlaylistSongSelector.TabIndex = 1;
            // 
            // PlaylistAddSongsButton
            // 
            this.PlaylistAddSongsButton.Location = new System.Drawing.Point(12, 293);
            this.PlaylistAddSongsButton.Name = "PlaylistAddSongsButton";
            this.PlaylistAddSongsButton.Size = new System.Drawing.Size(354, 23);
            this.PlaylistAddSongsButton.TabIndex = 2;
            this.PlaylistAddSongsButton.Text = "Add";
            this.PlaylistAddSongsButton.UseVisualStyleBackColor = true;
            this.PlaylistAddSongsButton.Click += new System.EventHandler(this.PlaylistAddSongsButton_Click);
            // 
            // PlaylistSongContainer
            // 
            this.PlaylistSongContainer.FormattingEnabled = true;
            this.PlaylistSongContainer.Location = new System.Drawing.Point(12, 205);
            this.PlaylistSongContainer.Name = "PlaylistSongContainer";
            this.PlaylistSongContainer.Size = new System.Drawing.Size(354, 82);
            this.PlaylistSongContainer.TabIndex = 3;
            // 
            // PlaylistNewButton
            // 
            this.PlaylistNewButton.Location = new System.Drawing.Point(118, 342);
            this.PlaylistNewButton.Name = "PlaylistNewButton";
            this.PlaylistNewButton.Size = new System.Drawing.Size(75, 23);
            this.PlaylistNewButton.TabIndex = 4;
            this.PlaylistNewButton.Text = "New";
            this.PlaylistNewButton.UseVisualStyleBackColor = true;
            this.PlaylistNewButton.Click += new System.EventHandler(this.PlaylistNewButton_Click);
            // 
            // PlaylistNewInputfield
            // 
            this.PlaylistNewInputfield.Location = new System.Drawing.Point(12, 342);
            this.PlaylistNewInputfield.Name = "PlaylistNewInputfield";
            this.PlaylistNewInputfield.Size = new System.Drawing.Size(100, 20);
            this.PlaylistNewInputfield.TabIndex = 5;
            // 
            // PlaylistMaker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(382, 400);
            this.Controls.Add(this.PlaylistNewInputfield);
            this.Controls.Add(this.PlaylistNewButton);
            this.Controls.Add(this.PlaylistSongContainer);
            this.Controls.Add(this.PlaylistAddSongsButton);
            this.Controls.Add(this.PlaylistSongSelector);
            this.Controls.Add(this.PlaylistSelectBox);
            this.Name = "PlaylistMaker";
            this.Text = "PlaylistMaker";
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
    }
}