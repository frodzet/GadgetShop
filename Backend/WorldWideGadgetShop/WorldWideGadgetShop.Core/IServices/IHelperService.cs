using System.Collections.Generic;
using System.Security.Claims;

namespace WorldWideGadgetShop.Core.IServices
{
    public interface IHelperService
    {
        (byte[] passwordHash, byte[] passwordSalt) CreatePasswordHash(string password);

        bool VerifyPasswordHash(string password, byte[] storedHash, byte[] storedSalt);

        string GenerateToken(IEnumerable<Claim> claims);

        string GenerateRefreshToken();

        ClaimsPrincipal GetExpiredPrincipal(string token);
    }
}