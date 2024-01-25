using Assignments;

namespace Assignemnts
{
    /// <summary>
    /// Schedule the tasks
    /// </summary>
    internal class ScheduleTasks
    {
        private TasksManager _tasksManager = new TasksManager();
        private EmployeeManager _employeeManager = new EmployeeManager();

        /// <summary>
        /// Starts Allocating Tasks
        /// </summary>
        public void StartAllocationgTasks()
        {
            IEnumerable<Tasks> taskslist;
            IEnumerable<Employee> employeelist;

            taskslist = _tasksManager.GetTasks();
            employeelist = _employeeManager.GetEmployees();

            foreach (Tasks tasks in taskslist)
            {
                foreach (Employee employee in employeelist)
                {
                    if (tasks.RequiredSkill == employee.Skills)
                    {
                        AssignTheTaskToEmployee(employee, tasks);
                    }
                }
            }
        }

        /// <summary>
        /// Assign the tasks to employee
        /// </summary>
        /// <param name="employee">object employee</param>
        /// <param name="tasks">object tasks</param>
        public void AssignTheTaskToEmployee(Employee employee, Tasks tasks)
        {
            if (tasks.RequiredHours > 0)
            {
                employee.Skills = tasks.RequiredSkill;
                tasks.RequiredHours -= employee.WorkingHours * tasks.DeadlineInDays;
                Console.WriteLine("Task Allocated to " + employee.Name + "for" + tasks.DeadlineInDays);
            }
            else
            {
                Console.WriteLine("Task Allocated");
            }
        }

        /// <summary>
        /// show the assigned tasks
        /// </summary>
        public void ShowLog()
        { 
            foreach (Employee employee in _employeeManager.GetEmployees())
            {
                if(employee.AssignedTask != null)
                {
                    Console.WriteLine("Tasks Allocated : " + employee.AssignedTask + "To :" + employee.Name);
                }
            }
        }
    }
}
