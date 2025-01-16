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

        public async Task<IEnumerable<Restaurant>> GetAllMatchingAsync(string? searchPhrase)
        {
            if (string.IsNullOrWhiteSpace(searchPhrase))
            {
                return await dbContext.Restaurants.ToListAsync();
            }

            var searchPhraseLower = searchPhrase?.ToLower();

            var restaurants = await dbContext.Restaurants
                .Where(r => r.Name.ToLower().Contains(searchPhraseLower)
                || r.Description.ToLower().Contains(searchPhraseLower))
                .ToListAsync();

            return restaurants;
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
