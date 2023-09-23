namespace expensereport_csharp
{
    public class CarRentalExpense : Expense
    {

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

        public override int Amount { get => this.Amount; protected set => this.Amount = value; }
    }
}