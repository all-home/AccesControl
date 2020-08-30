using Microsoft.EntityFrameworkCore;

namespace FileSave.Models
{
    public class FileContext : DbContext
    {
        public FileContext(DbContextOptions<FileContext> options)
          : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Files> FileItems { get; set; }
    }
}
