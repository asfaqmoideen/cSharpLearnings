namespace Assignments
{
    /// <summary>
    /// dsojfsdo
    /// </summary>
        public class ProductManager
        {
        private UserInterface _userInterface = new UserInterface();
        private List<Product> _productList = new List<Product>();

        /// <summary>
        /// irkf
        /// </summary>
        /// <param name="productName">sdds</param>
        /// <returns>true or false</returns>
        public bool ISProductNameUnique(string productName)
        {
            foreach (var products in this._productList)
                {
                    if (!products.ProductName.ToLower().Equals(productName.ToLower()))
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }

            return true;
        }
        /// <summary>
        /// uwerhweijr
        /// </summary>
        /// <param name="productID">ewr</param>
        /// <returns>erewr</returns>
        public bool IsProductIDUnique(string productID)
        {
            if (this._productList.Count > 1)
            {
                foreach (var products in this._productList)
                {
                    if (products.ProductID.ToLower().Equals(productID.ToLower()))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }

            return false;
        }
        /// <summary>
        /// Cheks whether double or not
        /// </summary>
        /// <param name="productPrice">String input</param>
        /// <param name="productPriceOutput">Double output</param>
        /// <returns>The bool value</returns>
        public bool IsProductPriceDouble(string productPrice, out double productPriceOutput)
        {
            bool isPriceDouble;
            double productprice;
            isPriceDouble = double.TryParse(productPrice, out productprice);
            productPriceOutput = productprice;
            return true ? isPriceDouble : false;
        } 
        /// <summary>
        /// Checks whether the product quanity integer
        /// </summary>
        /// <param name="productQuantity">Product quanitity as string</param>
        /// <param name="productQuanityOutput">ots product quantity as double</param>
        /// <returns>True if int</returns>
        public bool IsProductQuantityInt(string productQuantity, out int productQuanityOutput)
        {
            bool isPriceDouble;
            int productquantity;
            isPriceDouble = int.TryParse(productQuantity, out productquantity);
            productQuanityOutput = productquantity;
            return true ? isPriceDouble : false;
        }

        /// <summary>
        /// odijsi
        /// </summary>
        /// <param name="productName">klsdm</param>
        /// <param name="productID">lksd</param>
        /// <param name="productPrice">klsdjn</param>
        /// <param name="productQuantity">djkn</param>
        /// <returns>dskjkls</returns>
        public bool AddProductsInTheList(string productName, string productID, double productPrice, int productQuantity)
        {
            Product product = new Product(productName, productID, productPrice, productQuantity);
            _productList.Add(product);
            return true;
        }
        /// <summary>
        /// method to add products
        /// </summary>
        public void AddProducts()
        {
            string productName = this._userInterface.GetProductName();
            string productID = this._userInterface.GetProductID();
            double productPrice = this._userInterface.GetProductPrice();
            int productQuantity = this._userInterface.GetProductQuantity();
            Console.WriteLine("Product Added");

            bool ifAdded = AddProductsInTheList(productName, productID, productPrice, productQuantity);

            Console.WriteLine("[A]dd another Product or [M]enu");
            string option = Console.ReadLine();
            if (option == "A" || option == "a")
            {
                AddProducts();
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
                    Console.WriteLine("Product Name" + "\t" + "Product ID" + "\t" + "Price" + "Quantity");
                    Console.WriteLine(products.ProductName + "\t" + products.ProductID + "\t" + products.ProductPrice + "\t" + products.ProductQuantity);
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
                foreach (var products in this._productList)
                {
                    if (products.ProductName.ToLower() == searchNameOrID.ToLower() || products.ProductID.ToLower() == searchNameOrID.ToLower())
                    {
                        this._userInterface.SearchResults(products.ProductName, products.ProductID, products.ProductPrice, products.ProductQuantity);
                    }
                }
            }
            else
            {
                this._userInterface.PrintNoProductsYet();
            }
        }
        /// <summary>
        /// Method to delete products
        /// </summary>
        public void DeleteProduct()
        {
            if (this._productList.Count > 0)
            {
                string searchNameOrID = this._userInterface.GetProductNameOrId();

                foreach (var products in _productList)
                {
                    if (products.ProductName.ToLower() == searchNameOrID.ToLower() || products.ProductID.ToLower() == searchNameOrID.ToLower())
                    {
                      string userConfirmation = this._userInterface.ConfirmTheProduct(products.ProductName, products.ProductID, products.ProductPrice, products.ProductQuantity);

                      if (userConfirmation == "Y" || userConfirmation == "y")
                        {
                            this._productList.Remove(products);
                            Console.WriteLine("Product Deleted :(");
                        }
                        else if (userConfirmation == "C" || userConfirmation == "c")
                        {
                            this._userInterface.PrintOpertaionCancelled();
                        }
                    }
                    break;
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
            Product editproduct;
            if (this._productList.Count > 0)
            {
                string searchNameOrID = this._userInterface.GetProductNameOrId();

                foreach (var products in _productList)
                {
                    if (products.ProductName.ToLower() == searchNameOrID.ToLower() || products.ProductID.ToLower() == searchNameOrID.ToLower())
                    {
                        string userConfirmation = _userInterface.ConfirmTheProduct(products.ProductName, products.ProductID, products.ProductPrice, products.ProductQuantity);

                        if (userConfirmation == "Y" || userConfirmation == "y")
                        {
                            string productName = this._userInterface.GetProductName();
                            string productID = this._userInterface.GetProductID();
                            double productPrice = this._userInterface.GetProductPrice();
                            int productQuantity = this._userInterface.GetProductQuantity();
                            products.ProductName = productName;
                            products.ProductID = productID;
                            products.ProductPrice = productPrice;
                            products.ProductQuantity = productQuantity;

                            Console.WriteLine("Product Edited Succesfully :)");
                        }
                        else if (userConfirmation == "C" || userConfirmation == "c")
                        {
                            this._userInterface.PrintOpertaionCancelled();
                            break;
                        }
                    }
                    break;
                }
            }
            else
            {
                this._userInterface.PrintNoProductsYet();
            }
        }
    }
}
