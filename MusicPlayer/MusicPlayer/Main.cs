using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;

namespace MusicPlayer
{
    public class Main
    {
        public APIHandler api;
        public MainForm form;
        public NetworkHandler nw;
        public PlaylistHandler pl;
        public AudioHandler audio;

        public SongsTable table;
       
        private List<string> genres;
        private List<string> artists;

        public List<Song> currentPlayingList;

        public Main(NetworkHandler nw, APIHandler api, MainForm form, PlaylistHandler pl)
        {
            this.nw = nw;
            this.api = api;
            this.form = form;
            form.main = this;
            pl.main = this;
            pl.Populate();
            this.pl = pl;

            audio = new AudioHandler(this);
            table = new SongsTable();
            form.SongsTableView.DataSource = table;
            form.SongsTableView.Columns[5].Visible = false;

            genres = new List<string>();
            artists = new List<string>();

            currentPlayingList = new List<Song>();

            Populate();
        }

        public void SwitchServer(string server)
        {
            Clear();
            nw.ip = server;
            Populate();
        }

        private void Clear()
        {
            form.GenreListBox.Items.Clear();
            form.ArtistListBox.Items.Clear();
            form.AlbumListView.Items.Clear();
            form.PlaylistBox.Items.Clear();
            table.Clear();

            genres = new List<string>();
            artists = new List<string>();

            currentPlayingList = new List<Song>();
        }

        private void Populate()
        {
            this.api.GetAlbums().ForEach(a => { form.AlbumListView.Items.Add(a.albumnaam);});
            this.api.GetArtists().ForEach(a => { artists.Add(a.naam); form.ArtistListBox.Items.Add(a.naam); });
            this.api.GetGenres().ForEach(g => { genres.Add(g.name); form.GenreListBox.Items.Add(g.name); });
            this.pl.GetPlaylists().ForEach(p =>  form.PlaylistBox.Items.Add(p.name));
            BackgroundWorker bw = new BackgroundWorker();
            bw.DoWork += new DoWorkEventHandler(
            delegate (object o, DoWorkEventArgs args)
            {
                BackgroundWorker b = o as BackgroundWorker;
                ImageList imagelist = new ImageList();
                List<string> templist = new List<string>();
                Action action = () =>
                {
                    foreach (ListViewItem item in form.AlbumListView.Items)
                    {
                        templist.Add(item.Text);
                    }
                    };
                form.Invoke(action);

                foreach (string item in templist)
                {
                    imagelist.Images.Add(item, api.getAlbumCover(item));
                }

                action = () => {
                    imagelist.ImageSize = new System.Drawing.Size(64,64);
                    imagelist.ColorDepth = ColorDepth.Depth32Bit;
                    form.AlbumListView.View = View.LargeIcon;
                    form.AlbumListView.LargeImageList = imagelist;
                    foreach (ListViewItem item in form.AlbumListView.Items)
                    {
                        item.ImageKey = item.Text; 
                    }
                };
                form.Invoke(action);
            });
            bw.RunWorkerAsync();
        }

        public void Repopulate()
        {
            form.AlbumListView.Items.Clear();
            form.ArtistListBox.Items.Clear();
            form.GenreListBox.Items.Clear();
            form.PlaylistBox.Items.Clear();
            this.api.GetAlbums().ForEach(a => form.AlbumListView.Items.Add(a.albumnaam,a.albumnaam));
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

        public void SearchFilter(string search)
        {
            table.Clear();
            api.GetSongsBySearch(search).ForEach(s =>
            {
                table.Add(s);
            });
        }

        public void AdvancedSearchFilter(string search, string album, string artist, string genre)
        {
            JObject o = api.GetAllBySearch(search, album, artist, genre);
            if (o != null)
            {
                //q
                form.AlbumListView.Items.Clear();
                form.ArtistListBox.Items.Clear();
                form.GenreListBox.Items.Clear();
                form.PlaylistBox.Items.Clear();
                table.Clear();
                api.Songify(o).ForEach(s => table.Add(s));

                //albums
                api.Albumify(o).ForEach(a => form.AlbumListView.Items.Add(a.albumnaam));

                //artists
                api.Artistify(o).ForEach(a => form.ArtistListBox.Items.Add(a.naam));

                //genres
                api.Genrify(o).ForEach(g => form.GenreListBox.Items.Add(g.name));
                BackgroundWorker bw = new BackgroundWorker();
                bw.DoWork += new DoWorkEventHandler(
                delegate (object x, DoWorkEventArgs args)
                {
                    BackgroundWorker b = x as BackgroundWorker;
                    ImageList imagelist = new ImageList();
                    List<string> templist = new List<string>();
                    Action action = () =>
                    {
                        foreach (ListViewItem item in form.AlbumListView.Items)
                        {
                            templist.Add(item.Text);
                        }
                    };
                    form.Invoke(action);

                    foreach (string item in templist)
                    {
                        imagelist.Images.Add(item, api.getAlbumCover(item));
                    }

                    action = () => {
                        form.AlbumListView.LargeImageList = imagelist;
                        foreach (ListViewItem item in form.AlbumListView.Items)
                        {
                            item.ImageKey = item.Text;
                        }
                    };
                    form.Invoke(action);
                });
                bw.RunWorkerAsync();
            }

        }

        public void FilterCurrentPlaying()
        {
            table.Clear();
            currentPlayingList.ForEach(s =>
            {
                table.Add(s);
            });

            form.GenreListBox.ClearSelected();
            form.ArtistListBox.ClearSelected();
            form.PlaylistBox.ClearSelected();
            form.AlbumListView.SelectedIndices.Clear();
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

        public static bool CheckURLValid(string source)
        {
            Uri uriResult;
            return Uri.TryCreate(source, UriKind.Absolute, out uriResult) && uriResult.Scheme == Uri.UriSchemeHttp;
        }

        public static string GetDomain(string url)
        {
            Uri uri = new Uri(url);
            return uri.Host;
        }
    }

}


