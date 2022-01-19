using System.Collections.Generic;

namespace Connections.Abstracts
{
    public interface IListener : IConnection
    {
        IEnumerable<IClient> Listen(int capacity);
    }
}
