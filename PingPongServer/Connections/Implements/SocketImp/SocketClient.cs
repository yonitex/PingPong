using System.Net;
using System.Net.Sockets;
using Common.Abstracts;
using Connections.Abstracts;

namespace Connections.Implements.SocketImp
{
    public class SocketClient : IClient
    {
        private const int MaxBufferSize = 1024;
        private Socket _socket;

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

        public IMessage Request()
        {
            throw new System.NotImplementedException();
        }

        public void Response(IMessage data)
        {
            throw new System.NotImplementedException();
        }
    }
}
