namespace expensereport_csharp                                                                                        
{
    class Program
    {
        static void Main(string[] args)
        {
            var printableExpenses = new List<ExpensePrinter>();
            var consoleOutput = new ConsoleOutput();

            printableExpenses.Add(new ExpensePrinter(new DinnerExpense(2), consoleOutput));
            printableExpenses.Add(new ExpensePrinter(new BreakfastExpense(1), consoleOutput));
            printableExpenses.Add(new ExpensePrinter(new CarRentalExpense(134), consoleOutput));
            printableExpenses.Add(new ExpensePrinter(new LunchExpense(5000), consoleOutput));

            var expenseReport = new ExpenseReport(consoleOutput);
            expenseReport.Print(printableExpenses);

        }
    }
}
