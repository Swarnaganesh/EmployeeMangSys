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
    public class ProjectController : ControllerBase
    {

 [HttpGet("project")]
        public Models.Projects GetProject()
        {
            Models.Projects obj = new Models.Projects{
                ProjectId=1,
                ProjectName="R",
                ProjectDescription="SSSS",
            };
           return obj;  
        }
       
    }
}