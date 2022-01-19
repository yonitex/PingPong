namespace Common.Abstracts
{
    public interface IMessageFactory
    {
        IMessage Create(byte[] data);
    }
}
