
namespace Restaurants.API.Controllers
{
    public interface IWeatherForecastService
    {
        IEnumerable<WeatherForecast> Get(int result, int min, int max);
    }
}