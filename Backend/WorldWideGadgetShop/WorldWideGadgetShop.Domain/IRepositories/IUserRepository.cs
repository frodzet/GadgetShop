using System.Collections.Generic;
using WorldWideGadgetShop.Core.Models;

namespace WorldWideGadgetShop.Domain.IRepositories
{
    public interface IUserRepository
    {
        // Create
        User CreateUser(User user);

        // Read
        List<User> GetAllUsers();
        User GetUserById(int id);
        
        // Update
        User UpdateUser(User user);
        
        // Delete
        User DeleteUserById(int id);
    }
}