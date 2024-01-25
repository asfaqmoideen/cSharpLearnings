using System.ComponentModel;

namespace Assignments
{   /// <summary>
    /// Manipulates and Manages Employee class
    /// </summary>
    internal class EmployeeManager
    {
        private List<Employee> _employees = new List<Employee>();

        /// <summary>
        /// Method to add an employee to the llist
        /// </summary>
        public void AddEmpoyee()
        {
            Console.WriteLine("Enter Employee Name");
            string employeeName = Console.ReadLine();
            Console.WriteLine("Enter Skills of the Employee");
            string employeeSkill = Console.ReadLine();
            string taskAssigned = null;
            double workingHours = 8; //Constant working hours for all employee

            Employee employee = new Employee(employeeName, workingHours, employeeSkill, taskAssigned);

            _employees.Add(employee);
            Console.WriteLine("Employee Added");
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
            if(_employees != null)
            {
                foreach(Employee employee in _employees)
                {
                    Console.WriteLine("Employee Name: " + employee.Name + "Skills: " + employee.Skills + "AssignedTask: " + employee.AssignedTask);
                }
            }
        }
    }
}
