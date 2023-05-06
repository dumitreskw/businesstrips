using BusinessTrips.Business.DTOs;

namespace BusinessTrips.Business.Interfaces.Services;

public interface IUserService
{
    Task<IEnumerable<UserDTO>> GetAllWithRoles();
}
