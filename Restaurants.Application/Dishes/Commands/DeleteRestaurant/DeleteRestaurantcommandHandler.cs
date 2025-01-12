using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Domain.Constants;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Exceptions;
using Restaurants.Domain.Repositories;
using Restaurants.Infrastructure.Authorization.Services;


namespace Restaurants.Application.Dishes.Commands.DeleteRestaurant
{
    public class DeleteRestaurantcommandHandler(
            ILogger<DeleteRestaurantcommandHandler> logger,
            IRestaurantRepository restaurantRepository,
            IRestaurantAuthorizationService restaurantAuthorizationService
            ) : IRequestHandler<DeleteRestaurantcommand, bool>
    {
        public async Task<bool> Handle(DeleteRestaurantcommand request, CancellationToken cancellationToken)
        {
            logger.LogInformation("Restaurant {0} and Dishes inside restaurant is deleted", request.restaurantId);

            var restaurant = await restaurantRepository.GetByIdAsync(request.restaurantId);

            if (!restaurantAuthorizationService.Authorize(restaurant, ResourceOperation.Delete))
            {
                logger.LogWarning("User not authorized to delete restaurant with id {Id}", request.restaurantId);
                throw new ForbidException();
            }
            var result = restaurantRepository.Delete(request.restaurantId);
            return await Task.FromResult(result);
        }
    }
}
