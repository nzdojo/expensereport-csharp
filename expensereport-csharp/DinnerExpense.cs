namespace expensereport_csharp
{
    public class DinnerExpense : Expense
    {
        public DinnerExpense(int amount) : base(amount)
        {
        }

        public override string ExpenseName => "Dinner";

        public override int MealExpense => Amount;

        public override string Marker => Amount > 5000 ? "X" : " ";
    }
}