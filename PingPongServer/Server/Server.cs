using System;
using System.Threading.Tasks;
using System.Threading;
using Common.Abstracts;
using Connections.Abstracts;
using System.Collections.Concurrent;
using Server.Abstracts;

namespace Server
{
    public class Server
    {
        private const string IP = "127.0.0.1";
        private const int CAPACITY = 10;
        private IListener _listener;
        private IRequestHandler _requestHandler;
        private ConcurrentBag<Task> _clientHandlers;
        public Server(int port)
        {
            _clientHandlers = new ConcurrentBag<Task>();
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

                _clientHandlers.Add(HandleClient(client, token));
            }

            await Task.WhenAll(_clientHandlers);
        }

        private async Task HandleClient(IClient client, CancellationToken token)
        {
            while (!token.IsCancellationRequested)
            {
                IMessage request = client.Request();
                if (request != null)
                {
                    IMessage response = _requestHandler.GetResponse(request);
                    client.Response(response);
                }
            }

            client.Close();
        }
    }
}
