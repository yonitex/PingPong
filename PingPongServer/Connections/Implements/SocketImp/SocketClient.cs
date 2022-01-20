using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using Common.Abstracts;
using Connections.Abstracts;

namespace Connections.Implements.SocketImp
{
    public class SocketClient : IClient
    {
        private const int MAX_BUFFER_SIZE = 1024;
        private Socket _socket;

        public SocketClient(Socket socket)
        {
            _socket = socket;
        }

        public void Close()
        {
            _socket.Shutdown(SocketShutdown.Both);
            _socket.Close();
        }

        public void Open(string ip, int port)
        {
            IPHostEntry ipHost = Dns.GetHostEntry(ip);
            IPAddress ipAddr = ipHost.AddressList[0];
            IPEndPoint localEndPoint = new IPEndPoint(ipAddr, port);

            _socket = new Socket(ipAddr.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
        }

        public byte[] Request()
        {
            byte[] request = new byte[MAX_BUFFER_SIZE];
            _socket.Receive(request);

            return request;
        }

        public void Response(byte[] response)
        {
            if (response != null)
            {
                _socket.Send(response);
            }
        }
    }
}
