using Azure.Core;
using Microsoft.EntityFrameworkCore;
using Restaurants.Domain.Constants;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Repositories;
using Restaurants.Infrastructure.Persistence;
using System.Linq.Expressions;

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

        public async Task<(IEnumerable<Restaurant>, int)> GetAllMatchingAsync(string? searchPhrase, int pageSize, int pageNumber,
            string? sortBy, SortDirection sortDirection
            )
        {
            var query = dbContext.Restaurants.AsQueryable();

            if (!string.IsNullOrWhiteSpace(searchPhrase))
            {
                var searchPhraseLower = searchPhrase.ToLower();
                query = query.Where(r => r.Name.ToLower().Contains(searchPhraseLower)
                                      || (r.Description != null && r.Description.ToLower().Contains(searchPhraseLower)));
            }

            var totalCount = await query.CountAsync();

            if (!string.IsNullOrWhiteSpace(sortBy))
            {
                var columnSelector = new Dictionary<string, Expression<Func<Restaurant, object>>>
                {
                    { nameof(Restaurant.Name), r => r.Name },
                    { nameof(Restaurant.Description), r => r.Description },
                    { nameof(Restaurant.Category), r => r.Category },
                };

                var selectedColumn = columnSelector[sortBy];

                query = sortDirection == SortDirection.Ascending 
                    ? query.OrderBy(selectedColumn)
                    : query.OrderByDescending(selectedColumn);
            }

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
