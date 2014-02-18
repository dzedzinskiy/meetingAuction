using System;
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
        private readonly UsersDbContext _db = new UsersDbContext();
        private readonly Repository<User> _repo;

        public UserRepository()
        {
            _repo = new Repository<User>(_db);
        }

        public User GetUserByLogin(string login, bool joinAll = false)
        {
            var profile = _repo.SearchFor(_ => _.Login == login);
            if (joinAll)
            {
                profile.Include(_ => _.Profile)
                             .Include(_ => _.Profile.Phones)
                             .Include(_ => _.Profile.Images)
                             .Include(_ => _.Profile.SchoolDates)
                             .Include(_ => _.Profile.UniversityDates)
                             .Include(_ => _.Profile.MedicalCard);
            }
            return profile.FirstOrDefault();
        }

        public IList<User> GetUsers(int count = 0, bool joinAll = false)
        {
            IQueryable<User> usersProfiles = _repo.GetAll();
            if (joinAll)
            {
                usersProfiles.Include(_ => _.Profile)
                             .Include(_ => _.Profile.Phones)
                             .Include(_ => _.Profile.Images)
                             .Include(_ => _.Profile.SchoolDates)
                             .Include(_=>_.Profile.UniversityDates)
                             .Include(_=>_.Profile.MedicalCard);
            }
            if (count>0) return usersProfiles.Take(count).ToList();

            return usersProfiles.ToList();
        }

        public bool SaveUser(User user)
        {
            bool success = true;
            try
            {
                _repo.Insert(user);
                _db.SaveChanges();
            }
            catch (Exception)
            {
                success = false;
            }
            return success;
        }
    }
}
