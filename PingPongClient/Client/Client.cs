using Connections.Abstracts;
using IO.Abstracts;
using Converters.Abstracts;
using System.Threading;
using System;
using System.Threading.Tasks;

namespace ClientImp
{
    public class Client<TData>
    {
        private const string INVALID_INPUT = "invalid input";
        private const string CONNECTION_CLOSED = "connection was closed";
        private const int MAX_BUFFER_SIZE = 1024;

        private readonly IClient _client;

        private IInput _reader;
        private IOutput _writer;
        private IInputParser<TData> _parser;

        private IInputToRequest<TData> _inputToRequestConverter;
        private IResponseToOutput<TData> _responseToOutputConverter;

        public Client(IClient client,
                      IInput reader,
                      IOutput writer,
                      IInputParser<TData> parser,
                      IInputToRequest<TData> inputToRequestConverter,
                      IResponseToOutput<TData> responseToOutputConverter)
        {
            _client = client;
            _reader = reader;
            _writer = writer;
            _parser = parser;
            _inputToRequestConverter = inputToRequestConverter;
            _responseToOutputConverter = responseToOutputConverter;
        }

        public async Task Run(CancellationToken token)
        {
            while (!token.IsCancellationRequested)
            {
                try
                {
                    Send();
                    Receive();
                }
                catch (Exception)
                {
                    _writer.Write(CONNECTION_CLOSED);
                    break;
                }
            }

            Close();
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
            TData data;
            bool succeeded = _parser.TryParse(input, out data);
            if (succeeded)
            {
                byte[] request = _inputToRequestConverter.GetRequest(data);
                _client.Send(request);
            }
            else
            {
                _writer.Write(INVALID_INPUT);
            }
        }

        private void Receive()
        {
            byte[] response = new byte[MAX_BUFFER_SIZE];
            TData output = _responseToOutputConverter.Output(response);
            _writer.Write(output.ToString());
        }
    }
}
