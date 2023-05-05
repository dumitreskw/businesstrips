using Microsoft.AspNetCore.Identity;

namespace BusinessTrips.Models;

public class User : IdentityUser
{
    public ICollection<BusinessTrip> BusinessTrips { get; set; }
    public ICollection<BusinessTrip> ManagedBusinessTrips { get; set; }
}
