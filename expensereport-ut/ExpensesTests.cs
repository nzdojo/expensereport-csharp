using System.Collections.Generic;
using System.Runtime;
using expensereport_csharp;
using NUnit.Framework;

namespace Expenses
{
    public class ExpensesTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TotalIsOneMealExpenseIsZero()
        {
            var expenseReport = new ExpenseReport();
            var expenses = new List<Expense>
            {
                new CarRentalExpense(1) 
            };

            expenseReport.PrintReport(expenses);

            Assert.AreEqual(1, expenseReport.Total);
            Assert.AreEqual(0, expenseReport.MealExpenses);
            Assert.AreEqual(" ", expenseReport.ExpenseMarker);
            Assert.AreEqual("Car Rental", expenseReport.ExpenseName);
        }

        [Test]
        public void PrintExpenseTotalIsOneMealExpenseIsZero()
        {
            var expense = new ExpensePrinterToConsole(new CarRentalExpense(1));

            Assert.AreEqual("Car Rental \t 1 \t  ", expense.print());
        }

        [Test]
        public void TotalIsOneMealExpenseForDinnerIsOne()
        {
            var expenseReport = new ExpenseReport();
            var expenses = new List<Expense>
            {
                new DinnerExpense(1)
            };

            expenseReport.PrintReport(expenses);

            Assert.AreEqual(1, expenseReport.Total);
            Assert.AreEqual(1, expenseReport.MealExpenses);
            Assert.AreEqual(" ", expenseReport.ExpenseMarker);
            Assert.AreEqual("Dinner", expenseReport.ExpenseName);
        }

        [Test]
        public void TotalIsOneMealExpenseForBreakFastIsOneForBreakFast()
        {
            var expenseReport = new ExpenseReport();
            var expenses = new List<Expense>
            {
                new BreakfastExpense(1) 
            };

            expenseReport.PrintReport(expenses);

            Assert.AreEqual(1, expenseReport.Total);
            Assert.AreEqual(1, expenseReport.MealExpenses);
            Assert.AreEqual(" ", expenseReport.ExpenseMarker);
            Assert.AreEqual("Breakfast", expenseReport.ExpenseName);
        }

        [Test]
        public void DinnerExpenseIsMarkedWhenOverLimit()
        {
            var expenseReport = new ExpenseReport();
            var expenses = new List<Expense>
            {
                new DinnerExpense(5001)
            };

            expenseReport.PrintReport(expenses);

            Assert.AreEqual("X", expenseReport.ExpenseMarker);
        }
    }

}