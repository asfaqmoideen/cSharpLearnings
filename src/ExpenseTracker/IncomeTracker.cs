namespace Assignments
{
    internal partial class Program
    {
        internal sealed class ExpenseTracker
        {
            public string FirstName { get; set; }

            public string LastName { get; set; }

            public string Name => string.IsNullOrEmpty(LastName) ? FirstName : $"{FirstName} {LastName}";

            public string PhoneNumber { get; set; }

            public string Email { get; set; }

            public string? Notes { get; set; }

            public string Address { get; set; }
        }
    }
}