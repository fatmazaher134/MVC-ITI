using Microsoft.EntityFrameworkCore;

namespace mvcLab1.Repository
{
    public class InstructorRepository : IInstructorRepository
    {
        ITIDBContext _context;
        public InstructorRepository(ITIDBContext iTIDBContext)
        {
            _context = iTIDBContext;
        }
        public void Add(Instractore entity)
        {
            _context.Instractores.Add(entity);

        }

        public void Delete(int id)
        {
            Instractore instractore = GetById(id);
            if (instractore != null)
            {
                _context.Instractores.Remove(instractore);
            }
        }

        public List<Instractore> GetAll(string include = null)
        {
            if (include != null)
            {
                return _context.Instractores.Include(c => c.Department)
                    .Include(c => c.Course)
                    .ToList();
            }
            return _context.Instractores.ToList();
        }

        public void Update(Instractore entity)
        {
            Instractore instractore = GetById(entity.Id);
            if (instractore != null)
            {
                instractore.Name = entity.Name;
                instractore.Address = entity.Address;
                instractore.imageUrl = entity.imageUrl;
                instractore.Salary = entity.Salary;
                instractore.DepartmentId = entity.DepartmentId;
            }
        }
        public Instractore GetById(int id, string include = null)
        {
            if (include != null)
            {
                return _context.Instractores
                    .Include(c => c.Department)
                    .Include(c => c.Course)
                    .FirstOrDefault(i => i.Id == id);
            }
            return _context.Instractores.FirstOrDefault(i => i.Id == id);
        }

        public List<Instractore> SearchInstructorByName(string name)
        {
            return _context.Instractores
                .Where(i => i.Name.Contains(name)).ToList();
        }
        public void SaveChangesToDB()
        {
            _context.SaveChanges();
        }
    }
}
