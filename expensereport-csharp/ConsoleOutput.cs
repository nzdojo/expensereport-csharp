using System;

namespace expensereport_csharp
{
    internal class ConsoleOutput : IOutput
    {
        public string Output(string output)
        {
            Console.WriteLine(output);
            return output;
        }
    }
}