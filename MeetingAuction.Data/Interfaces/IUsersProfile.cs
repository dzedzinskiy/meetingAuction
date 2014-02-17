using MeetingAuction.Data.Entities;

namespace MeetingAuction.Data.Interfaces
{
    public interface IUsersProfile
    {
        int Id { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        string NickName { get; set; }
        string FullName { get; }
        Address Address { get; set; }
    }
}
