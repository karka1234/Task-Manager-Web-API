using Microsoft.AspNetCore.Mvc;
using Task_Manager_Web_API.Database;
using Task_Manager_Web_API.Enums;
using Task_Manager_Web_API.Models;

namespace Task_Manager_Web_API.Data
{
    public class UserRepository
    {
        private readonly AppDbContext _context;
        public UserRepository(AppDbContext context)
        {
            _context = context;
        }
        //get
        public IEnumerable<User> GetAllUsers() 
        {
            var users = _context.Users;
            return users;
        }

        public User GetUserById(Guid id)
        { 
            return _context.Users.FirstOrDefault(u => u.Id == id);
        }

        //add
        public void AddUser(User user) 
        { 
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        //set
        public void ChangeUserRoleById(Guid id, Role role)
        { 
            var user = GetUserById(id);
            user.AppRole = role;
            _context.SaveChanges();
        }

    }
}
