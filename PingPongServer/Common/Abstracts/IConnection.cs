namespace Common.Abstracts
{
    public interface IConnection
    {
        void Open(string ip, int port);

        void Close();
    }
}
