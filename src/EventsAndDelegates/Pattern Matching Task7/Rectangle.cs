namespace EventsAndDelegates
{
    /// <summary>
    /// Sub class of shape holds properties and methods of Rectagle
    /// </summary>
    public class Rectangle : Shape
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Rectangle"/> class.
        /// </summary>
        /// <param name="colour">Colour of the Rectangle</param>
        /// <param name="length">Lenght of the Rectange</param>
        /// <param name="breadth">Breadth of the Rectangle</param>
        public Rectangle(string colour, double length, double breadth)
        {
            this.Colour = colour;
            this.Length = length;
            this.Breadth = breadth;
        }

        /// <summary>
        /// Gets or sets Lenght of the Rectangle
        /// </summary>
        /// <value>Length of the Rectangle</value>
        public double Length { get; set; }

        /// <summary>
        /// Gets or sets Breadth of the Rectangle
        /// </summary>
        /// <value> Breadth of the Rectangle</value>
        public double Breadth { get; set; }

        /// <summary>
        /// Calculates area of Rectangle
        /// </summary>
        /// <returns>Area of Rectangle</returns>
        public double CalculateArea()
        {
            return this.Length * this.Breadth;
        }
    }
}
