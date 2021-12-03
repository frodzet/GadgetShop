using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using WorldWideGadgetShop.Core.IServices;
using WorldWideGadgetShop.Core.Models;
using WorldWideGadgetShop.Domain.IRepositories;

namespace WorldWideGadgetShop.Domain.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepo;
        private readonly IHelperService _authHelper;
        
        public UserService(IUserRepository  userRepo, IHelperService authHelper)
        {
            _userRepo = userRepo;
            _authHelper = authHelper;
        }
        
        public User CreateUser(User user)
        {
            throw new System.NotImplementedException();
        }

        public string Login(string name, string password)
        {
            var user = GetUserByName(name);
            if (!_authHelper.VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
            {
                throw new ArgumentException("Invalid Password.");
            }

            var claims = SetUpClaims(user);

            return _authHelper.GenerateToken(claims);
        }

        private List<Claim> SetUpClaims(User user)
        {
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, user.Username)
            };

            if (user.IsAdmin)
            {
                claims.Add(new Claim(ClaimTypes.Role, "Admin"));
            }
            else
            {
                claims.Add(new Claim(ClaimTypes.Role, "User"));
            }

            return claims;
        }

        private User GetUserByName(string username)
        {
            var user = _userRepo.GetAllUsers().FirstOrDefault(u => u.Username == username);
            if (user == null)
            {
                throw new ArgumentException("Invalid User.");
            }

            return user;
        }

        public List<User> GetAllUsers()
        {
            throw new System.NotImplementedException();
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