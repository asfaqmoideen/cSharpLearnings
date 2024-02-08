using System.Collections;

namespace CollectionsAndGenerics
{
    /// <summary>
    /// Creates, Holds and Manipulates the dictionariers
    /// </summary>
    /// <typeparam name="T">Generic Type T</typeparam>
    public class DictionaryManager<T>
    {
        private readonly Dictionary<T, T> _dictionary = new Dictionary<T, T>();
    }
}
