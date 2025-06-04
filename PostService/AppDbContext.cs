using PostService.DbEntities;
using Microsoft.EntityFrameworkCore;

namespace PostService
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Post> Posts { get; set; }
    }
}
