namespace EmployeeAdminPortal.Models.Entities
{
    public class Employee
    {
        public Guid Id { get; set; } // Guid - Global Unique Identifier.

        public required string Name { get; set; } //Non-nullable property.

        public required string Email { get; set; }

        public string? Phone { get; set; } // Nullable property, can be null using question mark to make it nullable property.

        public decimal? Salary { get; set; }
    }
}
