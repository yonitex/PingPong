using Common.Abstracts;

namespace ServerImp.Abstracts
{
    public interface IRequestHandler
    {
        IMessage GetResponse(IMessage request);
    }
}
