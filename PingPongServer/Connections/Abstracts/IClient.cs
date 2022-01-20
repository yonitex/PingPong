using Common.Abstracts;

namespace Connections.Abstracts
{
    public interface IClient : IConnection
    {
        byte[] Request();

        void Response(byte[] data);
    }
}
