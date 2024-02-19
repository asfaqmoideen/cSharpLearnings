namespace EventsAndDelegates
{
    /// <summary>
    /// Holds the product Entities
    /// </summary>
    public class Product
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Product"/> class.
        /// </summary>
        /// <param name="name">Name of the Product</param>
        /// <param name="category">Category of the Product</param>
        /// <param name="price">Price of the product</param>
        public Product(string name, string category, int price)
        {
            this.Name = name;
            this.Category = category;
            this.Price = price;
        }

        /// <summary>
        /// Gets or sets Product Name
        /// </summary>
        /// <value>
        /// product name
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets Product Category
        /// </summary>
        /// <value>
        /// Product Category
        /// </value>
        public string Category { get; set; }

        /// <summary>
        /// Gets or sets Product Price
        /// </summary>
        /// <value> Product Price</value>
        public int Price { get; set; }
    }
}
