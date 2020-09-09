using ProfilesDB.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.Interfaces
{
    public interface IProfiles
    {
        IEnumerable<Profile> Get();
        Profile Get(int id);
        void Remove(int id);
        void Update(Profile _profile);
        void Create(Profile _profile);
        Profile GetActive(); 
        
    }
}
