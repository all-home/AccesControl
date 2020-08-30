using Microsoft.EntityFrameworkCore;
using DbContext = Microsoft.EntityFrameworkCore.DbContext;

namespace WorkersDB.Models
{
    public class WorkerContext : DbContext
    {
        public WorkerContext(DbContextOptions<WorkerContext> options) : base(options)
            {}
        public System.Data.Entity.DbSet<Worker> WorkersItems { get; set; }
        public System.Data.Entity.DbSet<Statistics> StatItems { get; set; }

    }
}
