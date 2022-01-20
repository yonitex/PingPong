using System;
using IO.Abstracts;

namespace IO.Implements
{
    public class ConsoleInput : IInput
    {
        public string Read()
        {
            return Console.ReadLine();
        }
    }
}
