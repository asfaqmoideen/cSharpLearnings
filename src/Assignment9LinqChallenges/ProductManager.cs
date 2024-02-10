using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Assignment9LinqChallenges
{
    /// <summary>
    /// Manipulates the list of objects Product
    /// </summary>
    public class ProductManager
    {
        private List<Product> _products;
        private List<Supplier> _suppliers;
        private UserInterface _userInterface;
        private QueryBuilder _queryBuilder;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductManager"/> class.
        /// </summary>
        public ProductManager()
        {
            this._products = new List<Product>();
            this._suppliers = new List<Supplier>();
            this._userInterface = new UserInterface(this);
            this._queryBuilder = new QueryBuilder(this._products);
        }

        /// <summary>
        /// method to get product details from other functions
        /// </summary>
        public void AddProducts()
        {
            bool addProduct = true;
            while (addProduct)
            {
                Product product = this.CompileProductDetailsToAObject();
                this._products.Add(product);
                Console.WriteLine("Product Added");
                addProduct = this.IsAddAnotherTrue("Product");
            }
        }

        /// <summary>
        /// Adds product deatils to in-memory list
        /// </summary>
        public void AddSuppliers()
        {
            bool addSupplier = true;
            while (addSupplier)
            {
                Supplier supplier = this.CompileSupplierDeatilsToAObject();
                this._suppliers.Add(supplier);
                Console.WriteLine($"Totally{this._suppliers.Count} were Supplier Added");
                addSupplier = this.IsAddAnotherTrue("Supplier");
            }
        }

        /// <summary>
        /// Sorts the list of Object in the with category and price
        /// </summary>
        public void SortProducts()
        {
            Console.WriteLine("\nTask 1 - Sorting the products with Category Electronics and Descending Price above 500");
            var sortQuery = this._products.Where(p => p.Category == "Electronics" && p.ProductPrice > 500).ToList();
            var selectQuery = sortQuery.Select(p2 => new { p2.ProductName, p2.ProductPrice }).ToList();
            var orderByDescending = selectQuery.OrderByDescending(p1 => p1.ProductPrice).ToList();
            orderByDescending.ForEach(p => Console.WriteLine(p.ProductName + "-" + p.ProductPrice));
            var averagePrice = orderByDescending.Average(p => p.ProductPrice);
            Console.WriteLine("Average Price:" + averagePrice);
        }

        /// <summary>
        /// Group the products according to category and find expensive price
        /// </summary>
        public void GroupProducts()
        {
            Console.WriteLine("\nTask2 - Grouping Products by category and sorting by Expensive Price, Mapping with Suppliers");
            var groupQuery = this._products.GroupBy(p => p.Category).ToList();
            foreach (var group in groupQuery)
            {
                Console.WriteLine("Category : " + group.Key + " has : " + group.Count());
                foreach (var product in group.OrderByDescending(p => p.ProductPrice))
                {
                    Console.WriteLine($" Product Name : {product.ProductName}  Product Price : {product.ProductPrice}");
                }
            }

            this.GroupProductsWithSuppliers();
        }

        /// <summary>
        /// Sort Products with books category and price
        /// </summary>
        public void SortProductsWithBooks()
        {
            Console.WriteLine("\nTask 4.1 - Sorting the products with Category Books and Price");
            var sortQuery = this._products.Where(p => p.Category == "Books").OrderBy(p => p.ProductPrice).ToList();
            sortQuery.ForEach(p => Console.WriteLine(p.ProductName + " : " + p.ProductPrice));
        }

        /// <summary>
        /// Optimised function to Sort Products with books
        /// </summary>
        public void OptimisedSortProductsWithBooks()
        {
            Console.WriteLine("\nTask 4.2 - Optimised parallel query - Sorting the products with Category Books and Price");
            var sortQuery = this._products.AsParallel().Where(p => p.Category == "Books").OrderBy(p => p.ProductPrice).ToList();
            sortQuery.ForEach(p => Console.WriteLine(p.ProductName + " : " + p.ProductPrice));
        }

        /// <summary>
        /// Advance linq features for linq queries
        /// </summary>
        public void AdvancedlinqFeatures()
        {
            Func<Product, bool> filter = p => p.ProductPrice > 500;
            List<Product> sortedProductsByPrice = this.SortByPrice(this._products, filter);
            sortedProductsByPrice.ForEach(p => Console.WriteLine(p.ProductName));
            Console.WriteLine("Enter a category to sort");
        }

        /// <summary>
        /// task 6
        /// </summary>
        public void Task6()
        {
            Console.WriteLine("Enter option to Excute\n1.Filter Products\n2.SortProducts");
            bool isOptonInt = int.TryParse(Console.ReadLine(), out int option);
            if (option == 1)
            {
                this._queryBuilder = this._queryBuilder.Filter(p => p.ProductPrice > 500);
            }
            else if (option == 2)
            {
                this._queryBuilder = this._queryBuilder.Sort(p => p.ProductPrice);
            }
            else
            {
                Console.WriteLine("Enter valid Option");
            }

            var result = this._queryBuilder.Execute().ToList();

            foreach (var item in result)
            {
                Console.WriteLine(item.ProductName);
            }
        }

        /// <summary>
        /// Checks Whether product is already existing
        /// </summary>
        /// <param name="productName">sdds</param>
        /// <returns>true if product name existing else false</returns>
        public bool IsProductNameExists(string productName)
        {
            var productNameExists = this._products.Any(p => p.ProductName.ToLower() == productName.ToLower());
            return productNameExists;
        }

        /// <summary>
        /// Checks whether the product quanity integer
        /// </summary>
        /// <param name="productId">Product quanitity as string</param>
        /// <param name="productquantity">ots product quantity as double</param>
        /// <returns>true if product quantity int else false</returns>
        public bool IsGivenIdUInt(string? productId, out uint productquantity)
        {
            return uint.TryParse(productId, out productquantity);
        }

        /// <summary>
        /// Cheks whether double or not
        /// </summary>
        /// <param name="productPrice">String input</param>
        /// <param name="productPriceOutput">Double output</param>
        /// <returns>true if product price double else false</returns>
        public bool IsProductPricePositiveDouble(string? productPrice, out double productPriceOutput)
        {
            return double.TryParse(productPrice, out productPriceOutput) && productPriceOutput > 0;
        }

        private void GroupProductsWithSuppliers()
        {
            var matchingProducts = this._products.Join(
                this._suppliers,
                p => p.ProductId,
                s => s.ProductId,
                (product, supplier) => new
                {
                    productName = product.ProductName,
                    supplierName = supplier.SupplierName,
                });

            foreach (var product in matchingProducts)
            {
                Console.WriteLine($"{product.productName} is Supplied By  {product.supplierName}");
            }
        }

        /// <summary>
        /// Sorts by filter
        /// </summary>
        /// <param name="products">list</param>
        /// <param name="filter">filter </param>
        /// <returns>list of products</returns>
        private List<Product> SortByPrice(List<Product> products, Func<Product, bool> filter)
        {
            return products.Where(filter).ToList();
        }

        private bool IsAddAnotherTrue(string usecase)
        {
            Console.WriteLine($"Press 1 to Add another {usecase}. Press Any key to skip");
            string? option = Console.ReadLine();
            return true ? option == "1" : false;
        }

        private Product CompileProductDetailsToAObject()
        {
            string productName = this._userInterface.GetProductName();
            string productCategory = this._userInterface.GetProductcategory();
            double productPrice = this._userInterface.GetProductPrice();
            uint productId = this._userInterface.GetProductId();
            Product product = new Product(productId, productName, productPrice, productCategory);
            return product;
        }

        private Supplier CompileSupplierDeatilsToAObject()
        {
            string supplierName = this._userInterface.GetSupplierName();
            uint productId = this._userInterface.GetProductId();
            uint supplierId = this._userInterface.GetSupplierId();
            Supplier supplier = new (supplierName, supplierId, productId);
            return supplier;
        }
    }
}