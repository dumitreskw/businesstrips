using BusinessTrips.Models;

namespace BusinessTrips.Business.Interfaces.Services;

public interface ILoginService
{
    Task<bool> LoginByUser(User user);
}
