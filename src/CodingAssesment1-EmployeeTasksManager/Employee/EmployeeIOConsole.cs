
namespace CodingAssesment1
{
    /// <summary>
    /// Gets employee name from the user
    /// </summary>
    internal class EmployeeIOConsole
    {
        /// <summary>
        /// Get Employee Name from the user
        /// </summary>
        /// <returns>Employee name</returns>
        public string GetEmployeeName()
        {
            string? employeeName;
            Console.WriteLine("Enter Employee Name");
            while ((employeeName = Console.ReadLine()).Length == 0)
            {
                this.PrintInvalidInputMessage("Employee Name");
            }

            return employeeName;
        }

        /// <summary>
        /// Get employee skills from the user
        /// </summary>
        /// <returns>Skills as string</returns>
        public List <string> GetEmployeeSkills()
        {
            List<string> skillsList = new List<string>();
            string employeeSkills;
            do
            {
                Console.WriteLine("Enter Employee Skills");
                string? employeeSkill;
                while ((employeeSkill = Console.ReadLine()).Length == 0)
                {
                    this.PrintInvalidInputMessage("Skill");
                }

                skillsList.Add(employeeSkill);
            }
            while (this.IsAddAnotherTrue("Skill"));
            return skillsList;
        }

        /// <summary>
        /// Prints invalid input message
        /// </summary>
        /// <param name="format">format of input</param>
        public void PrintInvalidInputMessage(string format)
        {
            Console.WriteLine($"Invalid {format} Input");
        }

        /// <summary>
        /// Get Available Days from the User
        /// </summary>
        /// <returns>availabel days as double</returns>
        public double GetEmployeeAvailableHours()
        {
            double availableDays;
            Console.WriteLine("Enter employe availablility in days");
            while (!double.TryParse(Console.ReadLine(), out availableDays) && availableDays > 0)
            {
                this.PrintInvalidInputMessage("EmployeeAvailableHours");
            }
            return availableDays;
        }

        /// <summary>
        /// Get the option to add another employee
        /// </summary>
        /// <param name="format">parameter as string</param>
        /// <returns>true if yes </returns>
        public bool IsAddAnotherTrue(string format)
        {
            Console.WriteLine($"Need to add Another {format}\n1.Yes\nPress any key to skip");
            string? option = Console.ReadLine();
            return true ? option == "1" : false;
        }
    }
}
