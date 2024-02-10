using Assignments;

namespace Assignments
{
    /// <summary>
    /// This class stores all the expense and income expense manager methods
    /// </summary>
    public class FinanceTracker
    {
        private UserInterface _userInterface;
        private List<ExpenseEntity> _expenses;
        private List<IncomeEntity> _incomes;

        /// <summary>
        /// Initializes a new instance of the <see cref="FinanceTracker"/> class.
        /// </summary>
        public FinanceTracker()
        {
            this._expenses = new List<ExpenseEntity>();
            this._incomes = new List<IncomeEntity>();
            this._userInterface = new UserInterface();
        }

        /// <summary>
        /// Enabling to view expenses list outside the class
        /// </summary>
        /// <returns>returns the list of expenses when it called</returns>
        public List<ExpenseEntity> GetExpense()
        {
            return this._expenses;
        }

        /// <summary>
        /// Enabling to view incomes list outside the class
        /// </summary>
        /// <returns>returns the list of incomes when it called</returns>
        public List<IncomeEntity> GetIncome()
        {
            return this._incomes;
        }

        /// <summary>
        /// Method to Add a Expense
        /// </summary
        public void AddExpense()
        {
            double newExpense = this.GetExpenseAmount();
            string? expenseCategory = this.GetExpenseCategory();
            DateTime expenseDate = DateTime.Now;
            DateTime updatedExpensedate = DateTime.Now;
            ExpenseEntity expenseEntity = new ExpenseEntity(newExpense, expenseCategory, expenseDate, updatedExpensedate);
            this.AddExpenseToTheList(expenseEntity);
            string? option = this._userInterface.AddAnotherEntity();
            Console.WriteLine("Expense Added");
            if (option == "A" || option == "a")
            {
                this.AddExpense();
            }
            else
            {
                this._userInterface.PrintRedirectingToMenu();
            }
        }

        /// <summary>
        /// Adds expense parameters to th expense list
        /// </summary>
        /// <param name="expenseEntity">OPbject expenseentity</param>
        public void AddExpenseToTheList(ExpenseEntity expenseEntity)
        {
            this._expenses.Add(expenseEntity);
        }

        /// <summary>
        /// Method to add incomes
        /// </summary>
        public void AddIncome()
        {
            double newIncome = this.GetIncomeAmount();
            string? incomeCategory = this.GetIncomeSource();
            DateTime incomeDate = DateTime.Now;
            DateTime updatedIncomeDate = DateTime.Now;
            IncomeEntity incometracker = new IncomeEntity(newIncome, incomeCategory, incomeDate, updatedIncomeDate);
            this.AddIncomesToTheList(incometracker);
            string? option = this._userInterface.AddAnotherEntity();
            if (option == "A" || option == "a")
            {
                this.AddIncome();
            }
            else
            {
                this._userInterface.PrintRedirectingToMenu();
            }
        }

        /// <summary>
        /// Adding objects to the list of income
        /// </summary>
        /// <param name="incomeEntity"> object</param>
        public void AddIncomesToTheList(IncomeEntity incomeEntity)
        {
            this._incomes.Add(incomeEntity);
        }

        /// <summary>
        /// Method to View All Expenses
        /// </summary>
        public void ViewExpense()
        {
            if (this._expenses.Count > 0)
            {
                foreach (var expense in this._expenses)
                {
                    Console.WriteLine(expense.Amount + "\t" + expense.Category + "\t" + expense.CreatedAt + "\t" + expense.UpdatedAt);
                }
            }
            else
            {
                this._userInterface.DisplayMessageForEmptyExpenseList();
            }
        }

        /// <summary>
        /// Method to view inocomes
        /// </summary>
        public void ViewIncome()
        {
            Console.WriteLine("Income");
            if (this._incomes.Count > 0)
            {
                Console.WriteLine("Amouny\tSource\tCreated Date\tUpdtaed Date");
                foreach (var incomes in this._incomes)
                {
                    Console.WriteLine(incomes.Amount + "\t" + incomes.Source + "\t" + incomes.CreatedAt + "\t" + incomes.UpdatedAt);
                }
            }
            else
            {
                this._userInterface.DisplayMessageForEmptyIncomeList();
            }
        }

        /// <summary>
        /// To delete a past expense
        /// </summary>
        public void DeleteExpense()
        {
            if (this._expenses.Count > 0)
            {
                string? searchCategory = this._userInterface.GetExpenseCategoryFromTheUser();
                ExpenseEntity? expenseResult = this.SearchExpenseFromTheList(searchCategory);
                string? option = this._userInterface.GetConfirmation();
                if (option == "Y" || option == "y")
                {
                    this.RemoveExpenseFromTheList(expenseResult);
                }
                else
                {
                    this._userInterface.DisplayMessageForEmptyExpenseList();
                }
            }
        }

        /// <summary>
        /// Removes expense object with the refrence
        /// </summary>
        /// <param name="expenseEntity">object reference</param>
        public void RemoveExpenseFromTheList(ExpenseEntity expenseEntity)
        {
            this._expenses.Remove(expenseEntity);
        }

