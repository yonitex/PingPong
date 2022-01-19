using System;
using System.Threading.Tasks;
using System.Threading;
using Common.Abstracts;
using Connections.Abstracts;
using System.Collections.Concurrent;
using ServerImp.Abstracts;

namespace ServerImp
{
    public class Server
    {
        private const string IP = "127.0.0.1";
        private const int CAPACITY = 100;
        private IListener _listener;
        private IRequestHandler _requestHandler;
        private ConcurrentBag<Task> _clientHandlers;
        public Server(IListener listener, IRequestHandler requestHandler)
        {
            _listener = listener;
            _requestHandler = requestHandler;
            _clientHandlers = new ConcurrentBag<Task>();
        }

        public async Task RunServer(int port, CancellationToken token)
        {
            _listener.Open(IP, port);

            foreach (IClient client in _listener.Listen(CAPACITY, token))
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
