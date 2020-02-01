using Microsoft.EntityFrameworkCore.Migrations;

namespace Adv.DAL.Migrations
{
    public partial class AddFlatsColumnTOAppUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AppUserId",
                table: "Flats",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Flats_AppUserId",
                table: "Flats",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Flats_AspNetUsers_AppUserId",
                table: "Flats",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Flats_AspNetUsers_AppUserId",
                table: "Flats");

            migrationBuilder.DropIndex(
                name: "IX_Flats_AppUserId",
                table: "Flats");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "Flats");
        }
    }
}
