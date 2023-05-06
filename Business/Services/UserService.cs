using BusinessTrips.Business.DTOs;
using BusinessTrips.Business.Interfaces.Services;
using BusinessTrips.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BusinessTrips.Business.Services;

public class UserService : IUserService
{
    private readonly UserManager<User> _userManager;

    public UserService(UserManager<User> userManager)
    {
        _userManager = userManager;
    }
    public async Task<IEnumerable<UserDTO>> GetAllWithRoles()
    {
        var users = await _userManager.Users.ToListAsync();
        List<UserDTO> usersWithRoles = new();

        foreach (var u in users) { 
            var role = await _userManager.GetRolesAsync(u);
            var accountStatus = u.LockoutEnd > DateTime.UtcNow.ToUniversalTime();

            usersWithRoles.Add(new UserDTO
            {
                Id = u.Id,
                Email = u.Email,
                AccountStatus = accountStatus,
                UserRole = role.First(),
                UserName = u.UserName,
                IsEmailConfirmed = u.EmailConfirmed
            });
        }

        return usersWithRoles.OrderBy(u => u.UserName);
    }
}
