using System;
using System.Text;
using System.Net.Sockets;
using System.Threading;
using System.Net;
using System.IO;
using Newtonsoft.Json.Linq;


namespace MusicPlayer
{
    class NetworkHandler
    {
        private int port = 8585;
        private string ip;
 
        public NetworkHandler(string ip)
        {
            this.ip = ip;
        }

        public JObject SendString(string m)
        {
            HttpWebRequest server =   (HttpWebRequest)WebRequest.Create(ip+":"+port+"/"+m);
            server.KeepAlive = false;
            HttpWebResponse respond = (HttpWebResponse)server.GetResponse();
            Stream streamResponse = respond.GetResponseStream();
            StreamReader streamRead = new StreamReader(streamResponse);
            Char[] readBuff = new Char[256];
            int count = streamRead.Read(readBuff, 0, 256);
            string data = "";
            while (count > 0)
            {
                String outputData = new String(readBuff, 0, count);
                data +=outputData;
                count = streamRead.Read(readBuff, 0, 256);
            }
            JObject o = JObject.Parse(data);
            respond.Close();
            streamResponse.Close();
            streamRead.Close();
            return o;
        }
    }
}
