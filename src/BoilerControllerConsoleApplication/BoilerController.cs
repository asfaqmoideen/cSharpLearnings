using BoilerControllerConsoleApplication;

namespace BoilerControllerConsole
{
    /// <summary>
    /// Holds, manages the Boiler Controller Operations
    /// </summary>
    public class BoilerController
    {
        private string _systemStatus = " ";
        private string _logFilePath = "Boiler Log.txt";
        private BoilerSwitches _switches = new(false, false);

        /// <summary>
        /// Handles the interlock switch
        /// </summary>
        public void RunInterLockSwitch()
        {
            this.ShowSwitchPositions();

            if (ConsoleUserInterface.GetUserConfirmation("To Change Swicth State"))
            {
                this.ToogleInterlock();
            }

            var displayInterLockSwitch = this._switches.InterLock ? $"Inter Lock Switch toggled to Open" : $"Interlock switch is Closed";

            this.ShowSwitchPositions();

            this.WriteTOLogFile(displayInterLockSwitch);
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
        /// Starts the boiler sequence
        /// </summary>
        public void StartBoilerSequence()
        {
            if (!this._switches.InterLock && !this._switches.LockoutReset)
            {
                throw new InvalidOperationException("Switches are in Open State - Please Close Switches to Start Boiler Sequence");
            }

            Console.WriteLine("You're All set to Start the Boiler  Sequence");
            TimerController timerControllerPrepurge = new("Pre-Purge");
            this.WriteTOLogFile("Pre-Purge Started");
            timerControllerPrepurge.RunTimer();
            this.WriteTOLogFile("Pre-Purge Completed");

            TimerController timerControllerIgnition = new("Ignition");
            this.WriteTOLogFile("Ignition Started");
            timerControllerIgnition.RunTimer();
            this.WriteTOLogFile("Ignition Completed");

            this._systemStatus = "Operational";
            this.WriteTOLogFile(this._systemStatus);
        }

        /// <summary>
        /// Stops the boiler sequence
        /// </summary>
        public void StopBoilerSequence()
        {
            if (!_systemStatus.Equals("Operational"))
            {
                throw new InvalidOperationException("System status is not in Operational Mode");
            }

            this._systemStatus = "Stopped";
            this.WriteTOLogFile(this._systemStatus);
            this._switches = new (false, false);
        }

        /// <summary>
        /// runs reset lockout swicth
        /// </summary>
        public void RunResetLockout()
        {
            this.ShowSwitchPositions();

            if (ConsoleUserInterface.GetUserConfirmation("To Change Swicth State"))
            {
                this._switches.LockoutReset = true;
            }

            var displayLockoutResetSwitch = this._switches.LockoutReset ? $"Lockout Reset Switch toggled to Open" : $"Lockout Reset switch is Closed";

            this.ShowSwitchPositions();

            this.WriteTOLogFile(displayLockoutResetSwitch);
        }

        /// <summary>
        /// Simluate the Errors on the boiler
        /// </summary>
        public void SimulateBoilerErrors()
        {
            this.StopBoilerSequence();
        }

        private void ShowSwitchPositions()
        {
            var displayInterLockSwitch = this._switches.InterLock ? $"Inter Lock Switch is Open" : $"Interlock switch is Closed";
            Console.WriteLine(displayInterLockSwitch);
            var displayLockoutResetSwitch = this._switches.LockoutReset ? $"Lockout Reset Switch is Open" : $"Lockout Reset switch is Closed";
            Console.WriteLine(displayLockoutResetSwitch);
        }

        private void ToogleInterlock()
        {
            if (!this._switches.LockoutReset)
            {
                throw new Exception("First Open Reset Lockout Switch");
            }

            this._switches.InterLock = true;
            this._systemStatus = "Ready";
            this.WriteTOLogFile(this._systemStatus);
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