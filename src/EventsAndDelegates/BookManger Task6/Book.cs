namespace EventsAndDelegates
{
    /// <summary>
    /// Holds the Properties of Book
    /// </summary>
    public class Book
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Book"/> class.
        /// </summary>
        /// <param name="title">Title of the book</param>
        /// <param name="author">Author of the book</param>
        /// <param name="isbn">ISBN of the book</param>
        public Book(string title, string author, string isbn)
        {
            this.Author = author;
            this.Title = title;
            this.ISBN = isbn;
        }

        /// <summary>
        /// Gets or sets BookTitle
        /// </summary>
        /// <value> Book Title </value>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets Author of Book
        /// </summary>
        /// <value>Author of the Book</value>
        public string Author { get; set; }

        /// <summary>
        /// Gets or sets ISBN of the book
        /// </summary>
        /// <value> ISBN of the Book</value>
        public string ISBN { get; set; }
    }
}
