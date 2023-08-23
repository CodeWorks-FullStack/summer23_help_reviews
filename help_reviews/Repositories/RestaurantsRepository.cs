

namespace help_reviews.Repositories;

public class RestaurantsRepository
{
  private readonly IDbConnection _db;

  public RestaurantsRepository(IDbConnection db)
  {
    _db = db;
  }

  internal int CreateRestaurant(Restaurant restaurantData)
  {
    string sql = @"
    INSERT INTO restaurants(name, description, imgUrl, creatorId, isShutdown)
    VALUES(@Name, @Description, @ImgUrl, @CreatorId, @IsShutdown);
    SELECT LAST_INSERT_ID()
    ;";

    int restaurantId = _db.ExecuteScalar<int>(sql, restaurantData);
    return restaurantId;
  }

  internal Restaurant GetRestaurantById(int restaurantId)
  {
    string sql = @"
    SELECT
    rest.*,
    acc.*
    FROM restaurants rest
    JOIN accounts acc ON acc.id = rest.creatorId
    WHERE rest.id = @restaurantId
    ;";

    Restaurant restaurant = _db.Query<Restaurant, Profile, Restaurant>(
      sql,
      (restaurant, profile) =>
      {
        restaurant.Creator = profile;
        return restaurant;
      },
      new { restaurantId }
    ).FirstOrDefault();

    return restaurant;
  }

  internal List<Restaurant> GetRestaurants()
  {
    string sql = @"
    SELECT
    rest.*,
    acc.*
    FROM restaurants rest
    JOIN accounts acc ON acc.id = rest.creatorId
    ;";

    List<Restaurant> restaurants = _db.Query<Restaurant, Profile, Restaurant>(
      sql,
      (restaurant, profile) =>
      {
        restaurant.Creator = profile;
        return restaurant;
      }
    ).ToList();

    return restaurants;
  }

  internal void UpdateRestaurant(Restaurant originalRestaurant)
  {
    string sql = @"
    UPDATE restaurants
    SET
    name = @Name,
    description = @Description,
    imgUrl = @ImgUrl,
    isShutDown = @IsShutDown
    WHERE id = @Id
    ;";

    _db.Execute(sql, originalRestaurant);
  }
}
