using Microsoft.EntityFrameworkCore;
using RepositoryNetAPI.Data;
using RepositoryNetAPI.Repositories.Interfaces;

namespace RepositoryNetAPI.Repositories.EF
{
    public class Repository<T>(AppDbContext dbContext) : IRepository<T> where T : class
    {
        protected readonly AppDbContext _dbContext = dbContext;
        private readonly DbSet<T> _dbSet = dbContext.Set<T>();

        public void Add(T entity)
        {
            _dbSet.Add(entity);
        }

        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }

        public int DeleteById(object id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetAll()
        {
            return _dbSet.ToList();
        }

        public T GetById(object id)
        {
            return _dbSet.Find(id);
        }

        public void Update(T entity)
        {
            _dbSet.Update(entity);
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}
