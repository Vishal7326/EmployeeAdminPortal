using Azure;
using EmployeeAdminPortal.Data;
using EmployeeAdminPortal.Models;
using EmployeeAdminPortal.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using static System.Net.WebRequestMethods;


namespace EmployeeAdminPortal.Controllers
{
    //It Goes to the localhost port number that it is running on.
    //localhost:xxxx/api/controller.
    //In this case it would be 
    //localhost:xxxx/api/employees.

    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {

        private readonly ApplicationDbContext dbContext; //private field 

        //The Way to Inject DbContext in the Controller is through Constructor Injection.

        public EmployeesController(ApplicationDbContext dbContext) // Using ApplicationDbCOntext from the Data
        {
            this.dbContext = dbContext;
        }

        //Reading all the Employees from the Employee Table.

        [HttpGet]

        //An Action Method is a public method in an ASP.NET Core Controller
        //that responds to an HTTP request — like GET, POST, PUT, or DELETE.
        //IActionResult is an interface that allows you to return various kinds of HTTP responses from a controller action — making your controller
        //more flexible and RESTful.

        public IActionResult GetAllEmployees() //This Method Can help you connecct to the database and can help u return live data from the database.
        {
            // InOrder to Connect to the database we need sbcontext 
            //The Purpose of Injecting DbContext in Programcs was to Access the dbContext anywhere in the program.
            //Hence We are returning this to api we need to status ok.
            var allEmployees = dbContext.Employees.ToList();

            return Ok(allEmployees);
        }

        // Getting onlyone Employee by id.
        [HttpGet]
        [Route("{id:guid}")] // Im Accepting the identifier in the route itself.
        public IActionResult GetEmployeesById(Guid id) //Since we need to search for id we need id from the database hence we will accept the identifier in the route.
        {
            var employee = dbContext.Employees.Find(id);

            if (employee is null)
            {
                return NotFound();
            }

            return Ok(employee);
        } 
        

        [HttpPost] // This Method is used to add the properties to the table.

        // We Define the action method.

        public IActionResult AddEmployee(AddEmployeeDto addEmployeeDto) 
        {
            // Defining Method Structure.

            // To add an employee we need the details of the employee. which is in employee class. 

            // For this we use Dto data transfer objects - which transfer data from one operation to another.

            //The DBContext Class that we use to add this employee only accept the entities over here.

            var employeeEntity = new Employee() // Creating an entity over here 
            {
                Name = addEmployeeDto.Name,
                Email = addEmployeeDto.Email,
                Phone = addEmployeeDto.Phone,
                Salary = addEmployeeDto.Salary
            };

            dbContext.Employees.Add(employeeEntity); // What we have is EmployeeDto but in add function it takes only entity 
                                                     // So we need to convert dto into entity

            dbContext.SaveChanges(); // The actions that you want to make will be changed and saved.

            return Ok(employeeEntity);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public IActionResult UpdateEmployee(Guid id,UpdateEmployeeDto updateEmployeeDto) // This Method Also Need Information of the method that you are Updating.
            //The Second Parameter that we need is an object that contains the element that we need to update.
        {
            var employee = dbContext.Employees.Find(id);

            if (employee is  null)
            {
                return NotFound();
            }

            employee.Name = updateEmployeeDto.Name;

            employee.Email = updateEmployeeDto.Email;

            employee.Phone = updateEmployeeDto.Phone;

            employee.Salary = updateEmployeeDto.Salary;

            dbContext.SaveChanges(); // If You Forget to do this you will not see any changes in the db.

            return Ok(employee);

        }
        //Creating a Http requet to delete the employee from the db 

        [HttpDelete]

        [Route("{id:guid}")]

        public IActionResult DeleteEmployee(Guid id)
        {
            var deletedemployee = dbContext.Employees.Find(id);

            if (deletedemployee is null) {

                return NotFound();

            }

            dbContext.Employees.Remove(deletedemployee);

            dbContext.SaveChanges();

            return Ok(deletedemployee);
        }

        //We Need to Add jwt Token Generation logic.
    }
}
