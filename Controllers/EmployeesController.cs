using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EmployeeManagementSystem.Models;
using EmployeeManagementSystem.Infrastructure;
using System.Security.Claims;

namespace EmployeeManagementSystem.Controllers
{
    /*******************   CHANGED:  ******************************
Removed the Authorize attribute from here and moved it the  methods 
where the restrictions are required. 
******************************************************/
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        string userName;
        int userId;
        ICRUDRepository<Employee, int> _repository; 
        public EmployeesController( ICRUDRepository<Employee, int> repository ) => _repository = repository;
/************** CHANGES : ******************************************
* Add the Authorize attribute to the method 
* In the method, we are getting the Claim values like Name, NameIdentifier and Role 
* if the RoleName is not "admin" or any other role as required, 
*  then we are returning an Unauthorized() response back to the user.
* else valid response will be sent. 
********************************************************************/
        [Microsoft.AspNetCore.Authorization.Authorize()]
        public ActionResult<IEnumerable<Employee>> Get()
        {
//INclude the below 4 lines in every method.
            // userName = HttpContext.User.FindFirst(ClaimTypes.Name).Value;
            // userId = Convert.ToInt32("0" + HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);
            // var role = Convert.ToString(HttpContext.User.FindFirst(ClaimTypes.Role).Value);
            // if(role!="admin") 
            // {
            //     return Unauthorized();
            // }
//end of the code inclusion. 
           // if(userId==0) return BadRequest();
            var items = _repository.GetAll(); 
            return items.ToList();
        }
        //URL: /api/employees/1   
        //try with id parameter values between 1 and 9 
        [HttpGet("{id}")]
        public ActionResult<Employee> GetDetails(int id) 
        {
            var  item = _repository.GetDetails(id);
            if( item==null )
                return NotFound();
            return item;
        }
    // [HttpGet("employee")]
        // public Models.Employee GetEmployee()
        // {
        //     Models.Employee obj = new Models.Employee{
        //         EmployeeId= 12,
        //         FirstName = "RRR",
        //     };
        //     return obj;
        // }
        [HttpPost("register")]
        public ActionResult<Employee> Create(Employee emp)
        {
            userName = HttpContext.User.FindFirst(ClaimTypes.Name).Value;
            userId = Convert.ToInt32("0" + HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);
            var role = Convert.ToString(HttpContext.User.FindFirst(ClaimTypes.Role).Value);
            if(role!="newemployee") 
            {
                return Unauthorized();
            } 
            if(userId==0) return BadRequest();
            if(emp==null)
                return BadRequest();
            _repository.Create(emp);
            return emp;
        }

        [HttpPut("update/{id}")]
        public ActionResult<Employee> update(int id, Employee emp)
        {
            userName = HttpContext.User.FindFirst(ClaimTypes.Name).Value;
            userId = Convert.ToInt32("0" + HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);
            var role = Convert.ToString(HttpContext.User.FindFirst(ClaimTypes.Role).Value);
            if(role!="employee"&& role!="newemployee")
            { 
                return Unauthorized();
            }
            if(userId==0) return BadRequest();
            if(id==0)   return BadRequest();
            if(emp==null)
                return BadRequest();
            _repository.update(emp);
            return emp;
        }
        [HttpDelete("remove/{id}")]
        public ActionResult<Employee> Delete(int id)
        {
             userName = HttpContext.User.FindFirst(ClaimTypes.Name).Value;
            userId = Convert.ToInt32("0" + HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);
            var role = Convert.ToString(HttpContext.User.FindFirst(ClaimTypes.Role).Value);
            if(role!="admin") 
            {
                return Unauthorized();
            }
//end of the code inclusion. 
            if(userId==0) return BadRequest();
            _repository.Delete(id);
            return Ok();
        }
    
}
}