﻿using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
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
        public abstract int MealExpense
        {
            get;
        }

        public abstract string Marker {get;}
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

        public override int MealExpense => 0;

        public override string Marker => " ";
    }

    public class DinnerExpense : Expense
    {
        public DinnerExpense(int amount) : base(amount)
        {
        }

        public override string ExpenseName => "Dinner";

        public override int MealExpense => Amount;

        public override string Marker => Amount > 5000 ? "X" : " ";
    }

    public class BreakfastExpense : Expense
    {
        public BreakfastExpense(int amount) : base(amount)
        {
        }

        public override string ExpenseName => "Breakfast";

        public override int MealExpense => Amount;

        public override string Marker => Amount > 1000 ? "X" : " ";
    }
    public interface IPrint {
    string print();
}

    public class ExpensePrinterToConsole : IPrint
    {
        private readonly Expense Expense;

        public IOutput Output { get; }

        public ExpensePrinterToConsole(Expense expense, IOutput output)
        {
            this.Expense = expense;
            this.Output = output;
        }

        public string print()
        {
            string toPrint;
            toPrint = string.Format("{0} \t {1} \t {2}", this.Expense.ExpenseName, this.Expense.Amount, this.Expense.Marker);
            Output.Output(toPrint);
            return toPrint;
        }
    }

    public class ExpenseReport
    {
        public int Total { get; private set; }
        public int MealExpenses { get; private set; }
        public string ExpenseName { get; private set; }
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
                 new ExpensePrinterToConsole(expense, output).print();
            }

            output.Output("Meal expenses: " + MealExpenses);
            output.Output("Total expenses: " + Total);
        }
    }

    internal class ConsoleOutput : IOutput
    {
        public string Output(string output)
        {
            Console.WriteLine(output);
            return output;
        }
    }

    public interface IOutput {
        string Output(string output);
    }
}