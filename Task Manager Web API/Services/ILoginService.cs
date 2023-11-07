using Task_Manager_Web_API.Enums;
using Task_Manager_Web_API.Models;

namespace Task_Manager_Web_API.Services
{
    public interface ILoginService
    {
        public User CreateUser(string userName, string password, JobTitle jobTitle);
        public bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt);
    }
}