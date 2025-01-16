using Azure.Core;
using Microsoft.EntityFrameworkCore;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Repositories;
using Restaurants.Infrastructure.Persistence;

namespace Restaurants.Infrastructure.Repositories
{
    internal class RestaurantsRepository(RestaurantsDbContext dbContext) : IRestaurantRepository
    {
        public async Task<int> Create(Restaurant restaurant)
        {
            dbContext.Restaurants.Add(restaurant);
            await dbContext.SaveChangesAsync();
            return restaurant.Id;
        }

        public bool Delete(int id)
        {
            var restaurant = dbContext.Restaurants.Find(id);
            if (restaurant is null) return false;
            dbContext.Restaurants.Remove(restaurant);
            dbContext.SaveChanges();
            return true;
           
        }

        public async Task<IEnumerable<Restaurant>> GetAllAsync()
        {
            var restaurants = await dbContext.Restaurants.ToListAsync();
            return restaurants;
        }

        public async Task<(IEnumerable<Restaurant>, int)> GetAllMatchingAsync(string? searchPhrase, int pageSize, int pageNumber)
        {
            var query = dbContext.Restaurants.AsQueryable();

            if (!string.IsNullOrWhiteSpace(searchPhrase))
            {
                var searchPhraseLower = searchPhrase.ToLower();
                query = query.Where(r => r.Name.ToLower().Contains(searchPhraseLower)
                                      || (r.Description != null && r.Description.ToLower().Contains(searchPhraseLower)));
            }
            var totalCount = await query.CountAsync();

            var restaurants = await query
                .Skip(pageSize * (pageNumber - 1))
                .Take(pageSize)
                .ToListAsync();

            return (restaurants, totalCount);
        }

        public async Task<Restaurant?> GetByIdAsync(int id)
        {
            var restaurant = await dbContext.Restaurants
                .Include(r => r.Dishes)
                .FirstOrDefaultAsync(r => r.Id == id);
            return restaurant;
        }

        public async Task<int> Update(Restaurant restaurant)
        {
            dbContext.Restaurants.Update(restaurant);
            await dbContext.SaveChangesAsync();
            return restaurant.Id;
        }

    
    }
}
