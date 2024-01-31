using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using System.Transactions;

namespace Assignment9LinqChallenges
{
    /// <summary>
    /// Manipulates the list of objects Product
    /// </summary>
    internal class ProductManager
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
            this._queryBuilder = new QueryBuilder(_products);
        }
        /// <summary>
        /// Sorts the list of Object in the with category and price
        /// </summary>
        public void SortProducts()
        {
            Console.WriteLine("\nTask 1 - Sorting the products with Category Electronics and Descending Price above 500");
            var sortQuery = _products.Where(p => p.Category == "Electronics" && p.ProductPrice > 500).ToList();
            var selectQuery = sortQuery.Select(p2 => new { p2.ProductName, p2.ProductPrice }).ToList();
            var orderByDescending = selectQuery.OrderByDescending(p1 => p1.ProductPrice).ToList();
            orderByDescending.ForEach(p =>  Console.WriteLine(p.ProductName + "-" + p.ProductPrice));
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

        /// <summary>
        /// Array manipulation in linq
        /// </summary>
        public void LinqToObjects()
        {
            Console.WriteLine("Enter Array Lenht");
            bool isArrayLenghtInt = int.TryParse(Console.ReadLine(), out var length);
            int[] numberArray = new int[length];
            Console.WriteLine("Enter Array Elements");
            for ( int i = 0; i < length; i++)
            {
                int element;
                bool isElementInt = int.TryParse(Console.ReadLine(), out element);
                numberArray[i] = element;
            }
            Console.WriteLine("Enter target Sum");
            int targetSum;
            bool isTargetSumInt = int.TryParse(Console.ReadLine(), out targetSum);
            var secondMaximum = numberArray.OrderByDescending(n => n).ToArray().Skip(1).First();
            Console.WriteLine("The Second Maximum : " + secondMaximum);
           // var sumOfDistinct = numberArray.SelectMany(n => numberArray.Where(m => n + m == targetSum && m != n)).Distinct();
            var pairsProduceTargetSum = numberArray.SelectMany(
                                            (n, index) => numberArray.Skip(index + 1),
                                            (number1, number2) => new { Number1 = number1, Number2 = number2 })
                                            .Where(n => n.Number1 + n.Number2 == targetSum);
            foreach (var number in pairsProduceTargetSum)
            {
                Console.Write("(" + number.Number1 + "," + number.Number2+ ")\n" );
            }
        }

        /// <summary>
        /// Sort Products with books
        /// </summary>
        public void SortProductsWithBooks()
        {
            Console.WriteLine("\nTask 4.1 - Sorting the products with Category Books and Price");
            var sortQuery = _products.Where(p => p.Category == "Books").OrderBy(p => p.ProductPrice).ToList();
            sortQuery.ForEach(p => Console.WriteLine(p.ProductName + " : " + p.ProductPrice));
        }

        /// <summary>
        /// Optimised function to Sort Products with books
        /// </summary>
        public void OptimisedSortProductsWithBooks()
        {
            Console.WriteLine("\nTask 4.2 - Optimised parallel query - Sorting the products with Category Books and Price");
            var sortQuery = _products.AsParallel().Where(p => p.Category == "Books").OrderBy(p => p.ProductPrice).ToList();
            sortQuery.ForEach(p => Console.WriteLine(p.ProductName + " : " + p.ProductPrice));
        }

        /// <summary>
        /// Advance linq features for dynamic linq queries
        /// </summary>
        public void AdvancedlinqFeatures()
        {
            Func<Product, bool> filter = p => p.ProductPrice > 500;
            List<Product> sortedProductsByPrice= SortByPrice(_products, filter);
            sortedProductsByPrice.ForEach(p => Console.WriteLine( p.ProductName));
            Console.WriteLine("Enter a category to sort");
        }

        /// <summary>
        /// Sorts by filter
        /// </summary>
        /// <param name="products">list</param>
        /// <param name="filter">filter </param>
        /// <returns>list of products</returns>
        public List<Product> SortByPrice(List<Product> products, Func<Product, bool> filter)
        {
            return products.Where(filter).ToList();
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
        /// <param name="productdOutput">ots product quantity as double</param>
        /// <returns>true if product quantity int else false</returns>
        public bool IsProductIdUInt(string productId, out uint productdOutput)
        {
            bool isPriceDouble = false;
            uint productquantity;
            isPriceDouble = uint.TryParse(productId, out productquantity);
            productdOutput = productquantity;
            return isPriceDouble;
        }

        /// <summary>
        /// Cheks whether double or not
        /// </summary>
        /// <param name="productPrice">String input</param>
        /// <param name="productPriceOutput">Double output</param>
        /// <returns>true if product price double else false</returns>
        public bool IsProductPricePositiveDouble(string productPrice, out double productPriceOutput)
        {
            bool isPriceDouble = false;
            double productprice;
            isPriceDouble = double.TryParse(productPrice, out productprice);
            productPriceOutput = productprice;
            if (isPriceDouble && (productprice >= 0))
            {
                return true;
            }
            return false;
        }

        /// <summary>   
        /// Method to add prouct in the Lit
        /// </summary>
        /// <param name="product">gets objects and adds in the list</param>
        public void AddProductsToTheList(Product product)
        {
            this._products.Add(product);
        }

        /// <summary>
        /// method to get product details from other functions
        /// </summary>
        public void AddProducts()
        {
            string productName = this._userInterface.GetProductName();
            string productCategory = this._userInterface.GetProductcategory();
            double productPrice = this._userInterface.GetProductPrice();
            uint productId = this._userInterface.GetProductId();
            Product product = new Product(productId, productName, productPrice, productCategory);
            this._products.Add(product);
            Console.WriteLine("Product Added");
            Console.WriteLine("[A]dd another Product or [M]enu");
            string option = Console.ReadLine();
            if (option == "A" || option == "a")
            {
                this.AddProducts();
            }
        }

        /// <summary>
        /// method to get product details from other functions
        /// </summary>
        public void AddSuppliers()
        {
            string supplierName = this._userInterface.GetSupplierName();
            uint productId = this._userInterface.GetProductId();
            uint supplierId = this._userInterface.GetSupplierId();
            Supplier supplier = new(supplierName, supplierId, productId);
            this._suppliers.Add(supplier);
            Console.WriteLine("Supplier Added");
            Console.WriteLine("[A]dd another Supplier or [M]enu");
            string option = Console.ReadLine();
            if (option == "A" || option == "a")
            {
                this.AddSuppliers();
            }
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
                _queryBuilder = _queryBuilder.Filter(p => p.ProductPrice > 500);
            }
            else if (option == 2)
            {
                _queryBuilder = _queryBuilder.Sort(p => p.ProductPrice);
            }
            else
            {
                Console.WriteLine("Enter valid Option");
            }

            var result = _queryBuilder.Execute().ToList();

            foreach (var item in result)
            {
                Console.WriteLine(item.ProductName);
            }
        }
    }
}