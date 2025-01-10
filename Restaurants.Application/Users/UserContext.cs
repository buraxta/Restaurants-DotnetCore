using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace Restaurants.Application.Users
{
    public class UserContext(IHttpContextAccessor httpContextAccessor) : IUserContext
    {
        public CurrentUser? GetCurrentUser()
        {
            var user = httpContextAccessor?.HttpContext?.User;
            if (user is null)
            {
                throw new InvalidOperationException("User context is not present");
            }

            if (user.Identity is null || !user.Identity.IsAuthenticated)
            {
                return null;
            }

            var userId = user.FindFirst(ClaimTypes.NameIdentifier)!.Value;
            var email = user.FindFirst(ClaimTypes.Email)!.Value;
            var roles = user.FindAll(ClaimTypes.Role).Select(x => x.Value);
            var nationality = user.FindFirst(c => c.Type == "Nationality")?.Value;
            var dateOfBirthString = user.FindFirst(c => c.Type == "DateOfBirth")?.Value;
            var dateOfBirth = dateOfBirthString == null
                ? (DateOnly?)null
                : DateOnly.ParseExact(dateOfBirthString, "yyyy-MM-dd");

            return new CurrentUser(userId, email, roles, dateOfBirthString, dateOfBirth);
        }

    }
}
