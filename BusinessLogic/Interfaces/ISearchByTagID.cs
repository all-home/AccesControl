using System;
using System.Collections.Generic;
using System.Text;
using WorkersDB.Models;

namespace BusinessLogic.Interfaces
{
    public interface ISearchByTagID
    {
        public Worker GetWorker(int? TagID);
    }
}
