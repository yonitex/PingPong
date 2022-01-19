using System.Collections.Generic;

namespace Connections.Abstracts
{
    public interface IListener : IConnection
    {
        IEnumerable<IConnection> Listen(int capacity);
    }
}
