namespace expensereport_csharp
{
    public class BreakfastExpense : Expense
    {
        private int amount;

        public BreakfastExpense(int amount) 
        {
            this.Amount = amount;
        }

        public override string ExpenseName => "Breakfast";

        public override int MealExpense => Amount;

        public override string Marker => Amount > 1000 ? "X" : " ";

        public override int Amount { get => this.amount; protected set => this.amount = value; }
    }
}