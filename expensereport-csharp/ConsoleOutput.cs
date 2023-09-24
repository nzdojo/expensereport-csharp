using System;

namespace expensereport_csharp
{
    public class ConsoleOutput : IDisplay
    {
        public string Display(string toDisplay)
        {
            Console.WriteLine(toDisplay);
            return toDisplay;
        }
    }
}