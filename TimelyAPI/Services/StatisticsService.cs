// Services/StatisticsService.cs

using TimelyAPI.Data;

namespace TimelyAPI.Services;

public class StatisticsService
{
    private readonly TimelyDbContext _dbContext;

    public StatisticsService(TimelyDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    /*

    public async Task<IEnumerable<object>> GetTimeInvestmentData(int userId)
    {
        var result = await _dbContext.TimeLogs
            .Where(t => t.UserId == userId)
            .GroupBy(t => t.Activity.Name)
            .Select(g => new
            {
                Activity = g.Key,
                TotalHours = g.Sum(t => t.TotalHours)
            })
            .ToListAsync();

        return result;
    }

    public async Task<IEnumerable<object>> GetWeeklyReport(int userId)
    {
        var startDate = DateTime.Now.AddDays(-7);
        return await _dbContext.TimeLogs
            .Where(t => t.UserId == userId && t.StartTime >= startDate)
            .GroupBy(t => t.StartTime.DayOfWeek)
            .Select(g => new
            {
                Day = g.Key,
                TotalHours = g.Sum(t => t.TotalHours)
            })
            .ToListAsync();
    }

    // Other report methods
    */
}