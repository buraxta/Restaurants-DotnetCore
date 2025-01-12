using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Domain.Constants;
using Restaurants.Domain.Exceptions;
using Restaurants.Domain.Repositories;
using Restaurants.Infrastructure.Authorization.Services;

namespace Restaurants.Application.Restaurants.Commands.DeleteRestaurant
{
    public class DeleteRestaurantCommandHandler(
        ILogger<DeleteRestaurantCommandHandler> logger,
        IRestaurantRepository restaurantRepository,
        IRestaurantAuthorizationService restaurantAuthorizationService
        ) : IRequestHandler<DeleteRestaurantCommand, bool>
    {
        public async Task<bool> Handle(DeleteRestaurantCommand request, CancellationToken cancellationToken)
        {
            logger.LogInformation("Attempting to delete restaurant with id {Id}", request.Id);

            var restaurant = await restaurantRepository.GetByIdAsync(request.Id);
            if (restaurant is null)
            {
                logger.LogWarning("Restaurant with id {Id} not found", request.Id);
                return false;
            }

            if (!restaurantAuthorizationService.Authorize(restaurant, ResourceOperation.Delete))
            {
                logger.LogWarning("User not authorized to delete restaurant with id {Id}", request.Id);
                throw new ForbidException();
            }

            restaurantRepository.Delete(request.Id);
            logger.LogInformation("Restaurant with id {Id} deleted successfully", request.Id);
            return true;
        }
    }
}
