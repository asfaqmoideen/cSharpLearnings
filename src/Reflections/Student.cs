using System.Reflection;
using System.Runtime.InteropServices;

namespace Reflections
{
    /// <summary>
    /// Holds proeprties of Student
    /// </summary>
    public class Student
    {
        /// <summary>
        /// Gets or sets Student Name
        /// </summary>
        /// <value>
        /// Student Name
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets Student Grade
        /// </summary>
        /// <value>
        /// Student Grade
        /// </value>
        public string Grade { get; set; }

        /// <summary>
        /// Gets or sets Student Id
        /// </summary>
        /// <value>
        /// Student Id
        /// </value>
        public string StudentId { get; set;}

        /// <summary>
        /// sets the value of the property
        /// </summary>
        /// <param name="propertyInfo">property info</param>
        /// <param name="value">object value</param>
        public void SetValue(PropertyInfo propertyInfo, object value)
        {
            propertyInfo.SetValue(this, value, null);
        }
    }
}
