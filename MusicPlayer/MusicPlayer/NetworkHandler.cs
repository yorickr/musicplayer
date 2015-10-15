using System;
using System.Text;
using System.Net.Sockets;
using System.Threading;

namespace MusicPlayer
{
    class NetworkHandler
    {
        private int port = 8585;
        private TcpClient s;
        private NetworkStream serverStream;
        private APIHandler api;
 
        public NetworkHandler(string ip, APIHandler apihandler)
        {
            Console.WriteLine("Hello");
            s = new TcpClient();
            s.Connect(ip, port);
            serverStream = s.GetStream();
            ThreadStart thread = new ThreadStart(ReceiveData);
            Thread childThread = new Thread(thread);
            childThread.Start();
            api = apihandler;
        }

        public void SendString(string m)
        { 
            byte[] b = Encoding.UTF8.GetBytes(m);
            serverStream.Write(b, 0, b.Length);
            serverStream.Flush();
        }

        public void ReceiveData()
        {
            Console.WriteLine("Hello2");
            while (s.Connected)
            {
                Console.WriteLine("Hello3");
                byte[] data = new byte[512];
                Console.WriteLine("Hang je hier?");
                int bytesRec = serverStream.Read(data, 0, data.Length);
                Console.WriteLine("ën hier? ");
                Console.WriteLine("Echoed test = {0}",Encoding.ASCII.GetString(data, 0, bytesRec));
                

                string message = Encoding.ASCII.GetString(data);
                System.Console.WriteLine(message);
                //Iets doen met api calls
            }
        }
    }
}
