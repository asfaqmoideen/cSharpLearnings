namespace Assignments
{
    /// <summary>
    /// Internal Class Program
    /// </summary>
    internal partial class Program
    {
        private static ExpenseTracker _expenseTracker = new ExpenseTracker();
        private static IncomeTracker _incomeTracker = new IncomeTracker();

        private static void Main(string[] args)
        {
            string option;
            Console.WriteLine("\t\tWelcome to Expense Tracker");
            do
            {
                Console.WriteLine("----------------------------------------------------------\n");
                Console.WriteLine("Please find the list of operations offered below:");
                Console.WriteLine("1. Add an expense \n2. Add an Income \n3. Show History\n4. Edit a Income/Expense\n5. Show Financial Summary \n6. Delete Income/Expense\n Q - Exit application\n");
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
                    _expenseTracker.AddExpense();
                    break;
                case "2":
                    _incomeTracker.AddIncome();
                    break;
               
                case "3":
                    ShowRecord();
                    break;
                case "4":
                    EditRecord();
                    break; 
                case "5":
                    ShowSummary();
                    break;
                case "6":
                    DeleteRecord();
                    break;
            }
        }
        private static void ShowRecord()
        {
            _expenseTracker.ViewExpense();
            _incomeTracker.ViewIncome();
        }
        private static void EditRecord()
        {
            Console.WriteLine("Edit \n1.Income\n2.Expense");
            string option = Console.ReadLine();
            if (option == "1")
            {
                _incomeTracker.EditIncome();
            }
            else if (option == "2")
            {
                _expenseTracker.EditExpense();
            }
        }
        private static void DeleteRecord()
        {
            Console.WriteLine("Delete \n1.Income\n2.Expense");
            string option = Console.ReadLine();
            if (option == "1")
            {
                _incomeTracker.DeleteIncome();
            }
            else if (option == "2")
            {
                _expenseTracker.DeleteExpense();
            }
        }
        private static void ShowSummary()
        {  
            double accbalance = 0;
            Console.WriteLine("-------------------------------------------------------------------------------------------------");
            Console.WriteLine("Showing Summary of Income and Expenses");
            Console.WriteLine("-------------------------------------------------------------------------------------------------");
            double totalIncome = _incomeTracker.GenerateIncomerecord();
            double totalExpense = _expenseTracker.GenerateExpenserecord();
            accbalance = accbalance + totalIncome - totalExpense;
            Console.WriteLine("\tTotal Balance = "+  accbalance);
            Console.WriteLine("\tTotal Incomes = "+  totalIncome);
            Console.WriteLine("\tTotal Expense = " + totalExpense);
            Console.WriteLine("-------------------------------------------------------------------------------------------------");
        }
    }
}