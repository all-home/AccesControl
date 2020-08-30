using System.Collections.Generic;
using WorkersDB.Models;

namespace WorkersDB.Interfaces
{
    interface IStat
    {
        IEnumerable<Statistics> Get();
        Statistics Get(int id);
        void Create(Statistics item);
        void Update(Statistics item);
       
    }
}
