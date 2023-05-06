using BusinessTrips.Business.DTOs;
using BusinessTrips.Business.Interfaces.Services;
using BusinessTrips.Business.Services;
using BusinessTrips.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BusinessTrips.Controllers;

[Authorize(Roles = "Admin")]
public class AdminController : Controller
{
    private readonly IUserService _userService;
    public IEnumerable<UserDTO> Users { get; set; } = new List<UserDTO>();
    public AdminController(IUserService userService)
    {
        _userService = userService;
    }

    public async Task<IActionResult> Index()
    {
        Users = await _userService.GetAllWithRoles();

        return View(Users);
    }
}
