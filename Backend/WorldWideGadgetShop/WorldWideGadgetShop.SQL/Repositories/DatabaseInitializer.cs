
using System;
using WorldWideGadgetShop.Core.IServices;
using WorldWideGadgetShop.Core.Models;

namespace WorldWideGadgetShop.SQL.Repositories
{
    public class DatabaseInitializer : IDatabaseInitializer
    {
        private readonly IHelperService _authHelper;
        
        public DatabaseInitializer(IHelperService authHelper)
        {
            _authHelper = authHelper;
        }
        public void SeedDatabase(DBContext ctx)
        {
            var (passwordHashUser1, passwordSaltUser1) = _authHelper.CreatePasswordHash("12345");
            var (passwordHashUser2, passwordSaltUser2) = _authHelper.CreatePasswordHash("Hello");
            User user1 = new User()
            {
                Username = "Simon",
                PasswordHash = passwordHashUser1,
                PasswordSalt = passwordSaltUser1,
                IsAdmin = true,
            };
            User user2 = new User()
            {
                Username = "Conrad",
                PasswordHash = passwordHashUser2,
                PasswordSalt = passwordSaltUser2,
                IsAdmin = false,
            };
            ctx.Users.Add(user1);
            ctx.Users.Add(user2);
            
            Product product1 = new Product()
            {
                Name = "Helicopter",
                Description = "Cool Stuff",
                Amount = 5,
                CanShow = true,
                Price = 100,
                Type = "Gadget"
            };

            ctx.Products.Add(product1);

            ctx.SaveChanges();
        }
    }
}