using BoilerControllerConsoleApplication;

namespace BoilerControllerConsole
{
    /// <summary>
    /// Holds, manages the Boiler Controller Operations
    /// </summary>
    public class BoilerController
    {
        private string _logFilePath = "Boiler Log.txt";
        private Boiler _boiler = new (false, false);
        private TimerController _timerController = new TimerController();

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

            var displayInterLockSwitch = this._boiler.InterLock ? $"Inter Lock Switch toggled to Open" : $"Interlock switch is Closed";

            this.ShowSwitchPositions();

            this.WriteToFile(displayInterLockSwitch);
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
                    while ((readString = reader.ReadLine() !) != null)
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
            if (!this._boiler.InterLock && !this._boiler.LockoutReset)
            {
                throw new InvalidOperationException("Switches are in Open State - Please Close Switches to Start Boiler Sequence");
            }

            Console.WriteLine("You're All set to Start the Boiler  Sequence");

            this.StartPrePurge();

            this.StartIgnition();

            this._boiler.Status = Boiler.SystemStatus.Opeational;

            this.WriteToFile(nameof(Boiler.SystemStatus.Opeational));
        }

        /// <summary>
        /// Stops the boiler sequence
        /// </summary>
        public void StopBoilerSequence()
        {
            if (!(this._boiler.Status == Boiler.SystemStatus.Opeational))
            {
                throw new InvalidOperationException("System status is not in Operational Mode");
            }
        }

        /// <summary>
        /// runs reset lockout swicth
        /// </summary>
        public void RunResetLockout()
        {
            this.ShowSwitchPositions();

            if (ConsoleUserInterface.GetUserConfirmation("To Change Swicth State"))
            {
                this._boiler.LockoutReset = true;
            }

            var displayLockoutResetSwitch = this._boiler.LockoutReset ? $"Lockout Reset Switch toggled to Open" : $"Lockout Reset switch is Closed";

            this.ShowSwitchPositions();

            this.WriteToFile(displayLockoutResetSwitch);
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
            var displayInterLockSwitch = this._boiler.InterLock ? $"Inter Lock Switch is Open" : $"Interlock switch is Closed";
            Console.WriteLine(displayInterLockSwitch);
            var displayLockoutResetSwitch = this._boiler.LockoutReset ? $"Lockout Reset Switch is Open" : $"Lockout Reset switch is Closed";
            Console.WriteLine(displayLockoutResetSwitch);
        }

        private void ToogleInterlock()
        {
            if (!this._boiler.LockoutReset)
            {
                throw new Exception("First Open Reset Lockout Switch");
            }

            this._boiler.InterLock = true;
            this._boiler.Status = Boiler.SystemStatus.Ready;
            this.WriteToFile(nameof(Boiler.SystemStatus.Ready));
        }

        /// <summary>
        /// Writes to the file with time stamp
        /// </summary>
        /// <param name="stringtoPrintInLogFile">data to be written in the File</param>
        private void WriteToFile(string stringtoPrintInLogFile)
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

        private void StartIgnition()
        {
            this._boiler.Status = Boiler.SystemStatus.Ingnition;
            this.WriteToFile("Ignition Started");
            this._timerController.RunTimer();
            this.WriteToFile("Ignition Completed");
        }

        private void StartPrePurge()
        {
            this._boiler.Status = Boiler.SystemStatus.PrePurge;
            this.WriteToFile("Pre-Purge Started");
            this._timerController.RunTimer();
            this.WriteToFile("Pre-Purge Completed");
        }
    }
}