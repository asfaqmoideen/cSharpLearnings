namespace Assignments
{
    /// <summary>
    /// fg
    /// </summary>
    public class IncomeTracker
    {
        private List<FinanceManager> _incomes = new List<FinanceManager>();
        /// <summary>
        /// uhfdjis
        /// </summary>
        public void AddIncome()
        {
            bool temp;
            int proQuantity;
            double newIncome;

            do
            {
                Console.WriteLine("Enter Income (Type - Double)");
                string tempIncome = Console.ReadLine();
                temp = double.TryParse(tempIncome, out newIncome);
            }
            while (temp != true);
            Console.WriteLine("Enter Category");
            string incomeCategory = Console.ReadLine();
            Console.WriteLine("Enter Date");
            string date = Console.ReadLine();
            Console.WriteLine("Enter notes if any ");
            string notes = Console.ReadLine();

            Console.WriteLine("Product Added");
            FinanceManager incometracker = new FinanceManager{ Amount = newIncome, Category = incomeCategory, Date = date, Notes = notes};
            this._incomes.Add(incometracker);

            Console.WriteLine("[A]dd another Income or [M]enu");
            string option = Console.ReadLine();
            if (option == "A" || option == "a")
            {
                AddIncome();
            }
            else
            {
                Console.WriteLine("-------------------------------------------------------------------------------------------------");
                Console.WriteLine("Redirecing to Menu");
                // Main();
            }
        }
    }
}