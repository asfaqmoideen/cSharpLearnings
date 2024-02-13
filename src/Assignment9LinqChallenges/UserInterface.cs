namespace Assignment9LinqChallenges
{
    /// <summary>
    /// Interacts with User with Console
    /// </summary>
    internal class UserInterface
    {
        private ConsoleInputValidator _validator = new ConsoleInputValidator();

        /// <summary>
        /// checks whether the product name is unique
        /// </summary>
        /// <returns>returns the product name</returns>
        public string GetProductName()
        {
            string? productName;
            Console.WriteLine("Enter Product Name");
            productName = Console.ReadLine();
            while (productName.Count() == 0)
            {
                Console.WriteLine("Enter not null value");
                productName = Console.ReadLine();
            }

            return productName;
        }

        /// <summary>
        /// Method to get product Price
        /// </summary>
        /// <returns>Product Price</returns>
        public double GetProductPrice()
        {
            double productPrice;
            Console.WriteLine("Enter Product Price");
            string? productPriceInput = Console.ReadLine();
            while (!this._validator.IsProductPricePositiveDouble(productPriceInput, out productPrice))
            {
                Console.WriteLine("Invalid Product Price");
                productPriceInput = Console.ReadLine();
            }

            return productPrice;
        }

        /// <summary>
        /// Get of supplier
        /// </summary>
        /// <returns>supplier name</returns>
        public string GetSupplierName()
        {
            Console.WriteLine("Enter Supplier Name");
            string? supplierName;
            while ((supplierName = Console.ReadLine()) == null)
            {
                Console.WriteLine("Enter Valid Input");
            }

            return supplierName;
        }

        /// <summary>
        /// Gets product ID from the user
        /// </summary>
        /// <returns>the product ID</returns>
        public string GetProductcategory()
        {
            Console.WriteLine("Enter Category");
            string? productcategory;
            while ((productcategory = Console.ReadLine()) == null)
            {
                Console.WriteLine("Enter Valid Input");
            }

            return productcategory;
        }

        /// <summary>
        /// Gets product quantity from the user
        /// </summary>
        /// <returns>re</returns>
        public int GetProductId()
        {
            int getProductId;
            Console.WriteLine("Enter Product Id - Int");
            string? getProductIdFromUser = Console.ReadLine();
            while (!this._validator.IsGivenIdPositiveInt(getProductIdFromUser, out getProductId))
            {
                Console.WriteLine("Enter Not null value");
                getProductIdFromUser = Console.ReadLine();
            }

            return getProductId;
        }

        /// <summary>
        /// gets supplier id
        /// </summary>
        /// <returns>supplier id</returns>
        public int GetSupplierId()
        {
            int getSupplierId;
            Console.WriteLine("Enter Supplier ID");
            string? getSupplierIdFromUser = Console.ReadLine();
            while (!this._validator.IsGivenIdPositiveInt(getSupplierIdFromUser, out getSupplierId))
            {
                Console.WriteLine("Invalid Input");
                getSupplierIdFromUser = Console.ReadLine();
            }

            return getSupplierId;
        }
    }
}
