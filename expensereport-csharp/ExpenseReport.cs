using System;
using System.Collections.Generic;

namespace expensereport_csharp
{
    public enum ExpenseType
    {
        DINNER, BREAKFAST, CAR_RENTAL
    }

// Just an container, likely to have behaviour
    public class Expense
    {
        public ExpenseType type;
        public int amount;
    }

    public class ExpenseReport
    {
        public int Total { get; set; }

        //Curious, what print capability could be decorated over the expense class
        // hard to test, the test can only verify no error occurs.  checking totals is not possible without intercepting console output
        public void PrintReport(List<Expense> expenses)
        {
            int total = 0;
            int mealExpenses = 0;
// Not needed here
            Console.WriteLine("Expenses " + DateTime.Now);
            
            // This loop need only cycle over the expenses. total is accumulated and meal expenses accumulated, but could be done without a loop?
            foreach (Expense expense in expenses)
            {
                if (expense.type == ExpenseType.DINNER || expense.type == ExpenseType.BREAKFAST)
                {
                    mealExpenses += expense.amount;
                }

// Remove to Expense Printer class to be a decorator
                String expenseName = "";
                switch (expense.type)
                {
                    case ExpenseType.DINNER:
                        expenseName = "Dinner";
                        break;
                    case ExpenseType.BREAKFAST:
                        expenseName = "Breakfast";
                        break;
                    case ExpenseType.CAR_RENTAL:
                        expenseName = "Car Rental";
                        break;
                }

                String mealOverExpensesMarker =
                    expense.type == ExpenseType.DINNER && expense.amount > 5000 ||
                    expense.type == ExpenseType.BREAKFAST && expense.amount > 1000
                        ? "X"
                        : " ";

// avoid console writing here
                Console.WriteLine(expenseName + "\t" + expense.amount + "\t" + mealOverExpensesMarker);

                total += expense.amount;
            }

            Console.WriteLine("Meal expenses: " + mealExpenses);
            Console.WriteLine("Total expenses: " + total);
        }
    }
}