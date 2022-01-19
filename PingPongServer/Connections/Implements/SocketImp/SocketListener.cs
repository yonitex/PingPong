using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using Connections.Abstracts;

namespace Connections.Implements.SocketImp
{
    public class SocketListener : IListener
    {
        private Socket _listener;
        private IPEndPoint _localEndPoint;

        public void Close()
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<IClient> Listen(int capacity, CancellationToken token)
        {

            _listener.Bind(_localEndPoint);
            _listener.Listen(capacity);

            while (!token.IsCancellationRequested)
            {
                yield return new SocketClient(_listener.Accept());
            }
        }

        public void Open(string ip, int port)
        {
            IPHostEntry ipHost = Dns.GetHostEntry(ip);
            IPAddress ipAddr = ipHost.AddressList[0];

            _localEndPoint = new IPEndPoint(ipAddr, port);
            _listener = new Socket(ipAddr.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
        }
    }
}
