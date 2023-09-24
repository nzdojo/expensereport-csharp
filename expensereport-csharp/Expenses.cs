using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace expensereport_csharp
{
    public class Expenses : IEnumerable<ExpensePrinter>
    {
        List<ExpensePrinter> expensePrinters;

        public Expenses(params Expense[] expenses)
        {
            this.expensePrinters = new List<ExpensePrinter>();
            foreach (var e in expenses)
            {
                expensePrinters.Add(new ExpensePrinter(e));
            }
        }

        public int MealExpenses { get {
                return this.expensePrinters.Sum(e => e.MealExpense);
            } 
        }

        public int Total { get {
                return this.expensePrinters.Sum(e => e.Amount);
            } 
        }

        public IEnumerator<ExpensePrinter> GetEnumerator()
        {
            return expensePrinters.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return expensePrinters.GetEnumerator();
        }
    }
}