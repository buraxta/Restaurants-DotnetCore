using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurants.Application.Dishes.Commands.DeleteRestaurant
{
    public class DeleteRestaurantcommandHandler(
            ILogger<DeleteRestaurantcommandHandler> logger,
            IRestaurantRepository restaurantRepository
            ) : IRequestHandler<DeleteRestaurantcommand, bool>
    {
        public async Task<bool> Handle(DeleteRestaurantcommand request, CancellationToken cancellationToken)
        {
            logger.LogInformation("Restaurant {0} and Dishes inside restaurant is deleted", request.restaurantId);
            var result = restaurantRepository.Delete(request.restaurantId);
            return await Task.FromResult(result);
        }
    }
}
