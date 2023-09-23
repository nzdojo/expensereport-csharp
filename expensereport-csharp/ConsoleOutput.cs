using System;

namespace expensereport_csharp
{
    public class ConsoleOutput : IOutput
    {
        public string Output(string output)
        {
            Console.WriteLine(output);
            return output;
        }
    }
}