// Services/ActivityService.cs

using Microsoft.EntityFrameworkCore;
using TimelyAPI.Data;
using TimelyAPI.Models;

namespace TimelyAPI.Services;

public class ActivityService
{
    private readonly TimelyDbContext _dbContext;

    public ActivityService(TimelyDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<Activity>> GetActivitiesAsync()
    {
        return await _dbContext.Activities.ToListAsync();
    }
    // CRUD Methods
}