﻿using System;
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
            HttpWebRequest server =   (HttpWebRequest)WebRequest.Create(ip+":"+port+"/"+encodedstring);
            server.ReadWriteTimeout = 500;
            server.KeepAlive = false;
            try {
                HttpWebResponse respond = (HttpWebResponse)server.GetResponse();
                Stream streamResponse = respond.GetResponseStream();
                streamResponse.ReadTimeout = 500;
                StreamReader streamRead = new StreamReader(streamResponse);
                Char[] readBuff = new Char[256];
                int count = streamRead.Read(readBuff, 0, 256);
                string data = "";
                while (count > 0)
                {
                    String outputData = new String(readBuff, 0, count);
                    data += outputData;
                    count = streamRead.Read(readBuff, 0, 256);
                }
                JObject o = JObject.Parse(data);
                respond.Close();
                streamResponse.Close();
                streamRead.Close();
                return o;
            }
            catch(WebException e)
            {
                Console.WriteLine("Server is offline");
            }
            catch(Exception e)
            {
                Console.WriteLine("Er is iets fout gegaan bij het communiceren met de server.");
            }

            return null;
            
        }

        public MemoryStream downloadArtwork(string album)
        {
            try
            {
                string encodedstring = Microsoft.Security.Application.Encoder.HtmlEncode(ip + "/music/.artwork/" + album);
                WebRequest req = WebRequest.Create(encodedstring);
                req.Timeout = 500;
                //WebRequest req = WebRequest.Create((ip + "/music/.artwork/" + album).Replace(" ","%20"));
                WebResponse response = req.GetResponse();
                Stream stream = response.GetResponseStream();
                stream.ReadTimeout = 500;

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
