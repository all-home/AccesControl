using Microsoft.EntityFrameworkCore;

namespace ProfilesDB.Model
{
    class ProfileContext: DbContext
    {
        public ProfileContext(DbContextOptions<ProfileContext> options)
          : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<Profile> WorkersItems { get; set; }
    }
}
