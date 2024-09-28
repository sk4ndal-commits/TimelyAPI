// Controllers/UserController.cs

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TimelyAPI.Dtos;
using TimelyAPI.Models;
using TimelyAPI.Services;

namespace TimelyAPI.Controller;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly UserService _userService;
    private readonly PasswordHasher<User> _passwordHasher;

    public UserController(UserService userService)
    {
        _userService = userService;
        _passwordHasher = new PasswordHasher<User>();
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(
        [FromBody] UserRegisterDto userRegisterDto)
    {

        var user = CreateUser(userRegisterDto);

        var result = await _userService.RegisterUser(user);
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

    private User CreateUser(UserRegisterDto userRegisterDto)
    {
        var user = new User
        {
            Email = userRegisterDto.Email,
            UserName = userRegisterDto.UserName,
        };

        user.PasswordHash = _passwordHasher.HashPassword(user, 
            userRegisterDto.Password);
        return user;
    }
}