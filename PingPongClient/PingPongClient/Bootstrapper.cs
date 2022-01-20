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
        public Client<Person> Bootstrap()
        {
            var connection = new SocketClient();
            
            var reader = new ConsoleInput();
            var writer = new ConsoleOutput();
            var inputParser = new PersonParser();

            var serializer = new ObjectSerializer<Person>();
            var inputToRequestConverter = new ConsoleInputToRequest<Person>(serializer);
            var responseToOutputConverter = new ResponseToDataStructure<Person>(serializer);

            Client<Person> client = new Client<Person>(connection,
                                                       reader,
                                                       writer,
                                                       inputParser,
                                                       inputToRequestConverter,
                                                       responseToOutputConverter);

            return client;
        }
    }
}
