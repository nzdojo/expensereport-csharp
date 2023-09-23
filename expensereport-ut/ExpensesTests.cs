using System.Collections.Generic;
using System.Runtime;
using expensereport_csharp;
using NUnit.Framework;

namespace Expenses
{
    public class ExpensesTests
    {
        private FakeOutPut fakeOutput;
        private ExpenseReport expenseReport;

        [SetUp]
        public void SetUp()
        {
            fakeOutput = new FakeOutPut();
            expenseReport = new ExpenseReport(fakeOutput);
        }

        [Test]
        public void TotalIsOneMealExpenseIsZero()
        {
            var expenses = new List<ExpensePrinter>
            {
                new ExpensePrinter(new CarRentalExpense(1), fakeOutput) 
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
            var expenses = new List<ExpensePrinter>
            {
                new ExpensePrinter(new DinnerExpense(1), fakeOutput)
            };

            expenseReport.PrintReport(expenses);

            Assert.AreEqual("Meal expenses: 1\r\nTotal expenses: 1", fakeOutput.LastOutput());
        }

        [Test]
        public void TotalIsOneMealExpenseForBreakFastIsOneForBreakFast()
        {
            var expenses = new List<ExpensePrinter>
            {
                new ExpensePrinter(new BreakfastExpense(1), fakeOutput) 
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

    }
}