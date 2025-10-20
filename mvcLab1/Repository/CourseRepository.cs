using Microsoft.EntityFrameworkCore;

namespace mvcLab1.Repository
{
    public class CourseRepository : ICourseRepository
    {
        ITIDBContext _context;
        public CourseRepository(ITIDBContext iTIDBContext)
        {
            _context = iTIDBContext;
        }
        public void Add(Course entity)
        {
            _context.Courses.Add(entity);
            

        }

        public void Delete(int id)
        {
            Course course = GetById(id);
            if (course != null)
            {
                _context.Courses.Remove(course);
            }
        }

        public List<Course> GetAll(string include = null)
        {
            if (include!= null)
            {
                return _context.Courses.Include(c => c.Department).ToList();
            }
            return _context.Courses.ToList();
        }

        public void Update(Course entity)
        {
            Course course = GetById(entity.Id);
            if (course != null)
            {
                course.Name = entity.Name;
                course.Degree = entity.Degree;
                course.MinDegree = entity.MinDegree;
                course.Hours = entity.Hours;
                course.DepartmentId = entity.DepartmentId;
            }
        }
        public Course GetById(int id, string include = null)
        {
            if (include != null)
            {
                return _context.Courses.Include(c => c.Department).FirstOrDefault(c => c.Id == id);
            }
            return _context.Courses.FirstOrDefault(c => c.Id == id);
        }

        
        public void SaveChangesToDB()
        {
            _context.SaveChanges();
        }
        public List<Course> GetCoursesByDeptId(int departmentId)
        {
            return _context.Courses.Where(c => c.DepartmentId == departmentId).ToList();
        }
    }
}
