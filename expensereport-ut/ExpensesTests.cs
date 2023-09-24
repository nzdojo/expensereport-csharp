using System.Collections.Generic;
using System.Linq;
using expensereport_csharp;
using NUnit.Framework;

namespace expensereport_csharp
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
                new(new CarRentalExpense(1)) 
            };

            expenseReport.Print(expenses);

            Assert.AreEqual("Meal expenses: 0\r\nTotal expenses: 1", fakeOutput.LastOutput());
        }

        [Test]
        public void PrintExpenseTotalIsOneMealExpenseIsZero()
        {
            var expense = new ExpensePrinter(new CarRentalExpense(1));

            Assert.AreEqual("Car Rental \t 1", expense.Print());
        }

        [Test]
        public void PrintExpenseTotalIsOneMealExpenseForDinnerIsOne()
        {
            var expense = new ExpensePrinter(new DinnerExpense(1));

            Assert.AreEqual("Dinner \t 1", expense.Print());
        }

        [Test]
        public void PrintExpenseTotalIsOneMealExpenseForBreakfastIsOne()
        {
            var expense = new ExpensePrinter(new BreakfastExpense(1));

            Assert.AreEqual("Breakfast \t 1", expense.Print());
        }

        [Test]
        public void TotalIsOneMealExpenseForDinnerIsOne()
        {
            expenseReport.Print(new List<ExpensePrinter>
            {
                new(new DinnerExpense(1))
            });

            Assert.AreEqual("Meal expenses: 1\r\nTotal expenses: 1", fakeOutput.LastOutput());
        }

        [Test]
        public void TotalIsOneMealExpenseForBreakFastIsOneForBreakFast()
        {
            expenseReport.Print(new List<ExpensePrinter>
            {
                new(new BreakfastExpense(1))
            });

            Assert.AreEqual("Meal expenses: 1\r\nTotal expenses: 1", fakeOutput.LastOutput());
        }

        [Test]
        public void PrintDinnerExpenseIsMarkedWhenOverLimit()
        {
            var expense = new ExpensePrinter(new DinnerExpense(5001));

            Assert.AreEqual("Dinner \t 5001 \t X", expense.Print());
        }

        [Test]
        public void PrintLunchExpense()
        {
            var expense = new ExpensePrinter(new LunchExpense(5001));

            Assert.AreEqual("Lunch \t 2000", expense.Print());
        }

        [Test]
        public void LunchHasALimitOf2000()
        {
            var expense = new LunchExpense(5001);

            Assert.AreEqual(2000, expense.Amount);
        }

        [Test]
        public void LunchBelow2000isFine()       {
            var expense = new LunchExpense(1);

            Assert.AreEqual(1, expense.Amount);
        }

        [Test]
        public void LunchTextIsLunch()
        {
            var expense = new LunchExpense(5001);

            Assert.AreEqual("Lunch", expense.ExpenseName);
        }

        [Test]
        public void MoMarkerForLunch()
        {
            var expense = new LunchExpense(5001);

            Assert.AreEqual(" ", expense.Marker);
        }

        [Test]
        public void ExpensesArePrintable() 
        {
            var expenses = new ExpensesPrinter(new DinnerExpense(2),
                new BreakfastExpense(1),
                new CarRentalExpense(134),
                new LunchExpense(5000));
            foreach (var e in expenses) {
                Assert.IsFalse(string.IsNullOrEmpty(e.Print()));
            }
        }
    }


}