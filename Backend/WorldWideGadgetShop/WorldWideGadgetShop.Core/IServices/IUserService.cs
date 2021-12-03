using System.Collections.Generic;
using WorldWideGadgetShop.Core.Models;

namespace WorldWideGadgetShop.Core.IServices
{
    public interface IUserService
    {
        // Create
        User CreateUser(User user);
        string Login(string name, string password);
        
        // Read
        List<User> GetAllUsers();
        User GetUserById(int id);
        
        // Update
        User UpdateUser(User user);
        
        // Delete
        User DeleteUserById(int id);
    }
}