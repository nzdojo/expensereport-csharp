namespace expensereport_csharp
{
    public class CarRentalExpense : Expense
    {
        private int amount;

        public CarRentalExpense(int amount) 
        {
            this.Amount = amount;
        }

        public override string ExpenseName
        {
            get
            {
                return "Car Rental";
            }
        }

        public override int MealExpense => 0;

        public override string Marker => " ";

        public override int Amount { get => this.amount; protected set => this.amount = value; }
    }
}