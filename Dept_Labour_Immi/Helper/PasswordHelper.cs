using System.Buffers.Text;
using System.Text;

namespace Dept_Labour_Immi.Helper
{
    public class PasswordHelper
    {
        public static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            if (password == null) throw new ArgumentNullException("password");
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");

            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        public static bool VerifyPasswordHash(string password, byte[] storedHash, byte[] storedSalt)
        {
            if (password == null || storedHash == null || storedSalt == null) throw new ArgumentNullException("password");
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");
            
            using (var hmac = new System.Security.Cryptography.HMACSHA512(storedSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));               
                return computedHash.SequenceEqual(storedHash);
            }
        }

        public static bool ProveAdminVerify(string password, string encodePassword)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(password);
            var encodedPassword = System.Convert.ToBase64String(plainTextBytes);

            return encodedPassword.Equals(encodePassword);


        }
    }
}
