using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Domain.Constants;
using Restaurants.Domain.Exceptions;
using Restaurants.Domain.Repositories;
using Restaurants.Infrastructure.Authorization.Services;

namespace Restaurants.Application.Restaurants.Commands.UpdateRestaurant
{
    public class UpdateRestaurantCommandHandler(
        ILogger<UpdateRestaurantCommandHandler> logger,
        IMapper mapper,
        IRestaurantRepository restaurantRepository,
        IRestaurantAuthorizationService restaurantAuthorizationService
        ) : IRequestHandler<UpdateRestaurantCommand, int>
    {
        public async Task<int> Handle(UpdateRestaurantCommand request, CancellationToken cancellationToken)
        {

            logger.LogInformation("Updating restaurant {@Dto}", request);
            var restaurant = await restaurantRepository.GetByIdAsync(request.Id);
            if (restaurant == null)
            {
                return -1;
            }

            mapper.Map(request, restaurant);
            //restaurant.Name = request.Name ?? restaurant.Name;
            //restaurant.Description = request.Description ?? restaurant.Description;
            //restaurant.Category = request.Category ?? restaurant.Category;
            //restaurant.HasDelivery = request.HasDelivery ?? restaurant.HasDelivery;
            //restaurant.ContactEmail = request.ContactEmail ?? restaurant.ContactEmail;
            //restaurant.ContactNumber = request.ContactNumber ?? restaurant.ContactNumber;

            if (!restaurantAuthorizationService.Authorize(restaurant, ResourceOperation.Update))
            {
                logger.LogWarning("User not authorized to delete restaurant with id {Id}", request.Id);
                throw new ForbidException();
            }

            await restaurantRepository.Update(restaurant);
            logger.LogInformation("Restaurant updated {@Dto}", restaurant);

            return restaurant.Id;
        }
    }
}
