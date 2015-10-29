using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer
{
    class Main
    {
        private APIHandler api;
        private MainForm form;
        private NetworkHandler nw;
        private AudioHandler audio;

        public Main(NetworkHandler nw, APIHandler api, MainForm form)
        {
            this.nw = nw;
            this.api = api;
            this.form = form;

            audio = new AudioHandler();

            Console.WriteLine(api.GetSongURLByID("102"));
        }


    }
}
