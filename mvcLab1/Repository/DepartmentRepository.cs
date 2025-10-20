
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
            _context.Departments.Add(entity);
        }

        public void Delete(int id)
        {
            Department dept = _context.Departments.Find(id);
            if (dept != null)
            {
                _context.Departments.Remove(dept);
            }
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
            if (include != null)
            {
                _context.Departments.Include(d => d.Courses).ToList();
            }
            return _context.Departments.Find(id);
        }

        public void SaveChangesToDB()
        {
            _context.SaveChanges();
        }

        public void Update(Department entity)
        {
            _context.Departments.Update(entity);
        }
    }
}
