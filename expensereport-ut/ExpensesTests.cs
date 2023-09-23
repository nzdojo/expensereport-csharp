using System.Collections.Generic;
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
                new() { amount = 1, type = ExpenseType.CAR_RENTAL }
            };

            expenseReport.PrintReport(expenses);

            Assert.AreEqual(1, expenseReport.Total);
            Assert.AreEqual(0, expenseReport.MealExpenses);
            Assert.AreEqual(" ", expenseReport.ExpenseMarker);
            Assert.AreEqual("Car Rental", expenseReport.ExpenseName);
        }

        [Test]
        public void TotalIsOneMealExpenseForDinnerIsOne()
        {
            var expenseReport = new ExpenseReport();
            var expenses = new List<Expense>
            {
                new() { amount = 1, type = ExpenseType.DINNER}
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
                new() { amount = 1, type = ExpenseType.BREAKFAST}
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
                new() { amount = 5001, type = ExpenseType.BREAKFAST}
            };

            expenseReport.PrintReport(expenses);

            Assert.AreEqual("X", expenseReport.ExpenseMarker);
        }
    }
}