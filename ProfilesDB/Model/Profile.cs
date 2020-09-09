using System;

namespace ProfilesDB.Model
{
    public class Profile
    {
        public int id { get; set; }
        public string Name { get; set; }
        public DateTime StartWorking { get; set; }
        public DateTime EndWorking { get; set; }
        public bool Active { get; set; }
    }
}
