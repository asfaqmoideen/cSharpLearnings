using BoilerControllerConsoleApplication;

namespace BoilerControllerConsole
{
    /// <summary>
    /// Holds, manages the Boiler Controller Operations
    /// </summary>
    public class BoilerController
    {
        private string _logFilePath = "Boiler Log.txt";
        private BoilerSwitches? _switches = new (false, false);

        /// <summary>
        /// Handles the interlock switch
        /// </summary>
        public void RunInterLockSwitch()
        {
            this.ShowSwitchPositions();

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

            var displayInterLockSwitch = this._switches.InterLock ? $"Inter Lock Switch toggled to Open" : $"Interlock switch is Closed";
            var displayLockoutResetSwitch = this._switches.LockoutReset ? $"Lockout Reset Switch toggled to Open" : $"Lockout Reset switch is Closed";

            this.ShowSwitchPositions();

            if (!File.Exists(this._logFilePath))
            {
                using (StreamWriter writer = File.CreateText(this._logFilePath))
                {
                    writer.WriteLine(displayInterLockSwitch);
                    writer.Write(DateTime.Now);
                    writer.WriteLine(displayLockoutResetSwitch);
                    writer.Write(DateTime.Now);
                }
            }
        }

        private void ShowSwitchPositions()
        {
            var displayInterLockSwitch = this._switches.InterLock ? $"Inter Lock Switch is Open" : $"Interlock switch is Closed";
            Console.WriteLine(displayInterLockSwitch);
            var displayLockoutResetSwitch = this._switches.LockoutReset ? $"Lockout Reset Switch is Open" : $"Lockout Reset switch is Closed";
            Console.WriteLine(displayLockoutResetSwitch);
        }

        /// <summary>
        /// Shows the Event Log to the User
        /// </summary>
        public void ShowEventLog()
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        /// <summary>
        /// Stops the boiler sequence
        /// </summary>
        public void StopBoilerSequence()
        {
            throw new NotImplementedException();
        }
    }
}