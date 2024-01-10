namespace Assignments
{/// <summary>
/// /hnjb
/// </summary>
    internal class ExpenseTracker
    {
        private List<FinanceManager> _expense = new List<FinanceManager>();
        /// <summary>
        /// skjnksd
        /// </summary>
        public void AddExpense()
        {
            bool temp;
            int proQuantity;
            double newExpense;

            do
            {
                Console.WriteLine("Enter Expense (Type - Double)");
                string tempExpense = Console.ReadLine();
                temp = double.TryParse(tempExpense, out newExpense);
            }
            while (temp != true);
            Console.WriteLine("Enter Category");
            string expenseCategory = Console.ReadLine();
            Console.WriteLine("Enter Date");
            string date = Console.ReadLine();
            Console.WriteLine("Enter notes if any ");
            string notes = Console.ReadLine();

            Console.WriteLine("Product Added");
            FinanceManager expensetracker = new FinanceManager { Amount = newExpense, Category = expenseCategory, Date = date, Notes = notes };
            this._expense.Add(expensetracker);

            Console.WriteLine("[A]dd another Expense or [M]enu");
            string option = Console.ReadLine();
            if (option == "A" || option == "a")
            {
                AddExpense();
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