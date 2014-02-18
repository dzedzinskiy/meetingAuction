using System;
using MeetingAuction.Data.Entities;

namespace MeetingAuction.Data.Interfaces
{
    public interface IUser
    {
        int Id { get; set; }
        string Login { get; set; }
        string FirstName { get; set; }
        string FatherName { get; set; }
        string LastName { get; set; }
        string NickName { get; set; }
        string FullName { get; }
        string Email { get; set; }
        bool IsMale { get; set; }
        bool IsAdmin { get; set; }
        string Notes { get; set; }
        string TimeZoneInfoId { get; set; }
        string UserDateFormat { get; set; }
        string UserTimeFormat { get; set; }
        string Password { get; set; }
        string PasswordQuestion { get; set; }
        string PasswordAnswer { get; set; }
        bool IsActive { get; set; }
        DateTime CreatedDate { get; set; }
        int? ProfileId { get; set; }
        Profile Profile { get; set; }
        string RunFullValidation();

    }
}
