namespace Assignments
{/// <summary>
/// rthe
/// </summary>  
        public class IncomeEntity
        {
        /// <summary>
        /// Initializes a new instance of the <see cref="IncomeEntity"/> class.
        /// </summary>
        /// <param name="amount">Income Amount</param>
        /// <param name="source">Income source</param>
        /// <param name="createdAt">created date</param>
        /// <param name="updatedAt">updated date</param>
        public IncomeEntity( double amount, string source, DateTime createdAt, DateTime updatedAt) 
        {
            Amount = amount;
            Source = source;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
        }
        /// <summary>
        /// Gets or sets /Gets or sets asda
        /// </summary>
        /// <value>
        /// Income Amoungt
        /// </value>
        public double Amount { get; set; }
        /// <summary>
        /// Gets or sets odskfls
        /// </summary>
        /// <value>
        /// expense amount
        /// </value>
        public string Source { get; set; }
        /// <summary>
        /// Gets or sets date
        /// </summary>
        /// <value>
        /// date of the income or expense
        /// </value>
        public DateTime CreatedAt { get; set; }
        /// <summary>
        /// Gets the updated date
        /// </summary>
        /// <value>
        /// Stores the value of updated date
        /// </value>
        public DateTime UpdatedAt { get; set; }
        }
}
