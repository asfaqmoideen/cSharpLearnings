namespace BoilerControllerConsoleApplication
{
    /// <summary>
    /// Holds, Constrols the Timer Operations
    /// </summary>
    public class BoilerService
    {
        private int _invokeCount = 0;
        private int _maxCount = 10;
        private Boiler _boiler;

        /// <summary>
        /// Initializes a new instance of the <see cref="BoilerService"/> class.
        /// </summary>
        /// <param name="boiler">Boiler</param>
        public BoilerService(Boiler boiler)
        {
            this._boiler = boiler;
        }

        /// <summary>
        /// Starts the run timer
        /// </summary>
        public void RunTimer()
        {
            var autoEvent = new AutoResetEvent(false);

            Console.WriteLine($"{DateTime.Now} Starting{this._boiler.Status}.\n");

            var stateTimer = new Timer(TimerStatus, autoEvent, 1000, 250);

            autoEvent.WaitOne();
            stateTimer.Dispose();
        }

        private void TimerStatus(object stateInfo)
        {
            AutoResetEvent autoEvent = (AutoResetEvent)stateInfo;
            Console.WriteLine($"{DateTime.Now}, {this._boiler.Status}, {(++this._invokeCount).ToString()}");

            if (this._invokeCount == this._maxCount)
            {
                this._invokeCount = 0;
                autoEvent.Set();
            }
        }
    }
}
