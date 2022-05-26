namespace Erebor.Repositories
{
    public interface CrudRepository<T>
    {
        public List<T> GetAll();
        public T GetById(int id);
        public T Save(T entity);
        public void Delete(T entity);
    }
}