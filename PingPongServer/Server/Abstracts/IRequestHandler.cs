using Common.Abstracts;

namespace ServerImp.Abstracts
{
    public interface IRequestHandler<T>
    {
        IMessage<T> GetResponse(IMessage<T> request);
    }
}
