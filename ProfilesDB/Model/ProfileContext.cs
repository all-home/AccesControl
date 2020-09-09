using Microsoft.EntityFrameworkCore;

namespace ProfilesDB.Model
{
    public class ProfileContext: DbContext
    {
        public ProfileContext(DbContextOptions<ProfileContext> options)
          : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<Profile> ProfilesItems { get; set; }
    }
}
