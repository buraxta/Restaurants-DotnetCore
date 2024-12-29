
using MediatR;
using Restaurants.Application.Dishes.Dtos;

namespace Restaurants.Application.Dishes.Queries.GetDishForRestaurant
{
    public class GetDishForRestaurantQuery(int restaurantId, int dishId) : IRequest<DishDto>
    {
        public int RestaurantId { get; } = restaurantId;
        public int DishId { get; } = dishId;
    }
}
