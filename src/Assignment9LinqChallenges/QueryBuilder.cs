using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment9LinqChallenges
{
    /// <summary>
    /// Query builder class to handle methods
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
        /// Filters the product
        /// </summary>
        /// <param name="predicate">takes predicated</param>
        /// <returns>object reference</returns>
        public QueryBuilder Filter(Func<Product, bool> predicate)
        {
            Console.WriteLine(_products.Count());

            if (_queryable.Count() == 0)
            {
               _queryable = this._products.Where(predicate);
            }

            _queryable = _queryable.Where(predicate);
            return this;
        }

        /// <summary>
        /// Sorts the list 
        /// </summary>
        /// <param name="sort">sort</param>
        /// <returns>objects</returns>
        public QueryBuilder Sort(Func<Product, object> sort)
        {
            if (!_queryable.Any())
            {
                _queryable = this._products.OrderBy(sort);
            }
            this._queryable = this._queryable.OrderBy(sort);
            return this;
        }

        /// <summary>
        /// Executes
        /// </summary>
        /// <returns>queried</returns>
        public IEnumerable<Product> Execute()
        {
            return _queryable;
        }        
    }
}
