using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer
{
    public class Main
    {
        public APIHandler api;
        public MainForm form;
        public NetworkHandler nw;
        public AudioHandler audio;

        private SongsTable table;

        public Main(NetworkHandler nw, APIHandler api, MainForm form)
        {
            this.nw = nw;
            this.api = api;
            this.form = form;
            form.main = this;

            audio = new AudioHandler();
            table = new SongsTable();
            form.SongsTableView.DataSource = table;

            Populate();
        }

        private void Populate()
        {
            table.Add(new Song("102", "Test Song 1", "Test Album 1", "Test Artist 1", api));

            form.GenreListBox.Items.Add("Hardcore");
            form.GenreListBox.Items.Add("Hardstyle");
            form.GenreListBox.Items.Add("Pop");

            form.ArtistListBox.Items.Add("Kygo");
            form.ArtistListBox.Items.Add("Monstercat");
            form.ArtistListBox.Items.Add("Mozart");

            form.AlbumListView.Items.Add("Album 1");
            form.AlbumListView.Items.Add("Album 2");
            form.AlbumListView.Items.Add("Album 3");

            table.Add(new Song("104", "Test Song 2", "Test Album 2", "Test Artist 2", api));
        }
    }
}
