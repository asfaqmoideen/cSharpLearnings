namespace CollectionsAndGenerics
{
    /// <summary>
    /// Holds, Manipulates and manage the list of books
    /// </summary>
    /// <typeparam name="T">Generic Type </typeparam>
    public class ListManager<T>
    {
        private List<T> _books = new List<T>();

        private enum ListOperations
        {
            AddBooks = 1,
            RemoveBooks,
            SearchBooks,
            Quit,
        }

        /// <summary>
        /// Execute the list operations according to the users choice
        /// </summary>
        public void ExecuteTheOperation()
        {
            bool stop = false;
            do
            {
                Console.WriteLine("Book Manager\nChoose any option to proced\n1.Add Books\n2.Remove Books\n3.Search Books\n4.Quit");
                bool isUserOptionInt = int.TryParse(Console.ReadLine(), out int userOption);
                ListOperations bookOperations = (ListOperations)userOption;
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
                    case ListOperations.Quit:
                        stop = true;
                        break;
                    default:
                        break;
                }
            }
            while (!stop);
        }

        /// <summary>
        /// Gets input from the user and adds the book titles in a list
        /// </summary>
        private void AddBooks()
        {
            bool addBooks = true;
            while (addBooks)
            {
                Console.WriteLine("Add a new Book");
                T bookTitleT = this.GetAndConvertBookType("Add");
                this._books.Add(bookTitleT);
                Console.WriteLine($"Totally {this._books.Count()} were Added");
                Console.WriteLine("Add Another book ?\n1.Yes\nPress any key to skip");
                string? addAnother = Console.ReadLine();
                if (addAnother == "1")
                {
                    addBooks = true;
                }
                else
                {
                    addBooks = false;
                }
            }
        }

        /// <summary>
        /// Removes a specific book from the list
        /// </summary>
        private void RemoveBooks()
        {
            T bookTitleT = this.GetAndConvertBookType("Remove");
            this._books.Remove(bookTitleT);
            Console.WriteLine($"Book named : {bookTitleT} have been deleted");
        }

        /// <summary>
        /// Search the books from the List
        /// </summary>
        private void SearchBooks()
        {
            T bookTitleT = this.GetAndConvertBookType("Find");
            if (this._books.Contains(bookTitleT))
            {
                Console.WriteLine("Yes the book is in the list");
            }
            else
            {
                Console.WriteLine("Book not Found");
            }
        }

        private T GetAndConvertBookType(string useCase)
        {
            Console.WriteLine($"Enter Book Title to {useCase}");
            return (T)Convert.ChangeType(Console.ReadLine(), typeof(T));
        }
    }
}
