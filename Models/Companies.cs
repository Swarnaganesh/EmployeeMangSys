using System.ComponentModel.DataAnnotations;
namespace EmployeeManagementSystem.Models
{
    public class Company
    {
        [Key]
        public int CompanyId{get; set;}
        public string CompanyName{get; set;}
        public string? CompanyAddress{get; set;}
        public string? City{get; set;}
        public int? PostalCode{get; set;}
        public string? Country{get; set;}
    }
}