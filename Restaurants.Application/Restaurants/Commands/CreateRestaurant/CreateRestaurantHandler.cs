
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Restaurants.Command.CreateRestaurant
{
    public class CreateRestaurantHandler(ILogger<CreateRestaurantHandler> logger,
        IMapper mapper, IRestaurantRepository restaurantRepository
        ) : IRequestHandler<CreateRestaurantCommand, int>
    {
        public async Task<int> Handle(CreateRestaurantCommand request, CancellationToken cancellationToken)
        {
            logger.LogInformation("Creating restaurant {@Dto}", request);
            var restaurant = mapper.Map<Restaurant>(request);
            int id = await restaurantRepository.Create(restaurant);
            return id;
        }
    }
}
