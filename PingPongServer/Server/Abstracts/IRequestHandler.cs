using Common.Abstracts;

namespace Server.Abstracts
{
    public interface IRequestHandler
    {
        IMessageFactory GetResponse(IMessageFactory request);
    }
}
