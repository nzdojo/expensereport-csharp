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

        public void PrintReport(List<ExpensePrinter> expenses)
        {    
            int mealExpenses = 0;        
            int total = 0;
            foreach (ExpensePrinter expensePrinter in expenses)
            {
                mealExpenses += expensePrinter.MealExpense;
                total += expensePrinter.Amount;
                expensePrinter.print();
            }
            output.Output(string.Format("Meal expenses: {0}\r\nTotal expenses: {1}", mealExpenses, total));
        }
    }
}