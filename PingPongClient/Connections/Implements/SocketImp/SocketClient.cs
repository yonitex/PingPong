using System.Net;
using System.Net.Sockets;
using System.IO;
using Connections.Abstracts;

namespace Connections.Implements.SocketImp
{
    public class SocketClient : IClient
    {
        private const int MAX_BUFFER_SIZE = 1024;
        private Socket _socket;
        private IPEndPoint _localEndPoint;
        public void Close()
        {
            if (_socket != null)
            {
                _socket.Shutdown(SocketShutdown.Both);
                _socket.Close(); 
            }
        }

        public void Connect()
        {
            _socket.Connect(_localEndPoint);
        }

        public void Open(string ip, int port)
        {
            IPHostEntry iPHost = Dns.GetHostEntry(ip);
            IPAddress ipAddr = iPHost.AddressList[0];

            _localEndPoint = new IPEndPoint(ipAddr, port);
            _socket = new Socket(ipAddr.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
        }

        public byte[] Receive()
        {
            byte[] response = new byte[MAX_BUFFER_SIZE];
            _socket.Receive(response);

            return response;
        }

        public void Send(byte[] request)
        {
            _socket.Send(request);
        }
    }
}
