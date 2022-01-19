using Common.Abstracts;

namespace Connections.Abstracts
{
    public interface IClient : IConnection
    {
        IMessage Request();

        void Response(IMessage data);
    }
}
