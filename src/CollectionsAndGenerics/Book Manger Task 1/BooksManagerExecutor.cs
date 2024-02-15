using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionsAndGenerics
{
    /// <summary>
    /// Executes the Books Manager Operations
    /// </summary>
    internal class BooksManagerExecutor
    {
        private BooksManager<string> _booksManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="BooksManagerExecutor"/> class.
        /// </summary>
        public BooksManagerExecutor()
        {
            this._booksManager = new BooksManager<string>();
        }

        private enum BookMangerOperations
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
                Console.WriteLine("BooksManager\n1.Add Books" +
                   "\n2.Remove Books\n3.Search Books\n4.Show All Books \n5.Quit");
                try
                {
                    int userOption = ConsoleUserInterface.GetOptionFromUser();
                    BookMangerOperations bookOperations = (BookMangerOperations)userOption;
                    stop = this.ExecuteBooksManagerMenu(bookOperations);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            while (!stop);
        }

        private bool ExecuteBooksManagerMenu(BookMangerOperations bookOperations)
        {
            switch (bookOperations)
            {
                case BookMangerOperations.AddBooks:
                    string bookTitle = ConsoleUserInterface.GetStringFromTheUser("Add Book");
                    this._booksManager.AddBooks(bookTitle);
                    break;
                case BookMangerOperations.RemoveBooks:
                    string bookTitleToRemove = ConsoleUserInterface.GetStringFromTheUser("Remove Book");
                    this._booksManager.RemoveBooks(bookTitleToRemove);
                    break;
                case BookMangerOperations.SearchBooks:
                    string bookTitleToSearch = ConsoleUserInterface.GetStringFromTheUser("Search Book");
                    this._booksManager.SearchBooks(bookTitleToSearch);
                    break;
                case BookMangerOperations.ShowAllBooks:
                    this._booksManager.ShowAllBooks();
                    break;
                case BookMangerOperations.Quit:
                    return true;
                default:
                    break;
            }

            return false;
        }
    }
}
