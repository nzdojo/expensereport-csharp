namespace expensereport_csharp
{
    public interface IOutput {
        string Print(string output);
        string Print();
    }
}