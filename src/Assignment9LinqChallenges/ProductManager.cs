using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Assignment9LinqChallenges
{
    /// <summary>
    /// Manipulates the list of objects Product
    /// </summary>
    internal class ProductManager
    {
        private List<Product> _products;
        private List<Supplier> _suppliers;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductManager"/> class.
        /// </summary>
        public ProductManager()
        {
            this._products = new List<Product>();
            this._suppliers = new List<Supplier>
            {
                new Supplier ("Sony",  12, 101 ),
                new Supplier ("Elite", 20, 201)
            };
        }

        /// <summary>
        /// Add the list of products
        /// </summary>
        public void AddProduct()
        {
            Product product1 = new Product(100, "Laptop", 25000, "Electronics");
            this._products.Add(product1);
            Product product2 = new Product(101, "Monitor", 4000, "Electronics");
            this._products.Add(product2);
            Product product3 = new Product(200, "Chair", 5000, "Furniture");
            this._products.Add(product3);
            Product product4 = new Product(201, "Table", 4000, "Furniture");
            this._products.Add(product4);
            Product product5 = new Product(102, "Charger", 300, "Electronics");
            this._products.Add(product5);
            Product product6 = new Product(105, "Mouse", 250, "Electronics");
            this._products.Add(product6);
            Console.WriteLine("\tTotally 6 Products were added");
            _products.ForEach(p => Console.WriteLine(p.ProductName + "-" + p.ProductPrice));
        }

        /// <summary>
        /// Sorts the list of Object in the with category and price
        /// </summary>
        public void SortProducts()
        {
            Console.WriteLine("\nSorting the products with Category Electronics and Descending Price above $500");
            var sortQuery = _products.Where(p => p.Category == "Electronics" && p.ProductPrice > 500).ToList();
            var selectQuery = sortQuery.Select(p2 => new { p2.ProductName, p2.ProductPrice }).ToList();
            var orderByDescending = selectQuery.OrderByDescending(p1 => p1.ProductPrice).ToList();
            orderByDescending.ForEach(p =>  Console.WriteLine(p.ProductName + "-" + p.ProductPrice));
            var averagePrice = _products.Average(p => p.ProductPrice);
            Console.WriteLine("Average Price:" + averagePrice);
        }

        /// <summary>
        /// Group products
        /// </summary>
        public void GroupProducts()
        {
            Console.WriteLine("\nGrouping Products by category and sorting by Expensive Prices");
            var groupQuery = this._products.GroupBy(p => p.Category).ToList();
            foreach ( var group in groupQuery)
            {
                Console.WriteLine("Category : " + group.Key + " has : " + group.Count());
                foreach (var product in group.OrderByDescending(p => p.ProductPrice))
                {
                    Console.WriteLine("\t"+product.ProductName+" - "+ product.ProductPrice);
                }
            }

            var matchingProducts = this._products.Join(_suppliers,
                p => p.ProductId,
                s => s.ProductId,
                (product, supplier) => new
                {
                    productName = product.ProductName,
                    supplierName = supplier.SupplierName,
                });

            foreach ( var product in matchingProducts)
            {
                Console.WriteLine(product.productName +" is Supplied By " +  product.supplierName);
            }
        }
    }
}
    