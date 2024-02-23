namespace CodingAssesment1
{
    /// <summary>
    /// Gets input from the user
    /// </summary>
    internal class TaskIOConsole
    {
        /// <summary>
        /// Gets tasks name from the user
        /// </summary>
        /// <returns>task name as string</returns>
        public string GetTaskName()
        {
            string taskName;
            do
            {
                Console.WriteLine("Enter Task Name");
                taskName = Console.ReadLine() !;
            }
            while (taskName.Length == 0);
            return taskName;
        }

        /// <summary>
        /// Gets Tasks Description from the user
        /// </summary>
        /// <returns>Task description as string</returns>
        public string GetTaskDescription()
        {
            string taskDescription;
            do
            {
                Console.WriteLine("Enter Task Description");
                taskDescription = Console.ReadLine() !;
            }
            while (taskDescription.Length == 0);
            return taskDescription;
        }

        /// <summary>
        /// task required skills
        /// </summary>
        /// <returns>required skill as string</returns>
        public string GetTaskRequiredSkills()
        {
            string requiredSkills;
            do
            {
                Console.WriteLine("Enter Tasks Required Skills");
                requiredSkills = Console.ReadLine() !;
            }
            while (requiredSkills.Length == 0);
            return requiredSkills;
        }

        /// <summary>
        /// Get Required to complete the task
        /// </summary>
        /// <returns>Required zhours</returns>
        public double GetTasksRequiredHours()
        {
            double requiredHours;
            bool isrequiredHoursDouble;
            Console.WriteLine("Enter Required Hours to Complete");
            do
            {
                isrequiredHoursDouble = double.TryParse(Console.ReadLine(), out requiredHours);
            }
            while (!isrequiredHoursDouble && requiredHours > 0);
            return requiredHours;
        }

        /// <summary>
        /// Task deadline as date
        /// </summary>
        /// <returns>deadline</returns>
        public DateTime GetTaskDeadline()
        {
            DateTime taskDeadline;
            Console.WriteLine("Enter Deadline date");

            while (DateTime.TryParse(Console.ReadLine() !, out taskDeadline) && taskDeadline > DateTime.Now)
            {
                Console.WriteLine("Invaid Date Input");
            }

            return taskDeadline;
        }

        /// <summary>
        /// Gets add option to add another task from the user
        /// </summary>
        /// <returns>1 if Yes</returns>
        /// <param name="format">format</param>
        public bool IsAddAnother(string format)
        {
            string option = Console.ReadLine() !;
            Console.WriteLine($"Want to add another {format} ?\n 1.Yes\n Press any ket to skip");
            return option == "1";
        }
    }
}
