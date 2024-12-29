
using MediatR;

namespace Restaurants.Application.Dishes.Commands.DeleteRestaurant
{
    public class DeleteRestaurantcommand(int restaurantId) : IRequest<bool>
    {
        public int restaurantId { get; } = restaurantId;
    }
}
