namespace Assignments
{
    /// <summary>
    /// Internal Class Program
    /// </summary>
    internal partial class Program
    {
        private static void Main(string[] args)
        {
            string option;
            Console.WriteLine("\t\tWelcome to Expense Tracker");
            do
            {
                Console.WriteLine("----------------------------------------------------------\n");
                Console.WriteLine("Please find the list of operations offered below:");
                Console.WriteLine("1. Add an expense \n2. Add an Income \n3. Show History\n4. Edit a Income Expense\n5. Show Financial Summary\n0. Exit application\n");
                Console.Write("Choose one of the above listed option to proceed: ) ");
                option = Console.ReadLine();
                ChooseTheOption(option);
            }
            while (option != "q" && option != "Q");
        }
        private static void ChooseTheOption(string option)
        {
            switch (option)
            {
                case "1":
                    IncomeTracker incomeTracker; incomeTracker = new IncomeTracker();
                    incomeTracker.AddIncome();
                    break;
                case "2":
                    ExpenseTracker expenseTracker; expenseTracker = new ExpenseTracker();
                    expenseTracker.AddExpense();
                    break;
            }
        }
    }
}