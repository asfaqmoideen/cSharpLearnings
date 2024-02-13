namespace Assignment9LinqChallenges
{
    /// <summary>
    /// Manipulates the list of objects Product
    /// </summary>
    public class ProductManager
    {
        private List<Product> _products = new List<Product>();
        private UserInterface _userInterface = new UserInterface();

        /// <summary>
        /// method to get product details from other functions
        /// </summary>
        public void AddProducts()
        {
            bool addProduct = true;
            while (addProduct)
            {
                Product product = this.GetProductDetails();
                this._products.Add(product);
                Console.WriteLine("Product Added");
                addProduct = CommonMethods.IsAddAnotherItem("Product");
            }
        }

        /// <summary>
        /// To Access list in other claaes
        /// </summary>
        /// <returns>List of products</returns>
        public List<Product> GetProducts()
        {
            return this._products;
        }

        /// <summary>
        /// Checks Whether product ID is already existing
        /// </summary>
        /// <param name="productId">sdds</param>
        /// <returns>true if product id existing else false</returns>
        public bool IsProductIdExists(int productId)
        {
            return this._products.Any(p => p.ProductId == productId);
        }

        /// <summary>
        /// Checks Whether product is already existing
        /// </summary>
        /// <param name="productName">sdds</param>
        /// <returns>true if product name existing else false</returns>
        public bool IsProductNameExists(string productName)
        {
            return this._products.Any(p => p.ProductName.ToLower() == productName.ToLower());
        }

        /// <summary>
        /// Get product details and compiles it into a object
        /// </summary>
        /// <returns>object product with added fields</returns>
        private Product GetProductDetails()
        {
            string productName;
            do
            {
                productName = this._userInterface.GetProductName();
            }
            while (this.IsProductNameExists(productName));

            int productId;

            do
            {
                productId = this._userInterface.GetProductId();
            }
            while (this.IsProductIdExists(productId));

            double productPrice = this._userInterface.GetProductPrice();
            string productCategory = this._userInterface.GetProductcategory();
            Product product = new Product(productId, productName, productPrice, productCategory);
            return product;
        }
    }
}