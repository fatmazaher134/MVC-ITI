namespace mvcLab1.Repository
{
    public interface IInstructorRepository : IReposetory<Instractore>
    {
        public List<Instractore> SearchInstructorByName(string name);
    }
}
