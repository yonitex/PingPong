using Common.Abstracts;
using Server.Abstracts;

namespace Server.Implements
{
    public class PingPongRequestHandler : IRequestHandler
    {
        public IMessageFactory GetResponse(IMessageFactory request)
        {
            return request;
        }
    }
}
