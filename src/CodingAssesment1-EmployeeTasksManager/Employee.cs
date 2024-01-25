namespace Assignments
{   /// <summary>
    /// Employee Entity
    /// </summary>
    internal class Employee
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Employee"/> class.
        /// </summary>
        /// <param name="name">Employee Name</param>
        /// <param name="workingHours">Working Hours of the emloyee</param>
        /// <param name="skills">skills of the employee</param>
        /// <param name="assignedTask">assigned taskof the employee</param>
        public Employee(string name, double workingHours, string skills, string assignedTask)
        {
            this.Name = name;
            this.WorkingHours = workingHours;
            this.Skills = skills;
            this.AssignedTask = assignedTask;
        }
        /// <summary>
        /// Gets or sets name 
        /// </summary>
        /// <value>
        /// Employee name
        /// </value>
        public string Name { get; set; }
        /// <summary>
        /// Gets or sets employee working hours
        /// </summary>
        /// <value>
        /// employee working hours
        /// </value>
        public double WorkingHours { get; set;}
        /// <summary>
        /// Gets or sets Skills
        /// </summary>
        /// <value>
        /// employee skills
        /// </value>
        public string Skills { get; set; }
        /// <summary>
        /// Gets or sets employee's assigned task
        /// </summary>
        /// <value>
        /// task as string
        /// </value>
        public string AssignedTask { get; set;}
    }
}
