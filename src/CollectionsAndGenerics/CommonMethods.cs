using System;
using System.Collections.Generic;

namespace CollectionsAndGenerics
{
    /// <summary>
    /// Holds the Common methods in all Classes.
    /// </summary>
    /// <typeparam name="T">generic type T</typeparam>
    public class CommonMethods<T>
    {
        /// <summary>
        /// Confirm user to add another details
        /// </summary>
        /// <returns>True if user press 1</returns>
        /// <param name="useCase">usecase of teh Functionality when it is Called</param>
        public bool IsAddAnotherDetail(string useCase)
        {
            Console.WriteLine($"Add Another {useCase} ?\n1.Yes\nPress any key to skip");
            string? addAnother = Console.ReadLine();
            return true ? addAnother == "1" : false;
        }

        /// <summary>
        /// Gets String Input from user via console and converts to Generic type T
        /// </summary>
        /// <param name="useCase">Usecase while calling this functionality</param>
        /// <returns>generic Type T of the string</returns>
        public T GetAndConvertStringToType(string useCase)
        {
            Console.WriteLine($"Enter value to {useCase}");
            return (T)Convert.ChangeType(Console.ReadLine(), typeof(T));
        }
    }
}
