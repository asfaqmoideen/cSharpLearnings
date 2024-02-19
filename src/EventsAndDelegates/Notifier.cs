namespace EventsAndDelegates
{
    /// <summary>
    /// Methods
    /// </summary>
    public class Notifier
    {
        /// <summary>
        /// Delegate to notify
        /// </summary>
        /// <param name="newMessage">Message as string passed to the function</param>
        public delegate void Notify(string newMessage);

        /// <summary>
        /// Event Notify returns void
        /// </summary>
        public event Notify? OnAction;

        /// <summary>
        /// Writes the message to the console
        /// </summary>
        /// <param name="newMessage">message to be printed</param>
        public void MessageNotifier(string newMessage)
        {
            Console.WriteLine(newMessage + "Sms");
        }

        /// <summary>
        /// Writes the message to the console
        /// </summary>
        /// <param name="newMessage">message to be printed</param>
        public void EmailNotifier(string newMessage)
        {
            Console.WriteLine(newMessage + "Email");
        }

        /// <summary>
        /// To invoke the event
        /// </summary>
        /// <param name="newMessage">message to be printed</param>
        public void PerformEvent(string newMessage)
        {
            this.OnAction?.Invoke(newMessage);
        }
    }
}