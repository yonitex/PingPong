using System.Collections.Generic;
using System.Threading;
using Common.Abstracts;

namespace Connections.Abstracts
{
    public interface IListener : IConnection
    {
        IEnumerable<IClient> Listen(int capacity, CancellationToken token);
    }
}
