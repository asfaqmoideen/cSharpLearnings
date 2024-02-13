namespace CollectionsAndGenerics
{
    /// <summary>
    /// Exectues the operations in multiple classes
    /// </summary>
    public class MainMenuExecutionManager
    {
        private BooksManager<string> _listManager = new BooksManager<string>();
        private StackManager<char> _stacks = new StackManager<char>();
        private QueueManager<string> _queues = new QueueManager<string>();
        private DictionaryManager<string, int> _dictionaryManager = new DictionaryManager<string, int>();
        private EnumerableCollections _readOnlyCollections = new EnumerableCollections();

        private enum CollectionsAndGenerics
        {
            Quit,
            BookManager,
            Stacks,
            Queue,
            Dictionary,
            ReadOnlyCollections,
        }

        /// <summary>
        /// Main Menu to execute operations
        /// </summary>
        /// <param name="stop">true when stop is pressed</param>
        public void MainMenu(out bool stop)
        {
            Console.WriteLine("Working With Collections\nEnter a Option to Proceed\n1.BookManager\n2.Stack Operations" +
                                    "\n3.QueueOperations\n4.Dictionary Operations\n5.Read Only Collections\n0 or Press any key to Quit");

            stop = this.ExecuteUserOperation();
        }

        private bool ExecuteUserOperation()
        {
            bool isUserOptionInt = int.TryParse(Console.ReadLine(), out int userOption);
            CollectionsAndGenerics operationToBeperformed = (CollectionsAndGenerics)userOption;
            switch (operationToBeperformed)
            {
                case CollectionsAndGenerics.BookManager:
                    this._listManager.ShowBooksManagerMenu();
                    break;
                case CollectionsAndGenerics.Stacks:
                    this._stacks.ReverseStringWithStacks();
                    break;
                case CollectionsAndGenerics.Queue:
                    this._queues.ShowQueueManagerMenu();
                    break;
                case CollectionsAndGenerics.Dictionary:
                    this._dictionaryManager.ExecuteTheOperation();
                    break;
                case CollectionsAndGenerics.ReadOnlyCollections:
                    this._readOnlyCollections.ExecuteReadOnlyCollections();
                    break;
                case CollectionsAndGenerics.Quit:
                    return true;
                default:
                    Console.WriteLine("Invalid Choice");
                    break;
            }

            return false;
        }
    }
}
