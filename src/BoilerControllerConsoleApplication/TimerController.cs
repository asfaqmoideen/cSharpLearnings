namespace BoilerControllerConsoleApplication
{
    /// <summary>
    /// Holds, Constrols the Timer Operations
    /// </summary>
    public class TimerController
    {
        private int _invokeCount = 0;
        private int _maxCount = 10;

        /// <summary>
        /// Starts the run timer
        /// </summary>
        public void RunTimer()
        {
            var autoEvent = new AutoResetEvent(false);

            Console.WriteLine($"{DateTime.Now} Starting{nameof(Boiler.SystemStatus)}.\n");

            var stateTimer = new Timer(TimerStatus, autoEvent, 1000, 250);

            autoEvent.WaitOne();
            stateTimer.Dispose();
        }

        private void TimerStatus(object stateInfo)
        {
            AutoResetEvent autoEvent = (AutoResetEvent)stateInfo;
            Console.WriteLine($"{DateTime.Now}, {nameof(Boiler.SystemStatus)}, {(++this._invokeCount).ToString()}");

            if (this._invokeCount == this._maxCount)
            {
                this._invokeCount = 0;
                autoEvent.Set();
            }
        }
    }
}
