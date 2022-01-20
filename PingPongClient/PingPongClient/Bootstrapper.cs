using ClientImp;
using Connections.Implements.SocketImp;
using Converters.Implements;
using IO.Abstracts;
using IO.Implements;
using Common.Implements;

namespace PingPongClient
{
    public class Bootstrapper
    {
        public Client<string> Bootstrap()
        {
            var connection = new SocketClient();
            
            var reader = new ConsoleInput();
            var writer = new ConsoleOutput();
            var inputParser = new StringParser();

            var serializer = new StringSerializer();
            var inputToRequestConverter = new ConsoleInputToRequest<string>(serializer);
            var responseToOutputConverter = new ResponseToDataStructure<string>(serializer);

            Client<string> client = new Client<string>(connection,
                                                       reader,
                                                       writer,
                                                       inputParser,
                                                       inputToRequestConverter,
                                                       responseToOutputConverter);

            return client;
        }
    }
}
