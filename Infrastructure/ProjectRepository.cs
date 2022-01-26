using EmployeeManagementSystem.Models;
using EmployeeManagementSystem.Infrastructure;

namespace EmployeeManagementSystem.Infrastructure
{
    public class ProjectRepository : ICRUDRepository<Projects, int>
    {
        EmployeeDbContext _db;

        public ProjectRepository(EmployeeDbContext db)
        {
            _db = db;
        }

        public IEnumerable<Projects> GetAll()
        {
            return _db.Project.ToList();
        }

        public Projects GetDetails(int id)
        {
             return _db.Project.FirstOrDefault(c=>c.ProjectId==id);
        }
        public void Create(Projects item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void update(Projects item)
        {
            throw new NotImplementedException();
        }
    }
}