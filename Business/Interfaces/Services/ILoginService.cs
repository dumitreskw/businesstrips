using BusinessTrips.Business.DTOs;
using BusinessTrips.Models;
using Microsoft.AspNetCore.Identity;

namespace BusinessTrips.Business.Interfaces.Services;

public interface ILoginService
{
    Task<bool> LoginByUser(User user);
    Task<SignInResult> Login(LoginDTO input);
}
