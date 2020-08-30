using Microsoft.EntityFrameworkCore;

namespace WorkersDB.Models
{
    public class WorkerContext : DbContext
    {
        public WorkerContext(DbContextOptions<WorkerContext> options) 
            : base(options)
            {
            Database.EnsureCreated();
            }
        public DbSet<Worker> WorkersItems { get; set; }
        public DbSet<Statistics> StatItems { get; set; }

    }
}
