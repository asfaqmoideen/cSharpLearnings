namespace Assignment9LinqChallenges
{
    /// <summary>
    /// Query builder class to handle methods which uses passed delegate.
    /// </summary>
    public class QueryBuilder
    {
        private IEnumerable<Product> _queryable = new List<Product>();
        private List<Product> _products;

        /// <summary>
        /// Initializes a new instance of the <see cref="QueryBuilder"/> class.
        /// Constructor to get list from product manager
        /// </summary>
        /// <param name="products">products</param>
        public QueryBuilder(List<Product> products)
        {
            this._products = products;
        }

        /// <summary>
        /// Filters the product according to the passed delegate
        /// </summary>
        /// <param name="predicate">takes predicated</param>
        /// <returns>object reference</returns>
        public QueryBuilder Filter(Func<Product, bool> predicate)
        {
            Console.WriteLine(this._products.Count());

            if (this._queryable.Count() == 0)
            {
                this._queryable = this._products.Where(predicate);
            }

            this._queryable = this._queryable.Where(predicate);
            return this;
        }

        /// <summary>
        /// Sorts the list using OrderBy() with passed delegate
        /// </summary>
        /// <param name="sort">sort</param>
        /// <returns>objects</returns>
        public QueryBuilder Sort(Func<Product, object> sort)
        {
            if (!this._queryable.Any())
            {
                this._queryable = this._products.OrderBy(sort);
            }

            this._queryable = this._queryable.OrderBy(sort);
            return this;
        }

        /// <summary>
        /// Executes all the queries mentioned above
        /// </summary>
        /// <returns>queried</returns>
        public IEnumerable<Product> Execute()
        {
            return this._queryable;
        }
    }
}
