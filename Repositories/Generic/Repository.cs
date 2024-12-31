using Microsoft.EntityFrameworkCore;
using RepositoryNetAPI.Data;
using RepositoryNetAPI.Repositories.Interfaces;

namespace RepositoryNetAPI.Repositories
{
    public class Repository<T>(AppDbContext dbContext, DbSet<T> dbSet) : IRepository<T> where T : class
    {
        protected readonly AppDbContext _dbContext = dbContext;
        private readonly DbSet<T> _dbSet = dbSet;

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
    }
}
