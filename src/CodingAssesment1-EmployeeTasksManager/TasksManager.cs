namespace Assignments
{
    /// <summary>
    ///  manipulates and manages  Class Tasks
    /// </summary>
    internal class TasksManager
    {
        private List<Task> _tasks = new List<Task>();

        /// <summary>
        /// Method to Add tasks
        /// </summary>
        public void AddTask()
        {
            Console.WriteLine("Enter Task Name");
            string taskName = Console.ReadLine();
            Console.WriteLine("Enter Required Hours to Complete");
            string requiredHours = Console.ReadLine();
            Console.WriteLine("Enter Deadline in Days");
            double deadlineInDays = Console.ReadLine();
            Console.WriteLine("Enter Required SKill");
            string requiredSkill = Console.ReadLine();
            str

            Tasks tasks = new Tasks(taskName, requiredHours, deadlineInDays, requiredSkill);
        }

    }
}
