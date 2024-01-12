namespace Assignments
{/// <summary>
 ///  Manipulates the Lists created with the instances <see cref="Product"/>s.
 /// </summary>
    public class Product
    {
        /// <summary>
        /// Gets or sets initializes a new instance of the <see cref="Product"/> class.
        /// </summary>
        /// <param name="productName">Mouse</param>
        /// <param name="productID">ELe12</param>
        /// <param name="productPrice">500</param>
        /// <param name="productQunatity">100</param>
        /// <summary>
        /// Gets or sets Product Name
        /// </summary>
        /// <value>
        /// ele12
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
        public double ProductQuantity { get; set; }
    }
}