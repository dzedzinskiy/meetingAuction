using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Text.RegularExpressions;
using MeetingAuction.Data.Interfaces;

namespace MeetingAuction.Data.Entities
{
    [Table("UsersProfile")]
    public class UsersProfile : IUsersProfile
    {
        public const string UserNameAlreadyExistsMessage = "Provided User Name already exists.";
        public const string InvalidUserName = "User Name is empty or contains invalid characters or over 256 characters long.";
        public const string WrongEmailFormatFlag = "Email format flag accepts only 0 or 1 as its value.";
        public const string DuplicatedEmail = "Provided e-mail is already used.";

        [Key]
        public int Id { get; set; }
        public string Login { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NickName { get; set; }
        public string FullName {
            get
            {
                return (new StringBuilder())
                    .AppendFormat("{0} {1}", FirstName, LastName)
                    .ToString();
            }
        }
        public int Age { get; set; }
        public bool Male { get; set; }
        public string Email { get; set; }
        public int EmailFormat { get; set; }
        public string TimeZoneInfoId { get; set; }
        public string UserDateFormat { get; set; }
        public string UserTimeFormat { get; set; }
        public string Password { get; set; }
        public string PasswordQuestion { get; set; }
        public string PasswordAnswer { get; set; }
        public bool IsActive { get; set; }
        public string PhoneType { get; set; }
        public string PhoneNumber { get; set; }
        public int? AddressId { get; set; }
        public string AvatarPath { get; set; }
        public string WorkPost { get; set; }

        public int WorkProfileId { get; set; }

        [ForeignKey("AddressId")]
        public Address Address { get; set; }

        [ForeignKey("WorkProfileId")]
        public WorkProfile WorkProfile { get; set; }


        public string RunFullValidation()
        {
            StringBuilder validationResult = new StringBuilder();

            HashSet<string> errors = new HashSet<string>();

            errors.Add(ValidateUserName(FullName));
            errors.Add(ValidateUserRealNames(FirstName, "First Name"));
            errors.Add(ValidateUserRealNames(LastName, "Last Name"));
            errors.Add(PasswordTools.ValidatePasswordWithMessage(Password));
            errors.Add(ValidateNotNullAndLenght(PasswordQuestion, "Security Question", 256));
            errors.Add(ValidateNotNullAndLenght(PasswordAnswer, "Security Answer", 128));
            errors.Add(ValidateNotNullAndLenght(TimeZoneInfoId, "Time Zone", 100));
            errors.Add(ValidateNotNullAndLenght(UserDateFormat, "Date Format", 50));
            errors.Add(ValidateNotNullAndLenght(UserTimeFormat, "Time Format", 50));
            errors.Add(ValidateMailFormat(EmailFormat));

            errors.Remove(string.Empty);

            foreach (string error in errors)
            {
                validationResult.AppendLine(error);
            }

            return validationResult.ToString();
        }
        private static string ValidateUserName(string userName)
        {
            string result = string.Empty;
            if (string.IsNullOrWhiteSpace(userName) || !Regex.IsMatch(userName, @"^\w{1,256}$"))
            {
                result = InvalidUserName;
            }
            return result;
        }
        private static string ValidateUserRealNames(string input, string propertyName)
        {
            string result = string.Empty;
            if (string.IsNullOrWhiteSpace(input) || !Regex.IsMatch(input, @"^[\w\s]{1,50}$"))
            {
                result = string.Format("{0} is not valid. Must be letters and spaces up to 50 characters.", propertyName);
            }
            return result;
        }

        private static string ValidateNotNullAndLenght(string property, string propertyName, int maxLenght)
        {
            string result = string.Empty;
            if (string.IsNullOrWhiteSpace(property) || property.Length > maxLenght)
            {
                result = string.Format("{0} is either empty or exeeds {1} characters.", propertyName, maxLenght);
            }
            return result;
        }

        private static string ValidateMailFormat(int emailFormat)
        {
            string result = string.Empty;
            if (emailFormat < 0 || emailFormat > 1) result = WrongEmailFormatFlag;
            return result;
        }
    }
}
