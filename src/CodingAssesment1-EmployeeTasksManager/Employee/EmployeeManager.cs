using ConsoleTables;
namespace CodingAssesment1
{
    /// <summary>
    /// Manipulates and Manages Employee class
    /// </summary>
    internal class EmployeeManager
    {
        private List<Employee> _employees;
        private EmployeeIOConsole _console;

        /// <summary>
        /// Initializes a new instance of the <see cref="EmployeeManager"/> class.
        /// </summary>
        public EmployeeManager()
        {
            _employees = new List<Employee>();
            _console = new EmployeeIOConsole();
        }

        private enum Option
        {
            Add = 1,
            View,
            Remove,
        }

        /// <summary>
        /// To acces the employee list outside
        /// </summary>
        /// <returns>d</returns>
        public List<Employee> GetEmployees()
        {
            return _employees;
        }

        /// <summary>
        /// Method to add an employee to the llist
        /// </summary>
        public void AddEmpoyee()
        {
            string employeeName = _console.GetEmployeeName();
            List <string> employeeSkill = _console.GetEmployeeSkills();
            double availableDays = _console.GetEmployeeAvailableHours();
            string taskAssigned = null;
            double workingHours = 8; //Constant working hours for all employees
            Employee employee = new Employee(employeeName, workingHours, employeeSkill, taskAssigned, availableDays);
            this._employees.Add(employee);
            Console.WriteLine("Totally, " + this._employees.Count() + "Employees Were Added");
            string option = _console.GetOptionToAddAnother("Employee");
            if (option == "1") { AddEmpoyee(); }
        }

        /// <summary>
        /// Removes employee from the list
        /// </summary>
        public void RemoveEmpoyee()
        {
            string employeeName = this._console.GetEmployeeName();
            Employee searchResult = this.SearchEmployeeFromTheList(employeeName);
            this._employees.Remove(searchResult);
            Console.WriteLine("Employee Deleted");
        }

        /// <summary>
        /// Traverse through the list and returns employee reference
        /// </summary>
        /// <param name="employeeName"> Emp</param>
        /// <returns>object of employee</returns>
        public Employee SearchEmployeeFromTheList(string? employeeName)
        {
            if (this._employees != null)
            {
                foreach (Employee employee in this._employees)
                {
                    if (employee.Name.ToLower() == employeeName.ToLower())
                    {
                        return employee;
                    }
                }
            }

            return null;
        }

        /// <summary>
        /// Shows all the Employees
        /// </summary>
        public void ViewAllEmployees()
        {
            Console.WriteLine(_employees.Count());
            if (this._employees.Count() > 0)
            {
                var employeeTable = new ConsoleTable("Employee Name: ", "Skills: ", "AssignedTask: ", "Availability");
                foreach (Employee employee in this._employees)
                {
                    string skillSet = String.Join(",", employee.Skills);
                    employeeTable.AddRow(employee.Name, skillSet, employee.AssignedTask, employee.AvailableDays);
                }
                employeeTable.Write();
            }
            else
            {
                Console.WriteLine("No elmployees were added");
            }
        }

        /// <summary>
        /// Executed the opertaion in employee manager
        /// </summary>
        /// <param name="option">option from the user</param>
        public void ExecuteEmployeemanager()
        {
            Console.WriteLine("Choose any Operation\n1.AddEmployee\n2.ViewAllEmployee\n3.RemoveEmployee");
            bool isOptionInt = int.TryParse(Console.ReadLine(), out int option);

            Option userOption = (Option)option;

            switch (userOption)
            {
                case Option.Add:
                    this.AddEmpoyee();
                    break;
                case Option.Remove:
                    this.RemoveEmpoyee();
                    break;
                case Option.View:
                    this.ViewAllEmployees();
                    break;
                default:
                    Console.WriteLine("Enter Valid Opton");
                    break;
            }
        }
    }
}
