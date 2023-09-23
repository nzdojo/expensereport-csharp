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
            var fakeOutput = new FakeOutPut();
            var expenseReport = new ExpenseReport(fakeOutput);
            var expenses = new List<Expense>
            {
                new CarRentalExpense(1) 
            };

            expenseReport.PrintReport(expenses);

            Assert.AreEqual("Meal expenses: 0\r\nTotal expenses: 1", fakeOutput.LastOutput());
        }

        [Test]
        public void PrintExpenseTotalIsOneMealExpenseIsZero()
        {
            var expense = new ExpensePrinter(new CarRentalExpense(1), new FakeOutPut());

            Assert.AreEqual("Car Rental \t 1 \t  ", expense.print());
        }

        [Test]
        public void PrintExpenseTotalIsOneMealExpenseForDinnerIsOne()
        {
            var expense = new ExpensePrinter(new DinnerExpense(1), new FakeOutPut());

            Assert.AreEqual("Dinner \t 1 \t  ", expense.print());
        }

        [Test]
        public void PrintExpenseTotalIsOneMealExpenseForBreakfastIsOne()
        {
            var expense = new ExpensePrinter(new BreakfastExpense(1), new FakeOutPut());

            Assert.AreEqual("Breakfast \t 1 \t  ", expense.print());
        }

        [Test]
        public void TotalIsOneMealExpenseForDinnerIsOne()
        {
            var fakeOutput = new FakeOutPut();
            var expenseReport = new ExpenseReport(fakeOutput);
            var expenses = new List<Expense>
            {
                new DinnerExpense(1)
            };

            expenseReport.PrintReport(expenses);

            Assert.AreEqual("Meal expenses: 1\r\nTotal expenses: 1", fakeOutput.LastOutput());
        }

        [Test]
        public void TotalIsOneMealExpenseForBreakFastIsOneForBreakFast()
        {
            var fakeOutput = new FakeOutPut();
            var expenseReport = new ExpenseReport(fakeOutput);
            var expenses = new List<Expense>
            {
                new BreakfastExpense(1) 
            };

            expenseReport.PrintReport(expenses);

            Assert.AreEqual("Meal expenses: 1\r\nTotal expenses: 1", fakeOutput.LastOutput());
        }

        [Test]
        public void PrintDinnerExpenseIsMarkedWhenOverLimit()
        {
            var expense = new ExpensePrinter(new DinnerExpense(5001), new FakeOutPut());

            Assert.AreEqual("Dinner \t 5001 \t X", expense.print());
        }

        [Test]
        public void DinnerExpenseIsMarkedWhenOverLimit()
        {
            var fakeOutput = new FakeOutPut();
            var expenseReport = new ExpenseReport(fakeOutput);
            var expenses = new List<Expense>
            {
                new DinnerExpense(5001)
            };

            expenseReport.PrintReport(expenses);
            Assert.AreEqual("Meal expenses: 5001\r\nTotal expenses: 5001", fakeOutput.LastOutput());

        }
    }
}