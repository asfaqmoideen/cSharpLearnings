using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Assignment9LinqChallenges
{
    /// <summary>
    /// Operates Various operation on linq
    /// </summary>
    public class LINQOperationsManager
    {
        private QueryBuilder _queryBuilder;
        private ProductManager _productManager;
        private SupplierManager _supplierManager;
        private List<Product> _products;
        private List<Supplier> _suppliers;

        /// <summary>
        /// Initializes a new instance of the <see cref="LINQOperationsManager"/> class.
        /// </summary>
        /// <param name="productManager">current instance of product manager</param>
        /// <param name="supplierManager">current instance of supplier manager</param>
        public LINQOperationsManager(ProductManager productManager, SupplierManager supplierManager)
        {
            this._productManager = productManager;
            this._supplierManager = supplierManager;
            this._queryBuilder = new QueryBuilder(productManager.GetProducts());
            this._products = productManager.GetProducts();
            this._suppliers = supplierManager.GetSuppliers();
        }

        /// <summary>
        /// Sorts products with category electronics, product price greater than 500 and shows average price.
        /// </summary>
        public void SortProductsWithCategoryAndPriceRange()
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
        public void GroupProductsByCategoryAndExpensivePrice()
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
        public void ProductsOfCategoryBook()
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
    }
}
