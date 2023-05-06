using BusinessTrips.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BusinessTrips.DataAccess.EFCore;

public static class SeedData
{
    public static void SeedAccounts(this ModelBuilder builder)
    {
        var hasher = new PasswordHasher<User>();
        builder
            .Entity<User>()
            .HasData(
                new User
                {
                    Id = "8e445865-a24d-4543-a6c6-9443d048cdb7",
                    UserName = "NoRole",
                    NormalizedUserName = "NOROLE",
                    Email = "norole@gmail.com",
                    NormalizedEmail = "NOROLE@GMAIL.COM",
                    PasswordHash = hasher.HashPassword(null, "Pass_2002"),
                    LockoutEnabled = true,
                    EmailConfirmed = true
                },
                new User
                {
                    Id = "9c44780-a24d-4543-9cc6-0993d048aacu7",
                    UserName = "Atmin",
                    NormalizedUserName = "ATMIN",
                    Email = "atmin@gmail.com",
                    NormalizedEmail = "ATMIN@GMAIL.COM",
                    PasswordHash = hasher.HashPassword(null, "Pass_2002"),
                    LockoutEnabled = true,
                    EmailConfirmed = true
                },
                new User
                {
                    Id = "9a27620-a44f-4543-9dk6-0993d048sia7",
                    UserName = "BTO",
                    NormalizedUserName = "BTO",
                    Email = "bto@gmail.com",
                    NormalizedEmail = "BTO@GMAIL.COM",
                    PasswordHash = hasher.HashPassword(null, "Pass_2002"),
                    LockoutEnabled = true,
                    EmailConfirmed = true
                }
            );
    }

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

    public static void SeedRoles(this ModelBuilder builder)
    {
        builder
            .Entity<IdentityRole>()
            .HasData(
                new IdentityRole()
                {
                    Id = "1",
                    Name = "PM",
                    NormalizedName = "PM",
                },
                new IdentityRole()
                {
                    Id = "2",
                    Name = "BTO",
                    NormalizedName = "BTO",
                },
                new IdentityRole()
                {
                    Id = "0",
                    Name = "Employee",
                    NormalizedName = "EMPLOYEE",
                },
                new IdentityRole()
                {
                    Id = "3",
                    Name = "Admin",
                    NormalizedName = "ADMIN",
                }
            );
    }
    public static void SeedUserRoles(this ModelBuilder builder)
    {
        builder
            .Entity<IdentityUserRole<string>>()
            .HasData(
                new IdentityUserRole<string>()
                {
                    UserId = "8e445865-a24d-4543-a6c6-9443d048cdb7",
                    RoleId = "0"
                },
                new IdentityUserRole<string>()
                {
                    UserId = "9c44780-a24d-4543-9cc6-0993d048aacu7",
                    RoleId = "3"
                },
                new IdentityUserRole<string>()
                {
                    UserId = "9a27620-a44f-4543-9dk6-0993d048sia7",
                    RoleId = "2"
                }
            );
    }
}
