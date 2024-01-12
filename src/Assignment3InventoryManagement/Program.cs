using System.ComponentModel.Design;
using System.Runtime.CompilerServices;

namespace Assignments
{ /// <summary>
/// Initialies the program execution
/// </summary>
    internal partial class Program
    {
        /// <summary>
        /// The is the list of products stored as list of objects
        /// </summary>
        private static List<Product> _productList = new List<Product>();

        /// <summary>
        /// Method to get Product Name
        /// </summary>
        /// <returns>The product name</returns>
        private static string  GetProductName()
        {
            Console.WriteLine("Enter Product Name");
            string productName = Console.ReadLine();
            return (productName != null) ? productName : "-";
        }

        /// <summary>
        /// Method to get product ID
        /// </summary>
        /// <returns>Product ID</returns>
        private static string GetProductID()
        {
            Console.WriteLine("Enter Product !D");
            string productID = Console.ReadLine();
            return (productID != null) ? productID : "_";
        }

        /// <summary>
        /// Method to get product Price
        /// </summary>
        /// <returns>Product Price</returns>
        private static double GetProductPrice()
        {
            bool isPriceDouble;
            double productPrice;

            do
            {
                Console.WriteLine("Enter Product Price (Type - Double)");
                string tempPrice = Console.ReadLine();
                isPriceDouble = double.TryParse(tempPrice, out productPrice);
            }
            while (isPriceDouble != true);
            return productPrice;
        }

        /// <summary>
        /// Function to get product quantity
        /// </summary>
        /// <returns>the product quantity as int</returns>
        private static int GetProductQuantity()
        {
            bool isQuantityDouble;
            int productQuantity;
            do
            {
                Console.WriteLine("Enter Product Quantity (Type - Integer)");
                string tempQuan = Console.ReadLine();
                isQuantityDouble = int.TryParse(tempQuan, out productQuantity);
            }
            while (isQuantityDouble != true);
            return productQuantity;
        }

        private static void Main()
        {
            string option;
            do
            {
                Console.WriteLine("Menu");
                Console.WriteLine("Please Enter a Option");
                Console.WriteLine("[V]iew all Products");
                Console.WriteLine("[A]dd a Product");
                Console.WriteLine("[E]dit a Product");
                Console.WriteLine("[D]elete a Product");
                Console.WriteLine("[S]earch Product");
                Console.WriteLine("[Q]uit");
                option = Console.ReadLine();

                if (option == "V" || option == "v")
                    {
                        ViewProducts();
                    }
                    else if (option == "A" || option == "a")
                    {
                        AddProducts();
                    }
                    else if (option == "E" || option == "e")
                    {
                        EditProduct();
                    }
                    else if (option == "D" || option == "d")
                    {
                        DeleteProduct();
                    }
                    else if (option == "S" || option == "s")
                    {
                        SearchProducts();
                    }
                    else
                    {
                       Console.WriteLine("Enter a valid option");
                    }
            }
            while (option != "Q" && option != "q");
        }

        private static void AddProducts()
        {
            string productName = GetProductName();  
            string productID = GetProductID();
            double productPrice = GetProductPrice();
            int productQuantity = GetProductQuantity();

            Console.WriteLine("Product Added");
            Product product = new Product
            {
                ProductName = productName,
                ProductID = productID,
                ProductPrice = productPrice,
                ProductQuantity = productQuantity,
            };

            _productList.Add(product);

            Console.WriteLine("[A]dd another Product or [M]enu");
            string option = Console.ReadLine();
            if (option == "A" || option == "a")
            {
                AddProducts();
            }
            else
            {
                Console.WriteLine("-------------------------------------------------------------------------------------------------");
                Console.WriteLine("Redirecing to Menu");
            }
        }

        private static void ViewProducts()
        {
            if (_productList.Count > 0)
            {
                Console.WriteLine("List of Products");
                foreach (var products in _productList)
                {
                    Console.WriteLine("Product Name" + "\t" + "Product ID" + "\t" + "Price" + "Quantity");
                    Console.WriteLine(products.ProductName + "\t" + products.ProductID + "\t" + products.ProductPrice + "\t" + products.ProductQuantity);
                }
            }
            else
            {
                NoProductsYet();
            }
        }

