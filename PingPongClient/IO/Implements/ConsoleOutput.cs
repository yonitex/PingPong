using System;
using IO.Abstracts;

namespace IO.Implements
{
    internal class ConsoleOutput : IOutput
    {
        public void Write(string value)
        {
            Console.WriteLine(value);
        }
    }
}
