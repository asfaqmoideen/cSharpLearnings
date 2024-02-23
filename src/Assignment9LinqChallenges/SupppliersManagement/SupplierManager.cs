namespace Assignment9LinqChallenges
{
    /// <summary>
    /// Holds, Manipulates and Manages the List of Suppliers
    /// </summary>
    public class SupplierManager
    {
        private List<Supplier> _suppliers = new List<Supplier>();
        private UserInterface _userInterface = new UserInterface();

        /// <summary>
        /// Adds product deatils to in-memory list
        /// </summary>
        public void AddSuppliers()
        {
            bool addSupplier = true;
            while (addSupplier)
            {
                Supplier supplier = this.GetSupplierDeatils();
                this._suppliers.Add(supplier);
                Console.WriteLine($"Totally{this._suppliers.Count} were Supplier Added");
                addSupplier = CommonMethods.IsAddAnotherItem("Supplier");
            }
        }

        /// <summary>
        /// makes the supplier list accesible
        /// </summary>
        /// <returns>list of suppliers</returns>
        public List<Supplier> GetSuppliers()
        {
            return this._suppliers;
        }

        /// <summary>
        /// gets supplier details from various function and complies it to a list
        /// </summary>
        /// <returns>object suppliers</returns>
        private Supplier GetSupplierDeatils()
        {
            string supplierName = this._userInterface.GetSupplierName();

            int productId;
            do
            {
                productId = this._userInterface.GetProductId();
            }
            while (this.IsProductdExists(productId));

            int supplierId;
            do
            {
                supplierId = this._userInterface.GetSupplierId();
            }
            while (this.IsSupplierIdExists(supplierId));

            Supplier supplier = new (supplierName, supplierId, productId);
            return supplier;
        }

        /// <summary>
        /// Checks Whether Supplier ID already existing
        /// </summary>
        /// <param name="supplierId">sdds</param>
        /// <returns>true if supplier id existing else false</returns>
        private bool IsSupplierIdExists(int supplierId)
        {
            return this._suppliers.Any(p => p.SupplierId == supplierId);
        }

        /// <summary>
        /// Checks Whether product ID already existing
        /// </summary>
        /// <param name="productId">sdds</param>
        /// <returns>true if product id existing else false</returns>
        private bool IsProductdExists(int productId)
        {
            return this._suppliers.Any(p => p.ProductId == productId);
        }
    }
}
