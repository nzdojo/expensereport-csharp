using System.Collections.Generic;
using System.Linq;

namespace expensereport_csharp
{

    public class ExpenseReport
    {
        private Expenses expenses;
        private IDisplay display;

        public ExpenseReport(Expenses expenses) : this(expenses, new ConsoleOutput()){   
        }

        public ExpenseReport(Expenses expenses, IDisplay display) {
            this.expenses = expenses;
            this.display = display;
        }

        public void Print()
        {    
            foreach (var e in this.expenses)
                display.Display(e.Print());
            display.Display(string.Format("Meal expenses: {0}\r\nTotal expenses: {1}", expenses.MealExpenses, expenses.Total));
        }
    }
}