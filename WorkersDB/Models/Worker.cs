using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WorkersDB.Models
{
  public class Worker
    {
        public int id { get; set; }
        public int TagId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public string Tel { get; set; }
        public string Position { get; set; }
        public string Image { get; set; }
    }

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
