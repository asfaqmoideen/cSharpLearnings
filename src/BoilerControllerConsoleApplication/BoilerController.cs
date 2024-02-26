using BoilerControllerConsoleApplication;

namespace BoilerControllerConsole
{
    /// <summary>
    /// Holds, manages the Boiler Controller Operations
    /// </summary>
    public class BoilerController
    {
        private Boiler _boiler;
        private BoilerService _timerController;
        private LogFileService _logFileService;

        /// <summary>
        /// Initializes a new instance of the <see cref="BoilerController"/> class.
        /// </summary>
        public BoilerController()
        {
            this._boiler = new (false, false);
            this._timerController = new BoilerService(this._boiler);
            this._logFileService = new LogFileService();
        }

        /// <summary>
        /// Handles the interlock switch
        /// </summary>
        public void RunInterLockSwitch()
        {
            this.DisplaySwitchPositions();

            if (ConsoleUserInterface.GetUserConfirmation("To Change Swicth State"))
            {
                this.ToogleInterlock();
            }

            var displayInterLockSwitch = this._boiler.InterLock ? $"Inter Lock Switch toggled to Open" : $"Interlock switch is Closed";

            this.DisplaySwitchPositions();

            this._logFileService.WriteToFile(displayInterLockSwitch);
        }

        /// <summary>
        /// Toogle the Interlock Switch
        /// </summary>
        /// <exception cref="Exception">If the Reset swicth is Close</exception>
        public void ToogleInterlock()
        {
            if (!this._boiler.LockoutReset)
            {
                throw new Exception("First Open Reset Lockout Switch");
            }

            this._boiler.InterLock = true;
            this._boiler.Status = Boiler.SystemStatus.Ready;
            this._logFileService.WriteToFile(nameof(Boiler.SystemStatus.Ready));
        }

        /// <summary>
        /// runs reset lockout swicth
        /// </summary>
        public void LockoutReset()
        {
            this.DisplaySwitchPositions();

            if (ConsoleUserInterface.GetUserConfirmation("To Change Swicth State"))
            {
                this._boiler.LockoutReset = true;
            }

            var displayLockoutResetSwitch = this._boiler.LockoutReset ? $"Lockout Reset Switch toggled to Open" : $"Lockout Reset switch is Closed";

            this.DisplaySwitchPositions();

            this._logFileService.WriteToFile(displayLockoutResetSwitch);
        }

        /// <summary>
        /// Displays the Switch Positions
        /// </summary>
        public void DisplaySwitchPositions()
        {
            var displayInterLockSwitch = this._boiler.InterLock ? $"Inter Lock Switch is Open" : $"Interlock switch is Closed";
            Console.WriteLine(displayInterLockSwitch);
            var displayLockoutResetSwitch = this._boiler.LockoutReset ? $"Lockout Reset Switch is Open" : $"Lockout Reset switch is Closed";
            Console.WriteLine(displayLockoutResetSwitch);
        }

        /// <summary>
        /// Shows the Event Log to the User
        /// </summary>
        public void ShowEventLog()
        {
            this._logFileService.ReadFromFile();
        }

        /// <summary>
        /// Starts the boiler sequence
        /// </summary>
        public void StartBoilerSequence()
        {
            if (this._boiler.Status != Boiler.SystemStatus.Ready)
            {
                throw new InvalidOperationException("Boiler not Ready - Please Close Switches to Start Boiler Sequence");
            }

            Console.WriteLine("You're All set to Start the Boiler  Sequence");

            this.StartPrePurge();

            this.StartIgnition();

            this._boiler.Status = Boiler.SystemStatus.Opeational;

            this._logFileService.WriteToFile(nameof(Boiler.SystemStatus.Opeational));
        }

        /// <summary>
        /// Starts the Ignition Procces
        /// </summary>
        public void StartIgnition()
        {
            this._boiler.Status = Boiler.SystemStatus.Ingnition;
            this._logFileService.WriteToFile("Ignition Started");
            this._timerController.RunTimer();
            this._logFileService.WriteToFile("Ignition Completed");
        }

        /// <summary>
        /// Starts the pre-purge
        /// </summary>
        public void StartPrePurge()
        {
            this._boiler.Status = Boiler.SystemStatus.PrePurge;
            this._logFileService.WriteToFile("Pre-Purge Started");
            this._timerController.RunTimer();
            this._logFileService.WriteToFile("Pre-Purge Completed");
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

            this.ResetBoiler();
        }

        /// <summary>
        /// Simluate the Errors on the boiler
        /// </summary>
        public void SimulateBoilerErrors()
        {
            if (!(this._boiler.Status == Boiler.SystemStatus.Opeational))
            {
                throw new InvalidOperationException("System status is not in Operational Mode");
            }

            this.ResetBoiler();
        }

        /// <summary>
        /// Resest the Boiler
        /// </summary>
        public void ResetBoiler()
        {
            this._boiler.Status = Boiler.SystemStatus.Lockout;
            this._logFileService.WriteToFile(nameof(Boiler.SystemStatus.Lockout));
            this._boiler.LockoutReset = false;
            this._boiler.InterLock = false;
        }
    }
}