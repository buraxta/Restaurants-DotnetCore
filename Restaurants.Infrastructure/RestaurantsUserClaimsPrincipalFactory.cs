
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Restaurants.Domain.Entities;
using System.Security.Claims;

namespace Restaurants.Infrastructure
{
    public class RestaurantsUserClaimsPrincipalFactory(UserManager<User> userManager, 
        RoleManager<IdentityRole> roleManager, 
        IOptions<IdentityOptions> options) 
        : UserClaimsPrincipalFactory<User, IdentityRole>(userManager, roleManager, options)
    {
        public async override Task<ClaimsPrincipal> CreateAsync(User user)
        {
            // Temel claim'leri oluştur
            var identity = await base.GenerateClaimsAsync(user);

            // Custom claim'ler ekle
            if (user.Nationality != null)
            {
                identity.AddClaim(new Claim("Nationality", user.Nationality));
            }

            if (user.DateOfBirth != null)
            {
                identity.AddClaim(new Claim("DateOfBirth", user.DateOfBirth.Value.ToString("yyyy-MM-dd")));
            }

            return new ClaimsPrincipal(identity);
        }
    }
}
