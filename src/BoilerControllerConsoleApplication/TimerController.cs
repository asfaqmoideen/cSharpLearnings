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
        /// Initializes a new instance of the <see cref="TimerController"/> class.
        /// </summary>
        /// <param name="eventInformation">About the event</param>
        public TimerController(string eventInformation)
        {
            this.EventInformation = eventInformation;
        }

        /// <summary>
        /// Gets or sets information when the Timer is used
        /// </summary>
        /// <value>
        /// Info about the Event
        /// </value>
        public string EventInformation { get; set; }

        /// <summary>
        /// Starts the run timer
        /// </summary>
        public void RunTimer()
        {
            var autoEvent = new AutoResetEvent(false);

            Console.WriteLine($"{DateTime.Now} Starting{this.EventInformation}.\n");

            var stateTimer = new Timer(TimerStatus, autoEvent, 1000, 250);

            autoEvent.WaitOne();
            stateTimer.Dispose();
        }

        private void TimerStatus(object stateInfo)
        {
            AutoResetEvent autoEvent = (AutoResetEvent)stateInfo;
            Console.WriteLine($"{DateTime.Now}, {this.EventInformation}, {(++this._invokeCount).ToString()}");

            // Console.WriteLine("{0} Checking status {1,2}.",
            //    DateTime.Now.ToString("h:mm:ss.fff"),
            //    (++_invokeCount).ToString());
            if (this._invokeCount == this._maxCount)
            {
                this._invokeCount = 0;
                autoEvent.Set();
            }
        }
    }
}
