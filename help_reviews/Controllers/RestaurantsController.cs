
namespace help_reviews.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RestaurantsController : ControllerBase
{
  private readonly RestaurantsService _restaurantsService;
  private readonly ReportsService _reportsService;
  private readonly Auth0Provider _auth0Provider;

  public RestaurantsController(RestaurantsService restaurantsService, Auth0Provider auth0Provider, ReportsService reportsService)
  {
    _restaurantsService = restaurantsService;
    _auth0Provider = auth0Provider;
    _reportsService = reportsService;
  }

  [HttpPost]
  [Authorize]
  public async Task<ActionResult<Restaurant>> CreateRestaurant([FromBody] Restaurant restaurantData)
  {
    try
    {
      Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
      restaurantData.CreatorId = userInfo.Id;
      Restaurant restaurant = _restaurantsService.CreateRestaurant(restaurantData);
      return Ok(restaurant);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }

  [HttpGet("{restaurantId}")]
  public async Task<ActionResult<Restaurant>> GetRestaurantById(int restaurantId)
  {
    try
    {
      Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
      Restaurant restaurant = _restaurantsService.GetRestaurantByIdAndIncreaseVisits(restaurantId, userInfo?.Id);
      return Ok(restaurant);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }

  // NOTE would be useful for queries
  // [HttpGet]
  // public async Task<ActionResult<List<Restaurant>>> GetRestaurants([FromQuery] string name)
  // {
  //   try
  //   {
  //     // NOTE set this up to parameterize with dapper
  //     // name = $"%{name}%";
  //     Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
  //     List<Restaurant> restaurants = _restaurantsService.GetRestaurants(userInfo?.Id);
  //     return Ok(restaurants);
  //   }
  //   catch (Exception e)
  //   {
  //     return BadRequest(e.Message);
  //   }
  // }

  [HttpGet]
  public async Task<ActionResult<List<Restaurant>>> GetRestaurants()
  {
    try
    {
      Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
      List<Restaurant> restaurants = _restaurantsService.GetRestaurants(userInfo?.Id);
      return Ok(restaurants);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }


  [HttpPut("{restaurantId}")]
  [Authorize]
  public async Task<ActionResult<Restaurant>> UpdateRestaurant(int restaurantId, [FromBody] Restaurant restaurantData)
  {
    try
    {
      Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
      restaurantData.Id = restaurantId;
      Restaurant restaurant = _restaurantsService.UpdateRestaurant(restaurantData, userInfo.Id);
      return Ok(restaurant);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }


  [HttpGet("{restaurantId}/reports")]
  public async Task<ActionResult<List<Report>>> GetReportsByRestaurantId(int restaurantId)
  {
    try
    {
      Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
      List<Report> reports = _reportsService.GetReportsByRestaurantId(restaurantId, userInfo?.Id);
      return Ok(reports);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }
}
