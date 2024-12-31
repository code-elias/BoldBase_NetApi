namespace RepositoryNetAPI.Repositories.Interfaces
{
    public interface IRepository<T> where T : class
    {
        T GetById(object id);

        IEnumerable<T> GetAll();
        //IEnumerable<T> GetAllByProperty(string property, string propertyValue);

        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        int DeleteById(object id);
        void Save();
    }
}
