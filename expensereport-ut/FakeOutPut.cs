using System;
using expensereport_csharp;

namespace Expenses
{
    internal class FakeOutPut : IOutput
    {
        string lastOutput;

        public string Output(string output)
        {
            lastOutput = output;
            return output;
        }

        internal string LastOutput()
        {
            return lastOutput;
        }
    }
}