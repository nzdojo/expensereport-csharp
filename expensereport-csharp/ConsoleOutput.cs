using System;

namespace expensereport_csharp
{
    public class ConsoleOutput : IOutput
    {
        public string Print(string output)
        {
            Console.WriteLine(output);
            return output;
        }

        public string Print()
        {
            return Print(null);
        }
    }
}