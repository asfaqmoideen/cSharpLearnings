namespace Assignments
{/// <summary>
 ///  Manipulates the Lists created with the instances <see cref="Product"/>s.
 /// </summary>
    public class Product
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Product"/> class.
        /// </summary>
        /// <param name="productName"> Mouse </param>
        /// <param name="productID"> ELE12</param>
        /// <param name="productPrice"> 500</param>
        /// <param name="productQuantity">120 </param>
        public Product(string productName, string productID, double productPrice, int productQuantity)
        {
            ProductName = productName;
            ProductID = productID;
            ProductPrice = productPrice;
            ProductQuantity = productQuantity;
        }

        /// <summary>
        /// Gets or sets ProductName
        /// </summary>
        /// <value>
        /// Mouse
        /// </value>
        public string ProductName { get; set; }

        /// <summary>
        /// Gets or sets Product ID
        /// </summary>
        /// <value>
        /// ele12
        /// </value>
        public string ProductID { get; set; }

        /// <summary>
        /// Gets or sets ProductPrice
        /// </summary>
        /// <value>
        /// productprice
        /// </value>
        public double ProductPrice { get; set; }

        /// <summary>
        /// Gets or sets ProductQuantity
        /// </summary>
        /// <value>
        /// ProductQuantity
        /// </value>
        public int ProductQuantity { get; set; }
    }
}