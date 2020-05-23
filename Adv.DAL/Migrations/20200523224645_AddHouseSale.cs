using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Adv.DAL.Migrations
{
    public partial class AddHouseSale : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "HouseSaleId",
                table: "Image",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "HouseSales",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(nullable: false),
                    LastModified = table.Column<DateTime>(nullable: false),
                    AppUserId = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    Address = table.Column<string>(nullable: false),
                    HouseArea = table.Column<int>(nullable: false),
                    HouseLiveArea = table.Column<int>(nullable: false),
                    KitchenArea = table.Column<int>(nullable: false),
                    HousePlotArea = table.Column<int>(nullable: false),
                    Heating = table.Column<bool>(nullable: false),
                    Water = table.Column<bool>(nullable: false),
                    Gas = table.Column<bool>(nullable: false),
                    Sewage = table.Column<bool>(nullable: false),
                    Electricity = table.Column<bool>(nullable: false),
                    Bathhouse = table.Column<bool>(nullable: false),
                    Garage = table.Column<bool>(nullable: false),
                    Price = table.Column<decimal>(type: "money", nullable: false),
                    Phone = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HouseSales", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HouseSales_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Image_HouseSaleId",
                table: "Image",
                column: "HouseSaleId");

            migrationBuilder.CreateIndex(
                name: "IX_HouseSales_AppUserId",
                table: "HouseSales",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Image_HouseSales_HouseSaleId",
                table: "Image",
                column: "HouseSaleId",
                principalTable: "HouseSales",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Image_HouseSales_HouseSaleId",
                table: "Image");

            migrationBuilder.DropTable(
                name: "HouseSales");

            migrationBuilder.DropIndex(
                name: "IX_Image_HouseSaleId",
                table: "Image");

            migrationBuilder.DropColumn(
                name: "HouseSaleId",
                table: "Image");
        }
    }
}
