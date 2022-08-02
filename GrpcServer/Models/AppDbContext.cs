using Microsoft.EntityFrameworkCore;

namespace GrpcServer.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
    : base(options)
        {

        }
        public DbSet<product> products { get; set; }
    }
}
