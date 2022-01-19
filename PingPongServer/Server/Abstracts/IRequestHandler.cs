using Common.Abstracts;

namespace Server.Abstracts
{
    public interface IRequestHandler
    {
        IMessage GetResponse(IMessage request);
    }
}
