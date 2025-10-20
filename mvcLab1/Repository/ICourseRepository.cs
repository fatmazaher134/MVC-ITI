namespace mvcLab1.Repository
{
    public interface ICourseRepository : IReposetory<Course>
    {
        public List<Course> GetCoursesByDeptId(int deptId);
        public List<Course> GetCoursesByTraineeId(int traineeId);
    }
}