        /// <summary>
        /// Search from expense list
        /// </summary>
        /// <param name="searchCategory">search category</param>
        /// <returns> expense entity as</returns>
        public ExpenseEntity? SearchExpenseFromTheList(string searchCategory)
        {
            if (!string.IsNullOrEmpty(searchCategory))
            {
                foreach (var expense in this._expenses)
                {
                    if (expense.Category.ToLower() == searchCategory.ToLower())
                    {
                        this._userInterface.ShowSearchResults(expense.Amount, expense.Category, expense.CreatedAt, expense.UpdatedAt);
                        return expense;
                    }
                }
            }

            return null;
        }

        /// <summary>
        /// Search from expense list
        /// </summary>
        /// <param name="searchCategory">search category</param>
        /// <returns> expense entity as</returns>
        public IncomeEntity? SearchIncomeFromTheList(string? searchCategory)
        {
            if (!string.IsNullOrEmpty(searchCategory))
            {
                foreach (var income in this._incomes)
                {
                    if (income.Source.ToLower() == searchCategory.ToLower())
                    {
                        this._userInterface.ShowSearchResults(income.Amount, income.Source, income.CreatedAt, income.UpdatedAt);
                        return income;
                    }
                }
            }

            return null;
        }

        /// <summary>
        /// Method to delete income
        /// </summary>
        public void DeleteIncome()
        {
            if (this._incomes.Count > 0)
            {
                string? searchCategory = this._userInterface.GetIncomeSourceFromTheUser();
                IncomeEntity? incomeResult = this.SearchIncomeFromTheList(searchCategory);
                string? option = this._userInterface.GetConfirmation();

                if (option == "Y" || option == "y")
                {
                    this.RemoveIncomeFromTheList(incomeResult);
                }
                else
                {
                    this._userInterface.PrintRedirectingToMenu();
                }
            }
            else
            {
                this._userInterface.DisplayMessageForEmptyIncomeList();
            }
        }

        /// <summary>
        /// Removes incomes from the list
        /// </summary>
        /// <param name="incomeEntity">object reference to delete</param>
        public void RemoveIncomeFromTheList(IncomeEntity incomeEntity)
        {
            this._incomes.Remove(incomeEntity);
        }

        /// <summary>
        /// To edit past expense
        /// </summary>
        public void EditExpense()
        {
            if (this._expenses.Count > 0)
            {
                string? searchCategory = this._userInterface.GetExpenseCategoryFromTheUser();
                ExpenseEntity? expenseResult = this.SearchExpenseFromTheList(searchCategory);
                string? option = this._userInterface.GetConfirmation();

                if (option == "Y" || option == "y")
                {
                    double newExpense = this.GetExpenseAmount();
                    string? newExpenseCategory = this._userInterface.GetExpenseCategoryFromTheUser();

                    this.EditExpenseWithReferenceObject(expenseResult, newExpense, newExpenseCategory);
                }
                else
                {
                    this._userInterface.PrintRedirectingToMenu();
                }
            }
            else
            {
                this._userInterface.DisplayMessageForEmptyExpenseList();
            }
        }

        /// <summary>
        /// Edits the changed fields with refrence
        /// </summary>
        /// <param name="expenseEntity"> Result expense entity</param>
        /// <param name="newExpense">New expesne amount</param>
        /// <param name="newExpenseCategory">new expense category</param>
        public void EditExpenseWithReferenceObject(ExpenseEntity expenseEntity, double newExpense, string newExpenseCategory)
        {
            expenseEntity.Amount = newExpense;
            expenseEntity.Category = newExpenseCategory;
            expenseEntity.UpdatedAt = DateTime.Now;
        }

        /// <summary>
        /// Validating input expense amount is double
        /// </summary>
        /// <param name="expenseAmount">string input from UI</param>
        /// <param name="expenseAmountOutput">Double out put when</param>
        /// <returns>true if the input is double, false elsewhere</returns>
        public bool IsAmountDouble(string expenseAmount, out double expenseAmountOutput)
        {
            bool isExpenseDouble = double.TryParse(expenseAmount, out double expenseamount);
            expenseAmountOutput = expenseamount;
            return isExpenseDouble && (expenseAmountOutput > 0);
        }

