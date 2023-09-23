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
        public void TotalGreaterThanZero()
        {
            var expenseReport = new ExpenseReport();

            Assert.Greater(expenseReport.Total, 0);

        }
    }
}