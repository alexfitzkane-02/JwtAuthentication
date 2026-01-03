using JwtAuthentication.Repositories.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace JwtAuthentication.Repositories.Implementation
{
    public class TokenRepository: ITokenRepository
    {
        private readonly IConfiguration configuration;

        public TokenRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public string CreateJwtToken(IdentityUser user, List<string> roles)
        {
            //Create Claims
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, user.Email)
            };

            //Add Roles to Claims
            claims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role)));

            //Jwt Security Token Parameters
            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: configuration["Jwt:Issuer"],
                audience: configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: creds
            );

            //Return Token
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    }
}
