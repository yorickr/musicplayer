using System;
using System.Text;
using System.Net.Sockets;

namespace WindowsFormsApplication2
{
    class NetworkHandler
    {
        private int port = 8585;
        private Socket s;
 
        public NetworkHandler(string ip)
        {
            s = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            s.Connect(ip, port);
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
                int t = s.Receive(data);
                //Iets doen met api calls
            }
        }
    }
}
