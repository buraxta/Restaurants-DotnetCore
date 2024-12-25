
using FluentValidation;

namespace Restaurants.Application.Restaurants.Command.CreateRestaurant
{
    public class CreateRestaurantCommandValidator : AbstractValidator<CreateRestaurantCommand>
    {
        public CreateRestaurantCommandValidator()
        {
            RuleFor(x => x.Name).Length(3, 100);
            RuleFor(x => x.Description).NotEmpty().WithMessage("Description is required");
            RuleFor(x => x.Category).NotEmpty().WithMessage("Category is required");
            RuleFor(x => x.ContactEmail).EmailAddress().WithMessage("Insert a valid email");
            RuleFor(x => x.PostalCode).Matches(@"^\d{5}-\d{3}$").WithMessage("Insert a valid postal code");
        }
    }
}
