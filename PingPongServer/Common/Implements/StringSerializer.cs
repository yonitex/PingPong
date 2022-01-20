using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Abstracts;
namespace Common.Implements
{
    internal class stringSerializer : ISerializer<string, byte[]>
    {
        public string Deserialize(byte[] data)
        {
            return Encoding.UTF8.GetString(data);
        }

        public byte[] Serialize(string data)
        {
            return Encoding.UTF8.GetBytes(data);
        }
    }
}
