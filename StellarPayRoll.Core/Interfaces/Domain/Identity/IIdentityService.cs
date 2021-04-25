using StellarPayRoll.Core.Models.Entities;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;

namespace StellarPayRoll.Core.Domain.Identity
{
    public interface IIdentityService
    {
        string GetUserIdentity();

        string GenerateToken(User user, IEnumerable<string> roles);

        JwtSecurityToken GetClaims(string token);

        string GetClaimValue(string type);

        string GenerateSalt();

        public string GetPasswordHash(string password, string salt = null);
    }
}
