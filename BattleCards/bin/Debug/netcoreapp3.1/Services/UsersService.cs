using BattleCards.Data;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace BattleCards.Services
{
    public class UsersService : IUsersService
    {
        private readonly ApplicationDbContext db;

        public UsersService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public void AddUser(string username, string email, string password)
        {
            var user = new User()
            {
                Username = username,
                Email = email,
                Password = this.GenerateSHA512String(password),
            };
            this.db.Users.AddAsync(user);
            this.db.SaveChangesAsync();
        }

        public string GetUserId(string username, string password)
        {
            var user = db.Users.FirstOrDefault(x => x.Username == username && x.Password == this.GenerateSHA512String(password));

            if (user == null)
            {
                return null;
            }
            return user.UserId;
        }

        public bool IsValidEmail(string email)
        {
            return this.db.Users.FirstOrDefault(x => x.Email == email) == null;
        }

        public bool IsValidUser(string username)
        {
            return this.db.Users.FirstOrDefault(x => x.Username == username) == null;
        }

        private string GenerateSHA512String(string inputString)
        {
            SHA512 sha512 = SHA512Managed.Create();
            byte[] bytes = Encoding.UTF8.GetBytes(inputString);
            byte[] hash = sha512.ComputeHash(bytes);
            return GetStringFromHash(hash);
        }

        private string GetStringFromHash(byte[] hash)
        {
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                result.Append(hash[i].ToString("X2"));
            }
            return result.ToString();
        }
    }
}
