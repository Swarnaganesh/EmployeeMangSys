using Microsoft.EntityFrameworkCore;
using EmployeeManagementSystem.Infrastructure;
using EmployeeManagementSystem.Models;
using Microsoft.AspNetCore.Authentication.Cookies;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<EmployeeManagementSystem.Infrastructure.EmployeeManagementDBContext>
(
    options=> options.UseSqlServer(
        connectionString:
        "server=(local);database=EmployeeManagementDB;integrated security=sspi"
    )
);


builder.Services.AddScoped<ICRUDRepository<Project, int>, ProjectRepository>();
builder.Services.AddScoped<ICRUDRepository<Department, int>, DepartmentRepository>();
builder.Services.AddScoped<ICRUDRepository<Employee, int>, EmployeeRepository>();
builder.Services.AddScoped<ICRUDRepository<Company, int>, CompanyRepository>();
builder.Services.AddScoped<ICRUDRepository<User, int>, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>(); 
//builder.Services.AddHttpContextAccessor();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options => {
        options.ExpireTimeSpan = TimeSpan.FromMinutes(10);
        options.SlidingExpiration = true; // 10 minutes from the last access
        //options.LoginPath = "~/account/login";
    });
// Add services to the container.

// Add services to the container.  

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

}
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();
