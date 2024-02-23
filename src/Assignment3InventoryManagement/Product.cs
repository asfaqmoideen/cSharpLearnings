namespace Assignments
{
    /// <summary>
    ///  Manipulates the Lists created with the instances <see cref="Product"/>s.
    /// </summary>
    public class Product
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Product"/> class.
        /// </summary>
        /// <param name="productName">Name of the Product</param>
        /// <param name="productID">ID of the Product</param>
        /// <param name="productPrice"> Price of the Product</param>
        /// <param name="productQuantity">Quantity of the Product</param>
        public Product(string productName, string productID, double productPrice, uint productQuantity)
        {
            this.ProductName = productName;
            this.ProductID = productID;
            this.ProductPrice = productPrice;
            this.ProductQuantity = productQuantity;
        }

        /// <summary>
        /// Gets or sets ProductName
        /// </summary>
        /// <value>
        /// Name of the Product
        /// </value>
        public string ProductName { get; set; }

        /// <summary>
        /// Gets or sets Product ID
        /// </summary>
        /// <value>
        /// ID of the Product
        /// </value>
        public string ProductID { get; set; }

        /// <summary>
        /// Gets or sets ProductPrice
        /// </summary>
        /// <value>
        /// Price of the Product
        /// </value>
        public double ProductPrice { get; set; }

        /// <summary>
        /// Gets or sets ProductQuantity
        /// </summary>
        /// <value>
        /// Quantity of the Product
        /// </value>
        public uint ProductQuantity { get; set; }
    }
}