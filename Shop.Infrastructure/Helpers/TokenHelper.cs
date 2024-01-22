using Microsoft.IdentityModel.Tokens;
using Shop.Application.Repositories.Interfaces;
using Shop.Core.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Shop.Infrastructure.Helpers
{
	public class TokenHelper : ITokenHelper
    {
        private static readonly TimeSpan TokenLifetime = TimeSpan.FromHours(8);

        public string GenerateToken(Account account, TokenDetails tokenDetails)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(tokenDetails.SigningKey);

            var claims = new List<Claim>
            {
                new(JwtRegisteredClaimNames.Sub, account.Id.ToString()),
                new(ClaimTypes.Email, account.Email),
                new("phoneNumber", account.PhoneNumber),
				new("IdentityId", account.IdentityUserId),
			};

            if (account.IsAdmin)
            {
                claims.Add(new("isAdmin", "true"));
            }

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.Add(TokenLifetime),
                Issuer = tokenDetails.Issuer,
                Audience = tokenDetails.Audience,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
