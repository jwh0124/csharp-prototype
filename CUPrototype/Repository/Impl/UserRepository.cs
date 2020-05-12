using CUPrototype.Config;
using CUPrototype.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CUPrototype.Service.Impl
{
    public class UserRepository : IUserRepository
    {
        private DatabaseContext _dbContext;

        public UserRepository(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<User> GetList()
        {
            return _dbContext.Users.ToList();
        }

        public User GetUser(int id)
        {
            return _dbContext.Users.FirstOrDefault(p => p.Id == id);
        }

        public void SetUser(User user)
        {
            if(user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            _dbContext.Add(user);
            _dbContext.SaveChanges();
        }
    }
}
