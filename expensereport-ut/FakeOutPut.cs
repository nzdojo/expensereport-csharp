
namespace expensereport_csharp
{
    internal class FakeOutPut : IDisplay
    {
        string lastOutput;

        public FakeOutPut()
        {
        }

        public string Display(string output)
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