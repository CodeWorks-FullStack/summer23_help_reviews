
namespace help_reviews.Services;

public class RestaurantsService
{
  private readonly RestaurantsRepository _restaurantsRepository;

  public RestaurantsService(RestaurantsRepository restaurantsRepository)
  {
    _restaurantsRepository = restaurantsRepository;
  }

  internal Restaurant CreateRestaurant(Restaurant restaurantData)
  {
    int restaurantId = _restaurantsRepository.CreateRestaurant(restaurantData);

    Restaurant restaurant = GetRestaurantById(restaurantId, restaurantData.CreatorId);

    return restaurant;
  }

  internal Restaurant GetRestaurantById(int restaurantId, string userId = null)
  {
    Restaurant restaurant = _restaurantsRepository.GetRestaurantById(restaurantId);
    if (restaurant == null)
    {
      throw new Exception($"Bad restaurant id: {restaurantId}");
    }

    if (restaurant.IsShutDown == true && restaurant.CreatorId != userId)
    {
      throw new Exception($"Bad restaurant id: {restaurantId}. Sorry dude 😏");
    }

    return restaurant;
  }

  internal List<Restaurant> GetRestaurants(string userId)
  {
    List<Restaurant> restaurants = _restaurantsRepository.GetRestaurants();

    restaurants = restaurants.FindAll(restaurant => restaurant.IsShutDown == false || restaurant.CreatorId == userId);

    return restaurants;
  }

  internal Restaurant UpdateRestaurant(Restaurant restaurantData, string userId)
  {
    Restaurant originalRestaurant = GetRestaurantById(restaurantData.Id, userId);
    if (originalRestaurant.CreatorId != userId)
    {
      throw new Exception("NOT YOUR RESTAURANT");
    }

    originalRestaurant.Name = restaurantData.Name ?? originalRestaurant.Name;
    originalRestaurant.Description = restaurantData.Description ?? originalRestaurant.Description;
    originalRestaurant.ImgUrl = restaurantData.ImgUrl ?? originalRestaurant.ImgUrl;
    originalRestaurant.IsShutDown = restaurantData.IsShutDown ?? originalRestaurant.IsShutDown;

    _restaurantsRepository.UpdateRestaurant(originalRestaurant);

    return originalRestaurant;

  }
}
