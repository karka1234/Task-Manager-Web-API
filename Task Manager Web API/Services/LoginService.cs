﻿using System.Security.Cryptography;
using System.Text;
using Task_Manager_Web_API.Data;
using Task_Manager_Web_API.Database;
using Task_Manager_Web_API.Dto;
using static Task_Manager_Web_API.Enums.Enums;
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
        public User RegisterNewUser(string userName, string password)
        {
            var user = CreateUser(userName, password);
            _context.Users.Add(user);
            _context.SaveChanges();
            return user;
        }

        public LoginResponseDTO Login(string userName, string password)
        {
            var user = _context.Users.SingleOrDefault(u => u.UserName == userName);
            if (user == null)
                return new LoginResponseDTO(false);
            var isSuccess = VerifyPasswordHash(password, user.Password, user.PasswordSalt);
            return new LoginResponseDTO(isSuccess, user.AppRole);
        }

        public User CreateUser(string userName, string password)
        {
            CreatePasswordHash(password, out byte[] passwordHash, out byte[] passwordSalt);
            return new User
            {
                UserName = userName,
                Password = passwordHash,
                PasswordSalt = passwordSalt,
                AppRole = Role.User                
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
