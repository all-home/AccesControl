using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.Models
{
    class StatisticsModel
    {
        public DateTime StartWork { get; set; }
        public DateTime EndWork { get; set; }
        public string Late { get; set; }
        public string Overtime { get; set; }
        public int WorkerID { get; set; }
    }
}
