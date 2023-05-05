using BusinessTrips.Business.Interfaces;
using BusinessTrips.DataAccess;
using BusinessTrips.Models;
using System;
namespace BusinessTrips.Business;

internal class UnitOfWork : IUnitOfWork
{
    private readonly BusinessTripsContext _dbContext;
    private bool disposedValue;

    public IBaseRepository<CompanyHQ, int> AreaRepository { get; set; }
    public IBaseRepository<ClientLocation, int> ClientLocationRepository { get; set; }
    public IBaseRepository<User, string> UserRepository { get; set; }
    public IBaseRepository<BusinessTrip, int> BusinessTripRepository { get; set; }
    public IBaseRepository<Client, int> ClientRepository { get; set; }
    public IBaseRepository<ProjectTask, int> ProjectTaskRepository { get; set; }
    public IBaseRepository<Project, int> ProjectRepository { get; set; }

    public UnitOfWork(
        BusinessTripsContext dbContext,
        IBaseRepository<CompanyHQ, int> areaRepository,
        IBaseRepository<ClientLocation, int> clientLocationRepository,
        IBaseRepository<User, string> userRepository,
        IBaseRepository<BusinessTrip, int> businessTripRepository,
        IBaseRepository<Client, int> clientRepository,
        IBaseRepository<Project, int> projectRepository,
        IBaseRepository<ProjectTask, int> projectTaskRepository
    )
    {
        _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        AreaRepository = areaRepository ?? throw new ArgumentNullException(nameof(areaRepository));
        UserRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
        BusinessTripRepository =
            businessTripRepository
            ?? throw new ArgumentNullException(nameof(businessTripRepository));
        ClientRepository =
            clientRepository ?? throw new ArgumentNullException(nameof(clientRepository));
        ClientLocationRepository =
            clientLocationRepository
            ?? throw new ArgumentNullException(nameof(clientLocationRepository));
        ProjectRepository =
            projectRepository ?? throw new ArgumentNullException(nameof(projectRepository));
        ProjectTaskRepository =
            projectTaskRepository ?? throw new ArgumentNullException(nameof(projectTaskRepository));
    }

    public void Save()
    {
        _dbContext.SaveChanges();
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!disposedValue)
        {
            if (disposing)
            {
                _dbContext?.Dispose();
            }
            disposedValue = true;
        }
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}