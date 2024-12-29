using MediatR;
using Microsoft.AspNetCore.Mvc;
using Restaurants.Application.Dishes.Commands.CreateDish;
using Restaurants.Application.Dishes.Commands.DeleteRestaurant;
using Restaurants.Application.Dishes.Dtos;
using Restaurants.Application.Dishes.Queries.GetDishesForRestaurant;
using Restaurants.Application.Dishes.Queries.GetDishForRestaurant;

namespace Restaurants.API.Controllers
{
    [Route("api/restaurant/{restaurantId}/dishes")]
    [ApiController]
    public class DishesController(IMediator mediator) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> CreateDish([FromRoute] int restaurantId, CreateDishCommand command)
        {
            command.RestaurantId = restaurantId;
            await mediator.Send(command);
            return Created();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DishDto>>> GetAllForRestaurant([FromRoute] int restaurantId)
        {
            var dishes = await mediator.Send(new GetDishesForRestaurantQuery(restaurantId));
            return Ok(dishes);
        }

        [HttpGet("{dishId}")]
        public async Task<IActionResult> GetByIdForRestaurant([FromRoute] int restaurantId, [FromRoute] int dishId)
        {
            var dish = await mediator.Send(new GetDishForRestaurantQuery(restaurantId, dishId));
            return Ok(dish);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteForRestaurant([FromRoute] int restaurantId)
        {
            var isDeleted = await mediator.Send(new DeleteRestaurantcommand(restaurantId));
            if (isDeleted == false)
            {
                return NotFound();
            }
            return NoContent();
        }


    }
}
