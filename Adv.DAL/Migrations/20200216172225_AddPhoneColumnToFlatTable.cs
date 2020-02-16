using Microsoft.EntityFrameworkCore.Migrations;

namespace Adv.DAL.Migrations
{
    public partial class AddPhoneColumnToFlatTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "Flats",
                nullable: false,
                defaultValue: "375295357164");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Phone",
                table: "Flats");
        }
    }
}
