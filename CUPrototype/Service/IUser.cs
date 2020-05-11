using CUPrototype.Models;
using NUnit.Framework;
using System.Collections.Generic;

namespace CUPrototype.Service
{
    public interface IUser
    {
        public User GetUser(int id);

        public void SetUser(User user);

        public List<User> GetList();
    }
}
