namespace CollectionsAndGenerics
{
    /// <summary>
    /// Exectues the operations in multiple classes
    /// </summary>
    public class MainMenuExecutionManager
    {
        private BooksManagerExecutor _booksManagerExecutor = new BooksManagerExecutor();
        private StudentManagerExecutor _studentManagerExecutor = new StudentManagerExecutor();
        private QueueManagerExecutor _queueManagerExecutor = new QueueManagerExecutor();
        private EnumerableCollections _readOnlyCollections = new EnumerableCollections();
        private StackManager<char> _stacks = new StackManager<char>();

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
            Console.WriteLine("Working With Collections\nEnter an Option to Proceed\n1.BookManager\n2.Stack Operations" +
                                    "\n3.QueueOperations\n4.Dictionary Operations\n5.Read Only Collections\n0 or Press any key to Quit");

            int userOption = ConsoleUserInterface.GetOptionFromUser();

            stop = this.ExecuteUserOperation(userOption);
        }

        private bool ExecuteUserOperation(int userOption)
        {
            CollectionsAndGenerics operationToBeperformed = (CollectionsAndGenerics)userOption;

            switch (operationToBeperformed)
            {
                case CollectionsAndGenerics.BookManager:
                    this._booksManagerExecutor.ShowBooksManagerMenu();
                    break;
                case CollectionsAndGenerics.Stacks:
                    string stringToReverse = ConsoleUserInterface.GetStringFromTheUser("Reverse the string");
                    this._stacks.ReverseStringWithStacks(stringToReverse.ToCharArray());
                    break;
                case CollectionsAndGenerics.Queue:
                    this._queueManagerExecutor.ShowQueueManagerMenu();
                    break;
                case CollectionsAndGenerics.Dictionary:
                    this._studentManagerExecutor.ShowStudentManagerMenu();
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
