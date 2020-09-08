using BusinessLogic.Models;
using System.Collections.Generic;
using WorkersDB.Models;

namespace BusinessLogic.Interfaces
{
    public interface IWorkersRepo
    {
        IEnumerable<Worker> Get();
        Worker Get(int id);
        void Create(WorkerModel item);
        void Delete(int id);
        void Update(WorkerModel item);
        
    }
}
