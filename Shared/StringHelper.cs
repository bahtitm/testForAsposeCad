using System.Text;

namespace Shared
{
    public static class StringHelper
    {
        public static string GetMd5Sum(string password)
        {
            string salt = "My_Salt";
            var bsalt = Encoding.UTF8.GetBytes(salt);
            var bpassword = Encoding.UTF8.GetBytes(password);
            var hmacMD5 = new System.Security.Cryptography.HMACMD5(bsalt);
            var saltedHash = hmacMD5.ComputeHash(bpassword);
            return Convert.ToBase64String(saltedHash);
        }
    }
}
