using System.Collections.Generic;
using System.Linq;
using expensereport_csharp;
using NUnit.Framework;

namespace expensereport_csharp
{
    public class ExpensesTests
    {
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
            var expenses = new Expenses(new DinnerExpense(2),
                new BreakfastExpense(1),
                new CarRentalExpense(134),
                new LunchExpense(5000));
            foreach (var e in expenses) {
                Assert.IsFalse(string.IsNullOrEmpty(e.Print()));
            }
        }

        [Test]
        public void SumMealExpensesIs100() 
        {
            var expenses = new Expenses(new DinnerExpense(50),
                new BreakfastExpense(25),
                new CarRentalExpense(134),
                new LunchExpense(25));
            Assert.AreEqual(100, expenses.MealExpenses);
        }

        [Test]
        public void SumTotalExpensesIs125() 
        {
            var expenses = new Expenses(new DinnerExpense(50),
                new BreakfastExpense(25),
                new CarRentalExpense(25),
                new LunchExpense(25));
            Assert.AreEqual(125, expenses.Total);
        }

        [Test]
        public void ExpenseReportPrints()
        {
            IDisplay fakeOutput = new FakeOutPut();
            //TODO accumulate the fakeoutput to check it for correctness
            var expenseReport = new ExpenseReport(
                        new Expenses(
                            new DinnerExpense(2),
                            new BreakfastExpense(1),
                            new CarRentalExpense(134),
                            new LunchExpense(5000)), fakeOutput);
            expenseReport.Print();
        }
    }

}