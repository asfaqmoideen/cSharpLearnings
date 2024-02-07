namespace Assignments
{
    /// <summary>
    /// Iteracts with user via console
    /// </summary>
    public class UserInterface
    {
        /// <summary>
        /// Prints financial summary to the user
        /// </summary>
        /// <param name="accBalance">Total Acount Balance</param>
        /// <param name="totalIncome">Sum of Income</param>
        /// <param name="totalExpense">Sum of Expenditures</param>
        public void ShowSummaryToTheUser(double accBalance, double totalIncome, double totalExpense)
        {
            Console.WriteLine("-------------------------------------------------------------------------------------------------");
            Console.WriteLine("Showing Summary of Income and Expenses");
            Console.WriteLine("-------------------------------------------------------------------------------------------------");
            Console.WriteLine("\tTotal Balance = " + accBalance);
            Console.WriteLine("\tTotal Incomes = " + totalIncome);
            Console.WriteLine("\tTotal Expense = " + totalExpense);
            Console.WriteLine("-------------------------------------------------------------------------------------------------");
        }

        /// <summary>
        /// Gets the expense category from the user
        /// </summary>
        /// <returns>Category as string</returns>
        public string? GetExpenseCategoryFromTheUser()
        {
            Console.WriteLine("Expense Category");
            string? expenseCategory = Console.ReadLine();
            return expenseCategory;
        }

        /// <summary>
        /// Gets source of the income from the user
        /// </summary>
        /// <returns>Income source as string</returns>
        public string? GetIncomeSourceFromTheUser()
        {
            Console.WriteLine("Income Source");
            string? incomeSource = Console.ReadLine();
            return incomeSource;
        }

        /// <summary>
        /// Displays no incomes whenever it is called
        /// </summary>
        public void DisplayMessageForEmptyIncomeList()
        {
            Console.WriteLine("No Incomes added yet");
            Console.WriteLine("-------------------------------------------------------------------------------------------------");
            Console.WriteLine("Redirecing to Menu");
        }

        /// <summary>
        /// Display no expense whenever it is called
        /// </summary>
        public void DisplayMessageForEmptyExpenseList()
        {
            Console.WriteLine("No Expense added yet");
            Console.WriteLine("-------------------------------------------------------------------------------------------------");
            Console.WriteLine("Redirecing to Menu");
        }

        /// <summary>
        /// Get option to add another entity
        /// </summary>
        /// <returns>option entered</returns>
        public string? AddAnotherEntity()
        {
            Console.WriteLine("[A]dd another or [M]enu");
            string? option = Console.ReadLine();
            return option;
        }

        /// <summary>
        /// Gets income amount from the user
        /// </summary>
        /// <returns>income amount as string</returns>
        public string? GetExpenseAmountFromTheUser()
        {
            Console.WriteLine("Enter Expense Amount");
            string? expenseAmount = Console.ReadLine();
            return expenseAmount;
        }

        /// <summary>
        /// Gets income amount from the user
        /// </summary>
        /// <returns>income amount as tring</returns>
        public string? GetIncomeAmountFromTheUser()
        {
            Console.WriteLine("Enter Income Amount");
            string? incomeAmount = Console.ReadLine();
            return incomeAmount;
        }

        /// <summary>
        /// Printing Redirecting to menu when it is called
        /// </summary>
        public void PrintRedirectingToMenu()
        {
            Console.WriteLine("-------------------------------------------------------------------------------------------------");
            Console.WriteLine("Redirecing to Menu");
        }

        /// <summary>
        /// get confirmation from the user
        /// </summary>
        /// <returns>Y if yes</returns>
        public string? GetConfirmation()
        {
            Console.WriteLine("Confirm  Delete of Expense - [Y]es - [C]ancel");
            string? option = Console.ReadLine();
            return option;
        }

        /// <summary>
        /// Shows the search results to the user.
        /// </summary>
        /// <param name="amount">Expense Amount</param>
        /// <param name="category"> Expense Categoryfdsdf</param>
        /// <param name="createdAt">Expense created time </param>
        /// <param name="updatedAt">Expense updated time</param>
        public void ShowSearchResults(double amount, string category, DateTime createdAt, DateTime updatedAt)
        {
            Console.WriteLine("Search Result");
            Console.WriteLine("Amount :" + amount + "\n" + "Category :" + category +
                "\n" + "Created Date " + createdAt + "\n" + "Updated Date: " + updatedAt + "\t");
        }

        /// <summary>
        /// Option from the user
        /// </summary>
        /// <returns>1 if Inocme, 2 if epxpense</returns>
        public string? ChooseTheOption()
        {
            Console.WriteLine("Choose the opotion\n1.Income\n2.Expense");
            string? option = Console.ReadLine();
            return option;
        }
    }
}
