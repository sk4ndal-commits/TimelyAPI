// Controllers/StatisticsController.cs

using Microsoft.AspNetCore.Mvc;
using TimelyAPI.Services;

namespace TimelyAPI.Controller;

[Route("api/[controller]")]
[ApiController]
public class StatisticsController : ControllerBase
{
    private readonly StatisticsService _statisticsService;

    public StatisticsController(StatisticsService statisticsService)
    {
        _statisticsService = statisticsService;
    }
/*
       [HttpGet("timeinvestment/{userId}")]
       public async Task<IActionResult> GetTimeInvestmentData(int userId)
       {
           var data = await _statisticsService.GetTimeInvestmentData(userId);
           return Ok(data);
       }

       [HttpGet("weeklyreport/{userId}")]
       public async Task<IActionResult> GetWeeklyReport(int userId)
       {
           var report = await _statisticsService.GetWeeklyReport(userId);
           return Ok(report);
       }

       // Other endpoints
       */
}