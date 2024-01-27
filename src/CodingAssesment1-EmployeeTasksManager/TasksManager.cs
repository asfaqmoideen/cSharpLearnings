namespace Assignments
{
    /// <summary>
    ///  manipulates and manages  Class Tasks
    /// </summary>
    internal class TasksManager
    {
        private List<Tasks> _tasks;

        /// <summary>
        /// Initializes a new instance of the <see cref="TasksManager"/> class.
        /// </summary>
        public TasksManager()
        {
            this._tasks = new List<Tasks>();
        }

        private enum Option
        {
            Add = 1,
            View,
            Remove,
        }

        /// <summary>
        /// to acces the list outside
        /// </summary>
        /// <returns>the list of tasks</returns>
        public List<Tasks> GetTasks()
        {
            return this._tasks;
        }

        /// <summary>
        /// Method to Add tasks
        /// </summary>
        public void AddTask()
        {
            Console.WriteLine("Enter Task Name");
            string? taskName = Console.ReadLine();
            bool isRequiredHoursDouble, isDeadlineinDaysDouble;
            double requiredHours, deadlineInDays;
            do
            {
                Console.WriteLine("Enter Required Hours to Complete");
                string? requiredHoursString = Console.ReadLine();
                isRequiredHoursDouble = double.TryParse(requiredHoursString, out requiredHours);
            }
            while (!isRequiredHoursDouble);
            do
            {
                Console.WriteLine("Enter Deadline in Days");
                string? deadlineIndaysString = Console.ReadLine();
                isDeadlineinDaysDouble = double.TryParse(deadlineIndaysString, out deadlineInDays);
            }
            while (!isDeadlineinDaysDouble);

            Console.WriteLine("Enter Required SKill");
            string? requiredSkill = Console.ReadLine();
            Console.WriteLine("Enter Description");
            string? description = Console.ReadLine();

            Tasks tasks = new Tasks(taskName, requiredHours, deadlineInDays, requiredSkill, description);

            this._tasks.Add(tasks);
        }

        /// <summary>
        /// Removes employee from the list
        /// </summary>
        public void RemoveTask()
        {
            Console.WriteLine("Enter Task Name");
            string? taskName = Console.ReadLine();

            Tasks searchResult = this.SearchTasksFromTheList(taskName);

            this._tasks.Remove(searchResult);

            Console.WriteLine("Employee Deleted");
        }

        /// <summary>
        /// Traverse through the list and returns employee reference
        /// </summary>
        /// <param name="taskName"> Emp</param>
        /// <returns>object of employee</returns>
        public Tasks? SearchTasksFromTheList(string? taskName)
        {
            if (this._tasks != null)
            {
                foreach (Tasks tasks in _tasks)
                {
                    if (tasks.Name.ToLower() == taskName.ToLower())
                    {
                        return tasks;
                    }
                }
            }

            return null;
        }

        /// <summary>
        /// Shows all the Employees
        /// </summary>
        public void ViewAllTasks()
        {
            if (_tasks != null)
            {
                foreach (Tasks tasks in this._tasks)
                {
                    Console.WriteLine("Name of the Task: " + tasks.Name + "\tRequired Skills: " + tasks.RequiredSkill
                        + "\tDeadline in Days " + tasks.DeadlineInDays
                        + "\t Required Hours to Complete" + tasks.RequiredHours);
                }
            }
        }
        /// <summary>
        /// Executes the task mamanger
        /// </summary>
        public void ExecuteTasksmanager()
        {
            Console.WriteLine("Choose any Operation\n1.AddTask\n2.ViewAllTasks\n3.RemoveTasks");
            bool isOptionInt = int.TryParse(Console.ReadLine(), out int option);

            Option userOption = (Option)option;

            switch (userOption)
            {
                case Option.Add:
                    this.AddTask();
                    break;
                case Option.Remove:
                    this.RemoveTask();
                    break;
                case Option.View:
                    this.ViewAllTasks();
                    break;
                default:
                    Console.WriteLine("Enter Valid Opton");
                    break;
            }
        }
    }
}
