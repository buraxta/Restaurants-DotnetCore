

using FluentValidation;
using Restaurants.Application.Restaurants.Dtos;

namespace Restaurants.Application.Restaurants.Validators
{
    public class CreateRestaurantDtoValidators: AbstractValidator<CreateRestaurantDto>
    {
        public CreateRestaurantDtoValidators()
        {
            RuleFor(x => x.Name).Length(3,100);
            RuleFor(x => x.Description).NotEmpty().WithMessage("Description is required");
            RuleFor(x => x.Category).NotEmpty().WithMessage("Category is required");
            RuleFor(x => x.ContactEmail).EmailAddress().WithMessage("Insert a valid email");
            RuleFor(x => x.PostalCode).Matches(@"^\d{5}-\d{3}$").WithMessage("Insert a valid postal code");
        }
    }
}
