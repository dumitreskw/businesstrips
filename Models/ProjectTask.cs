using System.ComponentModel.DataAnnotations;

namespace BusinessTrips.Models
{
    public class ProjectTask
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Number { get; set; }
        public int ProjectId { get; set; }
        public Project Project { get; set; }
        public ICollection<BusinessTrip> BusinessTrips { get; set; }
    }
}
