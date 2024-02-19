using ConsoleTables;

namespace EventsAndDelegates
{
    /// <summary>
    /// Holds, Manipulates and Manages the List of Products
    /// </summary>
    public class ProductManager
    {
        private List<Product> _products;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductManager"/> class.
        /// </summary>
        public ProductManager()
        {
            this._products = new List<Product>();
        }

        private void AddProducts()
        {
            this._products.Add(new Product("Alchemist", "Books", 450));
            this._products.Add(new Product("Atomic Habits", "Books", 500));
            this._products.Add(new Product("5AM Club", "Books", 650));
            this._products.Add(new Product("Mouse", "Electronics", 350));
            this._products.Add(new Product("KeyBoard", "Electronics", 700));
            this._products.Add(new Product("Monitor", "Electronics", 4500));
            this._products.Add(new Product("Pen", "Stationary", 35));
            this._products.Add(new Product("NoteBook", "Stationary", 70));
            this._products.Add(new Product("Bag", "Stationary", 700));
        }

        private void ShowAllProducts()
        {
            ConsoleTable allProductsTable = new ConsoleTable();
            foreach (Product product in this._products)
            {
                allProductsTable.AddRow($"Prouct Name")
            }
        }
    }
}
