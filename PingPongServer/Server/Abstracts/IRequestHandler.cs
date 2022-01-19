using Common.Abstracts;

namespace Server.Abstracts
{
    public interface IRequestHandler
    {
        void Respond(IMessage request);
    }
}
