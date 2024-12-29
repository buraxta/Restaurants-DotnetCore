using Microsoft.EntityFrameworkCore;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Repositories;
using Restaurants.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurants.Infrastructure.Repositories
{
    internal class DishesRepository : IDishesRepository
    {
        private readonly RestaurantsDbContext dbContext;

        public DishesRepository(RestaurantsDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<int> Create(Dish entity)
        {
            dbContext.Dishes.Add(entity);
            await dbContext.SaveChangesAsync();
            return entity.Id;
        }

        public async Task<Dish> GetById(int restaurantId, int dishId)
        {

            var dish = await dbContext.Dishes
                .FirstOrDefaultAsync(d => d.RestaurantId == restaurantId && d.Id == dishId);
            return dish;
        }
    }
}
