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
            bool temp, temp1 ;
            double newIncome;
            DateOnly date;

            do
            {
                Console.WriteLine("Enter Income (Type - Double)");
                string tempIncome = Console.ReadLine();
                temp = double.TryParse(tempIncome, out newIncome);
            }
            while (temp != true);
            Console.WriteLine("Enter Category");
            string incomeCategory = Console.ReadLine();
            do
            {
                Console.WriteLine("Enter Date (YYYY-MM-DD");
                string tempDate = Console.ReadLine();
                temp1 = DateOnly.TryParse(tempDate, out date);
            }
            while (temp1 != true);

            Console.WriteLine("Enter notes if any ");
            string notes = Console.ReadLine();

            Console.WriteLine("Income Added");
            FinanceManager incometracker = new FinanceManager
            {
                Amount = newIncome,
                Category = incomeCategory,
                Date = date,
                Notes = notes
            };
            _incomes.Add(incometracker );
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
            }
        }
        /// <summary>
        /// Method inside this calss to show incomes
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
                    Console.WriteLine("No Incomes History");
                    Console.WriteLine("-------------------------------------------------------------------------------------------------");
                    Console.WriteLine("Redirecing to Menu");
                }
            }
        }
        /// <summary>
        /// /sjdksl
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
                Console.WriteLine("No Incomes added yet");
                Console.WriteLine("-------------------------------------------------------------------------------------------------");
                Console.WriteLine("Redirecing to Menu");
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
                            bool temp, temp2;
                            double newIncome;
                            DateOnly date;

                            do
                            {
                                Console.WriteLine("Enter Income (Type - Double)");
                                string tempIncome = Console.ReadLine();
                                temp = double.TryParse(tempIncome, out newIncome);
                            }
                            while (temp != true);
                            Console.WriteLine("Enter Category");
                            string incomeCategory = Console.ReadLine();
                            do
                            {
                                Console.WriteLine("Enter Date (YYYY-MM-DD");
                                string tempDate = Console.ReadLine();
                                temp2 = DateOnly.TryParse(tempDate, out date);
                            }
                            while (temp1 != true);

                            Console.WriteLine("Enter notes if any ");
                            string notes = Console.ReadLine();
                            income.Amount = newIncome;
                            income.Date = date;
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
                Console.WriteLine("No Incomes added yet");
                Console.WriteLine("-------------------------------------------------------------------------------------------------");
                Console.WriteLine("Redirecing to Menu");
            }
        }
        /// <summary>
        /// Method to generate the total income record
        /// </summary>
        /// <returns>the total income</returns>
        public double GenerateIncomerecord()
        {
            double sumofIncome = 0;
            foreach ( var income in this._incomes)
            {
                sumofIncome = income.Amount;
            }
            return sumofIncome;
        }
    }
}