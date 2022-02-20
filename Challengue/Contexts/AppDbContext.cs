using Challengue.Entities;
using Microsoft.EntityFrameworkCore;


namespace Challengue.Contexts
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { } 
        public DbSet<User> User { get; set; }

        
    }
}
