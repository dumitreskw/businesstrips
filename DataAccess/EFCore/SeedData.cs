using BusinessTrips.Models;
using Microsoft.EntityFrameworkCore;

namespace BusinessTrips.DataAccess.EFCore;

public static class SeedData
{
    public static void SeedHQs(this ModelBuilder builder)
    {
        builder.Entity<CompanyHQ>().HasIndex(area => area.Name).IsUnique();
        builder
            .Entity<CompanyHQ>()
            .HasData(
                new { Id = 1, Name = "Craiova" },
                new { Id = 2, Name = "Sibiu" },
                new { Id = 3, Name = "Cluj-Napoca" },
                new { Id = 4, Name = "Timisoara" },
                new { Id = 5, Name = "Bucuresti" },
                new { Id = 6, Name = "Brasov" }
            );
    }

    public static void SeedClientLocations(this ModelBuilder builder)
    {
        builder.Entity<ClientLocation>().HasIndex(area => area.Name).IsUnique();
        builder
            .Entity<ClientLocation>()
            .HasData(
                new { Id = 1, Name = "Dubai" },
                new { Id = 2, Name = "Stockholm" },
                new { Id = 3, Name = "Beijing" },
                new { Id = 4, Name = "Los Angeles" },
                new { Id = 5, Name = "Dublin" },
                new { Id = 6, Name = "Cairo" }
            );
    }

    public static void SeedClients(this ModelBuilder builder)
    {
        builder
            .Entity<Client>()
            .HasData(
                new Client { Id = 1, Name = "Jack", },
                new Client { Id = 2, Name = "Matthew", },
                new Client { Id = 3, Name = "Alin", }
            );
    }

    public static void SeedProjects(this ModelBuilder builder)
    {
        builder
            .Entity<Project>()
            .HasData(
                new Project
                {
                    Id = 1,
                    Name = "Project Nemesis",
                    Number = "bd009"
                }
            );
    }

    public static void SeedTasks(this ModelBuilder builder)
    {
        builder
            .Entity<ProjectTask>()
            .HasData(
                new ProjectTask
                {
                    Id = 1,
                    Name = "task1",
                    Number = "skvn",
                    ProjectId = 1
                }
            );
    }
}
