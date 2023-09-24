namespace expensereport_csharp
{
    public class LunchExpense : Expense
    {
        private const int MAX = 2000;
        private int amount;

        public LunchExpense(int amount) 
        {
            this.Amount = amount;
        }

        public override string ExpenseName => "Lunch";

        public override int MealExpense => Amount;

        public override string Marker => " ";

        public override int Amount
        {
            get => this.amount; protected set
            {
                this.amount = value <= MAX ? value : MAX;
            }
        }
    }
}