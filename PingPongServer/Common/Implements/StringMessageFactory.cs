using System.Text;
using Common.Abstracts;

namespace Common.Implements
{
    public class StringMessageFactory : IMessageFactory
    {
        public IMessage Create(byte[] data)
        {
            return new StringMessage(Encoding.UTF8.GetString(data));
        }
    }
}
