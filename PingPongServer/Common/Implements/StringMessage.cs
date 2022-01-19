using Common.Abstracts;
using System.Text;

namespace Common.Implements
{
    public class StringMessage : IMessage
    {
        public string Data { get; }

        public StringMessage(string data)
        {
            Data = data;
        }

        public byte[] GetDataInBytes()
        {
            return ASCIIEncoding.UTF8.GetBytes(Data);
        }
    }
}
