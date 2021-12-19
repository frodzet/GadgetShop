using WorldWideGadgetShop.Core.IServices;
using WorldWideGadgetShop.Core.Models;
using WorldWideGadgetShop.Domain.IRepositories;

namespace WorldWideGadgetShop.SQL.Repositories
{
    public class DatabaseInitializer : IDatabaseInitializer
    {
        private readonly IAuthenticationService _authHelper;
        
        public DatabaseInitializer(IAuthenticationService authHelper)
        {
            _authHelper = authHelper;
        }
        public void SeedDatabase(DBContext ctx)
        {
            IProductRepository productRepo = new ProductRepository(ctx);
            IUserRepository userRepo = new UserRepository(ctx);
            IOrderRepository orderRepo = new OrderRepository(ctx);
            
            var (passwordHashUser1, passwordSaltUser1) = _authHelper.CreatePasswordHash("12345");
            var (passwordHashUser2, passwordSaltUser2) = _authHelper.CreatePasswordHash("Hello");
            userRepo.CreateUser(new User()
            {
                Username = "Simon",
                PasswordHash = passwordHashUser1,
                PasswordSalt = passwordSaltUser1,
                IsAdmin = true,
            });
            userRepo.CreateUser(new User()
            {
                Username = "Conrad",
                PasswordHash = passwordHashUser2,
                PasswordSalt = passwordSaltUser2,
                IsAdmin = false,
            });

            productRepo.CreateProduct(new Product()
            {
                Name = "Helicopter 22",
                Description = "Cool Stuff",
                Amount = 5,
                CanShow = true,
                Price = 100,
                Type = "Gadget",
                ImageURL = "https://m.media-amazon.com/images/I/61edplm2TIL._AC_SL1500_.jpg",
            });

            productRepo.CreateProduct(new Product()
            {
                Name = "Spy Cam",
                Description = "A Spy Camera for Kids",
                Amount = 10,
                CanShow = true,
                Price = 300,
                Type = "Gadget",
                ImageURL = "https://canary.contestimg.wish.com/api/webimage/5c88b12040fb575b24c8165d-large.jpg?cache_buster=4e85615a9feb19c690c22310882c3586"
            });
            
            ctx.SaveChanges();
        }
    }
}