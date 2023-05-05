using BusinessTrips.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessTrips.Models
{
    public class BusinessTrip
    {
        [Key]
        public int Id { get; set; }
        public string PMName { get; set; }
        public string MeanOfTransportation { get; set; }
        public string Accomodation { get; set; }
        public string ExtraInfo { get; set; }
        public bool NeedOfPhone { get; set; }
        public bool NeedOfBankCard { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public int LeavingFromId { get; set; }
        public CompanyHQ LeavingFrom { get; set; }
        public int GoingToId { get; set; }
        public ClientLocation GoingTo { get; set; }
        public int ClientId { get; set; }
        public Client Client { get; set; }
        public int ProjectId { get; set; }
        public Project Project { get; set; }
        public int ProjectTaskId { get; set; }
        public ProjectTask ProjectTask { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
        public string BTOId { get; set; }
        public User BTO { get; set; }
        public StatusTypes Status { get; set; }
    }
}
