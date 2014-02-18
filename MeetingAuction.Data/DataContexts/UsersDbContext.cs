using System.Data.Entity;
using MeetingAuction.Data.Entities;

namespace MeetingAuction.Data.DataContexts
{
    class UsersDbContext : DbContext
    {
        public UsersDbContext()
            : base("DefaultConnection")
        {
        }
        public IDbSet<User> Addresses { get; set; }
    }
}
