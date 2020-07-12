using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ParkyAPI.Data;
using ParkyAPI.Models;
using ParkyAPI.Repository.IRepository;

namespace ParkyAPI.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _db;


        public bool IsUniqueUser(string username)
        {
            bool value = _db.Users.Any(a =>
                a.Username.ToLower().Trim() 
                == username.ToLower().Trim());

            return value;
        }

        public User Register(string username, string password)
        {
            throw new NotImplementedException();
        }

        public User Authenticate(string username, string password)
        {
            throw new NotImplementedException();
        }
    }
}
