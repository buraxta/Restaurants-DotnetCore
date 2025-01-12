
namespace Restaurants.Infrastructure.Authorization
{
    public static class PolicyNames
    {
        public const string HasNationality = "HasNationality";
        public const string AtLeaset20 = "AtLeaset20";
        public const string CreatedMultipleRestaurants = "CreatedMultipleRestaurants";

    } 
    public static class AppClaimTypes
    {
        public const string Nationality = "Nationality";
        public const string DateOfBirth = "DateOfBirth";
    }
}
