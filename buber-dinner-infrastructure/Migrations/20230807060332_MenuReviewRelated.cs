using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BuberDinner.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class MenuReviewRelated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MenuReviews",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Rating = table.Column<decimal>(type: "decimal(3,2)", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    HostId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MenuId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GuestId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DinnerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2(7)", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2(7)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuReviews", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "DinnerStatuses",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2023, 8, 7, 6, 3, 31, 930, DateTimeKind.Utc).AddTicks(3603), new DateTime(2023, 8, 7, 6, 3, 31, 930, DateTimeKind.Utc).AddTicks(3605) });

            migrationBuilder.UpdateData(
                table: "DinnerStatuses",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2023, 8, 7, 6, 3, 31, 930, DateTimeKind.Utc).AddTicks(3612), new DateTime(2023, 8, 7, 6, 3, 31, 930, DateTimeKind.Utc).AddTicks(3612) });

            migrationBuilder.UpdateData(
                table: "DinnerStatuses",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2023, 8, 7, 6, 3, 31, 930, DateTimeKind.Utc).AddTicks(3613), new DateTime(2023, 8, 7, 6, 3, 31, 930, DateTimeKind.Utc).AddTicks(3614) });

            migrationBuilder.UpdateData(
                table: "DinnerStatuses",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2023, 8, 7, 6, 3, 31, 930, DateTimeKind.Utc).AddTicks(3615), new DateTime(2023, 8, 7, 6, 3, 31, 930, DateTimeKind.Utc).AddTicks(3615) });

            migrationBuilder.UpdateData(
                table: "ReservationStatuses",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2023, 8, 7, 6, 3, 31, 946, DateTimeKind.Utc).AddTicks(8755), new DateTime(2023, 8, 7, 6, 3, 31, 946, DateTimeKind.Utc).AddTicks(8756) });

            migrationBuilder.UpdateData(
                table: "ReservationStatuses",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2023, 8, 7, 6, 3, 31, 946, DateTimeKind.Utc).AddTicks(8762), new DateTime(2023, 8, 7, 6, 3, 31, 946, DateTimeKind.Utc).AddTicks(8762) });

            migrationBuilder.UpdateData(
                table: "ReservationStatuses",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2023, 8, 7, 6, 3, 31, 946, DateTimeKind.Utc).AddTicks(8765), new DateTime(2023, 8, 7, 6, 3, 31, 946, DateTimeKind.Utc).AddTicks(8765) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MenuReviews");

            migrationBuilder.UpdateData(
                table: "DinnerStatuses",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2023, 8, 7, 6, 2, 22, 914, DateTimeKind.Utc).AddTicks(6088), new DateTime(2023, 8, 7, 6, 2, 22, 914, DateTimeKind.Utc).AddTicks(6089) });

            migrationBuilder.UpdateData(
                table: "DinnerStatuses",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2023, 8, 7, 6, 2, 22, 914, DateTimeKind.Utc).AddTicks(6095), new DateTime(2023, 8, 7, 6, 2, 22, 914, DateTimeKind.Utc).AddTicks(6095) });

            migrationBuilder.UpdateData(
                table: "DinnerStatuses",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2023, 8, 7, 6, 2, 22, 914, DateTimeKind.Utc).AddTicks(6096), new DateTime(2023, 8, 7, 6, 2, 22, 914, DateTimeKind.Utc).AddTicks(6097) });

            migrationBuilder.UpdateData(
                table: "DinnerStatuses",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2023, 8, 7, 6, 2, 22, 914, DateTimeKind.Utc).AddTicks(6098), new DateTime(2023, 8, 7, 6, 2, 22, 914, DateTimeKind.Utc).AddTicks(6098) });

            migrationBuilder.UpdateData(
                table: "ReservationStatuses",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2023, 8, 7, 6, 2, 22, 929, DateTimeKind.Utc).AddTicks(3322), new DateTime(2023, 8, 7, 6, 2, 22, 929, DateTimeKind.Utc).AddTicks(3324) });

            migrationBuilder.UpdateData(
                table: "ReservationStatuses",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2023, 8, 7, 6, 2, 22, 929, DateTimeKind.Utc).AddTicks(3331), new DateTime(2023, 8, 7, 6, 2, 22, 929, DateTimeKind.Utc).AddTicks(3331) });

            migrationBuilder.UpdateData(
                table: "ReservationStatuses",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2023, 8, 7, 6, 2, 22, 929, DateTimeKind.Utc).AddTicks(3332), new DateTime(2023, 8, 7, 6, 2, 22, 929, DateTimeKind.Utc).AddTicks(3333) });
        }
    }
}
