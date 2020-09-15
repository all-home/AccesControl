using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkersDB.Models;

namespace AccesControl.ViewModels
{
    public class WorkerDeatailModel
    {
        public IEnumerable<Statistics> CWorkerStat { get; set; }
        public Worker Worker { get; set; }

    }
}
