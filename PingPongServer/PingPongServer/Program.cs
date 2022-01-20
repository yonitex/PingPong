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
            var server = new Bootstrapper().Bootstrap();

            if (args != null && args.Length > 0 && int.TryParse(args[0], out port))
            {
                Task t = server.RunServer(port, cancellationToken);
            }
            else
            {
                Task t = server.RunServer(1234, cancellationToken);
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
