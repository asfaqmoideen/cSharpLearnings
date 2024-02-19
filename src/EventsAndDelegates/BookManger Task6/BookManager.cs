using ConsoleTables;

namespace EventsAndDelegates
{
    /// <summary>
    /// Holds manages and manipulates the Books
    /// </summary>
    public class BookManager
    {
        public record Book(string title, string author, string isbn);

        private List<Book> _books = new List<Book>();

        /// <summary>
        /// Executes the Book Manager
        /// </summary>
        public void ExecuteBookManager()
        {
            this.AddBooks();
            this.ShowAllBooks();
            this.IsBookValueEqual(this._books[3], this._books[4]);
            this.TryEditingBooks();
            this.ShowAllBooks();
            this.BookDeconstruction();
        }

        private void BookDeconstruction()
        {
            foreach (Book book in this._books)
            {
                var (title, author, isbn) = book;
                Console.WriteLine(title);   
                Console.WriteLine(author);
                Console.WriteLine(isbn);
            }
        }

        private void TryEditingBooks()
        {
            Book book1 = this._books[3] with { author = "asfaq" };
            this._books.Add(book1);
        }

        private void ShowAllBooks()
        {
            Console.WriteLine("All Books in the List");
            ConsoleTable unSortedTable = new ConsoleTable("Book Title", "Author", "ISBN");
            foreach (Book book in this._books)
            {
                unSortedTable.AddRow(book.title, book.author, book.isbn);
            }
            unSortedTable.Write(Format.MarkDown);
        }

        private void AddBooks()
        {
            this._books.Add(new Book("Alchemist", "Paulo Choelo", "382DSFJKSDNF"));
            this._books.Add(new Book("BPPS", "Charles Conn", "211SDFSKSDNF"));
            this._books.Add(new Book("Atomic Habits", "Sam Rishi", "25SKJSNDNF"));
            this._books.Add(new Book("Aram", "Kaviko", "67KJKJNDF"));
            this._books.Add(new Book("Aram", "Kaviko", "67KJKJNDF"));
            this._books.Add(new Book("Maatram", "JayaMohan", "81273JFJKSDNF"));
            this._books.Add(new Book("5AM Club", "Robin Sharma", "986dSFJKSDNF"));
        }

        private void IsBookValueEqual(Book book1, Book book2)
        {
            if (book1 == book2)
            {
                Console.WriteLine("Two Books are in Same value");
                return;
            }

            Console.WriteLine("No Matching books");
        }
    }
}
