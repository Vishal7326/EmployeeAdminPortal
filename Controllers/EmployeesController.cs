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
    //localhost:xxxx/api/employees
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

        [HttpPost] // This Method is used to add the properties to the table.
        //We Define the action method.

        public IActionResult AddEmployee(AddEmployeeDto addEmployeeDto) 
        {
            //Defining Method Structure.

            // To add an employee we need the details of the employee. which is in employee class. 

            //For this we use Dto data transfer objects - which transfer data from one operation to another.

            //The DBContext Class that we use to add this employee only accept the entities over here.

            var employeeEntity = new Employee()
            {
                Name = addEmployeeDto.Name,
                Email = addEmployeeDto.Email,
                Phone = addEmployeeDto.Phone,
                Salary = addEmployeeDto.Salary
            };

            dbContext.Employees.Add()


        }
    }
}
