namespace Converters.Abstracts
{
    public interface IResponseToOutput<out T>
    {
        T Output(byte[] response);
    }
}
