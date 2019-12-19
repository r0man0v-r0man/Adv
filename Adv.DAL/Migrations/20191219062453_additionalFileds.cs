using Microsoft.EntityFrameworkCore.Migrations;

namespace Adv.DAL.Migrations
{
    public partial class additionalFileds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Flats",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Flats",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Flats",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "Flats");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Flats");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Flats");
        }
    }
}
