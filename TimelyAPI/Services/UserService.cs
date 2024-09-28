// Services/UserService.cs

using Microsoft.AspNetCore.Identity;
using TimelyAPI.Models;

namespace TimelyAPI.Services;

public class UserService
{
    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;

    public UserService(UserManager<User> userManager, SignInManager<User> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }

    public async Task<IdentityResult> RegisterUser(User user)
    {
        return await _userManager.CreateAsync(user, user.PasswordHash!);
    }

    public async Task<SignInResult> LoginUser(string email, string password)
    {
        return await _signInManager.PasswordSignInAsync(email, password, false, false);
    }
    // CRUD Methods
}