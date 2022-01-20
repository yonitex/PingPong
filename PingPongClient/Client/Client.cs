using Connections.Abstracts;
using IO.Abstracts;
using Converters.Abstracts;

namespace ClientImp
{
    public class Client<TData>
    {
        private readonly IClient _client;

        private IInput _reader;
        private IOutput _writer;

        private IInputToRequest<TData> _inputToRequestConverter;
        private IResponseToOutput<TData> _responseToOutputConverter;

        public Client(IClient client,
                      IInput reader,
                      IOutput writer,
                      IInputToRequest<TData> inputToRequestConverter,
                      IResponseToOutput<TData> responseToOutputConverter)
        {
            _client = client;
            _reader = reader;
            _writer = writer;
            _inputToRequestConverter = inputToRequestConverter;
            _responseToOutputConverter = responseToOutputConverter;
        }

        public void Connect(string ip, int port)
        {
            _client.Open(ip, port);
            _client.Connect();
        }

        public void Close()
        {
            _client.Close();
        }

        private void Send()
        {
            string input = _reader.Read();
        }
    }
}
