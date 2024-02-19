namespace EventsAndDelegates
{
    /// <summary>
    /// The class for triangle shape
    /// </summary>
    public class Triangle : Shape
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Triangle"/> class.
        /// </summary>
        /// <param name="colour">Colour of the Triangle</param>
        /// <param name="triangleBase">Lenght of the Triangle</param>
        /// <param name="breadth">Breadth of the Triangle</param>
        public Triangle(string colour, double triangleBase, double breadth)
        {
            this.Colour = colour;
            this.Base = triangleBase;
            this.Height = breadth;
        }

        /// <summary>
        /// Gets or sets Lenght of the Triangle
        /// </summary>
        /// <value>Length of the Triangle</value>
        public double Base { get; set; }

        /// <summary>
        /// Gets or sets Breadth of the Triangle
        /// </summary>
        /// <value> Breadth of the Triangle</value>
        public double Height { get; set; }

        /// <summary>
        /// Calculates area of Triangle
        /// </summary>
        /// <param name="triangleBase">triangleBase of Triangle</param>
        /// <param name="height">height of Triangle</param>
        /// <returns>Area of Triangle</returns>
        public double CalculateArea()
        {
            return 0.5 * this.Base * this.Height;
        }
    }
}
