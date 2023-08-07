using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BuberDinner.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Xrefs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HostDinners");

            migrationBuilder.DropTable(
                name: "HostMenus");

            migrationBuilder.DropTable(
                name: "MenuDinners");

            migrationBuilder.DropTable(
                name: "MenuReviews");

            migrationBuilder.CreateTable(
                name: "HostDinnerXrefs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DinnerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HostId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HostDinnerXrefs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HostDinnerXrefs_Hosts_HostId",
                        column: x => x.HostId,
                        principalTable: "Hosts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HostMenuXrefs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MenuId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HostId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HostMenuXrefs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HostMenuXrefs_Hosts_HostId",
                        column: x => x.HostId,
                        principalTable: "Hosts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MenuDinnerXrefs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DinnerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MenuId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuDinnerXrefs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MenuDinnerXrefs_Menus_MenuId",
                        column: x => x.MenuId,
                        principalTable: "Menus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MenuReviewXrefs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MenuReviewId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MenuId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuReviewXrefs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MenuReviewXrefs_Menus_MenuId",
                        column: x => x.MenuId,
                        principalTable: "Menus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_HostDinnerXrefs_HostId",
                table: "HostDinnerXrefs",
                column: "HostId");

            migrationBuilder.CreateIndex(
                name: "IX_HostMenuXrefs_HostId",
                table: "HostMenuXrefs",
                column: "HostId");

            migrationBuilder.CreateIndex(
                name: "IX_MenuDinnerXrefs_MenuId",
                table: "MenuDinnerXrefs",
                column: "MenuId");

            migrationBuilder.CreateIndex(
                name: "IX_MenuReviewXrefs_MenuId",
                table: "MenuReviewXrefs",
                column: "MenuId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HostDinnerXrefs");

            migrationBuilder.DropTable(
                name: "HostMenuXrefs");

            migrationBuilder.DropTable(
                name: "MenuDinnerXrefs");

            migrationBuilder.DropTable(
                name: "MenuReviewXrefs");

            migrationBuilder.CreateTable(
                name: "HostDinners",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HostId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DinnerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HostDinners", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HostDinners_Hosts_HostId",
                        column: x => x.HostId,
                        principalTable: "Hosts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HostMenus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HostId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MenuId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HostMenus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HostMenus_Hosts_HostId",
                        column: x => x.HostId,
                        principalTable: "Hosts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MenuDinners",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MenuId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DinnerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuDinners", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MenuDinners_Menus_MenuId",
                        column: x => x.MenuId,
                        principalTable: "Menus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MenuReviews",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MenuId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MenuReviewId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuReviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MenuReviews_Menus_MenuId",
                        column: x => x.MenuId,
                        principalTable: "Menus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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

            migrationBuilder.CreateIndex(
                name: "IX_HostDinners_HostId",
                table: "HostDinners",
                column: "HostId");

            migrationBuilder.CreateIndex(
                name: "IX_HostMenus_HostId",
                table: "HostMenus",
                column: "HostId");

            migrationBuilder.CreateIndex(
                name: "IX_MenuDinners_MenuId",
                table: "MenuDinners",
                column: "MenuId");

            migrationBuilder.CreateIndex(
                name: "IX_MenuReviews_MenuId",
                table: "MenuReviews",
                column: "MenuId");
        }
    }
}
