using System.Collections.Generic;
using MeetingAuction.Data.Entities;

namespace MeetingAuction.Data.Interfaces
{
    public interface IUserRepository
    {
        IList<UsersProfile> GetUsersProfiles(int count = 0);
        UsersProfile GetUserProfileByLogin(string login);
        UsersProfile SaveUsersProfile(UsersProfile usersProfile);
    }
}
