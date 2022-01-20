using Common.Abstracts;

namespace Connections.Abstracts
{
    public interface IClient : IConnection
    {
        void Connect();

        void Send(byte[] request);

        byte[] Receive();
    }
}
