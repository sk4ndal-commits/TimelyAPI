// Controllers/GoalController.cs

using Microsoft.AspNetCore.Mvc;
using TimelyAPI.Models;
using TimelyAPI.Services;

namespace TimelyAPI.Controller;

[Route("api/[controller]")]
[ApiController]
public class GoalController : ControllerBase
{
    private readonly GoalService _goalService;

    public GoalController(GoalService goalService)
    {
        _goalService = goalService;
    }

    [HttpPost]
    public async Task<IActionResult> AddGoal(Goal goal)
    {
        await _goalService.AddGoalAsync(goal);
        return Ok();
    }
/*
       [HttpGet("{userId}")]
       public async Task<IActionResult> GetGoals(int userId)
       {
           var goals = await _goalService.GetGoalsAsync(userId);
           return Ok(goals);
       }

       [HttpPost("check/{goalId}")]
       public async Task<IActionResult> CheckGoalAchieved(int goalId)
       {
           var isAchieved = await _goalService.CheckGoalAchievedAsync(goalId);
           return Ok(isAchieved);
       }

       // CRUD Methods
       */
}