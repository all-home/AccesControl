using System;
using System.Collections.Generic;
using ProfilesDB.Interfaces;
using ProfilesDB.Model;

namespace ProfilesDB
{
    public class ProfilesRepo : IProfileRepo
    {
        private readonly ProfileContext context;
        public ProfilesRepo(ProfileContext _context)
        {
            context = _context;
        }
        public IEnumerable<Profile> Get()
        {
            return context.ProfilesItems;
        }
        public Profile Get(int id)
        {
            return context.ProfilesItems.Find(id);
        }

        public void Create(Profile item)
        {
            context.ProfilesItems.Add(item);
            context.SaveChanges();
        }

        public Profile Delete(int id)
        {
            Profile profile = Get(id);

            if (profile != null)
            {
                context.ProfilesItems.Remove(profile);
                context.SaveChanges();
            }
            return profile;
        }
             
        public void Update(Profile item)
        {
            Profile profileCurrent = Get(item.id);

            profileCurrent.Name = item.Name;
            profileCurrent.StartWorking = item.StartWorking;
            profileCurrent.Active = item.Active;
            profileCurrent.EndWorking = item.EndWorking;
            
            context.ProfilesItems.Update(profileCurrent);
            context.SaveChanges();
        }
    }
}
