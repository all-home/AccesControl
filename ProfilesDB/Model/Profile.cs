using System;

namespace ProfilesDB.Model
{
    public class Profile
    {
        int id { get; set; }
        string Name { get; set; }
        DateTime StartWorking { get; set; }
        DateTime EndWorking { get; set; }
    }
}
