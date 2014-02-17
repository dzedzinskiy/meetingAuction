using System;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Web.Security;

namespace MeetingAuction.Data.Entities
{
    public static class PasswordTools
    {
        private static string PASSWORD8 = @"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{8,}$";
        private static string NOCHARPAIRS = @"(.)(?=\1)";


        public static string CreateSalt()
        {
            byte[] data = new byte[0x10];
            new RNGCryptoServiceProvider().GetBytes(data);
            return Convert.ToBase64String(data);
        }

        public static string EncodeString(string password, string salt)
        {
            byte[] bytes = Encoding.Unicode.GetBytes(password);
            byte[] src = Convert.FromBase64String(salt);
            byte[] dst = new byte[src.Length + bytes.Length];
            byte[] inArray = null;
            Buffer.BlockCopy(src, 0, dst, 0, src.Length);
            Buffer.BlockCopy(bytes, 0, dst, src.Length, bytes.Length);

            HashAlgorithm algorithm = HashAlgorithm.Create(Membership.HashAlgorithmType);
            inArray = algorithm.ComputeHash(dst);

            return Convert.ToBase64String(inArray);
        }

        /// <summary>
        /// Validates the password against the rules
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        public static bool IsValidPassword(string password)
        {
            return (Regex.IsMatch(password, PASSWORD8) && !Regex.IsMatch(password, NOCHARPAIRS));
        }

        public static string ValidatePasswordWithMessage(string password)
        {
            StringBuilder message = new StringBuilder();

            if (string.IsNullOrWhiteSpace(password) || !Regex.IsMatch(password, PASSWORD8))
            {
                message.AppendLine("Password should contain at least 8 alphanumeric characters.");
            }
            if (!string.IsNullOrWhiteSpace(password) && Regex.IsMatch(password, NOCHARPAIRS))
            {
                message.AppendLine("Password should have no pairs of repeating characters.");
            }

            return message.ToString();
        }
    }
}
