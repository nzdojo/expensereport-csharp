namespace expensereport_csharp                                                                                        
{
    class Program
    {
        static void Main(string[] args)
        {
            var printableExpenses = new List<ExpensePrinter>();
            var consoleOutput = new ConsoleOutput();

            printableExpenses.Add(new ExpensePrinter(new DinnerExpense(2)));
            printableExpenses.Add(new ExpensePrinter(new BreakfastExpense(1)));
            printableExpenses.Add(new ExpensePrinter(new CarRentalExpense(134)));
            printableExpenses.Add(new ExpensePrinter(new LunchExpense(5000)));
            var expenseReport = new ExpenseReport();
            expenseReport.Print(printableExpenses);

            //  var expenseReport = new ExpenseReport(
            //                         new ExpensePrinter(
            //                             new Expenses(
            //                                 new DinnerExpense(2),
            //                                 new BreakfastExpense(1),
            //                                 new CarRentalExpense(134),
            //                                 new LunchExpense(5000))), 
            //                         consoleOutput).Print();
            // expenseReport.Print(printableExpenses);

        }
    }
}
