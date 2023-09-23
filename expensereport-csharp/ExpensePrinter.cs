namespace expensereport_csharp
{
    public class ExpensePrinter : IPrint
    {
        private readonly Expense Expense;

        public IOutput Output { get; }

        public ExpensePrinter(Expense expense, IOutput output)
        {
            this.Expense = expense;
            this.Output = output;
        }

        public string print()
        {
            string toPrint;
            toPrint = string.Format("{0} \t {1} \t {2}", this.Expense.ExpenseName, this.Expense.Amount, this.Expense.Marker);
            Output.Output(toPrint);
            return toPrint;
        }
    }
}