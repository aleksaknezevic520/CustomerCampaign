using System.Security.Cryptography;

namespace CustomerCampaign.SOAP.Helpers
{
    public static class PasswordHelper
    {
        public static (string hashedPassword, string salt) HashPassword(string password)
        {
            byte[] saltBytes = new byte[16];
            RandomNumberGenerator.Fill(saltBytes);
            string salt = Convert.ToBase64String(saltBytes);

            using (var rfc2898DeriveBytes = new Rfc2898DeriveBytes(password, saltBytes, 10000, HashAlgorithmName.SHA256))
            {
                byte[] hash = rfc2898DeriveBytes.GetBytes(32);
                string hashedPassword = Convert.ToBase64String(hash);
                return (hashedPassword, salt);
            }
        }

        public static bool VerifyPassword(string enteredPassword, string storedHash, string storedSalt)
        {
            byte[] saltBytes = Convert.FromBase64String(storedSalt);

            using (var rfc2898DeriveBytes = new Rfc2898DeriveBytes(enteredPassword, saltBytes, 10000, HashAlgorithmName.SHA256))
            {
                byte[] hash = rfc2898DeriveBytes.GetBytes(32);
                string enteredHash = Convert.ToBase64String(hash);
                return enteredHash == storedHash;
            }
        }
    }
}
