using System.Collections.Generic;
using WorkersDB.Models;

namespace WorkersDB.Interfaces
{
    public interface IStat
    {
        IEnumerable<Statistics> Get();
        Statistics Get(int id);
        void Create(Statistics item);
        void Delete(IEnumerable <Statistics> Stat);

        void Update(Statistics statistics);

    }
}
