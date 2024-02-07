namespace GarbageCollection
{
    /// <summary>
    /// Class to store Property
    /// </summary>
    public class ProjectCreateAndDetroy
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ProjectCreateAndDetroy"/> class.
        /// </summary>
        /// <param name="projects">list of strings</param>
        public ProjectCreateAndDetroy(List<string> projects)
        {
            this.Projects = projects;
        }

        /// <summary>
        /// Gets or sets projects list
        /// </summary>
        /// <value>
        /// List of project
        /// </value>
        public List<string> Projects { get; set; }
    }
}
