using Converters.Abstracts;
using Common.Abstracts;

namespace Converters.Implements
{
    public class ConsoleInputToRequest<T> : IInputToRequest<T>
    {
        private ISerializer<T> _serializer;

        public ConsoleInputToRequest(ISerializer<T> serializer)
        {
            _serializer = serializer;
        }

        public byte[] GetRequest(T input)
        {
            return _serializer.Serialize(input);
        }
    }
}
