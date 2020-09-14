using System;
using System.Collections.Generic;
using System.Text;

namespace WorkersDB.Models
{
     //class contain Person stat
    public class Statistics
    {
        public int id { get; set; }
        public DateTime StartWork { get; set; }
        public DateTime EndWork { get; set; }
        public string Latetime { get; set; }
        public bool Late { get; set; }
        public int WorkerID { get; set; }

    }
}
