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

        private void playToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PlayMp3FromUrl("http://imegumii.nl/music/English/Monstercat/Direct%20-%20Eternity.mp3");
        }

        private Stream ms = new MemoryStream();
        public void PlayMp3FromUrl(string url)
        {
            new Thread(delegate (object o)
            {
                var response = WebRequest.Create(url).GetResponse();
                using (var stream = response.GetResponseStream())
                {
                    byte[] buffer = new byte[65536]; // 64KB chunks
                    int read;
                    while ((read = stream.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        var pos = ms.Position;
                        ms.Position = ms.Length;
                        ms.Write(buffer, 0, read);
                        ms.Position = pos;
                    }
                }
            }).Start();

            // Pre-buffering some data to allow NAudio to start playing
            while (ms.Length < 65536 * 10)
                Thread.Sleep(1000);

            ms.Position = 0;
            using (WaveStream blockAlignedStream = new BlockAlignReductionStream(WaveFormatConversionStream.CreatePcmStream(new Mp3FileReader(ms))))
            {
                using (WaveOut waveOut = new WaveOut(WaveCallbackInfo.FunctionCallback()))
                {
                    waveOut.Init(blockAlignedStream);
                    waveOut.Play();
                    while (waveOut.PlaybackState == PlaybackState.Playing)
                    {
                        System.Threading.Thread.Sleep(100);
                    }
                }
            }
        }
    }
}
