using Common.Abstracts;

namespace ServerImp.Abstracts
{
    public interface IRequestHandler
    {
        byte[] GetResponse(byte[] request);
    }
}
