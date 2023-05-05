using BusinessTrips.Business.Interfaces;
using BusinessTrips.Business.Interfaces.Services;
using BusinessTrips.Models;
using Microsoft.AspNetCore.Identity;

namespace BusinessTrips.Business.Services;

public class LoginService : ILoginService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly SignInManager<User> _signInManager;

    public LoginService(IUnitOfWork unitOfWork,
        SignInManager<User> signInManager)
    {
        _unitOfWork = unitOfWork;
        _signInManager = signInManager;
    }

    public async Task<bool> LoginByUser(User user)
    {
        await _signInManager.SignInAsync(user, isPersistent:false);

        return true;
    }



}
