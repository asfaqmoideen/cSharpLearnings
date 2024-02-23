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

            IncrementTwoNumbers(number, valueTypeVariable);

            Console.WriteLine($"Value After Modification\nValueTyepeVariable : {valueTypeVariable}\n" +
                $"Reference Type Variable : {number.RefTypeVariable}\n");
            CreateArrayOfIntegers();
            MultiplyLargeNumber();
            Console.ReadKey();
        }

        /// <summary>
        /// Increments any two Numbers passed as integer and object(ValueType and Refrence Type
        /// </summary>
        /// <param name="number">Objcet with a Integer property</param>
        /// <param name="valueTypeVariable">Value type variale</param>
        private static void IncrementTwoNumbers(Number number, int valueTypeVariable)
        {
            number.RefTypeVariable++;
            valueTypeVariable++;
        }

        /// <summary>
        /// Creates a integer array with larger size
        /// </summary>
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

        /// <summary>
        /// Multiplies two large numbers which are in value types
        /// </summary>
        private static void MultiplyLargeNumber()
        {
            long firtsLargeNumber = 678902345676789;
            long secondLargeNumber = firtsLargeNumber * 57987367890;

            Console.WriteLine(secondLargeNumber);
        }
    }
}