using System.Collections.Generic;

namespace expensereport_csharp
{

    public class ExpenseReport
    {
        private IOutput output;

        public ExpenseReport() : this(new ConsoleOutput()){   
        }

        public ExpenseReport(IOutput output) {
            this.output = output;
        }

        public void PrintReport(List<Expense> expenses)
        {    
            int mealExpenses = 0;        
            int total = 0;
            foreach (Expense expense in expenses)
            {
                mealExpenses += expense.MealExpense;
                total += expense.Amount;
                new ExpensePrinter(expense, output).print();
            }
            output.Output(string.Format("Meal expenses: {0}\r\nTotal expenses: {1}", mealExpenses, total));
        }
    }
}