using GarbageCollection;
using System.Threading.Channels;

namespace Assignments
{ 
    /// <summary>
    /// Conatains the Main Method
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Inaites the Programor Starting point of the program
        /// </summary>
        private static void Main()
        {
            //CreateAndDestroyObjects();
            CreateAndDestroyObjectsWithGCCollector();
            Console.WriteLine("Programm Running\nPress any key to Exit");
            Console.ReadKey();
        }

        private static void CreateAndDestroyObjects()
        {
            ProjectCreateAndDetroy projectCreateAndDetroy;
            for (int i = 0; i < 1000100; i++)
            {
                projectCreateAndDetroy = new ProjectCreateAndDetroy(new List<string> (850000000) );
                projectCreateAndDetroy = null;
            }
        }
        private static void CreateAndDestroyObjectsWithGCCollector()
        {
            ProjectCreateAndDetroy projectCreateAndDetroy;
            for (int i = 0; i < 1000100; i++)
            {
                GC.Collect();
                projectCreateAndDetroy = new ProjectCreateAndDetroy(new List<string>(850000000));
                projectCreateAndDetroy = null;
            }
        }
    }
}