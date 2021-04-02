using CUPrototype.Models;
using NUnit.Framework;
using System.Collections.Generic;

namespace CUPrototype.Service
{
    public interface IUserRepository
    {
        public List<User> GetUserList();
        public User GetUser(int id);

        public void InsertUser(User user);

        public void UpdateUser(User user);

        public void DeleteUser(User user);
    }
}
