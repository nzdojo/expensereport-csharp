namespace expensereport_csharp                                                                                        
{
    class Program
    {
        static void Main(string[] args)
        {
            new ExpenseReport(new Expenses(
                                    new DinnerExpense(2),
                                    new BreakfastExpense(1),
                                    new CarRentalExpense(134),
                                    new LunchExpense(5000)), 
                            new ConsoleOutput()).Print();
        }
    }
}
