using BusinessTrips.Business.DTOs;
using BusinessTrips.Business.Interfaces.Services;
using BusinessTrips.Models;
using Microsoft.AspNetCore.Identity;

namespace BusinessTrips.Business.Services;

public class LoginService : ILoginService
{
    private readonly SignInManager<User> _signInManager;

    public LoginService(SignInManager<User> signInManager)
    {
        _signInManager = signInManager;
    }

    public async Task<bool> LoginByUser(User user)
    {
        await _signInManager.SignInAsync(user, isPersistent:false);

        return true;
    }

    public async Task<SignInResult> Login(LoginDTO input)
    {
        var userName = input.Email.Split('@', StringSplitOptions.None)[0];
        var result = await _signInManager.PasswordSignInAsync(userName, input.Password, input.RememberMe, lockoutOnFailure: false);

        return result;
    }
}
