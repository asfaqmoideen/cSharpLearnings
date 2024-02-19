using System.IO;

namespace EventsAndDelegates
{
    /// <summary>
    /// Holds the Methods of Var and Dynamic Types
    /// </summary>
    public class VarAndDynamic
    {
        /// <summary>
        /// Creates Var and Dynamic Types
        /// </summary>
        public void CreateVarAndDynamic()
        {
            var message = "This is Message that is created as string but using Var type";

            dynamic dynamicMessage = "Created as string but used dynamic type";

            // message = 12;
            dynamicMessage = 100;

            this.PrintUpdatedVaues(dynamicMessage, message);
        }

        private void PrintUpdatedVaues(dynamic dynamicMessage, string message)
        {
            Console.WriteLine($" {dynamicMessage} \n {message}");
        }
    }
}
