using System.ComponentModel.DataAnnotations;
namespace EmployeeManagementSystem.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeId{get; set;}
        public string? LastName{get; set;}
        public string? FirstName{get; set;}
        public DateTime? BirthDate{get; set;}
        public DateTime? HireDate{get; set;}
        public string? Address{get; set;}
        public string? City{get; set;}
        public string? Region{get; set;}
        public int? PostalCode{get; set;}
        public string? Country{get; set;}
        public int? HomePhone{get; set;}
        public int? DepartmentId{get; set;}
        public int? ProjectId{get; set;}
    }
}