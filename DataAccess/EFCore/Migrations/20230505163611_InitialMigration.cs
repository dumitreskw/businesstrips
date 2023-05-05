using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BusinessTrips.DataAccess.EFCore.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ClientLocations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientLocations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "companyHQs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_companyHQs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Number = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProjectTasks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProjectId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectTasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjectTasks_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "BusinessTrips",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PMName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MeanOfTransportation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Accomodation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExtraInfo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NeedOfPhone = table.Column<bool>(type: "bit", nullable: false),
                    NeedOfBankCard = table.Column<bool>(type: "bit", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LeavingFromId = table.Column<int>(type: "int", nullable: false),
                    GoingToId = table.Column<int>(type: "int", nullable: false),
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    ProjectId = table.Column<int>(type: "int", nullable: false),
                    ProjectTaskId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    BTOId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessTrips", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BusinessTrips_ClientLocations_GoingToId",
                        column: x => x.GoingToId,
                        principalTable: "ClientLocations",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BusinessTrips_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BusinessTrips_ProjectTasks_ProjectTaskId",
                        column: x => x.ProjectTaskId,
                        principalTable: "ProjectTasks",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BusinessTrips_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BusinessTrips_Users_BTOId",
                        column: x => x.BTOId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BusinessTrips_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BusinessTrips_companyHQs_LeavingFromId",
                        column: x => x.LeavingFromId,
                        principalTable: "companyHQs",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "ClientLocations",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Dubai" },
                    { 2, "Stockholm" },
                    { 3, "Beijing" },
                    { 4, "Los Angeles" },
                    { 5, "Dublin" },
                    { 6, "Cairo" }
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "Name", "Number" },
                values: new object[] { 1, "Project Nemesis", "bd009" });

            migrationBuilder.InsertData(
                table: "companyHQs",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Craiova" },
                    { 2, "Sibiu" },
                    { 3, "Cluj-Napoca" },
                    { 4, "Timisoara" },
                    { 5, "Bucuresti" },
                    { 6, "Brasov" }
                });

            migrationBuilder.InsertData(
                table: "ProjectTasks",
                columns: new[] { "Id", "Name", "Number", "ProjectId" },
                values: new object[] { 1, "task1", "skvn", 1 });

            migrationBuilder.CreateIndex(
                name: "IX_BusinessTrips_BTOId",
                table: "BusinessTrips",
                column: "BTOId");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessTrips_ClientId",
                table: "BusinessTrips",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessTrips_GoingToId",
                table: "BusinessTrips",
                column: "GoingToId");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessTrips_LeavingFromId",
                table: "BusinessTrips",
                column: "LeavingFromId");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessTrips_ProjectId",
                table: "BusinessTrips",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessTrips_ProjectTaskId",
                table: "BusinessTrips",
                column: "ProjectTaskId");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessTrips_UserId",
                table: "BusinessTrips",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientLocations_Name",
                table: "ClientLocations",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_companyHQs_Name",
                table: "companyHQs",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProjectTasks_ProjectId",
                table: "ProjectTasks",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BusinessTrips");

            migrationBuilder.DropTable(
                name: "ClientLocations");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "ProjectTasks");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "companyHQs");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
