using Task_Manager_Web_API.Enums;
using Task_Manager_Web_API.Models;

namespace Task_Manager_Web_API.Data
{
    public interface IUserRepository
    {
        User ChangeUserRoleById(Guid id, Role role);
        void DeleteUser(Guid id);
        IEnumerable<User> GetAllUsers();
        IEnumerable<Assignment> GetUserAssignments(Guid id);
        User GetUserById(Guid id);
        User GetUserByUserName(string userName);
        bool Login(string userName, string password);
        User RegisterNewUser(string userName, string password, JobTitle jobTitle);
    }
}