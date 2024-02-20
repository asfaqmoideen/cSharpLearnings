using System.Runtime.CompilerServices;

namespace BoilerControllerConsole
{   
    /// <summary>
    /// Execute the main menu operations
    /// </summary>
    public class MainMenuOperationsManager
    {
        private BoilerController _boilerController = new BoilerController();

        private enum BoilerControllerOperations
        {
            ExitApplication,
            StartBoilerSequence,
            StopBoilerSequence,
            SimulateBoilerErrors,
            ToogleRunInterLockSwitch,
            EventLog,
        }

        /// <summary>
        /// Shows and Executes the MainMenu Operations
        /// </summary>
        /// <returns>True if  user press Exit in the menu</returns>
        public bool ExecuteMainMenu()
        {
            ShowMainMenu();
            int userOption = ConsoleUserInterface.GetOptionFromTheUser();

            BoilerControllerOperations operationToBePerformed = (BoilerControllerOperations)userOption;

            switch (operationToBePerformed)
            {
                case BoilerControllerOperations.StartBoilerSequence:
                    this._boilerController.StartBoilerSequence();
                    break;
                case BoilerControllerOperations.StopBoilerSequence:
                    this._boilerController.StopBoilerSequence();
                    break;
                case BoilerControllerOperations.SimulateBoilerErrors:
                    this._boilerController.SimulateBoilerErrors();
                    break;
                case BoilerControllerOperations.ToogleRunInterLockSwitch:
                    this._boilerController.RunInterLockSwitch();
                    break;
                case BoilerControllerOperations.EventLog:
                    this._boilerController.ShowEventLog();
                    break;
                case BoilerControllerOperations.ExitApplication:
                    return true;
                default:
                    Console.WriteLine("Invalid Option");
                    break;
            }

            return false;
        }

        private static void ShowMainMenu()
        {
            Console.WriteLine("Boiler Controller Console Application");
            Console.WriteLine("1. Start Boiler Sequence");
            Console.WriteLine("2. Stop Boiler Sequence");
            Console.WriteLine("3. Simulate Boiler Errors");
            Console.WriteLine("4. Toogle Run InterLock Switch");
            Console.WriteLine("5. Event Log");
            Console.WriteLine("0. Exit Application");
        }
    }
}