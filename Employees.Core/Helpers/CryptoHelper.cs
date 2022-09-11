using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Employees.Core.Helpers
{
    public static class CryptoHelper
    {
        public static byte[] GetSalt()
        {
            byte[] salt;
             using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(salt = new byte[16]);
            }
            return salt;
        }
        public static string GetHash(string password, byte[] salt)
        {
            string hashPassword;
            

            using (SHA512 sha512 = new SHA512Managed())
            {

                var passwordBytes = Encoding.UTF8.GetBytes(password);
                var passwordWithSalt = new byte[salt.Length + passwordBytes.Length];
                salt.CopyTo(passwordWithSalt, 0);
                passwordBytes.CopyTo(passwordWithSalt, salt.Length);
                hashPassword = Encoding.UTF8.GetString(sha512.ComputeHash(passwordWithSalt));
            }
            return hashPassword;
        }
    }
}
