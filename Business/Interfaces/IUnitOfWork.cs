using BusinessTrips.Models;
namespace BusinessTrips.Business.Interfaces;

public interface IUnitOfWork
{
    IBaseRepository<CompanyHQ, int> AreaRepository { get; set; }
    IBaseRepository<ClientLocation, int> ClientLocationRepository { get; set; }
    IBaseRepository<User, string> UserRepository { get; set; }
    IBaseRepository<BusinessTrip, int> BusinessTripRepository { get; set; }
    IBaseRepository<Client, int> ClientRepository { get; set; }
    IBaseRepository<ProjectTask, int> ProjectTaskRepository { get; set; }
    IBaseRepository<Project, int> ProjectRepository { get; set; }
    void Save();
}
