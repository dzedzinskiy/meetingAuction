using System.Collections.Generic;
using MeetingAuction.Data.Entities;

namespace MeetingAuction.Data.Interfaces
{
    public interface IUserRepository
    {
        IList<User> GetUsers(int count = 0, bool joinAll = false);
        User GetUserByLogin(string login, bool joinAll = false);
        bool SaveUser(User user);
    }
}
