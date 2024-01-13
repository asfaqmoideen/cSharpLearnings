namespace Assignments
{
    /// <summary>
    /// Class to have methods and a list of Incomes
    /// </summary>
    public class IncomeTracker
    {
        private List<FinanceManager> _incomes = new List<FinanceManager>();

        /// <summary>
        /// funtion to add incomes as a list of objects
        /// </summary>
        public void AddIncome()
        {
            double newIncome = this.GetIncome();
            DateOnly incomeDate = this.GetIncomeDate();
            string incomeCategory = this.GetIncomeCategory();
            string incomeNotes = this.GetIncomeNotes();

            FinanceManager incometracker = new FinanceManager
            {
                Amount = newIncome,
                Category = incomeCategory,
                Date = incomeDate,
                Notes = incomeNotes
            };

            this._incomes.Add(incometracker );
            Console.WriteLine("[A]dd another Income or [M]enu");
            string option = Console.ReadLine();
            if (option == "A" || option == "a")
            {
                this.AddIncome();
            }
            else
            {
                Console.WriteLine("-------------------------------------------------------------------------------------------------");
                Console.WriteLine("Redirecing to Menu");
            }
        }

        /// <summary>
        /// Funtion to show incomes
        /// </summary>
        public void ViewIncome()
        {
            Console.WriteLine("Income");
            {
                if (_incomes.Count > 0)
                {
                    Console.WriteLine("-------------------------------------------------------------------------------------------------");
                    Console.WriteLine("History of Incomes");
                    Console.WriteLine("-------------------------------------------------------------------------------------------------");
                    foreach (var incomes in _incomes)
                    {
                        Console.WriteLine(incomes.Amount+ "\t" + incomes.Category + "\t" + incomes.Date + "\t" + incomes.Notes);
                    }
                    Console.WriteLine("-------------------------------------------------------------------------------------------------");
                }  
                else
                {
                    this.NoIncomesYet();
                }
            }
        }

        /// <summary>
        /// Function to delete a Income
        /// </summary>
        public void DeleteIncome()
        {
            if (this._incomes.Count > 0)
            {
                bool temp1; 
                DateOnly searchDate;
                Console.WriteLine("Delete your past Income");
                Console.WriteLine("Enter Income Category");
                string searchCategory = Console.ReadLine();
                do
                {
                    Console.WriteLine("Enter Date (YYYY-MM-DD");
                    string tempDate = Console.ReadLine();
                    temp1 = DateOnly.TryParse(tempDate, out searchDate);
                }
                while (temp1 != true);

                foreach (var income in this._incomes)
                    {
                        if (income.Category == searchCategory || income.Date == searchDate)
                        {
                            Console.WriteLine("You Might Want to delete");
                            Console.WriteLine("Amount :" + income.Amount + "\n" + "Category :" + income.Category +
                                "\n" + "Date " + income.Date + "\n" + "Notes: " + income.Notes + "\t");
                            Console.WriteLine("Confirm Deletion of Income - [Y]es - [C]ancel");
                            string option = Console.ReadLine();

                            if (option == "Y" || option == "y")
                            {
                                this._incomes.Remove(income);
                                Console.WriteLine("Income Deleted :(");
                                Console.WriteLine("-------------------------------------------------------------------------------------------------");
                                break;
                        }
                    }
                }
            }
            else
            {
                this.NoIncomesYet();
            }
        }

        /// <summary>
        /// eijw
        /// </summary>
        public void EditIncome()
        {
            if (this._incomes.Count > 0)
            {
                bool temp1;
                DateOnly searchDate;
                Console.WriteLine("Edit your past Income");
                Console.WriteLine("Enter Income Category");
                string searchCategory = Console.ReadLine();
                do
                {
                    Console.WriteLine("Enter Date (YYYY-MM-DD");
                    string tempDate = Console.ReadLine();
                    temp1 = DateOnly.TryParse(tempDate, out searchDate);
                }
                while (temp1 != true);
                foreach (var income in this._incomes)
                {
                    if (income.Category == searchCategory || income.Date == searchDate)
                    {
                        Console.WriteLine("You Might Want to Edit");
                        Console.WriteLine("Amount :" + income.Amount + "\n" + "Category :" + income.Category +
                            "\n" + "Date " + income.Date + "\n" + "Notes: " + income.Notes + "\t");
                        Console.WriteLine("Confirm Editing of Income - [Y]es - [C]ancel");
                        string option = Console.ReadLine();

                        if (option == "Y" || option == "y")
                        {
                            double newIncome = this.GetIncome();
                            DateOnly incomeDate = this.GetIncomeDate();
                            string incomeCategory = this.GetIncomeCategory();
                            string incomeNotes = this.GetIncomeNotes();

                            string notes = Console.ReadLine();
                            income.Amount = newIncome;
                            income.Date = incomeDate;
                            income.Category = incomeCategory;
                            income.Notes = notes;

                            Console.WriteLine("Income Edited :(");
                            Console.WriteLine("-------------------------------------------------------------------------------------------------");
                            break;
                        }
                    }
                }
            }
            else
            {
                this.NoIncomesYet();
            }
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
        /// dkfsj
        /// </summary>
        public void NoIncomesYet()
        {
            Console.WriteLine("No Incomes added yet");
            Console.WriteLine("-------------------------------------------------------------------------------------------------");
            Console.WriteLine("Redirecing to Menu");
        }

        private double GetIncome()
        {
            double newIncome;
            bool isIncomeDouble;
            do
            {
                Console.WriteLine("Enter Income (Type - Double)");
                string tempIncome = Console.ReadLine();
                isIncomeDouble = double.TryParse(tempIncome, out newIncome);
            }
            while (isIncomeDouble != true);
            return newIncome;
        }

        private string GetIncomeCategory()
        {
            Console.WriteLine("Enter Category");
            string incomeCategory = Console.ReadLine();
            return (incomeCategory != null) ? incomeCategory : "-";
        }

        private string GetIncomeNotes()
        {
            Console.WriteLine("Enter Income Notes");
            string incomeNotes = Console.ReadLine();
            return incomeNotes != null ? incomeNotes : "-";
        }

        private DateOnly GetIncomeDate()
        {
            DateOnly incomedate;
            bool isIncomedateDateonly;
            do
            {
                Console.WriteLine("Enter Date (YYYY-MM-DD");
                string tempDate = Console.ReadLine();
                isIncomedateDateonly = DateOnly.TryParse(tempDate, out incomedate);
            }
            while (isIncomedateDateonly != true);
            return incomedate;
        }
    }
}