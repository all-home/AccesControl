using System;
using System.Collections.Generic;
using System.Text;
using WorkersDB.Interfaces;
using WorkersDB.Models;

namespace WorkersDB
{
    public class SatisticsRepository : IStat
    {
        private readonly StatisticsContext Context;

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

        public void Delete(IEnumerable<Statistics> Stat)
        {
           

            if (Stat != null)
            {
                Context.StatItems.RemoveRange(Stat);
                Context.SaveChanges();
            }
                        
        }

        public void Update(Statistics statistics)
        {
            Statistics _statistics = Get(statistics.id);

            _statistics.WorkerID = statistics.WorkerID;
            _statistics.StartWork = statistics.StartWork;
            _statistics.Latetime = statistics.Latetime;
            _statistics.Late = statistics.Late;
            _statistics.EndWork = statistics.EndWork;
           
            Context.StatItems.Update(_statistics);
            Context.SaveChanges();
        }
    }
}
