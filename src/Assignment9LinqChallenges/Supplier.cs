using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment9LinqChallenges
{
    /// <summary>
    /// Supplier properties Class
    /// </summary>
    public class Supplier
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Supplier"/> class.
        /// </summary>
        /// <param name="supplierName">supplierName</param>
        /// <param name="supplierId">suuplierId</param>
        /// <param name="productId">productId</param>
        public Supplier(string supplierName, uint supplierId, uint productId)
        {
            this.SupplierName = supplierName;
            this.SupplierId = supplierId;
            this.ProductId = productId;
        }

        /// <summary>
        /// Gets or sets Supplier name
        /// </summary>
        /// <value>
        /// supplier name as string
        /// </value>
        public string SupplierName { get; set; }

        /// <summary>
        /// Gets or sets SupplierId
        /// </summary>
        /// <value>
        /// supplier Id
        /// </value>
        public uint SupplierId { get; set; }

        /// <summary>
        /// Gets or sets Product Id
        /// </summary>
        /// <value>
        /// productId
        /// </value>
        public uint ProductId { get; set; }
    }
}
