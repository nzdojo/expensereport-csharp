using System.Collections;
using System.Collections.Generic;

namespace expensereport_csharp
{
    public class ExpensesPrinter : IEnumerable<ExpensePrinter>
    {
        List<ExpensePrinter> expensePrinters;

        public ExpensesPrinter(params Expense[] expenses)
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

        IEnumerator IEnumerable.GetEnumerator()
        {
            return expensePrinters.GetEnumerator();
        }
    }
}