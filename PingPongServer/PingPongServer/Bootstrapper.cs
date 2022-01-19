using ServerImp;
using Common.Abstracts;
using Common.Implements;
using Connections.Abstracts;
using Connections.Implements.SocketImp;
using ServerImp.Implements;

namespace PingPongServer
{
    public class Bootstrapper
    {
        public Server Bootstrap()
        {
            var messageFactory = new StringMessageFactory();
            var listener = new SocketListener(messageFactory);
            var requestHandler = new PingPongRequestHandler();
            var server = new Server(listener, requestHandler);

            return server;
        }
    }
}
