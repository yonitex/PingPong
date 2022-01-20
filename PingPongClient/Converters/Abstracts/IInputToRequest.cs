namespace Converters.Abstracts
{
    public interface IInputToRequest<in T>
    {
        byte[] GetRequest(T input);
    }
}
