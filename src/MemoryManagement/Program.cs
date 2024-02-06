namespace ValueAndReferenceTypes
{
    /// <summary>
    /// Initiates the program
    /// </summary>
    internal class Program
    {
        private static Number number;

        /// <summary>
        /// Initiates the program execution
        /// </summary>
        private static void Main()
        {
            Console.WriteLine("Memory Management in C#");

            int valueTypeVariable = 40;

            Number number = new Number(50);

            Console.WriteLine($"Value Before Modification\nValueTyepeVariable : {valueTypeVariable}\n" +
            $"Reference Type Variable : {number.RefTypeVariable}\n");

            MultiplyTwoNumbers(number, valueTypeVariable);

            Console.WriteLine($"Value After Modification\nValueTyepeVariable : {valueTypeVariable}\n" +
                $"Reference Type Variable : {number.RefTypeVariable}\n");
            CreateArrayOfIntegers();
            CalculateLargeNumber();
            Console.ReadKey();
        }

        private static void MultiplyTwoNumbers(Number number, int valueTypeVariable)
        {
            number.RefTypeVariable++;
            valueTypeVariable++;
        }

        private static void CreateArrayOfIntegers()
        {
            Int64[] integerArray = new Int64[120];

            for (int i = 0; i < 120 ; i++)
            {
                integerArray[i] = i * 1256;
            }

            foreach (var item in integerArray)
            {
                Console.WriteLine(item);
            }
        }

        private static void CalculateLargeNumber()
        {
            long firtsLargeNumber = 678902345676789;
            long secondLargeNumber = firtsLargeNumber * 57987367890;

            Console.WriteLine(secondLargeNumber);
        }
    }
}