namespace CollectionsAndGenerics
{
    /// <summary>
    /// Holds, Manipulates and manage the in-memory list of books
    /// </summary>
    /// <typeparam name="T">Generic Type </typeparam>
    public class BooksManager<T>
    {
        private List<T> _books = new List<T>();

        /// <summary>
        /// Gets input from the user and adds the book titles in a list
        /// </summary>
        /// <param name="bookTitleT">New Book title to add</param>
        public void AddBooks(T bookTitleT)
        {
            if (this._books.Contains(bookTitleT))
            {
                throw new Exception("Enter Unique Name");
            }

            this._books.Add(bookTitleT);
            Console.WriteLine($"Totally {this._books.Count} were added");
        }

        /// <summary>
        /// Removes a specific book from the list
        /// </summary>
        /// <param name="bookTitleT">genric type of book title to remove</param>
        public void RemoveBooks(T bookTitleT)
        {
            this.SearchBooks(bookTitleT);
            if (ConsoleUserInterface.UserConfirmation("Deletion of above book"))
            {
                this._books.Remove(bookTitleT);
                Console.WriteLine($"Book named : {bookTitleT} have been deleted");
            }
            else
            {
                Console.WriteLine("Book Not Deleted");
            }
        }

        /// <summary>
        /// Search the books from the List
        /// </summary>
        /// <param name="bookTitleT">genric type of book title T</param>
        public void SearchBooks(T bookTitleT)
        {
            if (!this._books.Any())
            {
                throw new Exception("No Books were Added to the list");
            }
            else if (!this._books.Contains(bookTitleT))
            {
                Console.WriteLine($"Book Named {bookTitleT} Not Found");
            }
            else if (this._books.Contains(bookTitleT))
            {
                Console.WriteLine($"Book Named {bookTitleT} is found");
            }
        }

        /// <summary>
        /// Prints all the books from the List
        /// </summary>
        public void ShowAllBooks()
        {
            if (!this._books.Any())
            {
                throw new Exception("No Books were added yet");
            }

            foreach (T book in this._books)
            {
                Console.WriteLine(book);
            }
        }
    }
}
