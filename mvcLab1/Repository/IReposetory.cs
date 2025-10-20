namespace mvcLab1.Repository
{
    public interface IReposetory<T> 
    {
        public List<T> GetAll(string Include = null);

        public void Add(T entity);
        public void Update(T entity);
        public void Delete(int id);

        public T GetById (int id, string include = null);

        public void SaveChangesToDB();
    }
}
