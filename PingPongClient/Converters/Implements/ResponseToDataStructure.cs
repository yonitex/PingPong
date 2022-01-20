using Converters.Abstracts;
using Common.Abstracts;

namespace Converters.Implements
{
    public class ResponseToConsoleOutput<T> : IResponseToOutput<T>
    {
        private ISerializer<T> _serializer;

        public ResponseToConsoleOutput(ISerializer<T> serializer)
        {
            _serializer = serializer;
        }

        public T Output(byte[] response)
        {
            return _serializer.Deserialize(response);
        }
    }
}
