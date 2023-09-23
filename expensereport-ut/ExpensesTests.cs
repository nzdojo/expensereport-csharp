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

            Assert.AreEqual(1, expenseReport.Total);
            Assert.AreEqual(0, expenseReport.MealExpenses);
            //Assert.AreEqual("Car Rental", expenseReport.ExpenseName);
        }

        [Test]
        public void PrintExpenseTotalIsOneMealExpenseIsZero()
        {
            var expense = new ExpensePrinterToConsole(new CarRentalExpense(1), new FakeOutPut());

            Assert.AreEqual("Car Rental \t 1 \t  ", expense.print());
        }

        [Test]
        public void PrintExpenseTotalIsOneMealExpenseForDinnerIsOne()
        {
            var expense = new ExpensePrinterToConsole(new DinnerExpense(1), new FakeOutPut());

            Assert.AreEqual("Dinner \t 1 \t  ", expense.print());
        }

        [Test]
        public void PrintExpenseTotalIsOneMealExpenseForBreakfastIsOne()
        {
            var expense = new ExpensePrinterToConsole(new BreakfastExpense(1), new FakeOutPut());

            Assert.AreEqual("Breakfast \t 1 \t  ", expense.print());
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
        }

        [Test]
        public void PrintDinnerExpenseIsMarkedWhenOverLimit()
        {
            var expense = new ExpensePrinterToConsole(new DinnerExpense(5001), new FakeOutPut());

            Assert.AreEqual("Dinner \t 5001 \t X", expense.print());
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

        }
    }

    internal class FakeOutPut : IOutput
    {
        public string Output(string output)
        {
            return output;
        }
    }
}