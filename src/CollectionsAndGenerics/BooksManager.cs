namespace CollectionsAndGenerics
{
    /// <summary>
    /// Holds, Manipulates and manage the in-memory list of books
    /// </summary>
    /// <typeparam name="T">Generic Type </typeparam>
    public class BooksManager<T>
    {
        private List<T> _books = new List<T>();

        private enum ListOperations
        {
            AddBooks = 1,
            RemoveBooks,
            SearchBooks,
            ShowAllBooks,
            Quit,
        }

        /// <summary>
        /// Execute the list operations according to the users choice
        /// </summary>
        public void ShowBooksManagerMenu()
        {
            bool stop = false;
            do
            {
                int userOption = ConsoleUserInterface.PrintMenuDetailsAndGetOptionFromUser("BooksManager\n1.Add Books" +
                    "\n2.Remove Books\n3.Search Books\n4.Show All Books \n5.Quit");
                ListOperations bookOperations = (ListOperations)userOption;
                stop = this.ExecuteBooksManagerMenu(bookOperations);
            }
            while (!stop);
        }

        private bool ExecuteBooksManagerMenu(BooksManager<T>.ListOperations bookOperations)
        {
            switch (bookOperations)
            {
                case ListOperations.AddBooks:

                    this.AddBooks();
                    break;
                case ListOperations.RemoveBooks:
                    this.RemoveBooks();
                    break;
                case ListOperations.SearchBooks:
                    this.SearchBooks();
                    break;
                case ListOperations.ShowAllBooks:
                    this.ShowAllBooks();
                    break;
                case ListOperations.Quit:
                    return true;
                default:
                    break;
            }

            return false;
        }

        /// <summary>
        /// Gets input from the user and adds the book titles in a list
        /// </summary>
        private void AddBooks()
        {
            bool addBooks = true;
            while (addBooks)
            {
                T bookTitleT = ConsoleUserInterface.GetAndConvertStringToType<T>("Add Book");
                this.AddBook(bookTitleT);
                addBooks = ConsoleUserInterface.IsAddAnotherDetail("Book");
            }
        }

        /// <summary>
        /// Accepsts Generic parameter and adds to the In-memory list
        /// </summary>
        /// <param name="bookTitleT">Title of the book</param>
        private void AddBook(T bookTitleT)
        {
            this._books.Add(bookTitleT);
            Console.WriteLine($"Totally {this._books.Count} were Added");
        }

        /// <summary>
        /// Removes a specific book from the list
        /// </summary>
        private void RemoveBooks()
        {
            T bookTitleT = ConsoleUserInterface.GetAndConvertStringToType<T>("Remove Boooks");
            this._books.Remove(bookTitleT);
            Console.WriteLine($"Book named : {bookTitleT} have been deleted");
        }

        /// <summary>
        /// Search the books from the List
        /// </summary>
        private void SearchBooks()
        {
            T bookTitleT = ConsoleUserInterface.GetAndConvertStringToType<T>("Find Availablity of Book");
            if (this._books.Contains(bookTitleT))
            {
                Console.WriteLine("Yes the book is in the list");
            }
            else
            {
                Console.WriteLine("Book not Found");
            }
        }

        private void ShowAllBooks()
        {
            foreach (T book in this._books)
            {
                Console.WriteLine(book);
            }
        }
    }
}
