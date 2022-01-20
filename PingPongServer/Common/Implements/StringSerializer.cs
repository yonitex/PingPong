﻿using System;
using System.Text;
using Common.Abstracts;
namespace Common.Implements
{
    internal class stringSerializer : ISerializer<string>
    {
        public string Deserialize(byte[] data)
        {
            Type t = typeof(object);
            return Encoding.UTF8.GetString(data);
        }

        public byte[] Serialize(string data)
        {
            return Encoding.UTF8.GetBytes(data);
        }
    }
}
