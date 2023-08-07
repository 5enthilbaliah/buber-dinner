using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BuberDinner.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UserRelated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2(7)", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2(7)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "DinnerStatuses",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2023, 8, 7, 5, 6, 27, 705, DateTimeKind.Utc).AddTicks(4133), new DateTime(2023, 8, 7, 5, 6, 27, 705, DateTimeKind.Utc).AddTicks(4135) });

            migrationBuilder.UpdateData(
                table: "DinnerStatuses",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2023, 8, 7, 5, 6, 27, 705, DateTimeKind.Utc).AddTicks(4140), new DateTime(2023, 8, 7, 5, 6, 27, 705, DateTimeKind.Utc).AddTicks(4140) });

            migrationBuilder.UpdateData(
                table: "DinnerStatuses",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2023, 8, 7, 5, 6, 27, 705, DateTimeKind.Utc).AddTicks(4142), new DateTime(2023, 8, 7, 5, 6, 27, 705, DateTimeKind.Utc).AddTicks(4142) });

            migrationBuilder.UpdateData(
                table: "DinnerStatuses",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2023, 8, 7, 5, 6, 27, 705, DateTimeKind.Utc).AddTicks(4143), new DateTime(2023, 8, 7, 5, 6, 27, 705, DateTimeKind.Utc).AddTicks(4144) });

            migrationBuilder.UpdateData(
                table: "ReservationStatuses",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2023, 8, 7, 5, 6, 27, 719, DateTimeKind.Utc).AddTicks(8055), new DateTime(2023, 8, 7, 5, 6, 27, 719, DateTimeKind.Utc).AddTicks(8056) });

            migrationBuilder.UpdateData(
                table: "ReservationStatuses",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2023, 8, 7, 5, 6, 27, 719, DateTimeKind.Utc).AddTicks(8061), new DateTime(2023, 8, 7, 5, 6, 27, 719, DateTimeKind.Utc).AddTicks(8061) });

            migrationBuilder.UpdateData(
                table: "ReservationStatuses",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2023, 8, 7, 5, 6, 27, 719, DateTimeKind.Utc).AddTicks(8063), new DateTime(2023, 8, 7, 5, 6, 27, 719, DateTimeKind.Utc).AddTicks(8063) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.UpdateData(
                table: "DinnerStatuses",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2023, 8, 7, 4, 31, 8, 345, DateTimeKind.Utc).AddTicks(879), new DateTime(2023, 8, 7, 4, 31, 8, 345, DateTimeKind.Utc).AddTicks(881) });

            migrationBuilder.UpdateData(
                table: "DinnerStatuses",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2023, 8, 7, 4, 31, 8, 345, DateTimeKind.Utc).AddTicks(892), new DateTime(2023, 8, 7, 4, 31, 8, 345, DateTimeKind.Utc).AddTicks(892) });

            migrationBuilder.UpdateData(
                table: "DinnerStatuses",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2023, 8, 7, 4, 31, 8, 345, DateTimeKind.Utc).AddTicks(894), new DateTime(2023, 8, 7, 4, 31, 8, 345, DateTimeKind.Utc).AddTicks(894) });

            migrationBuilder.UpdateData(
                table: "DinnerStatuses",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2023, 8, 7, 4, 31, 8, 345, DateTimeKind.Utc).AddTicks(895), new DateTime(2023, 8, 7, 4, 31, 8, 345, DateTimeKind.Utc).AddTicks(895) });

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
    }
}
