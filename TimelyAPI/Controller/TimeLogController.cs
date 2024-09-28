// Controllers/TimeLogController.cs

using Microsoft.AspNetCore.Mvc;
using TimelyAPI.Services;

namespace TimelyAPI.Controller;

[Route("api/[controller]")]
[ApiController]
public class TimeLogController : ControllerBase
{
    private readonly TimeLogService _timeLogService;

    public TimeLogController(TimeLogService timeLogService)
    {
        _timeLogService = timeLogService;
    }
/*
       [HttpPost]
       public async Task<IActionResult> AddTimeLog(TimeLog timeLog)
       {
           await _timeLogService.AddTimeLogAsync(timeLog);
           return Ok();
       }

       [HttpGet("{userId}/{startDate}/{endDate}")]
       public async Task<IActionResult> GetTimeLogs(int userId, DateTime startDate, DateTime endDate)
       {
           var logs = await _timeLogService.GetTimeLogsAsync(userId, startDate, endDate);
           return Ok(logs);
       }

       // CRUD Methods
       */
}