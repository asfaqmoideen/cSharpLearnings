using System;
using System.Collections;
using System.Reflection.Metadata;

namespace CollectionsAndGenerics
{
    /// <summary>
    /// Creates,Holds and manipulates the stacks
    /// </summary>
    /// <typeparam name="T">generic type</typeparam>
    public class StackManager<T>
    {
        private Stack<T> _stacks = new Stack<T>();

        /// <summary>
        /// Prints the reversed string with operation in stack
        /// </summary>
        /// <param name="characterArray">Character array to push into a stack</param>
        public void ReverseStringWithStacks(T[] characterArray)
        {
            foreach (var character in characterArray)
            {
                this._stacks.Push(character);
            }

            string newStringFromStack = string.Empty;

            while (this._stacks.TryPop(out T? element))
            {
                newStringFromStack += element;
            }

            Console.WriteLine($"The reveresed string is {newStringFromStack}");
        }
    }
}
