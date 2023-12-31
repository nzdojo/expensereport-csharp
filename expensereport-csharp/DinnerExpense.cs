namespace expensereport_csharp
{
    public class DinnerExpense : Expense
    {
        private int amount;

        public DinnerExpense(int amount) 
        {
            this.Amount = amount;
        }

        public override string ExpenseName => "Dinner";

        public override int MealExpense => Amount;

        public override string Marker => Amount > 5000 ? "X" : " ";

        public override int Amount { get => this.amount; protected set => this.amount = value; }
    }
}