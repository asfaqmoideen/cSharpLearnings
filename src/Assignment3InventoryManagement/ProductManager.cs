namespace Assignments
{
    /// <summary>
    /// dsojfsdo
    /// </summary>
        public class ProductManager
        {
        private List<Product> _productList = new List<Product>();

        /// <summary>
        /// irkf
        /// </summary>
        /// <param name="productName">sdds</param>
        /// <returns>true or false</returns>
        public bool ValidateProductNameIfUnique(string productName)
        {
            foreach (var products in this._productList)
            {
                if (products.ProductName.ToLower() == productName.ToLower())
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        } 
        /// <summary>
        /// uwerhweijr
        /// </summary>
        /// <param name="productID">ewr</param>
        /// <returns>erewr</returns>
        public bool ValidateProductIDIfUnique(string productID)
        {
            foreach (var products in this._productList)
            {
                if (products.ProductName.ToLower() == productID.ToLower())
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
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
    }
}