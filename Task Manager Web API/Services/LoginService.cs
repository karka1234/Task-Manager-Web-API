using System.Security.Cryptography;
using System.Text;
using Task_Manager_Web_API.Database;
using Task_Manager_Web_API.Enums;
using Task_Manager_Web_API.Models;

namespace Task_Manager_Web_API.Services
{
    public class LoginService : ILoginService
    {
        private readonly AppDbContext _context;
        public LoginService(AppDbContext context)
        {
            _context = context;
        }

        public User CreateUser(string userName, string password, JobTitle jobTitle)
        {
            CreatePasswordHash(password, out byte[] passwordHash, out byte[] passwordSalt);
            return new User
            {
                UserName = userName,
                Password = passwordHash,
                PasswordSalt = passwordSalt,
                Job = jobTitle                
            };
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using var hmac = new HMACSHA256();
            passwordSalt = hmac.Key;
            passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
        }

        public bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using var hmac = new HMACSHA256(passwordSalt);
            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            return computedHash.SequenceEqual(passwordHash);
        }
    }
}
