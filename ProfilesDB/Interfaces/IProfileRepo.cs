using System;
using System.Collections.Generic;
using System.Text;
using ProfilesDB.Model;

namespace ProfilesDB.Interfaces
{
    public interface IProfileRepo
    {
        IEnumerable<Profile> Get();
        Profile Get(int id);
        void Create(Profile item);
        void Update(Profile item);
        Profile Delete(int id);
        Profile GetWorkerByTagID(int? TagID);

    }
}
