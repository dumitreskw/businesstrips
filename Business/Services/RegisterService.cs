using AutoMapper;
using BusinessTrips.Business.DTOs;
using BusinessTrips.Business.Interfaces.Services;
using BusinessTrips.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;
using System.Text;

namespace BusinessTrips.Business.Services;

public class RegisterService : IRegisterService
{
    private readonly UserManager<User> _userManager;
    private readonly IUserEmailStore<User> _emailStore;
    private readonly ILogger<RegisterService> _logger;
    private readonly IMapper _mapper;

    public RegisterService(
        UserManager<User> userManager,
        IUserStore<User> userStore,
        ILogger<RegisterService> logger,
        IMapper mapper)
    {
        _userManager = userManager;
        _emailStore = (IUserEmailStore<User>)userStore;
        _logger = logger;
        _mapper = mapper;
    }

    public async Task<User> RegisterUserAsync(RegisterDTO input)
    {
        User user = _mapper.Map<User>(input);
       
        await _emailStore.SetEmailAsync(user, input.Email, default);
        var result = await _userManager.CreateAsync(user, input.Password);

        if (!result.Succeeded)
        {
            return new User();
        }

        _logger.LogInformation("User created a new account with password.");

        var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
        code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));

        await _userManager.ConfirmEmailAsync(user, code);
        return user;
    }
}
