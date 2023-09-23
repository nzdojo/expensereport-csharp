using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text.Json.Serialization.Metadata;

namespace expensereport_csharp
{

    public class ExpenseReport
    {
        public int Total { get; private set; }
        public int MealExpenses { get; private set; }
        private IOutput output;

        public ExpenseReport() : this(new ConsoleOutput()){   
        }

        public ExpenseReport(IOutput output) {
            this.output = output;
        }

        //Curious, what print capability could be decorated over the expense class
        // hard to test, the test can only verify no error occurs.  checking totals is not possible without intercepting console output
        public void PrintReport(List<Expense> expenses)
        {            
            // This loop need only cycle over the expenses. total is accumulated and meal expenses accumulated, but could be done without a loop?
            foreach (Expense expense in expenses)
            {
                MealExpenses += expense.MealExpense;
                Total += expense.Amount;
                new ExpensePrinter(expense, output).print();
            }

            output.Output("Meal expenses: " + MealExpenses);
            output.Output("Total expenses: " + Total);
        }
    }
}