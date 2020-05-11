using CUPrototype.Config;
using CUPrototype.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CUPrototype.Service.Impl
{
    public class UserImpl : IUser
    {
        private DatabaseContext databaseContext;

        public UserImpl(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        public List<User> GetList()
        {
            return databaseContext.Users.ToList();
        }

        public User GetUser(int id)
        {
            var user = databaseContext.Users.Find(id);

            return user;
        }

        public void SetUser(User user)
        {
            databaseContext.Add(new User { Name = user.Name });
            databaseContext.SaveChanges();
        }
    }
}
