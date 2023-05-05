using BusinessTrips.DataAccess.EFCore;
using BusinessTrips.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BusinessTrips.DataAccess;

public class BusinessTripsContext : IdentityDbContext<IdentityUser>
{
    public DbSet<User> Users { get; set; }
    public DbSet<CompanyHQ> companyHQs { get; set; }
    public DbSet<ClientLocation> ClientLocations { get; set; }
    public DbSet<Project> Projects { get; set; }
    public DbSet<ProjectTask> ProjectTasks { get; set; }
    public DbSet<Client> Clients { get; set; }
    public DbSet<BusinessTrip> BusinessTrips { get; set; }

    public BusinessTripsContext(DbContextOptions<BusinessTripsContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.SeedHQs();
        modelBuilder.SeedClientLocations();
        modelBuilder.SeedProjects();
        modelBuilder.SeedTasks();
        modelBuilder.SeedRoles();

        modelBuilder.Entity<ProjectTask>(entity =>
        {
            entity
                .HasOne(t => t.Project)
                .WithMany(p => p.Tasks)
                .HasForeignKey(t => t.ProjectId)
                .OnDelete(DeleteBehavior.ClientNoAction);

            entity.Navigation(t => t.Project).AutoInclude();
        });

        modelBuilder.Entity<BusinessTrip>(entity =>
        {
            entity
                .HasOne(b => b.User)
                .WithMany(u => u.BusinessTrips)
                .HasForeignKey(b => b.UserId)
                .OnDelete(DeleteBehavior.ClientNoAction);
            entity
                .HasOne(b => b.BTO)
                .WithMany(u => u.ManagedBusinessTrips)
                .HasForeignKey(b => b.BTOId)
                .OnDelete(DeleteBehavior.ClientNoAction);
            entity
                .HasOne(b => b.LeavingFrom)
                .WithMany(a => a.BusinessTrips)
                .HasForeignKey(b => b.LeavingFromId)
                .OnDelete(DeleteBehavior.ClientNoAction);
            entity
                .HasOne(b => b.GoingTo)
                .WithMany(a => a.BusinessTrips)
                .HasForeignKey(b => b.GoingToId)
                .OnDelete(DeleteBehavior.ClientNoAction);
            entity
                .HasOne(b => b.Client)
                .WithMany(c => c.BusinessTrips)
                .HasForeignKey(b => b.ClientId)
                .OnDelete(DeleteBehavior.ClientNoAction);
            entity
                .HasOne(b => b.Project)
                .WithMany(p => p.BusinessTrips)
                .HasForeignKey(b => b.ProjectId)
                .OnDelete(DeleteBehavior.ClientNoAction);
            entity
                .HasOne(b => b.ProjectTask)
                .WithMany(t => t.BusinessTrips)
                .HasForeignKey(b => b.ProjectTaskId)
                .OnDelete(DeleteBehavior.ClientNoAction);

            entity.Navigation(b => b.User).AutoInclude();
            entity.Navigation(b => b.BTO).AutoInclude();
            entity.Navigation(b => b.Project).AutoInclude();
            entity.Navigation(b => b.ProjectTask).AutoInclude();
            entity.Navigation(b => b.LeavingFrom).AutoInclude();
            entity.Navigation(b => b.Client).AutoInclude();
            entity.Navigation(b => b.GoingTo).AutoInclude();
            entity.Property(b => b.ExtraInfo).IsRequired(false);
            entity.Property(b => b.BTOId).IsRequired(false);
        });
    }
}
