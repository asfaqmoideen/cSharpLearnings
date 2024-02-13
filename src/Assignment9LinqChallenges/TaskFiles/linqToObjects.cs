namespace Assignment9LinqChallenges
{
    /// <summary>
    /// Using LINQ to perform operations on in-memory objects such as arrays
    /// </summary>
    public class LinqToObjects
    {
        /// <summary>
        /// Array manipulation in linq
        /// </summary>
        public void ArrayLinqToObjects()
        {
            Console.WriteLine("Enter Array Lenht");
            bool isArrayLenghtInt = int.TryParse(Console.ReadLine(), out var length);
            int[] numberArray = new int[length];
            Console.WriteLine("Enter Array Elements");
            for (int i = 0; i < length; i++)
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
            var pairsProduceTargetSum = numberArray.SelectMany(
                                            (n, index) => numberArray.Skip(index + 1),
                                            (number1, number2) => new { Number1 = number1, Number2 = number2 })
                                            .Where(n => n.Number1 + n.Number2 == targetSum);
            foreach (var number in pairsProduceTargetSum)
            {
                Console.Write($"[ {number.Number1},{number.Number2}]");
            }
        }
    }
}
