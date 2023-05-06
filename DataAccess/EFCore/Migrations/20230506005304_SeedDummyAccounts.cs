using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BusinessTrips.DataAccess.EFCore.Migrations
{
    /// <inheritdoc />
    public partial class SeedDummyAccounts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "8e445865-a24d-4543-a6c6-9443d048cdb7", 0, "e3d3c26e-e2c1-45f6-aac4-b552fe70929c", "User", "norole@gmail.com", true, true, null, "NOROLE@GMAIL.COM", "NOROLE", "AQAAAAIAAYagAAAAED6EqUbkyEvCfj531ZJ1n8f6udUMbqhG7xTH0p5sOdas/6IMf32G5bDt9nyZ2rJ1Tw==", null, false, "7522a47f-e3fc-4f1e-bb12-eefd9f7fb816", false, "NoRole" },
                    { "9a27620-a44f-4543-9dk6-0993d048sia7", 0, "88f1bd5a-195c-47e1-95b7-4f53a34d2350", "User", "bto@gmail.com", true, true, null, "BTO@GMAIL.COM", "BTO", "AQAAAAIAAYagAAAAEFayTXbwYQnRUTFRmuqRxMs2V8cCUFZNCTE754fbGYHKykUD8S443Z2Z7bURSIgGNw==", null, false, "f69a4292-548f-4f56-82a9-7ec4520af5b5", false, "BTO" },
                    { "9c44780-a24d-4543-9cc6-0993d048aacu7", 0, "cc99416c-ea85-46f1-9c16-49b06df5197a", "User", "atmin@gmail.com", true, true, null, "ATMIN@GMAIL.COM", "ATMIN", "AQAAAAIAAYagAAAAENV1qazlQxcF4m1yEBhzc8HLYkKw5y2RYkGzJ6VMyo946+MS3kICA4f6XvWv8HiYZw==", null, false, "43fbd2ad-4f41-48b9-945f-096307be6cde", false, "Atmin" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "0", "8e445865-a24d-4543-a6c6-9443d048cdb7" },
                    { "2", "9a27620-a44f-4543-9dk6-0993d048sia7" },
                    { "3", "9c44780-a24d-4543-9cc6-0993d048aacu7" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "0", "8e445865-a24d-4543-a6c6-9443d048cdb7" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "2", "9a27620-a44f-4543-9dk6-0993d048sia7" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "3", "9c44780-a24d-4543-9cc6-0993d048aacu7" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb7");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9a27620-a44f-4543-9dk6-0993d048sia7");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9c44780-a24d-4543-9cc6-0993d048aacu7");
        }
    }
}
