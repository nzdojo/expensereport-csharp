namespace expensereport_csharp
{
    public class BreakfastExpense : Expense
    {
        public BreakfastExpense(int amount) : base(amount)
        {
        }

        public override string ExpenseName => "Breakfast";

        public override int MealExpense => Amount;

        public override string Marker => Amount > 1000 ? "X" : " ";
    }
}