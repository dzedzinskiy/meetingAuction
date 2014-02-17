using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using MeetingAuction.Data.DataContexts;
using MeetingAuction.Data.Entities;
using MeetingAuction.Data.Interfaces;

namespace MeetingAuction.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly UsersDbContext db = new UsersDbContext();
        private readonly Repository<UsersProfile> repo;

        public UserRepository()
        {
            repo = new Repository<UsersProfile>(db);
        }

        public UsersProfile GetUserProfileByLogin(string login)
        {
            var profile = repo.GetAll().FirstOrDefault(_ => _.Login == login);
            return profile;
        }

        public IList<UsersProfile> GetUsersProfiles(int count = 0)
        {
            var usersProfiles = repo.GetAll()
                .Include(_=>_.Address)
                .ToList();
            if (count>0) 
                return usersProfiles.Take(count).ToList();
            return usersProfiles;
        }

        public UsersProfile SaveUsersProfile(UsersProfile usersProfile)
        {
            repo.Insert(usersProfile);
            db.SaveChanges();
            return usersProfile;
        }
    }
}
