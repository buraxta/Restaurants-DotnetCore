
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Application.Dishes.Dtos;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Exceptions;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Dishes.Queries.GetDishForRestaurant
{
    public class GetDishForRestaurantQueryHandler(
            ILogger<GetDishForRestaurantQueryHandler> logger,
            IDishesRepository dishesRepository,
            IMapper mapper
            ) : IRequestHandler<GetDishForRestaurantQuery, DishDto>
    {
        public async Task<DishDto> Handle(GetDishForRestaurantQuery request, CancellationToken cancellationToken)
        {
            logger.LogInformation("Getting dish for restaurant");
            var dish = await dishesRepository.GetById(request.RestaurantId, request.DishId);
            if (dish == null)
            {
                throw new NotFoundException(nameof(Dish), request.DishId.ToString());
            }
            var result = mapper.Map<DishDto>(dish);
            return result;
        }
    }
}
