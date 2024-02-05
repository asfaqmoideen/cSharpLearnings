using ConsoleTables;

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

        private enum TaskOperations
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
            bool isAddAnothertask = false;
            while (isAddAnothertask)
            {
                string taskName = this._taskConsole.GetTaskName();
                string taskDescription = this._taskConsole.GetTaskDescription();
                double requiredHours = this._taskConsole.GetTasksRequiredHours();
                DateTime taskDeadline = this._taskConsole.GetTaskDeadline();
                string requiredSkill = this._taskConsole.GetTaskRequiredSkills();
                Tasks tasks = new Tasks(taskName, requiredHours, taskDeadline, requiredSkill, taskDescription);
                this._tasks.Add(tasks);
                isAddAnothertask = this._taskConsole.IsAddAnother("Task");
            }
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
        public Tasks SearchTasksFromTheList(string taskName)
        {
            if (this._tasks != null)
            {
                foreach (Tasks tasks in this._tasks)
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
            if (this._tasks != null)
            {
                var tasksTable = new ConsoleTable("Task Name", "Required Skills", "Deadline in Days ", "Required Hours to Complete");
                foreach (Tasks tasks in this._tasks)
                {
                    tasksTable.AddRow(tasks.Name, tasks.RequiredSkill, tasks.DeadlineInDays, tasks.RequiredHours);
                }

                tasksTable.Write(Format.MarkDown);
            }
        }

        /// <summary>
        /// Executes the task mamanger
        /// </summary>
        public void ExecuteTasksmanager()
        {
            Console.WriteLine("Choose any Operation\n1.AddTask\n2.ViewAllTasks\n3.RemoveTasks");
            bool isOptionInt = int.TryParse(Console.ReadLine(), out int option);

            TaskOperations userOption = (TaskOperations)option;

            switch (userOption)
            {
                case TaskOperations.Add:
                    this.AddTask();
                    break;
                case TaskOperations.Remove:
                    this.RemoveTask();
                    break;
                case TaskOperations.View:
                    this.ViewAllTasks();
                    break;
                default:
                    Console.WriteLine("Enter Valid Opton");
                    break;
            }
        }
    }
}
