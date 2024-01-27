namespace CodingAssesment1
{
    /// <summary>
    ///  manipulates and manages  Class Tasks
    /// </summary>
    internal class TasksManager
    {
        private List<Tasks> _tasks;
        private TaskIOConsole _taskConsole;

        /// <summary>
        /// Initializes a new instance of the <see cref="TasksManager"/> class.
        /// </summary>
        public TasksManager()
        {
            this._tasks = new List<Tasks>();
            this._taskConsole = new TaskIOConsole();
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
            string taskName = this._taskConsole.GetTaskName();
            string taskDescription = this._taskConsole.GetTaskDescription();
            double requiredHours = this._taskConsole.GetTasksRequiredHours();
            double deadlineInDays = this._taskConsole.GetTasksDeadlineInDays();
            string requiredSkill = this._taskConsole.GetTaskRequiredSkills();
            Tasks tasks = new Tasks(taskName, requiredHours, deadlineInDays, requiredSkill, taskDescription);
            this._tasks.Add(tasks);
            string addAnother = _taskConsole.AddAnotherTaskToTheList();
            if (addAnother == "1") { this.AddTask(); }
        }

        /// <summary>
        /// Removes employee from the list
        /// </summary>
        public void RemoveTask()
        {
            string taskName = this._taskConsole.GetTaskName();
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
