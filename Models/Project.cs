using System.ComponentModel.DataAnnotations;

namespace BusinessTrips.Models;

public class Project
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    public string Number { get; set; }
    public ICollection<ProjectTask> Tasks { get; set; }
    public ICollection<BusinessTrip> BusinessTrips { get; set; }
}
