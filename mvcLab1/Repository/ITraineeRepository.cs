namespace mvcLab1.Repository
{
    public interface ITraineeRepository : IReposetory<Trainee>
    {
        public List<Trainee> GetTraineesByCourseID(int courseId);
        public CrsResult? GetCrsResultByTraineeIdAndCourseId(int traineeId, int courseId);
    }
}
