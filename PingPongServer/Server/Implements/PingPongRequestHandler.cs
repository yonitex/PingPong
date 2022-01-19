using Common.Abstracts;
using Server.Abstracts;

namespace Server.Implements
{
    public class PingPongRequestHandler : IRequestHandler
    {
        public IMessage GetResponse(IMessage request)
        {
            return request;
        }
    }
}
