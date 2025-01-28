using Microsoft.IdentityModel.Tokens;
using SampleShop.Domain.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SampleApi.Security
{
    public class TokenGenerator : ITokenGenerator
    {
        public string GenerateToken(User user)
        {
            Claim claim = new Claim("userid", user.Id.ToString());
            Claim role = new Claim("Role", user.RoleId.ToString());
            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(new[] { claim, role }),
                Expires = DateTime.Now.AddHours(1),
                Issuer = "www.Bamdad.com",
                Audience = "www.Bamdad.com",
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(
                    Encoding.ASCII.GetBytes("I Am Amirhossein makineh")), SecurityAlgorithms.HmacSha256Signature)
            };
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            var securityToken = tokenHandler.CreateToken(tokenDescriptor);
            var result = tokenHandler.WriteToken(securityToken);
            return result;
        }

        public ClaimsPrincipal ValidateToken(string token)
        {
            var parameters = new TokenValidationParameters()
            {
                ValidateIssuer = false,
                ValidateAudience = false,
                RequireExpirationTime = true,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes("I Am Amirhossein makineh"))
            };

            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            tokenHandler.CanReadToken(token);
            return tokenHandler.ValidateToken(token, parameters, out SecurityToken securityToken);
        }
    }
}
