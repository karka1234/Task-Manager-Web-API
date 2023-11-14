using Task_Manager_Web_API.Dto;
using Task_Manager_Web_API.Models;

namespace Task_Manager_Web_API.Services
{
    public interface ILoginService
    {
        public User RegisterNewUser(string userName, string password);
        public LoginResponseDTO Login(string userName, string password);
    }
}