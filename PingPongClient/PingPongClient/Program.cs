using ClientImp;
using System.Threading;
using System.Threading.Tasks;

namespace PingPongClient
{
    internal class Program
    {
        private const string IP = "127.0.0.1";
        private const int PORT = 1234;
        private const int TIMEOUT = 100000;
        static async Task Main(string[] args)
        {
            Client<string> client = new Bootstrapper().Bootstrap();
            client.Connect(IP, PORT);

            CancellationTokenSource cts = new CancellationTokenSource();
            CancellationToken cancellationToken = cts.Token;

            Task runClient = client.Run(cancellationToken);
            Task end = await Task.WhenAny(Task.Delay(TIMEOUT), runClient);
            if (end != runClient)
            {
                cts.Cancel();
            }
        }
    }
}
