using Microsoft.EntityFrameworkCore;

namespace CacheServer.Models
{

    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
    : base(options)
        {

        }
        public DbSet<product> products { get; set; }
        public DbSet<ExecuteTime> executetimes { get; set; }
    }
}
