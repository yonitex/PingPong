using System;
using IO.Abstracts;

namespace IO.Implements
{
    public class ConsoleOutput : IOutput
    {
        public void Write(string value)
        {
            Console.WriteLine(value);
        }
    }
}
