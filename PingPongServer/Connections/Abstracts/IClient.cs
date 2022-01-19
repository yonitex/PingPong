using Common.Abstracts;

namespace Connections.Abstracts
{
    public interface IClient : IConnection
    {
        IMessageFactory Request();

        void Response(IMessageFactory data);
    }
}
