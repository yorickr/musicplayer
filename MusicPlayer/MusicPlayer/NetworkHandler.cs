using System.Text;
using System.Net.Sockets;
using System.Threading;

namespace MusicPlayer
{
    class NetworkHandler
    {
        private int port = 8585;
        private Socket s;
        private APIHandler api;
 
        public NetworkHandler(string ip, APIHandler apihandler)
        {
            s = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            s.Connect(ip, port);
            ThreadStart thread = new ThreadStart(ReceiveData);
            Thread childThread = new Thread(thread);
            childThread.Start();
            api = apihandler;
        }

        public void SendString(string m)
        {
            byte[] req_as_bytes = Encoding.UTF8.GetBytes(m);
            s.Send(req_as_bytes);
        }

        public void ReceiveData()
        {
            while (s.Connected)
            {
                byte[] data = new byte[1024 * 200]; 
                s.Receive(data);
                string message = Encoding.ASCII.GetString(data);
                System.Console.WriteLine(message);
                //Iets doen met api calls
            }
        }
    }
}
