namespace Assignments
{/// <summary>
/// /hnjb
/// </summary>
    internal class ExpenseTracker
    {
        private List<FinanceManager> _expense = new List<FinanceManager>();

        /// <summary>
        /// This is the Method to Add a Expense
        /// </summary>
        public void AddExpense()
        {
            Console.Write("Adding a Expense\n");
            bool temp, temp1;
            double newExpense;
            DateOnly date;
            do
            {
                Console.WriteLine("Enter Expense (Type - Double)");
                string tempExpense = Console.ReadLine();
                temp = double.TryParse(tempExpense, out newExpense);
            }
            while (temp != true);
            Console.WriteLine("Enter Category");
            string expenseCategory = Console.ReadLine();
            do
            {
                Console.WriteLine("Enter Date (YYYY-MM-DD");
                string tempDate = Console.ReadLine();
                temp1 = DateOnly.TryParse(tempDate, out date);
            }
            while (temp1 != true);
            Console.WriteLine("Enter notes if any ");
            string notes = Console.ReadLine();

            Console.WriteLine("Expense Added");
            FinanceManager expensetracker = new FinanceManager
            {
                Amount = newExpense,
                Category = expenseCategory,
                Date = date,
                Notes = notes,
            };
            this._expense.Add(expensetracker);
            Console.WriteLine("[A]dd another Expense or [M]enu");
            string? option = Console.ReadLine();
            if (option == "A" || option == "a")
            {
                AddExpense();
            }
            else
            {
                Console.WriteLine("-------------------------------------------------------------------------------------------------");
                Console.WriteLine("Redirecing to Menu");
            }
        }

        /// <summary>
        /// This is the Method to View All Expenses
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
                    Console.WriteLine("No Expense History");
                    Console.WriteLine("-------------------------------------------------------------------------------------------------");
                    Console.WriteLine("Redirecing to Menu");
                }
            }
        }
        /// <summary>
        /// khg
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
                Console.WriteLine("No Expenses yet");
                Console.WriteLine("-------------------------------------------------------------------------------------------------");
                Console.WriteLine("Redirecing to Menu");
            }
        }
        /// <summary>
        /// juhj
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
                            editExpense = expense;
                            Console.Write("Enter New details");
                            bool temp, temp2;
                            double newExpense;
                            DateOnly date;
                            do
                            {
                                Console.WriteLine("Enter Expense (Type - Double)");
                                string tempExpense = Console.ReadLine();
                                temp = double.TryParse(tempExpense, out newExpense);
                            }
                            while (temp != true);
                            Console.WriteLine("Enter Category");
                            string expenseCategory = Console.ReadLine();
                            do
                            {
                                Console.WriteLine("Enter Date (YYYY-MM-DD");
                                string tempDate = Console.ReadLine();
                                temp2 = DateOnly.TryParse(tempDate, out date);
                            }
                            while (temp1 != true);
                            Console.WriteLine("Enter notes if any ");
                            string notes = Console.ReadLine();

                            Console.WriteLine("Expense Added");
                            FinanceManager expensetracker = new FinanceManager
                            {
                                Amount = newExpense,
                                Category = expenseCategory,
                                Date = date,
                                Notes = notes,
                            };
                            this._expense.Add(editExpense);
                            Console.WriteLine("Expense Edited :)");
                            Console.WriteLine("-------------------------------------------------------------------------------------------------");
                            break;
                            }
                        }
                    }
                }
            else
            {
                Console.WriteLine("No Expenses yet");
                Console.WriteLine("-------------------------------------------------------------------------------------------------");
                Console.WriteLine("Redirecing to Menu");
            }
        }
        /// <summary>
        /// Method that returs the total Expense
        /// </summary>
        /// <returns>returs the total Expense</returns>
        public double GenerateExpenserecord()
        {
            double sumOfExpense = 0;
            foreach(var expense in this._expense)
            {
                sumOfExpense += expense.Amount;
            }
            return sumOfExpense;
        }
    }
 }
