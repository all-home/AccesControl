using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace WorkersDB.Models
{
    public class StatisticsContext: DbContext
    {
        public StatisticsContext(DbContextOptions<StatisticsContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Statistics> StatItems { get; set; }
    }
}
