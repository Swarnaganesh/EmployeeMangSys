using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EmployeeManagementSystem.Models;
using EmployeeManagementSystem.Infrastructure;

namespace EmployeeManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        [HttpGet("employee")]
        public Models.Employees GetEmployee()
        {
            Models.Employees obj = new Models.Employees{
                EmployeeId=1,
                LastName="R",
                FirstName="SSSS",
            };
           return obj;  
        }
       
    }
}