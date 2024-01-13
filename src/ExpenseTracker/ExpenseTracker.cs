namespace Assignments
{/// <summary>
/// This class stores all the expense entities and methods
/// </summary>
    internal class ExpenseTracker
    {
        private List<FinanceManager> _expense = new List<FinanceManager>();

        /// <summary>
        /// Method to Add a Expense
        /// </summary>
        public void AddExpense()
        {
            Console.Write("Adding a Expense\n");
            double newExpense = this.GetExpenseAmount();
            DateOnly expenseDate = this.GetExpenseDate();
            string expenseCategory = this.GetExpenseCategory();
            string expenseNotes = this.GetExpenseNotes();
            Console.WriteLine("Expense Added");
            FinanceManager expensetracker = new FinanceManager
            {
                Amount = newExpense,
                Category = expenseCategory,
                Date = expenseDate,
                Notes = expenseNotes
            };

            this._expense.Add(expensetracker);
            Console.WriteLine("[A]dd another Expense or [M]enu");
            string? option = Console.ReadLine();
            if (option == "A" || option == "a")
            {
                this.AddExpense();
             }
            else
            {
                Console.WriteLine("-------------------------------------------------------------------------------------------------");
                Console.WriteLine("Redirecing to Menu");
            }
        }

        /// <summary>
        /// Method to View All Expenses
        /// </summary>
        public void ViewExpense()
        {
            Console.WriteLine("Loading Expenses");
            {
                if (this._expense.Count > 0)
                {
                    Console.WriteLine("-------------------------------------------------------------------------------------------------");
                    Console.WriteLine("History of Expense");
                    Console.WriteLine("-------------------------------------------------------------------------------------------------");
                    Console.WriteLine("Amouny" + "\t" + "Category" + "\t" + "Date" + "Notes");
                    foreach (var expense in this._expense)
                    {
                        Console.WriteLine(expense.Amount + "\t" + expense.Category + "\t" + expense.Date + "\t" + expense.Notes);
                    }
                }
                else
                {
                    this.NoExpenseYet();
                }
            }
        }

        /// <summary>
        /// To delete a past expense
        /// </summary>
        public void DeleteExpense()
        {
            if (this._expense.Count > 0)
            {
                bool temp1; DateOnly searchDate;
                Console.WriteLine("Deleting your past Expense");
                Console.WriteLine("Enter Expense Category");
                string searchCategory = Console.ReadLine();
                do
                {
                    Console.WriteLine("Enter Date (YYYY-MM-DD");
                    string tempDate = Console.ReadLine();
                    temp1 = DateOnly.TryParse(tempDate, out searchDate);
                }
                while (temp1 != true);
                {
                    foreach (var expense in this._expense)
                    {
                        if (expense.Category == searchCategory || expense.Date == searchDate)
                        {
                            Console.WriteLine("You Might Want to delete");
                            Console.WriteLine("Amount :" + expense.Amount + "\n" + "Category :" + expense.Category +
                                "\n" + "Date " + expense.Date + "\n" + "Notes: " + expense.Notes + "\t");
                            Console.WriteLine("Confirm  Delete of Expense - [Y]es - [C]ancel");
                            string option = Console.ReadLine();

                            if (option == "Y" || option == "y")
                            {
                                this._expense.Remove(expense);

                                Console.WriteLine("Expense Deleted :(");
                                Console.WriteLine("-------------------------------------------------------------------------------------------------");
                                break;
                            }
                        }
                    }
                }
            }
            else
            {
                this.NoExpenseYet();
            }
        }

        /// <summary>
        /// To edit past expense
        /// </summary>
        public void EditExpense()
        {
            FinanceManager editExpense;
            if (this._expense.Count > 0)
            {
                bool temp1; DateOnly searchDate;
                Console.WriteLine("Deleting your past Expense");
                Console.WriteLine("Enter Expense Category");
                string searchCategory = Console.ReadLine();
                do
                {
                    Console.WriteLine("Enter Date (YYYY-MM-DD");
                    string tempDate = Console.ReadLine();
                    temp1 = DateOnly.TryParse(tempDate, out searchDate);
                }
                while (temp1 != true);
                foreach (var expense in this._expense)
                {
                    if (expense.Category == searchCategory || expense.Date == searchDate)
                    {
                        Console.WriteLine("You Might Want to Edit");
                        Console.WriteLine("Amount :" + expense.Amount + "\n" + "Category :" + expense.Category +
                            "\n" + "Date " + expense.Date + "\n" + "Notes: " + expense.Notes + "\t");
                        Console.WriteLine("Confirm  Edit of Expense - [Y]es - [C]ancel");
                        string option = Console.ReadLine();

                        if (option == "Y" || option == "y")
                        {
                            double newExpense = this.GetExpenseAmount();
                            DateOnly expenseDate = this.GetExpenseDate();
                            string expenseCategory = this.GetExpenseCategory();
                            string expenseNotes = this.GetExpenseNotes();
                            expense.Amount = newExpense;
                            expense.Category = expenseCategory;
                            expense.Date = expenseDate;
                            expense.Notes = expenseNotes;
                            Console.WriteLine("Expense Edited :)");
                            Console.WriteLine("-------------------------------------------------------------------------------------------------");
                            break;
                        }
                    }
                }
            }
            else
            {
                this.NoExpenseYet();
            }
        }
        /// <summary>
        /// Method that returs the total Expense
        /// </summary>
        /// <returns>returs the total Expense</returns>
        public double GenerateExpenserecord()
        {
            double sumOfExpense = 0;
            foreach (var expense in this._expense)
            {
                sumOfExpense += expense.Amount;
            }
            return sumOfExpense;
        }
        /// <summary>
        /// A function to print no expenses
        /// </summary>
        public void NoExpenseYet()
        {
            Console.WriteLine("No Expenses yet");
            Console.WriteLine("-------------------------------------------------------------------------------------------------");
            Console.WriteLine("Redirecing to Menu");
        }
        /// <summary>
        /// Function to get expense amount from th user
        /// </summary>
        /// <returns>Amount as double</returns>
        public double GetExpenseAmount()
        {
            bool isExpenseDouble;
            double expenseAmount;
            do
            {
                Console.WriteLine("Enter Expense (Type - Double)");
                string tempExpense = Console.ReadLine();
                isExpenseDouble = double.TryParse(tempExpense, out expenseAmount);
            }
            while (isExpenseDouble != true);
            return expenseAmount;
        }
        /// <summary>
        /// Function to get expense date
        /// </summary>
        /// <returns> Expense date </returns>
        private DateOnly GetExpenseDate()
        {
            bool isExpenseDateDateonly;
            DateOnly expenseDateOnly;
            do
            {
                Console.WriteLine("Enter Date (YYYY-MM-DD");
                string tempDate = Console.ReadLine();
                isExpenseDateDateonly = DateOnly.TryParse(tempDate, out expenseDateOnly);
            }
            while (isExpenseDateDateonly != true);
            return expenseDateOnly;
        }

        private string GetExpenseCategory()
        {
            Console.WriteLine("Expense Category");
            string expenseCategory = Console.ReadLine();
            return (expenseCategory != null) ? expenseCategory : "-";
        }

        private string GetExpenseNotes()
        {
            Console.WriteLine("Enter notes if any ");
            string expensenotes = Console.ReadLine();
            return (expensenotes != null) ? expensenotes : "-";
        }
    }
}
