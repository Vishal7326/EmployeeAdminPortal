namespace EmployeeAdminPortal.Models
{
    public class AddEmployeeDto // This class will have the same properties as the employee class because that is what it has to add.
    {
        public required string Name { get; set; } //Non-nullable property.

        public required string Email { get; set; }

        public string? Phone { get; set; } // Nullable property, can be null using question mark to make it nullable property.

        public decimal? Salary { get; set; }
    }
}
