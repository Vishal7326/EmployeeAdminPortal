using Microsoft.EntityFrameworkCore;
using EmployeeAdminPortal.Models.Entities;
namespace EmployeeAdminPortal.Data
    
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base (options) //DbContextOptions<ApplicationDbContext> is a Generic class that tells how to configure to the database whereas base is used to call the constructor of the parent class and options is passed is in as parameter.
        {
            
        }

       //Next What we are going do to the class is that we will add a property or the collection that we are going to store in the database.
        //dbset is used to interact with the database table.
        //We are going to store the employees in the database hence we need to create dbset of employees here

        public DbSet<Employee> Employees { get; set; } //This tells Entity Framework “I want to create and manage a table of Employee objects in the database.”
        //The Employee class represents the structure(columns) of each row in the table.




    }
}
