
namespace help_reviews.Services;

public class ReportsService
{
  private readonly ReportsRepository _reportsRepository;
  private readonly RestaurantsService _restaurantsService;

  public ReportsService(ReportsRepository reportsRepository, RestaurantsService restaurantsService)
  {
    _reportsRepository = reportsRepository;
    _restaurantsService = restaurantsService;
  }

  internal Report CreateReport(Report reportData)
  {
    // NOTE just checking
    _restaurantsService.GetRestaurantById(reportData.RestaurantId, reportData.CreatorId);

    Report report = _reportsRepository.CreateReport(reportData);
    return report;
  }

  internal List<Report> GetReportsByRestaurantId(int restaurantId, string userId)
  {
    _restaurantsService.GetRestaurantById(restaurantId, userId);
    List<Report> reports = _reportsRepository.GetReportsByRestaurantId(restaurantId);
    return reports;
  }
}
