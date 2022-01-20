using IO.Abstracts;

namespace IO.Implements
{
    public class StringParser : IInputParser<string>
    {
        public bool TryParse(string input, out string result)
        {
            result = input;
            return true;
        }
    }
}
