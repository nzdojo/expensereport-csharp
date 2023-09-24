using System.Collections.Generic;
using System.Linq;

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

        public void Print(List<ExpensePrinter> expenses)
        {    
            expenses.ForEach(e => e.Print());
            output.Print(string.Format("Meal expenses: {0}\r\nTotal expenses: {1}", expenses.Sum(e => e.MealExpense), expenses.Sum(e => e.Amount)));
        }
    }
}