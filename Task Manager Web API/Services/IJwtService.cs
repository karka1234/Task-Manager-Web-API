namespace Task_Manager_Web_API.Services
{
    public interface IJwtService
    {
        string GetJwtToken(string username);
    }
}