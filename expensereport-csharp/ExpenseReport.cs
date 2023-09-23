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
        public int Total { get; private set; }
        public int MealExpenses { get; private set; }
        public string ExpenseMarker { get; private set; }
        public string ExpenseName { get; private set; }

        //Curious, what print capability could be decorated over the expense class
        // hard to test, the test can only verify no error occurs.  checking totals is not possible without intercepting console output
        public void PrintReport(List<Expense> expenses)
        {
// Not needed here
            Console.WriteLine("Expenses " + DateTime.Now);
            
            // This loop need only cycle over the expenses. total is accumulated and meal expenses accumulated, but could be done without a loop?
            foreach (Expense expense in expenses)
            {
                if (expense.type == ExpenseType.DINNER || expense.type == ExpenseType.BREAKFAST)
                {
                    MealExpenses += expense.amount;
                }

// Remove to Expense Printer class to be a decorator
                String expenseName = "";
                switch (expense.type)
                {
                    case ExpenseType.DINNER:
                        ExpenseName = "Dinner";
                        break;
                    case ExpenseType.BREAKFAST:
                        ExpenseName = "Breakfast";
                        break;
                    case ExpenseType.CAR_RENTAL:
                        ExpenseName = "Car Rental";
                        break;
                }

                ExpenseMarker =
                    expense.type == ExpenseType.DINNER && expense.amount > 5000 ||
                    expense.type == ExpenseType.BREAKFAST && expense.amount > 1000
                        ? "X"
                        : " ";

// avoid console writing here
                Console.WriteLine(expenseName + "\t" + expense.amount + "\t" + ExpenseMarker);

                Total += expense.amount;
            }

            Console.WriteLine("Meal expenses: " + MealExpenses);
            Console.WriteLine("Total expenses: " + Total);
        }
    }
}