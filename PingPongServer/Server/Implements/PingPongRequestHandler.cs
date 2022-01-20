using Common.Abstracts;
using ServerImp.Abstracts;

namespace ServerImp.Implements
{
    public class PingPongRequestHandler : IRequestHandler
    {
        public byte[] GetResponse(byte[] request)
        {
            return request;
        }
    }
}
