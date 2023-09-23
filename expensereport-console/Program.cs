namespace expensereport_csharp                                                                                        
{
    class Program
    {
        static void Main(string[] args)
        {
            var printableExpenses = new List<ExpensePrinter>();
            var consoleOutputter = new ConsoleOutput();

            printableExpenses.Add(new ExpensePrinter(new DinnerExpense(2), consoleOutputter));
            printableExpenses.Add(new ExpensePrinter(new BreakfastExpense(1), consoleOutputter));
            printableExpenses.Add(new ExpensePrinter(new CarRentalExpense(10), consoleOutputter));

            var expenseReport = new ExpenseReport(consoleOutputter);
            expenseReport.PrintReport(printableExpenses);

        }
    }
}
