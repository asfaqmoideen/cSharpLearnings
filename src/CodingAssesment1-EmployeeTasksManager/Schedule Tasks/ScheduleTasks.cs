namespace CodingAssesment1
{
    /// <summary>
    /// Schedule the tasks
    /// </summary>
    internal class ScheduleTasks
    {
        private TasksManager _tasksManager;
        private EmployeeManager _employeeManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="ScheduleTasks"/> class.
        /// </summary>
        /// <param name="tasksManager">instance from program class</param>
        /// <param name="employeeManager">instance form program class</param>
        public ScheduleTasks(TasksManager tasksManager, EmployeeManager employeeManager)
        {
            this._tasksManager = tasksManager;
            this._employeeManager = employeeManager;
        }

        /// <summary>
        /// Sorts the list with lowest to highest deadline
        /// </summary>
        /// <returns>Sorted list</returns>
        public List<Tasks> PrioritiseTheTasks()
        {
           var prioritisedList = this._tasksManager.GetTasks().OrderBy(pi => pi.DeadlineInDays).ToList();
           return prioritisedList;
        }

        /// <summary>
        /// Starts Allocating Tasks
        /// </summary>
        public void StartAllocationgTasks()
        {
            foreach (Tasks tasks in this.PrioritiseTheTasks())
            {
                foreach (Employee employee in this._employeeManager.GetEmployees())
                {
                    if (tasks.RequiredSkill == employee.Skills && employee.AvailableDays >= tasks.DeadlineInDays)
                    {
                        this.AssignTheTaskToEmployee(employee, tasks);
                    }
                }
            }
        }

        /// <summary>
        /// Assign the tasks to employee
        /// </summary>
        /// <param name="employee">object employee with matched required skill</param>
        /// <param name="tasks">object task with matched employee skill</param>
        public void AssignTheTaskToEmployee(Employee employee, Tasks tasks)
        {
            if (tasks.RequiredHours > 0)
            {
                employee.AssignedTask = tasks.Name;

                double employeeWillWorkFor = employee.AvailableDays ;

                employee.AvailableDays -= tasks.RequiredHours / employee.WorkingHours;

                tasks.RequiredHours -= employee.WorkingHours * employeeWillWorkFor;

                Console.WriteLine("Task : " + tasks.Name +  "Allocated to: " + employee.Name);
            }
        }

        /// <summary>
        /// To Show the assigned tasks
        /// </summary>
        public void ShowLog()
        {
            foreach (Employee employee in this._employeeManager.GetEmployees())
            {
                if (employee.AssignedTask != null)
                {
                    Console.WriteLine("Tasks Allocated : " + employee.AssignedTask + "To :" + employee.Name);
                }
                else if (employee.AssignedTask == null)
                {
                    Console.WriteLine("No Tasks were allocated to :" + employee.Name);
                }
            }
        }
    }
}
