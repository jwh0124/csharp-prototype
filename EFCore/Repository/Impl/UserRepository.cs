using CUPrototype.Config;
using CUPrototype.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CUPrototype.Service.Impl
{
    public class UserRepository : IUserRepository
    {
        private readonly DatabaseContext _dbContext;

        public UserRepository(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<User> GetUserList()
        {
            return _dbContext.Users.ToList();
        }

        public User GetUser(int id)
        {
            return _dbContext.Users.FirstOrDefault(p => p.Id == id);
        }

        public void InsertUser(User user)
        {
            if(user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();
        }

        public void UpdateUser(User user)
        {
            _dbContext.Entry(user).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }

        public void DeleteUser(User user)
        {
            if(user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }
            _dbContext.Users.Remove(user);
            _dbContext.SaveChanges();
        }
    }
}
