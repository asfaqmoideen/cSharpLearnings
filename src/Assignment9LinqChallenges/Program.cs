using Assignment9LinqChallenges;

namespace Assignments
{
    /// <summary>
    /// Iniates the program execution
    /// </summary>
    internal class Program
    { 
        /// <summary>
        /// The program execution starts here
        /// </summary>
        private static void Main()
        {
            ProductManager productManager = new ProductManager();
            Console.WriteLine("Hello, Humans !");
            productManager.AddProduct();
            productManager.SortProducts();
            Console.WriteLine("Sorted");
            productManager.GroupProducts();
            productManager.LinqToObjects();
            Console.ReadKey();
        }
    }
}