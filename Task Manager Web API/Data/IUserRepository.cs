using Microsoft.EntityFrameworkCore;
using static Task_Manager_Web_API.Enums.Enums;
using Task_Manager_Web_API.Models;

namespace Task_Manager_Web_API.Data
{
    public interface IUserRepository
    {
        public void ChangeUserRoleById(Guid id, Role role);
        public IEnumerable<User> GetAllUsers();
        public User GetUserById(Guid id);
        public User GetUserByUserName(string userName);
        public IEnumerable<Assignment> GetUserAssignments(Guid id);
        public void DeleteUser(Guid id);
    }
}