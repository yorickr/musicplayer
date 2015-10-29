using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace MusicPlayer
{
    public partial class MainForm : Form
    {
        private SongsTable table;

        public MainForm()
        {
            InitializeComponent();
//            nw.SendString("GET / HTTP/1.1");

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //APIHandler api = new APIHandler();
            //NetworkHandler nw = new NetworkHandler("83.128.250.123", api);
            table = new SongsTable();
            SongsTableView.DataSource = table;

            Populate();
        }

        private void Populate()
        {
            table.Add(new Song("Test Song 1", "Test Album 1", "Test Artist 1"));

            GenreListBox.Items.Add("Hardcore");
            GenreListBox.Items.Add("Hardstyle");
            GenreListBox.Items.Add("Pop");

            ArtistListBox.Items.Add("Kygo");
            ArtistListBox.Items.Add("Monstercat");
            ArtistListBox.Items.Add("Mozart");

            AlbumListView.Items.Add("Album 1");
            AlbumListView.Items.Add("Album 2");
            AlbumListView.Items.Add("Album 3");

            table.Add(new Song("Test Song 2", "Test Album 2", "Test Artist 2"));
        }
    }
}
