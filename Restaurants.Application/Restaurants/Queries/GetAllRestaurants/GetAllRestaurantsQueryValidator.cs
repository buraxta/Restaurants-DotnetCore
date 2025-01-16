
using FluentValidation;

namespace Restaurants.Application.Restaurants.Queries.GetAllRestaurants
{
    public class GetAllRestaurantsQueryValidator : AbstractValidator<GetAllRestaurantsQuery>
    {
        private int[] allowPagesizes = [5, 10, 15, 30];
        public GetAllRestaurantsQueryValidator()
        {
            RuleFor(x => x.PageNumber).GreaterThanOrEqualTo(1);
            RuleFor(x => x.PageSize)
                .Must(x => allowPagesizes.Contains(x))
                .WithMessage($"PageSize must be in [{string.Join(",", allowPagesizes)}]");
        }
    }
}
