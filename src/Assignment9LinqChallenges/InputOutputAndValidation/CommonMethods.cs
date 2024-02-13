namespace Assignment9LinqChallenges
{
    /// <summary>
    /// Conatians methods that are common for all multiple classes
    /// </summary>
    public class CommonMethods
    {
        /// <summary>
        /// gets choice to add another true
        /// </summary>
        /// <param name="item">Use case</param>
        /// <returns>true if 1 is presses</returns>
        public static bool IsAddAnotherItem(string item)
        {
            Console.WriteLine($"Press 1 to Add another {item}. Press Any key to skip");
            return Console.ReadLine() == "1";
        }
    }
}
