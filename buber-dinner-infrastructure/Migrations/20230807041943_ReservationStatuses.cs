using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BuberDinner.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ReservationStatuses : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ReservationStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2(7)", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2(7)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReservationStatuses", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "ReservationStatuses",
                columns: new[] { "Id", "CreatedOn", "ModifiedOn", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 8, 7, 4, 19, 42, 963, DateTimeKind.Utc).AddTicks(2159), new DateTime(2023, 8, 7, 4, 19, 42, 963, DateTimeKind.Utc).AddTicks(2162), "PendingGuestConfirmation" },
                    { 2, new DateTime(2023, 8, 7, 4, 19, 42, 963, DateTimeKind.Utc).AddTicks(2169), new DateTime(2023, 8, 7, 4, 19, 42, 963, DateTimeKind.Utc).AddTicks(2169), "Reserved" },
                    { 3, new DateTime(2023, 8, 7, 4, 19, 42, 963, DateTimeKind.Utc).AddTicks(2171), new DateTime(2023, 8, 7, 4, 19, 42, 963, DateTimeKind.Utc).AddTicks(2171), "Cancelled" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReservationStatuses");
        }
    }
}
