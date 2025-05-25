using EmployeeAdminPortal.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Injecting the DbContext Class that we created to establish the connection with the databse and we an use it inside the controller or anyother class inside our application.
//In AddDbContext we are passing the type of the DbContext Class that we have created inside the data folder in this case it is ApplicationDbContext.
builder.Services.AddDbContext<ApplicationDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//Adding JWT Authentiction.

builder.Services.AddAuthentication(options => // This Method add authentication to the web application this method is responsible for adding jwt authentication.
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme; // authorizes the user based on the based on the tokens of the each user.
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme; //So this 2 methods does the work of authorization at the backend.
})
.AddJwtBearer(options => //This method takes some parameter to authenticate the issuer , Audience , Lifetime.
{
    options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
    };
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

//Migrations is a way for the application to create some files in C# classes in the program  and execute this files and then convert them to sql to create  a new database and new table.
