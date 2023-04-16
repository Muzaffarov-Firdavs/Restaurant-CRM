namespace Restaurant.Service.Helpers
{
    public class PasswordHasher
    {
        public static (string passwordHash, string salt) Hash(string password)
        {
            string salt = Guid.NewGuid().ToString();
            string strongPassword = salt + password;
            string passwordHash = BCrypt.Net.BCrypt.HashPassword(strongPassword);
            return (passwordHash, salt);
        }

        public static bool Verify(string password, string salt, string passwordHash)
        {
            string strongPassword = salt + password;
            return BCrypt.Net.BCrypt.Verify(strongPassword, passwordHash);
        }
    }
}
