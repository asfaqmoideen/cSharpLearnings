namespace ValueAndReferenceTypes
{
    /// <summary>
    /// Class number that stores value type variabe
    /// </summary>
    public class Number
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Number"/> class.
        /// </summary>
        /// <param name="referenceTypeVariable">
        /// value from main methods
        /// </param>
        public Number(int referenceTypeVariable) => this.RefTypeVariable = referenceTypeVariable;

        /// <summary>
        /// Gets or sets ReferenceType Vriable.
        /// </summary>
        /// <value>
        /// value assigned in main method
        /// </value>
        public int RefTypeVariable { get;set; }
    }
}