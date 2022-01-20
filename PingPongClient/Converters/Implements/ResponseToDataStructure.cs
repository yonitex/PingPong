using Converters.Abstracts;
using Common.Abstracts;

namespace Converters.Implements
{
    public class ResponseToDataStructure<T> : IResponseToOutput<T>
    {
        private ISerializer<T> _serializer;

        public ResponseToDataStructure(ISerializer<T> serializer)
        {
            _serializer = serializer;
        }

        public T Output(byte[] response)
        {
            return _serializer.Deserialize(response);
        }
    }
}
