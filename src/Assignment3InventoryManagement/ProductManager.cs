using System.Runtime.CompilerServices;

namespace Assignments
{
    /// <summary>
    /// Manages and executes methods of Products
    /// </summary>
    public class ProductManager
    {
        private UserInterface _userInterface;
        private List<Product> _productList;

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
        public IEnumerable<Product> GetProducts()
        {
            return this._productList;
        }

        /// <summary>
        /// Checks Whether product is already existing
        /// </summary>
        /// <param name="productName">sdds</param>
        /// <returns>true if product name existing else false</returns>
        public bool ISProductNameUnique(string productName)
        {
            var productNameExists = this._productList.Any(p => p.ProductName.ToLower() == productName.ToLower());
            return productNameExists;
        }

        /// <summary>
        /// validate whether the product ID is unique
        /// </summary>
        /// <param name="productID">ewr</param>
        /// <returns>true if product ID existing else false</returns>
        public bool IsProductIDUnique(string productID)
        {
            var productIDExists = this._productList.Any(p => p.ProductID.ToLower() == productID.ToLower());
            return productIDExists;
        }

        /// <summary>
        /// Cheks whether double or not
        /// </summary>
        /// <param name="productPrice">String input</param>
        /// <param name="productPriceOutput">Double output</param>
        /// <returns>true if product price double else false</returns>
        public bool IsProductPriceDouble(string productPrice, out double productPriceOutput)
        {
            bool isPriceDouble = false;
            double productprice;
            isPriceDouble = double.TryParse(productPrice, out productprice);
            productPriceOutput = productprice;
            if (isPriceDouble && (productprice >= 0))
            {
             return true;
            }
            return false;
        }

        /// <summary>
        /// Checks whether the product quanity integer
        /// </summary>
        /// <param name="productQuantity">Product quanitity as string</param>
        /// <param name="productQuanityOutput">ots product quantity as double</param>
        /// <returns>true if product quantity int else false</returns>
        public bool IsProductQuantityInt(string productQuantity, out uint productQuanityOutput)
        {
            bool isPriceDouble = false;
            uint productquantity;
            isPriceDouble = uint.TryParse(productQuantity, out productquantity);
            productQuanityOutput = productquantity;
            return isPriceDouble;
        }

        /// <summary>   
        /// Method to add prouct in the Lit
        /// </summary>
        /// <param name="product">gets objects and adds in the list</param>
        public void AddProductsToTheList(Product product)
        {
            this._productList.Add(product);
        }

        /// <summary>
        /// Removes the object from the list
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
            string option = Console.ReadLine();
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
        /// Method to delete products
        /// </summary>
        public void DeleteProduct()
        {
            if (this._productList.Count > 0)
            {
                string searchNameOrID = this._userInterface.GetProductNameOrId();
                Product searchResult = SearchProductInTheList(searchNameOrID);
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
        /// Edits the products
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
