namespace expensereport_csharp
{
    // Just an container, likely to have behaviour
    public abstract class Expense
    {
        
        public abstract int Amount { get; protected set; }

        public abstract string ExpenseName
        {
            get;
        }
        public abstract int MealExpense
        {
            get;
        }

        public abstract string Marker {get;}
    }
}