namespace EmployeeAdminPortal.Models
{
    //The Whole Point of Creating the UpdateDto is that because we need new object to pass in the update parameter
    //so that is why we created new EmployeeDto to pass the new object which will contain new values or property in that object.
    public class UpdateEmployeeDto
    {
        public required string Name { get; set; } //Non-nullable property.

        public required string Email { get; set; }

        public string? Phone { get; set; } // Nullable property, can be null using question mark to make it nullable property.

        public decimal? Salary { get; set; }
    }
}
