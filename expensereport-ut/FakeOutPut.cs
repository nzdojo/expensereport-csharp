
namespace expensereport_csharp
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