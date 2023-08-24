
namespace help_reviews.Repositories;

public class ReportsRepository
{
  private readonly IDbConnection _db;

  public ReportsRepository(IDbConnection db)
  {
    _db = db;
  }

  internal Report CreateReport(Report reportData)
  {
    string sql = @"
    INSERT INTO reports (title, body, creatorId, restaurantId)
    VALUES (@Title, @Body, @CreatorId, @RestaurantId);
    SELECT LAST_INSERT_ID()
    ;";

    int reportId = _db.ExecuteScalar<int>(sql, reportData);
    reportData.Id = reportId;
    return reportData;
  }

  internal List<Report> GetReportsByRestaurantId(int restaurantId)
  {
    string sql = @"
    SELECT
    rep.*,
    acc.*
    FROM reports rep
    JOIN accounts acc ON acc.id = rep.creatorId
    WHERE rep.restaurantId = @restaurantId
    ;";

    List<Report> reports = _db.Query<Report, Profile, Report>(
      sql,
      (report, profile) =>
      {
        report.Creator = profile;
        return report;
      },
      new { restaurantId }
    ).ToList();

    return reports;
  }
}
