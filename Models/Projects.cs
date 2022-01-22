namespace EmployeeManagementSystem.Models
{
    public class Projects
    {
        public int ProjectId{get; set;}
        public string ProjectName{get; set;}
        public string ProjectLocation{get; set;}
        public string ProjectDescription{get; set;}
        public DateTime StartDate{get; set;}
        public DateTime EndDate{get; set;}
    }
}