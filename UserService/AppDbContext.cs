using UserService.DbEntities;
using Microsoft.EntityFrameworkCore;

namespace UserService
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Destination> Destinations { get; set; }
    }
}
