using ServerImp;
using Connections.Implements.SocketImp;
using ServerImp.Implements;

namespace PingPongServer
{
    public class Bootstrapper
    {
        public Server Bootstrap()
        {
            var listener = new SocketListener();
            var requestHandler = new PingPongRequestHandler();
            var server = new Server(listener, requestHandler);

            return server;
        }
    }
}
