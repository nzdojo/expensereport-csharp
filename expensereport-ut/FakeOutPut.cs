using System;
using expensereport_csharp;

namespace Expenses
{
    internal class FakeOutPut : IOutput
    {
        string lastOutput;

        public FakeOutPut()
        {
        }

        public string Print(string output)
        {
            lastOutput = output;
            return output;
        }

        public string Print()
        {
            return Print(null);
        }

        internal string LastOutput()
        {
            return lastOutput;
        }
    }
}