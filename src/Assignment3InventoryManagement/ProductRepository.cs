namespace Assignments
{
    /// <summary>
    /// 
    /// </summary>
        public class ProductRepository
        {
        private static void AddProducts()
        {
            string productName = GetProductName();
            string productID = GetProductID();
            double productPrice = GetProductPrice();
            int productQuantity = GetProductQuantity();
            Console.WriteLine("Product Added");

            bool ifAdded = AddProductsInTheList(productName, productID, productPrice, productQuantity);

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



    }


}