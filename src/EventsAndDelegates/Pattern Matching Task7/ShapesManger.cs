namespace EventsAndDelegates
{
    /// <summary>
    /// Manages the Shapes 
    /// </summary>
    public class ShapesManger
    {
        private List<Shape> _shapes = new List<Shape>();

        /// <summary>
        /// efw
        /// </summary>
        public void PatternMatching()
        {
            this._shapes.Add(new Circle("green", 5));
            this._shapes.Add(new Rectangle("blue", 5, 10));
            this._shapes.Add(new Triangle("White", 5, 9));

            foreach (var shape in this._shapes)
            {
                var color = shape switch
                {
                    Circle => shape.Colour,
                    Rectangle => shape.Colour,
                    Triangle => shape.Colour,
                };
                Console.WriteLine(color);

                var area = shape switch
                {
                    Circle => ((Circle)(shape)).CalculateArea(),
                    Rectangle => ((Rectangle)(shape)).CalculateArea(),
                    Triangle => ((Triangle)(shape)).CalculateArea(),
                };
                Console.WriteLine(area);
            }
        }
    }
}
