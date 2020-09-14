using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessLogic.Interfaces;
using ProfilesDB.Interfaces;
using ProfilesDB.Model;
using WorkersDB.Models;

namespace BusinessLogic.Profiles
{
    public class ProfileRepo : IProfiles
    {
        private readonly IProfileRepo profile;
        public ProfileRepo(IProfileRepo _profile)
        {
            profile = _profile;
        }
        public void Create(Profile _profile)
        {
            if (_profile.Active == false)
            {
                profile.Create(_profile);
            }
            else
            {
                Profile aprofile = GetActive();
                if (aprofile != null)
                {
                    aprofile.Active = false;
                    Update(aprofile);
                }
                    profile.Create(_profile);
                
            }
            
        }

        public IEnumerable<Profile> Get()
        {
            return profile.Get();
        }

        public Profile Get(int id)
        {
            return profile.Get(id);
        }

        public Profile GetActive()
        {
            var Profiles = profile.Get();

            return Profiles.FirstOrDefault(a=> a.Active == true);
        }

        public void Remove(int id)
        {
            profile.Delete(id);
        }

        public void Update(Profile _profile)
        {
            if (_profile.Active == false)
            {
                profile.Update(_profile);
            }
            else
            {
                Profile aprofile = GetActive();
                if (aprofile != null)
                {
                    aprofile.Active = false;
                    profile.Update(aprofile);
                }
                profile.Update(_profile);
            }
           
        }
                
    }
}
