using System;
using System.Collections;

namespace CollectionsAndGenerics
{
    /// <summary>
    /// Creates Holds and Manipulates Queues.
    /// </summary>
    /// <typeparam name="T">Generic type</typeparam>
    public class QueueManager<T>
    {
        private Queue<T> _queueOfPersons = new Queue<T>();

        /// <summary>
        /// Gets input from the user and adds the persons in the in-memory queue
        /// </summary>
        /// <param name="personName">Enqueue person to the queue</param>
        public void AddPersons(T personName)
        {
            if (this._queueOfPersons.Contains(personName))
            {
                throw new Exception("Enter Unique Person Name");
            }

            this._queueOfPersons.Enqueue(personName);
        }

        /// <summary>
        /// Removes person from in-memory Queue
        /// </summary>
        public void RemoveFirstPerson()
        {
            if (ConsoleUserInterface.UserConfirmation("To remove the first person from the queque"))
            {
                this._queueOfPersons.Dequeue();
            }
            else
            {
                Console.WriteLine("First Person not removed");
            }
        }

        /// <summary>
        /// Search person from in-memory Queue
        /// </summary>
        public void ShowAllPersons()
        {
            foreach (var person in this._queueOfPersons)
            {
                Console.WriteLine(person);
            }
        }

        /// <summary>
        /// Search persons from the queue and prints the value
        /// </summary>
        /// <param name="personToFind">Person name to be found</param>
        /// <exception cref="Exception">If the Quque is empty</exception>
        public void SearchPerson(T personToFind)
        {
            if (this._queueOfPersons.Any())
            {
                throw new Exception("No persons were added to the queue");
            }
            else if (this._queueOfPersons.Contains(personToFind))
            {
                Console.WriteLine($"Person Named {personToFind} Found in the Queue");
            }
        }
    }
}
