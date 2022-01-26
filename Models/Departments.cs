using System.ComponentModel.DataAnnotations;
namespace EmployeeManagementSystem.Models
{
    public class Department
    {
        [Key]
        public int DepartmentId{get; set;}
        public string? DepartmentName{get; set;}
        public string? DepartmentLocation{get; set;}
    }
}
