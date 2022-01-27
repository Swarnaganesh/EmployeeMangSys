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
        public Models.Project GetProject()
        {
            Models.Project obj = new Models.Project{
                ProjectId=1,
                ProjectName="R",
                ProjectDescription="SSSS",
            };
           return obj;  
        }
       
    }
}