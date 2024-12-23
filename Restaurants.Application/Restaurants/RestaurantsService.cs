

using AutoMapper;
using Microsoft.Extensions.Logging;
using Restaurants.Application.Restaurants.Dtos;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Restaurants;

internal class RestaurantsService(IRestaurantRepository restaurantRepository,
    ILogger<RestaurantsService> logger, IMapper mapper) : IRestaurantsService
{
    public async Task<int> Create(CreateRestaurantDto dto)
    {
        logger.LogInformation("Creating restaurant {@Dto}", dto);
        var restaurant = mapper.Map<Restaurant>(dto);
        int id = await restaurantRepository.Create(restaurant);
        return id;
    }

    public async Task<IEnumerable<RestaurantDto>> GetAllRestaurants()
    {
        logger.LogInformation("Getting all restaurants");
        var restaurants = await restaurantRepository.GetAllAsync();

        var restaurantDtos = mapper.Map<IEnumerable<RestaurantDto>>(restaurants);

        return restaurantDtos!;
    }

    public async Task<RestaurantDto?> GetRestaurantById(int id)
    {
        logger.LogInformation("Getting restaurant by id {Id}", id);
        var restaurant = await restaurantRepository.GetByIdAsync(id);
        var restaurantDto =  mapper.Map<RestaurantDto?>(restaurant);

        return restaurantDto;
    }
}
