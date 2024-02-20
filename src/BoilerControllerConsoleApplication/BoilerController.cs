using BoilerControllerConsoleApplication;

namespace BoilerControllerConsole
{
    /// <summary>
    /// Holds, manages the Boiler Controller Operations
    /// </summary>
    public class BoilerController
    {
        private string _logFilePath = "Boiler Log.txt";
        private BoilerSwitches _switches = new (false, false);

        /// <summary>
        /// Handles the interlock switch
        /// </summary>
        public void RunInterLockSwitch()
        {
            this.ShowSwitchPositions();

            if (ConsoleUserInterface.GetUserConfirmation("To Change Swicth State"))
            {
                this.ToogleSwitchState();
            }

            var displayInterLockSwitch = this._switches.InterLock ? $"Inter Lock Switch toggled to Open" : $"Interlock switch is Closed";
            var displayLockoutResetSwitch = this._switches.LockoutReset ? $"Lockout Reset Switch toggled to Open" : $"Lockout Reset switch is Closed";

            this.ShowSwitchPositions();

            this.WriteTOLogFile(displayInterLockSwitch);
            this.WriteTOLogFile(displayLockoutResetSwitch);
        }

        /// <summary>
        /// Shows the Event Log to the User
        /// </summary>
        public void ShowEventLog()
        {
            if (File.Exists(this._logFilePath))
            {
                using (StreamReader reader = File.OpenText(this._logFilePath))
                {
                    string readString;
                    while ((readString = reader.ReadLine()) != null)
                    {
                        Console.WriteLine(readString);
                    }
                }
            }
            else
            {
                throw new FileNotFoundException("Log File Not Found");
            }
        }

        /// <summary>
        /// Simluate the Errors on the boiler
        /// </summary>
        public void SimulateBoilerErrors()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Starts the boiler sequence
        /// </summary>
        public void StartBoilerSequence()
        {
            if (!this._switches.InterLock && !this._switches.LockoutReset)
            {
                throw new InvalidOperationException("Switches are in Open State - Please Close Switches to Start Boiler Sequence");
            }

            Console.WriteLine("You're All set to Start the Boiler  Sequence");
            TimerController timerController = new ("Pre-Purge");
            this.WriteTOLogFile("Pre-Purge Started");
            timerController.RunTimer();
            this.WriteTOLogFile("Pre-Purge Completed");
        }

        /// <summary>
        /// Stops the boiler sequence
        /// </summary>
        public void StopBoilerSequence()
        {
            throw new NotImplementedException();
        }

        private void ShowSwitchPositions()
        {
            var displayInterLockSwitch = this._switches.InterLock ? $"Inter Lock Switch is Open" : $"Interlock switch is Closed";
            Console.WriteLine(displayInterLockSwitch);
            var displayLockoutResetSwitch = this._switches.LockoutReset ? $"Lockout Reset Switch is Open" : $"Lockout Reset switch is Closed";
            Console.WriteLine(displayLockoutResetSwitch);
        }

        private void ToogleSwitchState()
        {
            Console.WriteLine("Toogle Switches\nPress 1 to Close,0 to Open");
            Console.WriteLine("Interlock Swicth");
            int interlockSwitchPosition = ConsoleUserInterface.GetOptionFromTheUser();
            Console.WriteLine("Lockout Reset Switch");
            int lockoutSwicthPosition = ConsoleUserInterface.GetOptionFromTheUser();
            if (interlockSwitchPosition == 1 && lockoutSwicthPosition == 1)
            {
                this._switches = new (true, true);
            }
            else if (interlockSwitchPosition == 0 && lockoutSwicthPosition == 0)
            {
                this._switches = new (false, false);
            }
        }

        /// <summary>
        /// Writes to the file with time stamp
        /// </summary>
        /// <param name="stringtoPrintInLogFile">data to be written in the File</param>
        private void WriteTOLogFile(string stringtoPrintInLogFile)
        {
            if (!File.Exists(this._logFilePath))
            {
                using (StreamWriter writer = File.CreateText(this._logFilePath))
                {
                    writer.Write(stringtoPrintInLogFile);
                    writer.Write("," + DateTime.Now);
                }
            }
        }
    }
}