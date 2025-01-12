
using Microsoft.AspNetCore.Authorization;

namespace Restaurants.Infrastructure.Authorization.Requirements
{
    public class CreatedMultipleRestaurantsReuirement(
        int minimumRestaurantsCreated
        ) : IAuthorizationRequirement
    {
        public int MinimumRestaurantsCreated { get;  } = minimumRestaurantsCreated;
    }
}
