using System.Runtime.CompilerServices;

namespace Assignments
{
    /// <summary>
    /// Manages and executes methods of Products
    /// </summary>
    public class ProductManager
    {
        private List<Product> _productList;
        private UserInterface _userInterface;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductManager"/> class.
        /// </summary>
        public ProductManager()
        {
            this._productList = new List<Product>();
            this._userInterface = new UserInterface(this);
        }

        /// <summary>
        /// Get the products in the list.
        /// </summary>
        /// <returns>returns product list</returns>
        public List<Product> GetProducts()
        {
            return this._productList;
        }

        /// <summary>
        /// Checks Whether product Name is already existing in the Products list
        /// </summary>
        /// <param name="productName">New name of the product to be added</param>
        /// <returns>True if product name existing else false</returns>
        public bool IsProductNameExists(string productName)
        {
            var productNameExists = this._productList.Any(p => p.ProductName.ToLower() == productName.ToLower());
            return productNameExists;
        }

        /// <summary>
        /// Checks Whether product ID is already existing in the Products list
        /// </summary>
        /// <param name="productID">New ID of the product to be added</param>
        /// <returns>true if product ID existing else false</returns>
        public bool IsProductIDExists(string productID)
        {
            return this._productList.Any(p => p.ProductID.ToLower() == productID.ToLower());
        }

        /// <summary>
        /// Cheks whether the Product Price is Positive Double Value
        /// </summary>
        /// <param name="productPrice">Product price from Cosole</param>
        /// <param name="productPriceOutput">Parsed string to double</param>
        /// <returns>True if product price double else false</returns>
        public bool IsProductPricePositiveDouble(string productPrice, out double productPriceOutput)
        {
            return double.TryParse(productPrice, out productPriceOutput) && productPriceOutput >= 0;
        }

        /// <summary>
        /// Checks whether the product quanity integer
        /// </summary>
        /// <param name="productQuantity">Product quanitity as string</param>
        /// <param name="productQuanityOutput">ots product quantity as double</param>
        /// <returns>true if product quantity int else false</returns>
        public bool IsProductQuantityUInt(string productQuantity, out uint productQuanityOutput)
        {
            return uint.TryParse(productQuantity, out productQuanityOutput);
        }

        /// <summary>
        /// Method to add object prouct in the Lit
        /// </summary>
        /// <param name="product">gets objects and adds in the list</param>
        public void AddProductsToTheList(Product product)
        {
            this._productList.Add(product);
        }

        /// <summary>
        /// Removes the object product from the list
        /// </summary>
        /// <param name="product">gets Object to delete</param>
        public void DeleteProductFromTheList(Product product)
        {
            this._productList.Remove(product);
        }

        /// <summary>
        /// Edits the product with existing reference
        /// </summary>
        /// <param name="productToBeEdited"> reference object</param>
        /// <param name="updatedProductName">new product name</param>
        /// <param name="updatedProductID">new product ID</param>
        /// <param name="updtaedProductPrice">new product price</param>
        /// <param name="updtaedProductQuantity">new product quantity</param>
        public void EditProductsWithReference(Product productToBeEdited, string updatedProductName, string updatedProductID, double updtaedProductPrice, uint updtaedProductQuantity)
        {
            productToBeEdited.ProductName = updatedProductName;
            productToBeEdited.ProductID = updatedProductID;
            productToBeEdited.ProductPrice = updtaedProductPrice;
            productToBeEdited.ProductQuantity = updtaedProductQuantity;
        }

        /// <summary>
        /// method to get product details from other functions
        /// </summary>
        public void AddProducts()
        {
            string productName = this._userInterface.GetProductName();
            string productID = this._userInterface.GetProductID();
            double productPrice = this._userInterface.GetProductPrice();
            uint productQuantity = this._userInterface.GetProductQuantity();
            Product product = new Product(productName, productID, productPrice, productQuantity);
            this.AddProductsToTheList(product);
            Console.WriteLine("Product Added");
            Console.WriteLine("[A]dd another Product or [M]enu");
            string? option = Console.ReadLine();
            if (option == "A" || option == "a")
            {
                this.AddProducts();
            }
        }

        /// <summary>
        /// Method to view product
        /// </summary>
        public void ViewProducts()
        {
            if (this._productList.Count > 0)
            {
                Console.WriteLine("List of Products");
                foreach (var products in this._productList)
                {
                    this._userInterface.ShowResults(products.ProductName, products.ProductID, products.ProductPrice, products.ProductQuantity);
                }
            }
            else
            {
                this._userInterface.PrintNoProductsYet();
            }
        }

        /// <summary>
        /// Traverse in the list to search products
        /// </summary>
        public void SearchProducts()
        {
            if (this._productList.Count > 0)
            {
                string searchNameOrID = this._userInterface.GetProductNameOrId();
                this.SearchProductInTheList(searchNameOrID);
            }
            else
            {
                this._userInterface.PrintNoProductsYet();
            }
        }

        /// <summary>
        /// Traverse through the list and shows the search resulst
        /// </summary>
        /// <param name="searchNameorID">searchNameorID</param>
        /// <returns> the instance if the product is in the list</returns>
        public Product? SearchProductInTheList(string searchNameorID)
        {
            foreach (var products in this._productList)
            {
                if (products.ProductName.ToLower() == searchNameorID.ToLower() || products.ProductID.ToLower() == searchNameorID.ToLower())
                {
                    this._userInterface.ShowResults(products.ProductName, products.ProductID, products.ProductPrice, products.ProductQuantity);
                    return products;
                }
            }

            return null;
        }

        /// <summary>
        /// Method to delete product from the list
        /// </summary>
        public void DeleteProduct()
        {
            if (this._productList.Count > 0)
            {
                string searchNameOrID = this._userInterface.GetProductNameOrId();
                Product searchResult = this.SearchProductInTheList(searchNameOrID);
                string userConfirmation = this._userInterface.ConfirmTheProduct(searchResult.ProductName, searchResult.ProductID, searchResult.ProductPrice, searchResult.ProductQuantity);

                if (userConfirmation == "Y" || userConfirmation == "y")
                {
                    this.DeleteProductFromTheList(searchResult);
                    Console.WriteLine("Product Deleted :(");
                }
                else if (userConfirmation == "C" || userConfirmation == "c")
                {
                    this._userInterface.PrintOpertaionCancelled();
                }
            }
            else
            {
                this._userInterface.PrintNoProductsYet();
            }
        }

        /// <summary>
        /// Edits the product in the Product List
        /// </summary>
        public void EditProduct()
        {
            if (this._productList.Count > 0)
            {
                string searchNameOrID = this._userInterface.GetProductNameOrId();
                Product searchResult = this.SearchProductInTheList(searchNameOrID);
                string userConfirmation = this._userInterface.ConfirmTheProduct(searchResult.ProductName, searchResult.ProductID, searchResult.ProductPrice, searchResult.ProductQuantity);

                if (userConfirmation == "Y" || userConfirmation == "y")
                {
                    string productName = this._userInterface.GetProductName();
                    string productID = this._userInterface.GetProductID();
                    double productPrice = this._userInterface.GetProductPrice();
                    uint productQuantity = this._userInterface.GetProductQuantity();
                    this.EditProductsWithReference(searchResult, productName, productID, productPrice, productQuantity);
                    Console.WriteLine("Product Edited Succesfully :)");
                }
                else if (userConfirmation == "C" || userConfirmation == "c")
                {
                    this._userInterface.PrintOpertaionCancelled();
                }
            }
            else
            {
                this._userInterface.PrintNoProductsYet();
            }
        }
    }
}
