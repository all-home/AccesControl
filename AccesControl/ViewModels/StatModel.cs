using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccesControl.ViewModels
{
    public class StatModel
    {
        public DateTime StartWork { get; set; }
        public DateTime EndWork { get; set; }
        public string Latetime { get; set; }
        public bool Late { get; set; }
        public int WorkerID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
    }
}
