using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment9LinqChallenges
{
    /// <summary>
    /// Entity class to store product properties
    /// </summary>
    public class Product
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Product"/> class.
        /// </summary>
        /// <param name="productId">product iD</param>
        /// <param name="productName">product name</param>
        /// <param name="productPrice">product price </param>
        /// <param name="productCategory">product category</param>
        public Product(uint productId, string productName, double productPrice, string productCategory)
        {
            this.ProductId = productId;
            this.ProductName = productName;
            this.ProductPrice = productPrice;
            this.Category = productCategory;
        }

        /// <summary>
        /// Gets or sets ProductID
        /// </summary>
        /// <value>
        /// ProductID
        /// </value>
        public uint ProductId { get; set; }

        /// <summary>
        /// Gets or sets ProductName
        /// </summary>
        /// <value>
        /// ProductName
        /// </value>
        public string ProductName { get; set; }

        /// <summary>
        /// Gets or sets ProductPrice
        /// </summary>
        /// <value>
        /// Product price
        /// </value>
        public double ProductPrice { get; set; }

        /// <summary>
        /// Gets or sets Category
        /// </summary>
        /// <value>
        /// Product Category
        /// </value>
        public string Category { get; set; }
    }
}
