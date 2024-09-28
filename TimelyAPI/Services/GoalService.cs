// Services/GoalService.cs

using TimelyAPI.Data;
using TimelyAPI.Models;

namespace TimelyAPI.Services;

public class GoalService
{
    private readonly TimelyDbContext _dbContext;

    public GoalService(TimelyDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task AddGoalAsync(Goal goal)
    {
        _dbContext.Goals.Add(goal);
        await _dbContext.SaveChangesAsync();
    }

    /*
    public async Task<IEnumerable<Goal>> GetGoalsAsync(int userId)
    {
        return await _dbContext.Goals
            .Where(g =>
                g.UserId == userId
                && g.StartDate <= DateTime.Now
                && g.EndDate >= DateTime.Now)
            .ToListAsync();
    }

    public async Task<bool> CheckGoalAchievedAsync(int goalId)
    {
        var goal = await _dbContext.Goals.FindAsync(goalId);
        var totalHours = await _dbContext.TimeLogs
            .Where(t =>
                t.UserId == goal.UserId
                && t.ActivityId == goal.ActivityId
                && t.StartTime >= goal.StartDate
                && t.EndTime <= goal.EndDate)
            .SumAsync(t => t.TotalHours);

        goal.IsAchieved = totalHours >= goal.TargetHours;
        await _dbContext.SaveChangesAsync();
        return goal.IsAchieved;
    }
    */
    // CRUD Methods
}