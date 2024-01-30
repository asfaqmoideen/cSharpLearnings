using Assignment9LinqChallenges;

namespace Assignments
{
    /// <summary>
    /// Iniates the program execution
    /// </summary>
    internal class Program
    {
        private enum Option
        {
            AddProducts = 1,
            AddSuppliers,
            Task1,
            Task2,
            Task3,
            Task4,
            Task5,
        }
        /// <summary>
        /// The program execution starts here
        /// </summary>
        private static void Main()
        {
            ProductManager productManager = new ProductManager();
            Console.WriteLine("Language Integrated Query");
            do
            {
                Console.WriteLine("Enter a Option to Proceed\n1.AddProducts\n2.AddSuppliers\n3.Task1-Sorting\n4. Task2 -Grouping" +
                    "\n5.Task3-Array with LINQ\n6.Task-4 Sorting & optimised Sorting\n7.Advanced LINQ Query");
                bool isOptionInt = int.TryParse(Console.ReadLine(), out int option);
                Option optionFromUser = (Option)option;
                switch (optionFromUser)
                {
                    case Option.AddProducts:
                        productManager.AddProducts();
                        break;
                    case Option.AddSuppliers:
                        productManager.AddSuppliers();
                        break;
                    case Option.Task1:
                        productManager.SortProducts();
                        productManager.GroupProducts();
                        break;
                    case Option.Task2:
                        productManager.GroupProducts();
                        break;
                    case Option.Task3:
                        productManager.LinqToObjects();
                        break;
                    case Option.Task4:
                        productManager.SortProductsWithBooks();
                        productManager.OptimisedSortProductsWithBooks();
                        break;
                    case Option.Task5:
                        productManager.AdvancedlinqFeatures();
                        break;
                }
            }
            while(true);
        }
    }
}