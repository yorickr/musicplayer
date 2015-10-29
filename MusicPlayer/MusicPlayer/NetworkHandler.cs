using System;
using System.Text;
using System.Net.Sockets;
using System.Threading;
using System.Net;
using System.IO;

namespace MusicPlayer
{
    class NetworkHandler
    {
        private int port = 8585;
        private string ip;
        private APIHandler api;
 
        public NetworkHandler(string ip, APIHandler apihandler)
        {
            this.ip = ip;
            this.api = apihandler;
        }

        public void SendString(string m)
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
            System.Console.WriteLine(data);
            respond.Close();
            streamResponse.Close();
            streamRead.Close();
        }
    }
}
