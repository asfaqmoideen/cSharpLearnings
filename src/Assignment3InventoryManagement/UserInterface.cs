namespace Assignments
{
        /// <summary>
        /// Interacts with User via console
        /// </summary>
        public class UserInterface
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
                productName = Console.ReadLine() !;
            }

            return productName;
        }

        /// <summary>
        /// Gets product ID from the user
        /// </summary>
        /// <returns>the product ID</returns>
        public string GetProductID()
        {
            string productID;
            Console.WriteLine("Enter ID Name");
            productID = Console.ReadLine();

            while(_productManager.IsProductIDExists(productID))
            {
                Console.WriteLine("Enter Uniquq ID Name");
                productID = Console.ReadLine();
            }
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
            while (_productManager.IsProductPricePositiveDouble(productprice, out productPrice ) != true);
            bool isPriceDouble;
            return productPrice;
        }

        /// <summary>
        /// Gets product quantity from the user
        /// </summary>
        /// <returns>re</returns>
        public uint GetProductQuantity()
        {
            string productQuantityFromUser;
            uint productQuantity;
            do
            {
                Console.WriteLine("Enter Quantity (Type - Double)");
                productQuantityFromUser = Console.ReadLine();
            }
            while (_productManager.IsProductQuantityUInt(productQuantityFromUser, out productQuantity) != true);
            return productQuantity;
        }

        /// <summary>
        /// Shows the List of all products
        /// </summary>
        /// <param name="productName">product names</param>
        /// <param name="productID">product ID</param>
        /// <param name="productPrice">price</param>
        /// <param name="productQuantity">quantity</param>
        public void ShowResults(string productName, string productID, double productPrice, double productQuantity )
        {
            Console.WriteLine("ProductName: " + productName + "\n" + "ProductID: " + productID +
                "\n" + "ProductPrice: " + productPrice + "\n" + "ProductQuantity: " + productQuantity + "\t");
        }

        /// <summary>
        /// gets confirmtion from the user
        /// </summary>
        /// <param name="productName">the product name</param>
        /// <param name="productID">product ID</param>
        /// <param name="productPrice">product price</param>
        /// <param name="productQuantity">product quantity</param>
        /// <returns>yes or no from user input </returns>
        public string ConfirmTheProduct(string productName, string productID, double productPrice, double productQuantity )
        {
            Console.WriteLine("ProductName :" + productName + "\n" + "ProductID:" + productID +
                "\n" + "ProductPrice: " + productPrice + "\n" + "ProductQuantity" + productQuantity + "\t");
            Console.WriteLine("Confirm the Product - [Y]es - [C]ancel");
            string? productConfirmation = Console.ReadLine();
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
        /// <returns>The product name or ID from the user</returns>
        public string GetProductNameOrId()
        {
            Console.WriteLine("Enter Name or ID of the Product");
            string? searchNameOrID = Console.ReadLine();
            return searchNameOrID;
        }
    }
}