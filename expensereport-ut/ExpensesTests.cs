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
        }

        [Test]
        public void TotalIsOneMealExpenseIsOne()
        {
            var expenseReport = new ExpenseReport();
            var expenses = new List<Expense>
            {
                new() { amount = 1, type = ExpenseType.DINNER}
            };

            expenseReport.PrintReport(expenses);

            Assert.AreEqual(1, expenseReport.Total);
            Assert.AreEqual(1, expenseReport.MealExpenses);
        }
    }
}