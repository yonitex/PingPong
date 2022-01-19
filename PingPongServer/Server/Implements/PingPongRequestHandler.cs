using Common.Abstracts;
using ServerImp.Abstracts;

namespace ServerImp.Implements
{
    public class PingPongRequestHandler : IRequestHandler
    {
        public IMessageFactory GetResponse(IMessageFactory request)
        {
            return request;
        }
    }
}
