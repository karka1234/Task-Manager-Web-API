using static Task_Manager_Web_API.Enums.Enums;

namespace Task_Manager_Web_API.Services
{
    public interface IJwtService
    {
        public string GetJwtToken(string username, Role role);
    }
}