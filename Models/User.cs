using Microsoft.AspNetCore.Identity;

namespace BusinessTrips.Models;

public class User
{
    public string Id { get; set; }
    public string UserName { get; set; }
    public ICollection<BusinessTrip> BusinessTrips { get; set; }
    public ICollection<BusinessTrip> ManagedBusinessTrips { get; set; }
}
