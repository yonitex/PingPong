using System;
using System.Threading.Tasks;
using System.Threading;
using Common.Abstracts;
using Connections.Abstracts;
using System.Collections.Concurrent;

namespace Server
{
    public class Server
    {
        private const string IP = "127.0.0.1";
        private const int CAPACITY = 10;
        private IListener _listener;
        private ConcurrentBag<IClient> _clients;
        public Server(int port)
        {
            _clients = new ConcurrentBag<IClient>();
            _listener.Open(IP, port);
        }

        public async Task RunServer(CancellationToken token)
        {
            foreach (IClient client in _listener.Listen(CAPACITY))
            {
                if (token.IsCancellationRequested)
                {
                    break;
                }

                _clients.Add(client);
                HandleClient(client, token);
            }
        }

        private async Task HandleClient(IClient client, CancellationToken token)
        {
            while (!token.IsCancellationRequested)
            {
                IMessage request = client.Request();
                if (request != null)
                {
                    // todo: response handler
                }
            }
        }
    }
}
