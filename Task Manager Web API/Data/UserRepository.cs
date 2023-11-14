using Microsoft.AspNetCore.Mvc;
using Task_Manager_Web_API.Database;
using Task_Manager_Web_API.Dto;
using static Task_Manager_Web_API.Enums.Enums;
using Task_Manager_Web_API.Models;
using Task_Manager_Web_API.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace Task_Manager_Web_API.Data
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;        

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        //update
        public void ChangeUserRoleById(Guid id, Role role)  //try catch idet ? 
        {
            var user = GetUserById(id);
            if (user == null)
                throw new Exception("User does not exist");
            user.AppRole = role;
            _context.SaveChanges();
        }
        //delete
        public void DeleteUser(Guid id)
        {
            var user = GetUserById(id);
            if (user == null)
                throw new Exception("User does not exist");
            _context.Users.Remove(user);
            _context.SaveChanges();
        }
        //get

        public IEnumerable<User> GetAllUsers()//butina autoricuoti nes ktiaip nesaugu
        {
            var users = _context.Users;
            if (users == null)
                throw new Exception("Users does not exist");
            return users;
        }
        public User GetUserById(Guid id)
        {
            return _context.Users.SingleOrDefault(u => u.Id == id);
        }
        public User GetUserByUserName(string userName)
        {
            return _context.Users.SingleOrDefault(u => u.UserName == userName);
        }
        public IEnumerable<Assignment> GetUserAssignments(Guid id)
        {
            var user = _context.Users.Where(u => u.Id == id).Include(a=>a.Assignments).FirstOrDefault();
            if (user == null)
                throw new Exception("User does not exist");
            return user.Assignments;          
        }
    }
}
