// Controllers/ActivityController.cs

using Microsoft.AspNetCore.Mvc;
using TimelyAPI.Models;
using TimelyAPI.Services;

namespace TimelyAPI.Controller;

[Route("api/[controller]")]
[ApiController]
public class ActivityController : ControllerBase
{
    private readonly ActivityService _activityService;

    public ActivityController(ActivityService activityService)
    {
        _activityService = activityService;
    }

    [HttpGet]
    public async Task<IEnumerable<Activity>> GetActivities()
    {
        return await _activityService.GetActivitiesAsync();
    }

    // CRUD Methods
}