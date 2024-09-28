// Controllers/UserController.cs

using Microsoft.AspNetCore.Mvc;
using TimelyAPI.Models;
using TimelyAPI.Services;

namespace TimelyAPI.Controller;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly UserService _userService;

    public UserController(UserService userService)
    {
        _userService = userService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(User user, string password)
    {
        var result = await _userService.RegisterUser(user, password);
        if (result.Succeeded)
        {
            return Ok();
        }

        return BadRequest(result.Errors);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(string email, string password)
    {
        var result = await _userService.LoginUser(email, password);
        if (result.Succeeded)
        {
            return Ok();
        }

        return Unauthorized();
    }

    // CRUD Methods
}