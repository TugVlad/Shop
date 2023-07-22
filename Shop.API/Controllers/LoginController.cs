using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Shop.API.ViewModels.Login;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Shop.API.Controllers
{
	[Route("api/login")]
	[ApiController]
	public class LoginController : ControllerBase
	{
		private const string TokenSecret = "ThisIsMyVeryLongLongLongSecurityKey";
		private const string Issuer = "https://test.com";
		private const string Audience = "https://ttest.com";
		private static readonly TimeSpan TokenLifetime = TimeSpan.FromHours(8);

		[HttpPost]
		public ActionResult GenerateToken([FromBody] LoginViewModel loginViewModel)
		{
			var tokenHandler = new JwtSecurityTokenHandler();
			var key = Encoding.UTF8.GetBytes(TokenSecret);

			var claims = new List<Claim>
			{
				new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
				new(JwtRegisteredClaimNames.Sub, loginViewModel.Email),
				new(JwtRegisteredClaimNames.Email, loginViewModel.Email),
				new("userId", "1234")
			};

			if(loginViewModel.Email.Contains(".com"))
			{
				claims.Add(new("isAdmin", "true"));
			}
			else
			{
				claims.Add(new("isAdmin", "false"));
			}

			var tokenDescriptor = new SecurityTokenDescriptor
			{
				Subject = new ClaimsIdentity(claims),
				Expires = DateTime.UtcNow.Add(TokenLifetime),
				Issuer = Issuer,
				Audience = Audience,
				SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
			};

			var token = tokenHandler.CreateToken(tokenDescriptor);

			var jwt = tokenHandler.WriteToken(token);
			return Ok(jwt);
		}
	}
}
