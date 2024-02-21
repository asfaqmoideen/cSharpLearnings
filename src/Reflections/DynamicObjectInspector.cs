namespace Reflections
{
    /// <summary>
    /// Inspects the objects with relevant methods
    /// </summary>
    public class DynamicObjectInspector
    {
        /// <summary>
        /// Gets the type of the object and property
        /// </summary>
        /// <param name="obj">object</param>
        public void GetTypeof(object obj)
        {
            Type type = obj.GetType();
            var property = type.GetProperties();
            foreach (var propertyInfo in property)
            {
                Console.WriteLine(propertyInfo);
            }
        }
    }
}
