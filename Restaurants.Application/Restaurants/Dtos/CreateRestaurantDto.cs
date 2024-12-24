using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurants.Application.Restaurants.Dtos
{
    public class CreateRestaurantDto
    {
        [StringLength(100, MinimumLength = 3)]
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        [Required(ErrorMessage = "Insert a valid category")]
        public string Category { get; set; } = default!;
        public bool HasDelivery { get; set; }
        [EmailAddress(ErrorMessage = "Insert a valid email")]
        public string? ContactEmail { get; set; }
        [Phone(ErrorMessage = "Insert a valid phone number")]
        public string? ContactNumber { get; set; }

        public string? City { get; set; }
        public string? Street { get; set; }
        [RegularExpression(@"^\d{5}-\d{3}$", ErrorMessage = "Insert a valid postal code")]
        public string? PostalCode { get; set; }

    }
}
