
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Application.Common;
using Restaurants.Application.Restaurants.Dtos;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Restaurants.Queries.GetAllRestaurants
{
    public class GetAllRestaurantsQueryHandler(ILogger<GetAllRestaurantsQueryHandler> logger,
        IMapper mapper,
        IRestaurantRepository restaurantRepository) : IRequestHandler<GetAllRestaurantsQuery, PagedResults<RestaurantDto>>
    {
        public async Task<PagedResults<RestaurantDto>> Handle(GetAllRestaurantsQuery request, CancellationToken cancellationToken)
        {
            logger.LogInformation("Getting all restaurants");
            var (restaurants, totalCount) = await restaurantRepository.GetAllMatchingAsync(request.SearchPhrase, request.PageSize, request.PageNumber);

            var restaurantDtos = mapper.Map<IEnumerable<RestaurantDto>>(restaurants);
            var result = new PagedResults<RestaurantDto>(restaurantDtos, totalCount,  request.PageSize, request.PageNumber);

            return result;
        }
    }
}
