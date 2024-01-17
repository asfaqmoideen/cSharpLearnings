using System.Security.Cryptography.X509Certificates;

namespace Assignments
{
    /// <summary>
    /// Initialies the program execution
    /// </summary>
    internal partial class Program
    {
        private static ProductManager _productManager = new ProductManager();

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
                    _productManager.ViewProducts();
                }
                else if (option == "A" || option == "a")
                {
                    _productManager.AddProducts();
                }
                else if (option == "E" || option == "e")
                {
                    _productManager.EditProduct();
                }
                else if (option == "D" || option == "d")
                {
                    _productManager.DeleteProduct();
                }
                else if (option == "S" || option == "s")
                {
                    _productManager.SearchProducts();
                }
                else
                {
                    Console.WriteLine("Enter a valid option");
                }
            }
            while (option != "Q" && option != "q");
        }
    }
}