        /// <summary>
        /// Cheks whether the income source is unique
        /// </summary>
        /// <param name="incomeSource">string value of income source</param>
        /// <returns>true if not unique false else where</returns>
        public bool IsIncomeSourceUnique(string incomeSource)
        {
            foreach (var income in this._incomes)
            {
                if (income.Source.ToLower() == incomeSource.ToLower())
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// checks whether the expense is unique
        /// </summary>
        /// <param name="expenseCategory">string value of expense</param>
        /// <returns>true if not unique false elsewhere</returns>
        public bool IsExpenseCategoryUnique(string expenseCategory)
        {
            foreach (var expense in this._expenses)
            {
                if (expense.Category.ToLower() == expenseCategory.ToLower())
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Method that returs the total Expense
        /// </summary>
        /// <returns>returs the total Expense</returns>
        public double GenerateExpenserecord()
        {
            double sumOfExpense = 0;
            foreach (var expense in this._expenses)
            {
                sumOfExpense += expense.Amount;
            }

            return sumOfExpense;
        }

        /// <summary>
        /// Method to generate the total income record
        /// </summary>
        /// <returns>the total income</returns>
        public double GenerateIncomerecord()
        {
            double sumofIncome = 0;
            foreach (var income in this._incomes)
            {
                sumofIncome = income.Amount;
            }

            return sumofIncome;
        }

        /// <summary>
        /// Generates financial summary
        /// </summary>
        public void GenerateFinancialSummary()
        {
            double sumOfFinancialSummary = 0;
            double totalIncome = this.GenerateIncomerecord();
            double totalExpense = this.GenerateExpenserecord();
            sumOfFinancialSummary = sumOfFinancialSummary + totalIncome - totalExpense;
            this._userInterface.ShowSummaryToTheUser(sumOfFinancialSummary, totalIncome, totalExpense);
        }

        /// <summary>
        /// Gets valid Income amount
        /// </summary>
        /// <returns>income amount as double</returns>
        public double GetExpenseAmount()
        {
            string? expesneAmountString = this._userInterface.GetExpenseAmountFromTheUser();
            double expenseAmountDouble;
            while (!this.IsAmountDouble(expesneAmountString, out expenseAmountDouble))
            {
                expesneAmountString = this._userInterface.GetExpenseAmountFromTheUser();
            }

            return expenseAmountDouble;
        }

        /// <summary>
        /// Gets expense category
        /// </summary>
        /// <returns>validtaes and return expense category</returns>
        public string GetExpenseCategory()
        {
            string? expesneAmountString = this._userInterface.GetExpenseCategoryFromTheUser();
            while (!this.IsExpenseCategoryUnique(expesneAmountString))
            {
                expesneAmountString = this._userInterface.GetExpenseCategoryFromTheUser();
            }

            return expesneAmountString;
        }

        /// <summary>
        /// gets unique income source from the user
        /// </summary>
        /// <returns>validtaes and return expense category</returns>
        public string GetIncomeSource()
        {
            string? expesneAmountString = this._userInterface.GetIncomeSourceFromTheUser();
            while (!this.IsIncomeSourceUnique(expesneAmountString))
            {
                expesneAmountString = this._userInterface.GetIncomeSourceFromTheUser();
            }

            return expesneAmountString;
        }

        /// <summary>
        /// Gets Income amount from the user
        /// </summary>
        /// <returns>return input as double</returns>
        public double GetIncomeAmount()
        {
            string? incomeAmountString = this._userInterface.GetIncomeAmountFromTheUser();
            double incomeAmountDouble;
            while (!this.IsAmountDouble(incomeAmountString, out incomeAmountDouble))
            {
                incomeAmountString = this._userInterface.GetIncomeAmountFromTheUser();
            }

            return incomeAmountDouble;
        }

        /// <summary>
        /// Edits income
        /// </summary>
        public void EditIncome()
        {
            if (this._incomes.Count > 0)
            {
                string? searchCategory = this._userInterface.GetIncomeSourceFromTheUser();
                IncomeEntity? incomeResult = this.SearchIncomeFromTheList(searchCategory);
                string? option = this._userInterface.GetConfirmation();

                if (option == "Y" || option == "y")
                {
                    double newIncomeToBeEdited = this.GetIncomeAmount();
                    string? incomeCategoryToBeEdited = this._userInterface.GetIncomeSourceFromTheUser();
                    this.EditIncomeWithReferenceObject(incomeResult, newIncomeToBeEdited, incomeCategoryToBeEdited);
                }
                else
                {
                    this._userInterface.DisplayMessageForEmptyIncomeList();
                }
            }
        }

        /// <summary>
        /// Edit expense with refrence
        /// </summary>
        /// <param name="incomeEntity">object</param>
        /// <param name="newIncome">new income </param>
        /// <param name="incomeCategory">new income category</param>
        public void EditIncomeWithReferenceObject(IncomeEntity incomeEntity, double newIncome, string incomeCategory)
        {
            incomeEntity.Amount = newIncome;
            incomeEntity.Source = incomeCategory;
            incomeEntity.UpdatedAt = DateTime.Now;
        }

        /// <summary>
        /// Get choice to view either income or expense
        /// </summary>
        public void ShowRecord()
        {
            string? option = this._userInterface.ChooseTheOption();
            if (option == "1")
            {
                this.ViewIncome();
            }
            else if (option == "2")
            {
                this.ViewExpense();
            }
        }

        /// <summary>
        /// Get the option to select income or expense.
        /// </summary>
        public void EditRecord()
        {
            string? option = this._userInterface.ChooseTheOption();
            if (option == "1")
            {
                this.EditIncome();
            }
            else if (option == "2")
            {
                this.EditExpense();
            }
        }

        /// <summary>
        /// Chooses the option to delete income or expense
        /// </summary>
        public void DeleteRecord()
        {
            string? option = this._userInterface.ChooseTheOption();
            if (option == "1")
            {
                this.DeleteIncome();
            }
            else if (option == "2")
            {
                this.DeleteExpense();
            }
        }
    }
}