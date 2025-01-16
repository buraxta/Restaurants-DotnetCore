using Restaurants.Domain.Entities;

namespace Restaurants.Domain.Repositories
{
    public interface IRestaurantRepository
    {
        Task<IEnumerable<Restaurant>> GetAllAsync();
        Task<(IEnumerable<Restaurant>, int)> GetAllMatchingAsync(string? searchPhrase, int PageSize, int PageNumber);
        Task<Restaurant?> GetByIdAsync(int id);
        Task<int> Create(Restaurant restaurant);
        bool Delete(int id);
        Task<int> Update(Restaurant restaurant);
        

    }
}
