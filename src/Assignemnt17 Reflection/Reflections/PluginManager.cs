using System.Reflection;

namespace Reflections
{
    /// <summary>
    /// Manages the plugin
    /// </summary>
   public class PluginManager
    {
        private const string Plugin1FilePath = @"C:\New\backend_tips_2024\src\Assignemnt17 Reflection\Plugin1\bin\Debug\net6.0\plugin1.dll";
        private const string Plugin2FilePath = @"C:\New\backend_tips_2024\src\Assignemnt17 Reflection\Plugin2\bin\Debug\net6.0\plugin2.dll";

        public void ExecutePluginManager()
        {
            Assembly pluginAssembly1 = Assembly.LoadFile(Plugin1FilePath);
            Assembly pluginAssembly2 = Assembly.LoadFile(Plugin2FilePath);

            var pluginTypes = pluginAssembly1.GetTypes();
        }
    }
}
