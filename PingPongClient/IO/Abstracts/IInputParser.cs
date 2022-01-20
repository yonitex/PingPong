namespace IO.Abstracts
{
    public interface IInputParser<T>
    {
        bool TryParse(string input, out T result);
    }
}
