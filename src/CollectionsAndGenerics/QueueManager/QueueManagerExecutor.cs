using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionsAndGenerics
{
    /// <summary>
    /// Executes the operation for queue operation
    /// </summary>
    public class QueueManagerExecutor
    {
        private QueueManager<string> _queueManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="QueueManagerExecutor"/> class.
        /// </summary>
        public QueueManagerExecutor()
        {
            this._queueManager = new QueueManager<string>();
        }

        private enum QueueManagerOperations
        {
            Quit,
            AddPerson,
            Remove,
            ShowAll,
        }

        /// <summary>
        /// Execute the list operations according to the users choice
        /// </summary>
        public void ShowQueueManagerMenu()
        {
            bool stop = false;
            do
            {
                Console.WriteLine("Queue Operations Manager\nChoose any option to proced\n1.Add Persons to queue" +
                    "\n2.Remove first person from queue\n3.Show all Persons after removal\n0.Quit");
                int userOption = ConsoleUserInterface.GetOptionFromUser();

                QueueManagerOperations operationToBePerformed = (QueueManagerOperations)userOption;

                stop = this.ExecuteQueueManagerOperation(operationToBePerformed);
            }
            while (!stop);
        }

        private bool ExecuteQueueManagerOperation(QueueManagerOperations operationToBePerformed)
        {
            switch (operationToBePerformed)
            {
                case QueueManagerOperations.AddPerson:
                    string personName = ConsoleUserInterface.GetStringFromTheUser("Add new person to the Queue");
                    this._queueManager.AddPersons(personName);
                    break;
                case QueueManagerOperations.Remove:
                    this._queueManager.RemoveFirstPerson();
                    break;
                case QueueManagerOperations.ShowAll:
                    this._queueManager.ShowAllPersons();
                    break;
                case QueueManagerOperations.Quit:
                    return true;
                default:
                    Console.WriteLine("Invalid Choice");
                    break;
            }

            return false;
        }
    }
}
