namespace CollectionsAndGenerics
{
    /// <summary>
    /// Prints any type of generic dictionary
    /// </summary>
    /// <typeparam name="TKey">Key</typeparam>
    /// <typeparam name="TValue">Value</typeparam>
    public class PrintReadOnlyDictionary<TKey,  TValue>
    {
        /// <summary>
        /// Prints the dictionary
        /// </summary>
        /// <param name="dictionaryToBePrinted">dictionaryToBePrinted</param>
        public static void PrintDictionary(IReadOnlyDictionary<TKey, TValue> dictionaryToBePrinted)
        {
            foreach (KeyValuePair<TKey, TValue> pair in dictionaryToBePrinted)
            {
                Console.WriteLine($"{pair.Key} : {pair.Value}");
            }
        }
    }
}