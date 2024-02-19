using System.Collections.Immutable;
using System.Reflection;

namespace EventsAndDelegates
{
    /// <summary>
    /// Sorts array
    /// </summary>
    public class SortArray
    {
        /// <summary>
        /// Sorts tha array
        /// </summary>
        /// <param name="integerArray">integer Array</param>
        public void SortArrayDelegate(int[] integerArray)
        {
            Array.Sort(integerArray, delegate(int x, int y)
            {
                if (x < y)
                {
                    return -1;
                }

                if (x > y)
                {
                    return 1;
                }

                return 0;
            });

            Console.WriteLine("Sorted Array");

            foreach (var item in integerArray)
            {
                Console.Write(item + ",");
            }

            Console.WriteLine("-----------------------");
        }
    }
}
