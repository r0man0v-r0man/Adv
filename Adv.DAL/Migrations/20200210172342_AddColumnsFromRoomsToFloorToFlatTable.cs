using Microsoft.EntityFrameworkCore.Migrations;

namespace Adv.DAL.Migrations
{
    public partial class AddColumnsFromRoomsToFloorToFlatTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AllFloor",
                table: "Flats",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Duration",
                table: "Flats",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Floor",
                table: "Flats",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "Furniture",
                table: "Flats",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Internet",
                table: "Flats",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "MicrowaveOven",
                table: "Flats",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Refrigerator",
                table: "Flats",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<byte>(
                name: "Rooms",
                table: "Flats",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<bool>(
                name: "WashingMachine",
                table: "Flats",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AllFloor",
                table: "Flats");

            migrationBuilder.DropColumn(
                name: "Duration",
                table: "Flats");

            migrationBuilder.DropColumn(
                name: "Floor",
                table: "Flats");

            migrationBuilder.DropColumn(
                name: "Furniture",
                table: "Flats");

            migrationBuilder.DropColumn(
                name: "Internet",
                table: "Flats");

            migrationBuilder.DropColumn(
                name: "MicrowaveOven",
                table: "Flats");

            migrationBuilder.DropColumn(
                name: "Refrigerator",
                table: "Flats");

            migrationBuilder.DropColumn(
                name: "Rooms",
                table: "Flats");

            migrationBuilder.DropColumn(
                name: "WashingMachine",
                table: "Flats");
        }
    }
}
