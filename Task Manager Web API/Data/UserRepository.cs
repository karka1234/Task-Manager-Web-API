using Microsoft.AspNetCore.Mvc;
using Task_Manager_Web_API.Database;
using Task_Manager_Web_API.Enums;
using Task_Manager_Web_API.Models;
using Task_Manager_Web_API.Services;

namespace Task_Manager_Web_API.Data
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;
        private readonly ILoginService _loginService;

        public UserRepository(AppDbContext context, ILoginService loginService)
        {
            _context = context;
            _loginService = loginService;
        }
        //add
        public User RegisterNewUser(string userName, string password, JobTitle jobTitle)
        {
            var user = _loginService.CreateUser(userName, password, jobTitle);
            _context.Users.Add(user);
            _context.SaveChanges();
            return user;
        }
        //update
        public User ChangeUserRoleById(Guid id, Role role)
        {
            var user = GetUserById(id);
            user.AppRole = role;
            _context.SaveChanges();
            return user;
        }
        //delete
        public void DeleteUser(Guid id)
        {
            var user = GetUserById(id);
            _context.Users.Remove(user);
            _context.SaveChanges();
        }
        //get
        public bool Login(string userName, string password)
        {
            var user = GetUserByUserName(userName);
            if (user == null)
                return false;
            return _loginService.VerifyPasswordHash(password, user.Password, user.PasswordSalt);
        }
        public IEnumerable<User> GetAllUsers()
        {
            var users = _context.Users;
            return users;
        }
        public User GetUserById(Guid id)
        {
            return _context.Users.FirstOrDefault(u => u.Id == id);
        }
        public User GetUserByUserName(string userName)
        {
            return _context.Users.FirstOrDefault(u => u.UserName == userName);
        }
        public IEnumerable<Assignment> GetUserAssignments(Guid id)
        {
            var user = GetUserById(id);
            return user.Assignments;
        }
    }
}
