namespace BoilerControllerConsoleApplication
{
    /// <summary>
    /// Holds the property of boiler switches
    /// </summary>
    public class BoilerSwitches
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BoilerSwitches"/> class.
        /// </summary>
        /// <param name="interLock">Interlock switch of the boiler</param>
        /// <param name="lockoutReset">LockoutSwitch If it faces any failiure</param>
        public BoilerSwitches(bool interLock, bool lockoutReset)
        {
            this.InterLock = interLock;
            this.LockoutReset = lockoutReset;
        }

        /// <summary>
        /// Gets or sets a value indicating whether gets or sets InterLock Switch
        /// </summary>
        /// <value>
        /// Default open(false) and true if closed
        /// </value>
        public bool InterLock { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or sets LockoutReset value
        /// </summary>
        /// <value>
        /// opens when the system caught with failiure
        /// </value>
        public bool LockoutReset { get; set; }
    }
}
