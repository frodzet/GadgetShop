using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using WorldWideGadgetShop.Core.Models;
using WorldWideGadgetShop.Domain.IRepositories;

namespace WorldWideGadgetShop.SQL.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DBContext _ctx;

        public UserRepository(DBContext ctx)
        {
            _ctx = ctx;
        }
        
        public User CreateUser(User user)
        {
            throw new System.NotImplementedException();
        }

        public List<User> GetAllUsers()
        {
            return _ctx.Users.ToList();
        }

        public User GetUserById(int id)
        {
            throw new System.NotImplementedException();
        }

        public User UpdateUser(User user)
        {
            throw new System.NotImplementedException();
        }

        public User DeleteUserById(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}