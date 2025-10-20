
using Microsoft.EntityFrameworkCore;

namespace mvcLab1.Repository
{
    public class DepartmentRepository : IDepartmentReposetory
    {
        ITIDBContext _context;
        public DepartmentRepository(ITIDBContext iTIDBContext)
        {
            _context = iTIDBContext;
        }
        public void Add(Department entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Department> GetAll(string include = null)
        {
            if (include != null) {
                _context.Departments.Include(d => d.Courses).ToList();
            }
            return _context.Departments.ToList();
        }

        public Department GetById(int id, string include = null)
        {
            throw new NotImplementedException();
        }

        public void SaveChangesToDB()
        {
            throw new NotImplementedException();
        }

        public void Update(Department entity)
        {
            throw new NotImplementedException();
        }
    }
}