        private static void SearchProducts()
        {
            if (_productList.Count > 0)
            {
                Console.WriteLine("Enter Name or ID of the Product");
                string searchNameOrID = Console.ReadLine();
                foreach (var products in _productList)
                {
                    if (products.ProductName == searchNameOrID || products.ProductID == searchNameOrID)
                    {
                        Console.WriteLine("You Might Want");
                        Console.WriteLine("ProductName :" + products.ProductName + "\n" + "ProductID:" + products.ProductID +
                            "\n" + "ProductPrice: " + products.ProductPrice + "\n" + "ProductQuantity" + products.ProductQuantity + "\t");
                    }
                }
            }
            else
            {
                NoProductsYet();
            }
        }

        private static void DeleteProduct()
        {
            if (_productList.Count > 0)
            {
                Console.WriteLine("Enter Name or ID of the Product to Delete");
                string searchNameOrID = Console.ReadLine();

                foreach (var products in _productList)
                    {
                        if (products.ProductName == searchNameOrID || products.ProductID == searchNameOrID)
                        {
                            Console.WriteLine("You Might Want");
                            Console.WriteLine("ProductName :" + products.ProductName + "\n" + "ProductID:" + products.ProductID +
                                "\n" + "ProductPrice: " + products.ProductPrice + "\n" + "ProductQuantity: " + products.ProductQuantity + "\t");
                            Console.WriteLine("Confirm Deletion of Product - [Y]es - [C]ancel");
                            string option = Console.ReadLine();

                            if (option == "Y" || option == "y")
                            {
                                _productList.Remove(products);
                                Console.WriteLine("Product Deleted :(");
                            }
                            else if (option == "C" || option == "c")
                            {
                            Console.WriteLine("-------------------------------------------------------------------------------------------------");
                            Console.WriteLine("Redirecing to Menu");
                        }
                        }
                        break;
                    }
            }
            else
            {
                NoProductsYet();
            }
        }

        private static void EditProduct()
        {
            Product editproduct;
            if (_productList.Count > 0)
            {
                Console.WriteLine("Enter Name or ID of the Product to Edit");
                string searchNameorID = Console.ReadLine();

                foreach (var products in _productList)
                    {
                        if (products.ProductName == searchNameorID || products.ProductID == searchNameorID)
                        {
                            Console.WriteLine("You Might Want");
                            Console.WriteLine("ProductName :" + products.ProductName + "\n" + "ProductID:" + products.ProductID +
                                "\n" + "ProductPrice: " + products.ProductPrice + "\n" + "ProductQuantity: " + products.ProductQuantity + "\t");
                            Console.WriteLine("Confirm Editing the Product - [Y]es - [C]ancel");
                            string option = Console.ReadLine();

                            if (option == "Y" || option == "y")
                            {
                            string productName = GetProductName();
                            string productID = GetProductID();
                            double productPrice = GetProductPrice();
                            int productQuantity = GetProductQuantity();
                            products.ProductName = productName;
                            products.ProductID = productID;
                            products.ProductPrice = productPrice;
                            products.ProductQuantity = productQuantity;

                            Console.WriteLine("Product Edited Succesfully :)");
                            }
                            else if (option == "C" || option == "c")
                            {
                            Console.WriteLine("-------------------------------------------------------------------------------------------------");
                            Console.WriteLine("Redirecing to Menu");
                            break;
                        }
                        }
                        break;
                }
            }
            else
            {
                NoProductsYet();
            }
        }

        /// <summary>
        /// Prints no products if the list is empty
        /// </summary>
        private static void NoProductsYet()
        {
            Console.WriteLine("No Products yet");
            Console.WriteLine("-------------------------------------------------------------------------------------------------");
            Console.WriteLine("Redirecing to Menu");
        }
    }
}