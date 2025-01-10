using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Restaurants.Application.Restaurants.Command.CreateRestaurant
{
    public class CreateRestaurantCommand : IRequest<int> //return type int
    {
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;

        public string Category { get; set; } = default!;
        public bool HasDelivery { get; set; }
        public string? ContactEmail { get; set; }
        public string? ContactNumber { get; set; }

        public string? City { get; set; }
        public string? Street { get; set; }

        [RegularExpression(@"^\d{2}-\d{3}$", ErrorMessage = "Insert a valid postal code")]
        public string? PostalCode { get; set; }
    }
}
