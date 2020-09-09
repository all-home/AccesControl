using System;
using System.Collections.Generic;
using System.Text;
using WorkersDB.Interfaces;
using WorkersDB.Models;

namespace WorkersDB
{
    public class SatisticsRepository : IStat
    {
        private StatisticsContext Context;

        public SatisticsRepository(StatisticsContext _context)
        {
            Context = _context;
        }

        public IEnumerable<Statistics> Get()
        {
            return Context.StatItems;
        }
        
        public void Create(Statistics item)
        {
            Context.StatItems.Add(item);
            Context.SaveChanges();
        }
               
        public Statistics Get(int id)
        {
            return Context.StatItems.Find(id);
        }

        public Statistics Delete(int id)
        {
            Statistics Stat = Get(id);

            if (Stat != null)
            {
                Context.StatItems.Remove(Stat);
                Context.SaveChanges();
            }

            return Stat;
        }
    }
}
