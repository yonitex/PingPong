using Common.Abstracts;
using ServerImp.Abstracts;

namespace ServerImp.Implements
{
    public class PingPongRequestHandler : IRequestHandler
    {
        public IMessage GetResponse(IMessage request)
        {
            return request;
        }
    }
}
