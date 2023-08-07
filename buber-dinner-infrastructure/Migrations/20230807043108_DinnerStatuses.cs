using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BuberDinner.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class DinnerStatuses : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DinnerStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2(7)", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2(7)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DinnerStatuses", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "DinnerStatuses",
                columns: new[] { "Id", "CreatedOn", "ModifiedOn", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 8, 7, 4, 31, 8, 345, DateTimeKind.Utc).AddTicks(879), new DateTime(2023, 8, 7, 4, 31, 8, 345, DateTimeKind.Utc).AddTicks(881), "Upcoming" },
                    { 2, new DateTime(2023, 8, 7, 4, 31, 8, 345, DateTimeKind.Utc).AddTicks(892), new DateTime(2023, 8, 7, 4, 31, 8, 345, DateTimeKind.Utc).AddTicks(892), "InProgress" },
                    { 3, new DateTime(2023, 8, 7, 4, 31, 8, 345, DateTimeKind.Utc).AddTicks(894), new DateTime(2023, 8, 7, 4, 31, 8, 345, DateTimeKind.Utc).AddTicks(894), "Ended" },
                    { 4, new DateTime(2023, 8, 7, 4, 31, 8, 345, DateTimeKind.Utc).AddTicks(895), new DateTime(2023, 8, 7, 4, 31, 8, 345, DateTimeKind.Utc).AddTicks(895), "Cancelled" }
                });

            migrationBuilder.UpdateData(
                table: "ReservationStatuses",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2023, 8, 7, 4, 31, 8, 359, DateTimeKind.Utc).AddTicks(7711), new DateTime(2023, 8, 7, 4, 31, 8, 359, DateTimeKind.Utc).AddTicks(7713) });

            migrationBuilder.UpdateData(
                table: "ReservationStatuses",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2023, 8, 7, 4, 31, 8, 359, DateTimeKind.Utc).AddTicks(7719), new DateTime(2023, 8, 7, 4, 31, 8, 359, DateTimeKind.Utc).AddTicks(7719) });

            migrationBuilder.UpdateData(
                table: "ReservationStatuses",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2023, 8, 7, 4, 31, 8, 359, DateTimeKind.Utc).AddTicks(7721), new DateTime(2023, 8, 7, 4, 31, 8, 359, DateTimeKind.Utc).AddTicks(7721) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DinnerStatuses");

            migrationBuilder.UpdateData(
                table: "ReservationStatuses",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2023, 8, 7, 4, 19, 42, 963, DateTimeKind.Utc).AddTicks(2159), new DateTime(2023, 8, 7, 4, 19, 42, 963, DateTimeKind.Utc).AddTicks(2162) });

            migrationBuilder.UpdateData(
                table: "ReservationStatuses",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2023, 8, 7, 4, 19, 42, 963, DateTimeKind.Utc).AddTicks(2169), new DateTime(2023, 8, 7, 4, 19, 42, 963, DateTimeKind.Utc).AddTicks(2169) });

            migrationBuilder.UpdateData(
                table: "ReservationStatuses",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2023, 8, 7, 4, 19, 42, 963, DateTimeKind.Utc).AddTicks(2171), new DateTime(2023, 8, 7, 4, 19, 42, 963, DateTimeKind.Utc).AddTicks(2171) });
        }
    }
}
