using BusinessTrips.Business.DTOs;
using BusinessTrips.Models;

namespace BusinessTrips.Business.Interfaces.Services;

public interface IRegisterService
{
    Task<User> RegisterUserAsync(RegisterDTO input);
}
