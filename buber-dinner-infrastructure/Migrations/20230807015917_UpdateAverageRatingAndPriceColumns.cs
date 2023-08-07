using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BuberDinner.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateAverageRatingAndPriceColumns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AverageRating_Value",
                table: "Menus",
                newName: "AverageRating");

            migrationBuilder.RenameColumn(
                name: "AverageRating_NumOfRatings",
                table: "Menus",
                newName: "NumOfRatings");

            migrationBuilder.RenameColumn(
                name: "AverageRating_Value",
                table: "Hosts",
                newName: "AverageRating");

            migrationBuilder.RenameColumn(
                name: "AverageRating_NumOfRatings",
                table: "Hosts",
                newName: "NumOfRatings");

            migrationBuilder.RenameColumn(
                name: "Price_Currency",
                table: "Bills",
                newName: "Currency");

            migrationBuilder.RenameColumn(
                name: "Price_Amount",
                table: "Bills",
                newName: "Amount");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "MenuSections",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Menus",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<decimal>(
                name: "AverageRating",
                table: "Menus",
                type: "decimal(3,2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "MenuItems",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<decimal>(
                name: "AverageRating",
                table: "Hosts",
                type: "decimal(3,2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<string>(
                name: "Currency",
                table: "Bills",
                type: "varchar(100)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Amount",
                table: "Bills",
                type: "money",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NumOfRatings",
                table: "Menus",
                newName: "AverageRating_NumOfRatings");

            migrationBuilder.RenameColumn(
                name: "AverageRating",
                table: "Menus",
                newName: "AverageRating_Value");

            migrationBuilder.RenameColumn(
                name: "NumOfRatings",
                table: "Hosts",
                newName: "AverageRating_NumOfRatings");

            migrationBuilder.RenameColumn(
                name: "AverageRating",
                table: "Hosts",
                newName: "AverageRating_Value");

            migrationBuilder.RenameColumn(
                name: "Currency",
                table: "Bills",
                newName: "Price_Currency");

            migrationBuilder.RenameColumn(
                name: "Amount",
                table: "Bills",
                newName: "Price_Amount");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "MenuSections",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(1000)",
                oldMaxLength: 1000);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Menus",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(1000)",
                oldMaxLength: 1000);

            migrationBuilder.AlterColumn<double>(
                name: "AverageRating_Value",
                table: "Menus",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(3,2)");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "MenuItems",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(1000)",
                oldMaxLength: 1000);

            migrationBuilder.AlterColumn<double>(
                name: "AverageRating_Value",
                table: "Hosts",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(3,2)");

            migrationBuilder.AlterColumn<string>(
                name: "Price_Currency",
                table: "Bills",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(100)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Price_Amount",
                table: "Bills",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "money");
        }
    }
}
