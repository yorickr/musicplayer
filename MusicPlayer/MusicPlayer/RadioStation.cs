using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer
{
    class RadioStation :Song
    {
        string radiourl;
        public RadioStation(string name, APIHandler api, string url):base("-1", name,"","","",0,api)
        {
            radiourl = url;
        }

        protected override string GetURL()
        {
            return radiourl;
        }

    }
}
