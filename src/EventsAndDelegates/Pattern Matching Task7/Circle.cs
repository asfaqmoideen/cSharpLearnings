namespace EventsAndDelegates
{
    /// <summary>
    /// Sub class of shape holds properties and methods of Circle
    /// </summary>
    public class Circle : Shape
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Circle"/> class.
        /// </summary>
        /// <param name="colour">Colour of the Circle</param>
        /// <param name="radius">diameter of the Circle</param>
        public Circle(string colour, double radius)
        {
            this.Colour = colour;
            this.Radius = radius;
        }

        /// <summary>
        /// Gets or sets Diameter of the Circle
        /// </summary>
        /// <value> Diameter of the Rectangle</value>
        public double Radius { get; set; }

        /// <summary>
        /// Calculates area of Circle
        /// </summary>
        /// <returns>Area of Circle</returns>
        public double CalculateArea()
        {
            return 3.14 * this.Radius;
        }
    }
}
