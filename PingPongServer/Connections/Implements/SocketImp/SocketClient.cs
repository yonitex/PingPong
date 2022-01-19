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
        private IMessageFactory _messageFactory;

        public SocketClient(IMessageFactory messageFactory)
        {
            _messageFactory = messageFactory;
        }

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

        public IMessageFactory Request()
        {
            byte[] request = new byte[MAX_BUFFER_SIZE];
            _socket.Receive(request);

            return _messageFactory.Create(request);
        }

        public void Response(IMessageFactory data)
        {
            if (data != null)
            {
                MemoryStream memoryStream = new MemoryStream();
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                binaryFormatter.Serialize(memoryStream, data);

                _socket.Send(memoryStream.ToArray());
            }
        }
    }
}
