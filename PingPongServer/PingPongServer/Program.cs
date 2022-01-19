using System.Threading.Tasks;
using System.Threading;
using System;

namespace PingPongServer
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            CancellationTokenSource cts = new CancellationTokenSource();
            CancellationToken cancellationToken = cts.Token;

            int port;

            if (int.TryParse(args[0], out port))
            {
                var server = new Bootstrapper().Bootstrap();
                Task t = server.RunServer(port, cancellationToken);
            }

            bool stop = false;
            do
            {
                if (Console.ReadKey().Key == ConsoleKey.Y)
                {
                    stop = true;
                }
            } while (!stop);

            cts.Cancel();
        }
    }
}
