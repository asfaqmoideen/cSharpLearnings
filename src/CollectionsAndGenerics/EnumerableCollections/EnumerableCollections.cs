using System;
using System.Collections;

namespace CollectionsAndGenerics
{
    /// <summary>
    /// Creates, Holds, Manipulates the in-memory Collection in IEnumerable Interface
    /// </summary>
    public class EnumerableCollections
    {
        /// <summary>
        /// Execute the operation in the Class ReadOnlyCollections
        /// </summary>
        public void ExecuteReadOnlyCollections()
        {
            Console.WriteLine("IEnumerable Collections ");

            List<int> integerList = new List<int> { 1, 2, 2, 4, 6, 7 };

            int[] integerArray = integerList.ToArray();

            Queue<int> integerQueue = new Queue<int>(integerList);

            Stack<int> integerStack = new Stack<int>(integerList);

            this.PrintSumOfElementsInCollections(integerList, integerArray, integerQueue, integerStack);

            IReadOnlyDictionary<string, int> immutableDictionary = this.GenerateDictionary();

            PrintReadOnlyDictionary<string, int>.PrintDictionary(immutableDictionary);
        }

        /// <summary>
        /// prints the Collection passed to it
        /// </summary>
        /// <param name="integerList">List of Integers</param>
        /// <param name="integerArray">Array of Integers</param>
        /// <param name="integerQueue">Queue of Integers</param>
        /// <param name="integerStack">Statck of Integers</param>
        private void PrintSumOfElementsInCollections(List<int> integerList, int[] integerArray, Queue<int> integerQueue, Stack<int> integerStack)
        {
            Console.WriteLine($"Sum of elements in List {this.SumOfElements(integerList)}");

            Console.WriteLine($"Sum of elements in Array {this.SumOfElements(integerArray)}");

            Console.WriteLine($"Sum of elements in Queue {this.SumOfElements(integerQueue)}");

            Console.WriteLine($"Sum of elements in Stack {this.SumOfElements(integerStack)}");
        }

        /// <summary>
        /// Calculates the sum of elements in the given collection
        /// </summary>
        /// <param name="collection">Any type of collection under IEnumerable</param>
        /// <returns>The sum of elemsts as integer</returns>
        private int SumOfElements(IEnumerable<int> collection)
        {
            int sumOfElements = 0;
            foreach (int element in collection)
            {
                sumOfElements += element;
            }

            return sumOfElements;
        }

        /// <summary>
        /// Generates Immutable Dictionary with Key and  Value
        /// </summary>
        /// <returns>Readonly Dictionary</returns>
        private IReadOnlyDictionary<string, int> GenerateDictionary()
        {
            Dictionary<string, int> alphabetDictionary = new ();
            for (int i = 65; i < 120; i++)
            {
                char tKeychar = (char)i;
                alphabetDictionary.Add(tKeychar.ToString(), i);
            }

            return alphabetDictionary;
        }
    }
}
