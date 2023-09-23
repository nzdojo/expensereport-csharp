namespace expensereport_csharp
{
    public class CarRentalExpense : Expense
    {
        public CarRentalExpense(int amount) : base(amount)
        {
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
    }
}