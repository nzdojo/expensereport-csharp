using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;
using Microsoft.VisualBasic;

namespace expensereport_csharp
{
    public class ExpensePrinter : Expense, IOutput
    {
        private readonly Expense Expense;

        public IOutput Output { get; }

        public override string ExpenseName => Expense.ExpenseName;

        public override int MealExpense => Expense.MealExpense;

        public override string Marker => Expense.Marker;

        public override int Amount { get => Expense.Amount; protected set { throw new NotImplementedException(); } }

        public ExpensePrinter(Expense expense, IOutput output)
        {
            this.Expense = expense;
            this.Output = output;
        }

        public string Print(string output)
        {
            string toPrint;
            toPrint = string.Format("{0} \t {1} \t {2}", this.Expense.ExpenseName, this.Expense.Amount, this.Expense.Marker);
            Output.Print(toPrint);
            return toPrint;
        }

        public string Print()
        {
            return Print(null);
        }
    }
}