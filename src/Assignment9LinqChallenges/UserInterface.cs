namespace Assignment9LinqChallenges
{
    /// <summary>
    /// Interacts with User with Console
    /// </summary>
    internal class UserInterface
    {
        private ProductManager _productManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserInterface"/> class.
        /// </summary>
        /// <param name="productManager">y</param>
        public UserInterface(ProductManager productManager)
        {
            this._productManager = productManager;
        }

        /// <summary>
        /// checks whether the product name is unique
        /// </summary>
        /// <returns>returns the product name</returns>
        public string GetProductName()
        {
            string productName;
            Console.WriteLine("Enter Product Name");
            productName = Console.ReadLine()!;
            while (_productManager.IsProductNameExists(productName))
            {
                Console.WriteLine("Enter Unique product Name");
                productName = Console.ReadLine()!;
            }

            return productName;
        }

        /// <summary>
        /// Method to get product Price
        /// </summary>
        /// <returns>Product Price</returns>
        public double GetProductPrice()
        {
            string productprice;
            double productPrice;
            do
            {
                Console.WriteLine("Enter Product Price (Type - Double)");
                productprice = Console.ReadLine();
            }
            while (_productManager.IsProductPricePositiveDouble(productprice, out productPrice) != true);
            bool isPriceDouble;
            return productPrice;
        }

        /// <summary>
        /// Get of supplier
        /// </summary>
        /// <returns>supplier name</returns>
        public string GetSupplierName()
        {
            string supplierName;
            Console.WriteLine("Enter Supplier Name");
            supplierName = Console.ReadLine();
            return supplierName;
        }

        /// <summary>
        /// Gets product ID from the user
        /// </summary>
        /// <returns>the product ID</returns>
        public string GetProductcategory()
        {
            string productcategory;
            Console.WriteLine("Enter Category");
            productcategory = Console.ReadLine();
            return productcategory;
        }

        /// <summary>
        /// Gets product quantity from the user
        /// </summary>
        /// <returns>re</returns>
        public uint GetProductId()
        {
            string getProductIdFromUser;
            uint getProductId;

            do
            {
                Console.WriteLine("Enter Product Id - Int");
                getProductIdFromUser = Console.ReadLine();
            }
            while (!_productManager.IsProductIdUInt(getProductIdFromUser, out getProductId));
            return getProductId;
        }

        /// <summary>
        /// gets supplier id
        /// </summary>
        /// <returns>supplier id</returns>
        public uint GetSupplierId()
        {
            string getSupplierIdFromUser;
            uint getSupplierId;

            do
            {
                Console.WriteLine("Enter Supplier Id - Int");
                getSupplierIdFromUser = Console.ReadLine();
            }
            while (!_productManager.IsProductIdUInt(getSupplierIdFromUser, out getSupplierId));
            return getSupplierId;
        }
    }
}
