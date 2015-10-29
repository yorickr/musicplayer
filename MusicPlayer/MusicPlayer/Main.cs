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
            form.AlbumListView.Items.Add(" Alle albums");
            foreach (Album a in this.api.GetAlbums())
            {
                form.AlbumListView.Items.Add(a.albumnaam);

            }
            form.ArtistListBox.Items.Add("Alle artiesten");
            foreach (Artist a in this.api.GetArtists())
            {
                form.ArtistListBox.Items.Add(a.naam);

            }
            
            table.Add(new Song("102", "Test Song 1", "Test Album 1", "Test Artist 1", api));
      
            table.Add(new Song("104", "Test Song 2", "Test Album 2", "Test Artist 2", api));
        }

        public void ArtistFilter(string artist)
        {
            System.Console.Write(artist);
        }

        public void AlbumFilter(string album)
        {
            System.Console.Write(album);

        }
    }

}


