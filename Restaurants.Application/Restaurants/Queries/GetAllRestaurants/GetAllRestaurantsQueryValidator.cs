
using FluentValidation;
using Restaurants.Application.Restaurants.Dtos;

namespace Restaurants.Application.Restaurants.Queries.GetAllRestaurants
{
    public class GetAllRestaurantsQueryValidator : AbstractValidator<GetAllRestaurantsQuery>
    {
        private int[] allowPagesizes = [5, 10, 15, 30];
        private readonly string[] allowedSortByColumnNames = [nameof(RestaurantDto.Name),nameof(RestaurantDto.Category),nameof(RestaurantDto.Description),];
        public GetAllRestaurantsQueryValidator()
        {
            RuleFor(x => x.PageNumber).GreaterThanOrEqualTo(1);
            RuleFor(x => x.PageSize)
                .Must(x => allowPagesizes.Contains(x))
                .WithMessage($"PageSize must be in [{string.Join(",", allowPagesizes)}]");
            RuleFor(x => x.SortBy)
                .Must(value => allowedSortByColumnNames.Contains(value))
                //Eğer SortBy değeri verilmişse (null değilse), 
                .When(x => x.SortBy != null)
                //bu değerin allowedSortByColumnNames listesinde bulunması gerekir.
                .WithMessage($"Sort by is optional, or must be in [{string.Join(",", allowedSortByColumnNames)}]");
                //Eğer SortBy değeri null ise, bu kuralın çalışmasına gerek yoktur.
        }
    }
}
