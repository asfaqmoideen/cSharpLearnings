namespace CodingAssesment1
{
    /// <summary>
    /// Initiates the Program
    /// </summary>
    internal class Program
    {
        private enum Option
        {
            EmployeeManager = 1,
            TasksManager,
            Schedule,
            ShowLogs,
        }

        private static void Main()
        {
            TasksManager tasksManager = new TasksManager();
            EmployeeManager employeeManager = new EmployeeManager();
            ScheduleTasks scheduleTasks = new ScheduleTasks(tasksManager, employeeManager);

            while (true)
            {
                Console.WriteLine("Welcome to Employee Tasks Manager");

                Console.WriteLine("Choose any option to proceed\n1.Manage Employee\n2.ManageTasks\n3.Run Schedule Task\n4.Show Log");
                bool isOptionInt = int.TryParse(Console.ReadLine(), out int option);
                Option userOption = (Option)option;

                switch (userOption)
                {
                    case Option.EmployeeManager:
                        employeeManager.ExecuteEmployeemanager();
                        break;
                    case Option.TasksManager:
                        tasksManager.ExecuteTasksmanager();
                        break;
                    case Option.Schedule:
                        scheduleTasks.StartAllocationgTasks();
                        break;
                    case Option.ShowLogs:
                        scheduleTasks.ShowLog();
                        break;
                    default:
                        break;
                }
            }
        }
    }
}