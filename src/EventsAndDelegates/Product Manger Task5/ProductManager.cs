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

        /// <summary>
        /// Delegate to sort products
        /// </summary>
        /// <param name="product1">Product 1 </param>
        /// <param name="product2">Product 2</param>
        /// <returns>Numerical value on comparision</returns>
        public delegate int SortDelegate(Product product1, Product product2);

        /// <summary>
        /// Executes the product Manager Operations
        /// </summary>
        public void ExecuteProductManager()
        {
            this.AddProducts();
            this.ShowAllProducts();
        }

        /// <summary>
        /// Sorts the products by name
        /// </summary>
        /// <param name="product1">Product 1 object containing name</param>
        /// <param name="product2">Product 2 object containing name</param>
        /// <returns>0 if same, 1 if greator, -1 if lesser</returns>
        public int SortByName(Product product1, Product product2)
        {
            return string.Compare(product1.Name, product2.Name);
        }

        /// <summary>
        /// Sorts the product by category
        /// </summary>
        /// <param name="product1">Product 1 object containing name</param>
        /// <param name="product2">Product 2 object containing name</param>
        /// <returns>0 if same, 1 if greator, -1 if lesser</returns>
        public int SortByCategory(Product product1, Product product2)
        {
            return string.Compare(product1.Category, product2.Category);
        }

        /// <summary>
        /// Sorts the product by price
        /// </summary>
        /// <param name="product1">Product 1 object containing name</param>
        /// <param name="product2">Product 2 object containing name</param>
        /// <returns>0 if same, 1 if greator, -1 if lesser</returns>
        public int SortByPrice(Product product1, Product product2)
        {
            return product1.Price.CompareTo(product2.Price);
        }

        /// <summary>
        /// Displays the sorted products
        /// </summary>
        /// <param name="sortedDelegate">Delegate sorted</param>
        public void SortAndDisplay(SortDelegate sortedDelegate)
        {
            this._products.Sort(new Comparison<Product>(sortedDelegate));

            ConsoleTable sortedTable = new ConsoleTable("Name", "Category", "Price");
            foreach (Product product in this._products)
            {
                sortedTable.AddRow(product.Name, product.Category, product.Price);
            }

            sortedTable.Write(Format.MarkDown);
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
            ConsoleTable allProductsTable = new ConsoleTable("Product Name", "Category", "Price");
            foreach (Product product in this._products)
            {
                allProductsTable.AddRow(product.Name, product.Category, product.Price);
            }

            allProductsTable.Write(Format.MarkDown);
        }
    }
}
