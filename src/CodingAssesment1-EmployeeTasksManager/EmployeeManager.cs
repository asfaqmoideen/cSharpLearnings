using System.ComponentModel;

namespace Assignments
{   
    /// <summary>
    /// Manipulates and Manages Employee class
    /// </summary>
    internal class EmployeeManager
    {
        private List<Employee> _employees = new List<Employee>();
        ///// <summary>
        ///// Initializes a new instance of the <see cref="EmployeeManager"/> class.
        ///// </summary>
        //public EmployeeManager()
        //{
        //    _employees = new List<Employee>();
        //}
        private enum Option
        {
            Add = 1,
            View,
            Remove
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
            Console.WriteLine("Enter Employee Name");
            string employeeName = Console.ReadLine();
            Console.WriteLine("Enter Skills of the Employee");
            string employeeSkill = Console.ReadLine();
            string taskAssigned = null ;
            double workingHours = 8; //Constant working hours for all employee
            double availableDays;
            Console.WriteLine("Enter employe availablility in days");
            bool isAvailableDaysDouble = double.TryParse(Console.ReadLine(), out availableDays);

            Employee employee = new Employee(employeeName, workingHours, employeeSkill, taskAssigned, availableDays);

            this._employees.Add(employee);
            Console.WriteLine("Employee Added" + _employees.Count());
        }

        /// <summary>
        /// Removes employee from the list
        /// </summary>
        public void RemoveEmpoyee()
        {
            Console.WriteLine("Enter Employee Name");
            string employeeName = Console.ReadLine();

            Employee searchResult = this.SearchEmployeeFromTheList(employeeName);

            _employees.Remove(searchResult);

            Console.WriteLine("Employee Deleted");
        }

        /// <summary>
        /// Traverse through the list and returns employee reference
        /// </summary>
        /// <param name="employeeName"> Emp</param>
        /// <returns>object of employee</returns>
        public Employee SearchEmployeeFromTheList(string? employeeName)
        {
            if(_employees != null)
            {
                foreach (Employee employee in _employees)
                {
                    if(employee.Name.ToLower() == employeeName.ToLower())
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
            if (_employees.Count() > 0)
            {
                Console.WriteLine("Employess");
                foreach (Employee employee in _employees)
                {
                    Console.WriteLine("Employee Name: " + employee.Name + "Skills: " + employee.Skills + "AssignedTask: " + employee.AssignedTask);
                }
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
