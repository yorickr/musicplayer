using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MusicPlayer
{
    public class Main
    {
        public APIHandler api;
        public MainForm form;
        public NetworkHandler nw;
        public PlaylistHandler pl;
        public AudioHandler audio;

        private SongsTable table;
        private ImageList imagelist;

        private List<string> genres;
        private List<string> artists;

        public Main(NetworkHandler nw, APIHandler api, MainForm form, PlaylistHandler pl)
        {
            this.nw = nw;
            this.api = api;
            this.form = form;
            form.main = this;
            this.pl = pl;

            audio = new AudioHandler(this);
            table = new SongsTable();
            imagelist = new ImageList();
            form.SongsTableView.DataSource = table;
            form.SongsTableView.Columns[5].Visible = false;

            genres = new List<string>();
            artists = new List<string>();

            Populate();
        }

        private void Populate()
        {
            form.AlbumListView.LargeImageList = imagelist;
            this.api.GetAlbums().ForEach(a => { var item = form.AlbumListView.Items.Add(a.albumnaam); imagelist.Images.Add(a.albumnaam, a.cover); item.ImageKey = a.albumnaam;});
            this.api.GetArtists().ForEach(a => { artists.Add(a.naam); form.ArtistListBox.Items.Add(a.naam); });
            this.api.GetGenres().ForEach(g => { genres.Add(g.name); form.GenreListBox.Items.Add(g.name); });
            this.pl.GetPlaylists().ForEach(p =>  form.PlaylistBox.Items.Add(p.name));
        }

        public void Repopulate()
        {
            form.AlbumListView.Items.Clear();
            form.ArtistListBox.Items.Clear();
            form.GenreListBox.Items.Clear();
            form.PlaylistBox.Items.Clear();
            this.api.GetAlbums().ForEach(a => form.AlbumListView.Items.Add(a.albumnaam));
            this.api.GetArtists().ForEach(a => form.ArtistListBox.Items.Add(a.naam));
            this.api.GetGenres().ForEach(g => form.GenreListBox.Items.Add(g.name));
            this.pl.GetPlaylists().ForEach(p => form.PlaylistBox.Items.Add(p.name));
        }

        public void ArtistFilter(string artist)
        {
            table.Clear();
            api.GetSongsByArtist(artist).ForEach(s =>
            {
                table.Add(s);
            });
        }

        public void SearchArtist(string search)
        {
            form.ArtistListBox.Items.Clear();

            if (search.Length > 1)
            {
                string sPattern = search;

                foreach (string s in artists)
                {
                    if (System.Text.RegularExpressions.Regex.IsMatch(s, sPattern, System.Text.RegularExpressions.RegexOptions.IgnoreCase))
                    {
                        form.ArtistListBox.Items.Add(s);
                    }
                }
            }
            else
            {
                artists.ForEach(a => form.ArtistListBox.Items.Add(a));
            }
        }

        public void SearchGenre(string search)
        {
            form.GenreListBox.Items.Clear();

            if (search.Length > 1)
            {
                string sPattern = search;

                foreach (string s in genres)
                {
                    if (System.Text.RegularExpressions.Regex.IsMatch(s, sPattern, System.Text.RegularExpressions.RegexOptions.IgnoreCase))
                    {
                        form.GenreListBox.Items.Add(s);
                    }
                }
            }
            else
            {
                genres.ForEach(g => form.GenreListBox.Items.Add(g));
            }
        }

        public void GenreFilter(string genre)
        {
            table.Clear();
            api.GetSongsByGenre(genre).ForEach(s =>
            {
                table.Add(s);
            });
        }

        public void PlaylistFilter(string name)
        {
            table.Clear();
            pl.GetPlaylistByName(name).GetSongs().ForEach(s => table.Add(s));

        }

        public void AlbumFilter(string album)
        {
            table.Clear();
            api.GetSongsByAlbum(album).ForEach(s =>
            {
                table.Add(s);
            });
        }

        public static string SecondsToTimestamp(int seconds)
        {
            string str = "";

            //Hours
            str += (seconds / 3600).ToString("D2") + ":";
            seconds %= 3600;

            //Minutes
            str += (seconds / 60).ToString("D2") + ":";
            seconds %= 60;

            //Seconds
            str += seconds.ToString("D2");

            return str;
        }
    }

}


