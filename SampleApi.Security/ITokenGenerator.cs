using SampleShop.Domain.Models;
using System.Security.Claims;

namespace SampleApi.Security
{
    public interface ITokenGenerator
    {
        string GenerateToken(User user);
        ClaimsPrincipal ValidateToken(string token);
    }
}
