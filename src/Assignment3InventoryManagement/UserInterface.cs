namespace Assignments
{
    /// <summary>
    /// Intercats with User via console
    /// </summary>
        public class UserInterface
        {
          private static ProductManager _productManager = new ProductManager();
        /// <summary>
        /// checks whether the product name is unique
        /// </summary>
        /// <returns>returns the product name</returns>
          public string GetProductName()
        {
            string productName;
            do
            {
                Console.WriteLine("Enter Product Name");
                productName = Console.ReadLine();
            }
            while (!_productManager.ISProductNameUnique(productName));
            return productName;
        }
        /// <summary>
        /// Gets product ID fro the user
        /// </summary>
        /// <returns>the product ID</returns>
          public string GetProductID()
        {
            string productID;
            do
            {
                Console.WriteLine("Enter ID Name");
                productID = Console.ReadLine();
            }
            while (_productManager.IsProductIDUnique(productID));
            return productID;
        }
        /// <summary>
        /// Method to get product ID
        /// </summary>
        /// <returns>Product ID</returns>

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
            while (_productManager.IsProductPriceDouble(productprice, out productPrice ) != true);
            bool isPriceDouble;
            return productPrice;
        }
        /// <summary>
        /// Gets product quantity from the user
        /// </summary>
        /// <returns>re</returns>
          public int GetProductQuantity()
        {
            string productQuantityFromUser;
            int productQuantity;
            do
            {
                Console.WriteLine("Enter Quantity (Type - Double)");
                productQuantityFromUser = Console.ReadLine();
            }
            while (_productManager.IsProductQuantityInt(productQuantityFromUser, out productQuantity) != true);
            return productQuantity;
        }
        /// <summary>
        /// Shows the search reults
        /// </summary>
        /// <param name="productName">klerw</param>
        /// <param name="productID">ewr</param>
        /// <param name="productPrice">ewre</param>
        /// <param name="productQuantity">erw</param>
          public void SearchResults(string productName, string productID, double productPrice, double productQuantity )
        {
            Console.WriteLine("Search Results: ");
            Console.WriteLine("ProductName :" + productName + "\n" + "ProductID:" + productID +
                "\n" + "ProductPrice: " + productPrice + "\n" + "ProductQuantity" + productQuantity + "\t");
        }  
        /// <summary>
        /// gets confirmtion from the user
        /// </summary>
        /// <param name="productName">the product name</param>
        /// <param name="productID">product ID</param>
        /// <param name="productPrice">product price</param>
        /// <param name="productQuantity">product quantity</param>
        /// <returns>yes or no </returns>
          public string ConfirmTheProduct(string productName, string productID, double productPrice, double productQuantity )
        {
            Console.WriteLine("ProductName :" + productName + "\n" + "ProductID:" + productID +
                "\n" + "ProductPrice: " + productPrice + "\n" + "ProductQuantity" + productQuantity + "\t");
            Console.WriteLine("Confirm the Product - [Y]es - [C]ancel");
            string productConfirmation = Console.ReadLine();
            return productConfirmation;
        }
        /// <summary>
        /// Prints no products whenever it is called
        /// </summary>
          public void PrintNoProductsYet()
        {
            Console.WriteLine("No Products yet");
            Console.WriteLine("-------------------------------------------------------------------------------------------------");
            Console.WriteLine("Redirecing to Menu");
        } 
        /// <summary>
        /// Prints operation Cancelled whenever it is called
        /// </summary>
          public void PrintOpertaionCancelled()
        {
            Console.WriteLine("----------------Operation Cancelled----------------------");
            Console.WriteLine("Redirecing to Menu");
        }
        /// <summary>
        /// Gets name or Id from the user for edit or delete
        /// </summary>
        /// <returns>The product name or ID</returns>
          public string GetProductNameOrId()
        {
            Console.WriteLine("Enter Name or ID of the Product to Delete");
            string searchNameOrID = Console.ReadLine();
            return searchNameOrID;
        }
    }
}