namespace EventsAndDelegates
{
    /// <summary>
    /// Hold sthe methods that uses lamda expressions
    /// </summary>
    public class LambdaExpressions
    {
        private List<int> _randomElements = new List<int>();

        /// <summary>
        /// Generates the list of random integers
        /// </summary>
        /// <param name="lenghtofList">lenght of the list to create</param>
        public void GenerateList(int lenghtofList)
        {
            Random random = new Random();
            for (int i = 0; i <= lenghtofList; i++)
            {
                this._randomElements.Add(random.Next(200, 999));
            }

            this.FilterEvenNumbers();
        }

        /// <summary>
        /// Filter the even numbers in integer List
        /// </summary>
        public void FilterEvenNumbers()
        {
            var evenNumber = this._randomElements.Where(x => x % 2 != 0).ToList();
            this.SquareTheNumberinList(evenNumber);
        }

        private void SquareTheNumberinList(List<int> evenNumbers)
        {
            var squaredNumbers = evenNumbers.Select(x => x * x).ToList();
            this.PrintList(squaredNumbers);
        }

        private void PrintList(List<int> squaredNumbers)
        {
            Console.WriteLine("Square of Odd Numbers");
            foreach (int number in squaredNumbers)
            {
                Console.Write(number + ",");
            }
        }
    }
}
