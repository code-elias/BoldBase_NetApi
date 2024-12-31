using Microsoft.EntityFrameworkCore;
using RepositoryNetAPI.Models;

namespace RepositoryNetAPI.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<User> Users { get; set; }
    }
}
