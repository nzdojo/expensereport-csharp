using System;
using System.Collections;
using System.Collections.Generic;

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

        public IEnumerator<ExpensePrinter> GetEnumerator()
        {
            return expensePrinters.GetEnumerator();
        }

        internal void ForEach(Func<object, object> value)
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return expensePrinters.GetEnumerator();
        }
    }
}