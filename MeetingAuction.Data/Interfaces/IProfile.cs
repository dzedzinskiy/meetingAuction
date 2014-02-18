using System;
using System.Collections.Generic;
using MeetingAuction.Data.Entities;

namespace MeetingAuction.Data.Interfaces
{
    public interface IProfile
    {
        int Id { get; set; }
        DateTime? BirthDate { get; set; }
        string Phone { get; set; }
        string Email { get; set; }
        string Icq { get; set; }
        string Skype { get; set; }
        ICollection<UserPhone> Phones { get; set; }
        string WorkingPosition { get; set; }
        string Hobby { get; set; }
        string SmallBio { get; set; }
        string Interests { get; set; }
        ICollection<UserImage> Images { get; set; }
        string AvatarPath { get; set; }
        string Intro { get; set; }
        string Portfolio { get; set; }
        string AboutMe { get; set; }
        string Contact { get; set; }
        ICollection<SchoolDates> SchoolDates { get; set; }
        ICollection<UniversityDates> UniversityDates { get; set; }
        int? MedicalCardId { get; set; }
        MedicalCard MedicalCard { get; set; }
        Address Address { get; set; }
    }
}
