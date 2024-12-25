using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurants.Application.Restaurants.Commands.DeleteRestaurant
{
    public class DeleteRestaurantCommandHandler(
        ILogger<DeleteRestaurantCommandHandler> logger,
        IRestaurantRepository restaurantRepository
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

            restaurantRepository.Delete(request.Id);
            logger.LogInformation("Restaurant with id {Id} deleted successfully", request.Id);
            return true;
        }
    }
}
