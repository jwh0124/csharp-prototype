using CUPrototype.Config;
using CUPrototype.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CUPrototype.Service.Impl
{
    public class UserRepository : IUserRepository
    {
        private DatabaseContext databaseContext;

        public UserRepository(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        public IEnumerable<User> GetList()
        {
            return databaseContext.Users.ToList();
        }

        public User GetUser(int id)
        {
            return databaseContext.Users.FirstOrDefault(p => p.Id == id);
        }

        public void SetUser(User user)
        {
            if(user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            databaseContext.Add(user);
            databaseContext.SaveChanges();
        }

        List<User> IUserRepository.GetList()
        {
            return databaseContext.Users.ToList();
        }
    }
}
