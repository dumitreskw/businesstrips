using System.ComponentModel.DataAnnotations;

namespace BusinessTrips.Models;

public class CompanyHQ
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    public ICollection<BusinessTrip> BusinessTrips { get; set; }
}
