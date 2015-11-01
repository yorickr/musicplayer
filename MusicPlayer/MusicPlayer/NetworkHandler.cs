using System;
using System.Text;
using System.Net.Sockets;
using System.Threading;
using System.Web;
using System.Net;
using System.IO;
using Microsoft.Security.Application;
using Newtonsoft.Json.Linq;


namespace MusicPlayer
{
    public class NetworkHandler
    {
        private int port = 8585;
        public string ip { get; set; }
 
        public NetworkHandler(string ip)
        {
            this.ip = ip;
        }

        public JObject SendString(string m)
        {
            string encodedstring = Microsoft.Security.Application.Encoder.HtmlEncode(m);
            Console.WriteLine(encodedstring);
            HttpWebRequest server =   (HttpWebRequest)WebRequest.Create(ip+":"+port+"/"+encodedstring);
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

        public MemoryStream downloadArtwork(string album)
        {
            try
            {
                WebRequest req = WebRequest.Create((ip + "/music/.artwork/"+album).Replace(" ", "%20"));
                WebResponse response = req.GetResponse();
                Stream stream = response.GetResponseStream();

                //Download in chuncks
                byte[] buffer = new byte[1024];
                //Get Total Size
                int dataLength = (int)response.ContentLength;
                //Download to memory
                MemoryStream memStream = new MemoryStream();
                while (true)
                {
                    //Try to read the data
                    int bytesRead = stream.Read(buffer, 0, buffer.Length);
                    if (bytesRead == 0)
                    {
                        break;
                    }
                    else
                    {
                        memStream.Write(buffer, 0, bytesRead);
                    }
                }
                //Clean up
                stream.Close();

                //Convert the downloaded stream to a byte array
                return memStream;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
