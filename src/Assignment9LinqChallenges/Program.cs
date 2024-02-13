using Assignment9LinqChallenges;

namespace Assignments
{
    /// <summary>
    /// Iniates the program execution
    /// </summary>
    public class Program
    {
        private static ProductManager productManager = new ProductManager();
        private static SupplierManager supplierManager = new SupplierManager();
        private static LinqToObjects linqToObjects = new LinqToObjects();
        private static LINQOperationsManager operationsManager = new LINQOperationsManager(productManager, supplierManager);

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
            Console.WriteLine("Language Integrated Query");
            do
            {
                try
                {
                    Console.WriteLine("\nEnter a Option to Proceed\n1.AddProducts\n2.AddSuppliers\n3.Task1-Sorting\n4. Task2 -Grouping" +
                     "\n5.Task3-Array with LINQ\n6.Task-4 Sorting & optimised Sorting\n7.Advanced LINQ Query");
                    bool isOptionInt = int.TryParse(Console.ReadLine(), out int option);
                    Option optionFromUser = (Option)option;
                    ExecuteOperation(optionFromUser);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
            while (true);
        }

        private static void ExecuteOperation(Option optionFromUser)
        {
            switch (optionFromUser)
            {
                case Option.AddProducts:
                    productManager.AddProducts();
                    break;
                case Option.AddSuppliers:
                    supplierManager.AddSuppliers();
                    break;
                case Option.Task1:
                    operationsManager.SortProducts();
                    operationsManager.GroupProducts();
                    break;
                case Option.Task2:
                    operationsManager.GroupProducts();
                    break;
                case Option.Task3:
                    linqToObjects.ArrayLinqToObjects();
                    break;
                case Option.Task4:
                    operationsManager.SortProductsWithBooks();
                    operationsManager.OptimisedSortProductsWithBooks();
                    break;
                case Option.Task5:
                    operationsManager.Task6();
                    break;
            }
        }
    }
}