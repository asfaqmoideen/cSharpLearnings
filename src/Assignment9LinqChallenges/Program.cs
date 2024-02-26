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
        private static UserInterface userInterface = new UserInterface();

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
            bool contnue = true;
            do
            {
                try
                {
                    int option = userInterface.GetMainMenuOption();
                    Option optionFromUser = (Option)option;
                    ExecuteOperation(optionFromUser);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
            while (contnue);
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
                    operationsManager.SortProductsWithCategoryAndPriceRange();
                    operationsManager.GroupProductsByCategoryAndExpensivePrice();
                    break;
                case Option.Task2:
                    operationsManager.GroupProductsByCategoryAndExpensivePrice();
                    break;
                case Option.Task3:
                    linqToObjects.ArrayLinqToObjects();
                    break;
                case Option.Task4:
                    operationsManager.ProductsOfCategoryBook();
                    operationsManager.OptimisedSortProductsWithBooks();
                    break;
                case Option.Task5:
                    operationsManager.Task6();
                    break;
            }
        }
    }
}