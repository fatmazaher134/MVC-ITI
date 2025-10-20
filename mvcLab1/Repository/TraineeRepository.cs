using Microsoft.EntityFrameworkCore;

namespace mvcLab1.Repository
{
    public class TraineeRepository : ITraineeRepository
    {
        private readonly ITIDBContext _context;
        public TraineeRepository(ITIDBContext context)
        {
            _context = context;
        }
        public void Add(Trainee entity)
        {
            _context.Trainees.Add(entity);
        }
        public void Delete(int id)
        {
            var trainee = GetById(id);
            if (trainee != null)
            {
                _context.Trainees.Remove(trainee);
            }
        }
        public List<Trainee> GetAll(string include = null)
        {
            if (include != null)
            {
                return _context.Trainees.Include(t => t.Department)
                    .Include(include)
                    .ToList();
            }

            return _context.Trainees.ToList();
        }
        public Trainee? GetById(int id, String include = null)
        {
            if (include != null)
            {
                return _context.Trainees.Include(t => t.Department)
                                     .FirstOrDefault(t => t.Id == id);
            }
            return _context.Trainees.Find(id);
        }
        public void Update(Trainee entity)
        {
            _context.Trainees.Update(entity);
        }
        public void SaveChangesToDB()
        {
            _context.SaveChanges();
        }

        public List<Trainee> GetTraineesByCourseID(int courseId)
        {
            List<Trainee> trainees = _context.Trainees
                .Where(t => _context.CrsResults
                    .Any(cr => cr.TraineeId == t.Id && cr.CourseId == courseId))
                .ToList();
            return trainees;
        }
        public CrsResult? GetCrsResultByTraineeIdAndCourseId(int traineeId, int courseId)
        {
            return _context.CrsResults
                .Include(cr => cr.Trainee)
                .Include(cr => cr.Course)
                .FirstOrDefault(cr => cr.TraineeId == traineeId && cr.CourseId == courseId);
        }
    }
}
