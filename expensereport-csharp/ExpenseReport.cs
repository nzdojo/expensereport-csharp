using System;
using System.Collections.Generic;
using System.Text.Json.Serialization.Metadata;

namespace expensereport_csharp
{
    public enum ExpenseType
    {
        DINNER, BREAKFAST, CAR_RENTAL
    }

// Just an container, likely to have behaviour
    public abstract class Expense
    {
        public Expense(int amount){
            Amount = amount;
        }
        
        public int Amount { get; private set; }
        public abstract string ExpenseName
        {
            get;
        }
    }

    public class CarRentalExpense : Expense
    {
        public CarRentalExpense(int amount) : base(amount)
        {
        }

        public override string ExpenseName
        {
            get
            {
                return "Car Rental";
            }
        }
    }

    public class DinnerExpense : Expense
    {
        public DinnerExpense(int amount) : base(amount)
        {
        }

        public override string ExpenseName => "Dinner";
    }

    public class BreakfastExpense : Expense
    {
        public BreakfastExpense(int amount) : base(amount)
        {
        }

        public override string ExpenseName => "Breakfast";
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
            // This loop need only cycle over the expenses. total is accumulated and meal expenses accumulated, but could be done without a loop?
            foreach (Expense expense in expenses)
            {
                if (expense is DinnerExpense || expense is BreakfastExpense)
                {
                    MealExpenses += expense.Amount;
                }

                ExpenseMarker =
                    expense is DinnerExpense && expense.Amount > 5000 ||
                    expense is BreakfastExpense && expense.Amount > 1000
                        ? "X"
                        : " ";

//expecting this to be temporary
                ExpenseName = expense.ExpenseName;
                Total += expense.Amount;
            }
        }
    }
}