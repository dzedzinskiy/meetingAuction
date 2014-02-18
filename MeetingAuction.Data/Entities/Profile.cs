using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using MeetingAuction.Data.Interfaces;

namespace MeetingAuction.Data.Entities
{
    public class Profile : IProfile
    {
        public int Id { get; set; }
        public DateTime? BirthDate { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Icq { get; set; }
        public string Skype { get; set; }
        public ICollection<UserPhone> Phones { get; set; }
        public string WorkingPosition { get; set; }
        public string Hobby { get; set; }
        public string SmallBio { get; set; }
        public string Interests { get; set; }
        public ICollection<UserImage> Images { get; set; }
        public string AvatarPath { get; set; }
        public string Intro { get; set; }
        public string Portfolio { get; set; }
        public string AboutMe { get; set; }
        public string Contact { get; set; }
        public ICollection<SchoolDates> SchoolDates { get; set; }
        public ICollection<UniversityDates> UniversityDates { get; set; }
        public int? MedicalCardId { get; set; }
        public int? AddressId { get; set; }

        [ForeignKey("MedicalCardId")]
        public MedicalCard MedicalCard { get; set; }

        [ForeignKey("AddressId")]
        public Address Address { get; set; }
    }
}
