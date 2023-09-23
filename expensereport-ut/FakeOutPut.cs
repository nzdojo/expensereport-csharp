using expensereport_csharp;

namespace Expenses
{
    internal class FakeOutPut : IOutput
    {
        public string Output(string output)
        {
            return output;
        }
    }
}