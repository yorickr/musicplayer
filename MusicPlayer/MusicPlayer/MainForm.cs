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
            
        }

        private void PlayButton_Click(object sender, EventArgs e)
        {
            AudioHandler.PlayMp3FromUrl("http://imegumii.nl/music/English/Monstercat/Direct%20-%20Eternity.mp3");
        }

        private void SongsTableView_SelectionChanged(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection col = SongsTableView.SelectedRows;
        }
    }
}
