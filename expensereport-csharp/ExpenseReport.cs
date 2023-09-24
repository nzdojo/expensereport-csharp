using System.Collections.Generic;
using System.Linq;

namespace expensereport_csharp
{

    public class ExpenseReport
    {
        private Expenses expenses;
        private IOutput output;

        public ExpenseReport(Expenses expenses) : this(expenses, new ConsoleOutput()){   
        }

        public ExpenseReport(Expenses expenses, IOutput output) {
            this.expenses = expenses;
            this.output = output;
        }

        public void Print()
        {    
            foreach (var e in this.expenses)
                output.Print(e.Print());
                //TODO: Possible that the sums can come from the collection
            output.Print(string.Format("Meal expenses: {0}\r\nTotal expenses: {1}", expenses.Sum(e => e.MealExpense), expenses.Sum(e => e.Amount)));
        }
    }
}