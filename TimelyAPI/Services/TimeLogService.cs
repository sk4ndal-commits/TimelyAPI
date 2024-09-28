// Services/TimeLogService.cs

using TimelyAPI.Data;

namespace TimelyAPI.Services;

public class TimeLogService
{
    private readonly TimelyDbContext _dbContext;

    public TimeLogService(TimelyDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    /*
    public async Task AddTimeLogAsync(TimeLog timeLog)
    {
        timeLog.TotalHours = (timeLog.EndTime - timeLog.StartTime).TotalHours;
        _dbContext.TimeLogs.Add(timeLog);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<IEnumerable<TimeLog>> GetTimeLogsAsync(int userId, DateTime startDate, DateTime endDate)
    {
        return await _dbContext.TimeLogs
            .Where(t => t.UserId == userId && t.StartTime >= startDate && t.EndTime <= endDate)
            .ToListAsync();
    }
    // CRUD Methods
    */
}