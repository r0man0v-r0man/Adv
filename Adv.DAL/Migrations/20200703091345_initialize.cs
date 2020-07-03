using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Adv.DAL.Migrations
{
    public partial class initialize : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Country_code = table.Column<string>(nullable: true),
                    Postal_code = table.Column<string>(nullable: true),
                    Formatted = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Envelope",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    LowerCorner = table.Column<string>(nullable: true),
                    UpperCorner = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Envelope", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Point",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Pos = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Point", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Component",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Kind = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    AddressId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Component", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Component_Address_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Address",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GeocoderMetaData",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Kind = table.Column<string>(nullable: true),
                    Text = table.Column<string>(nullable: true),
                    Precision = table.Column<string>(nullable: true),
                    AddressId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GeocoderMetaData", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GeocoderMetaData_Address_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Address",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BoundedBy",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    EnvelopeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BoundedBy", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BoundedBy_Envelope_EnvelopeId",
                        column: x => x.EnvelopeId,
                        principalTable: "Envelope",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MetaDataProperty",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    GeocoderMetaDataId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MetaDataProperty", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MetaDataProperty_GeocoderMetaData_GeocoderMetaDataId",
                        column: x => x.GeocoderMetaDataId,
                        principalTable: "GeocoderMetaData",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GeoObject",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    BoundedById = table.Column<int>(nullable: false),
                    MetaDataPropertyId = table.Column<int>(nullable: false),
                    PointId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GeoObject", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GeoObject_BoundedBy_BoundedById",
                        column: x => x.BoundedById,
                        principalTable: "BoundedBy",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GeoObject_MetaDataProperty_MetaDataPropertyId",
                        column: x => x.MetaDataPropertyId,
                        principalTable: "MetaDataProperty",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GeoObject_Point_PointId",
                        column: x => x.PointId,
                        principalTable: "Point",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "YandexAddresses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    GeoObjectId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_YandexAddresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_YandexAddresses_GeoObject_GeoObjectId",
                        column: x => x.GeoObjectId,
                        principalTable: "GeoObject",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FlatRents",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Created = table.Column<DateTime>(nullable: false),
                    LastModified = table.Column<DateTime>(nullable: false),
                    AppUserId = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    AddressId = table.Column<int>(nullable: false),
                    Floor = table.Column<int>(nullable: false),
                    AllFloor = table.Column<int>(nullable: false),
                    Rooms = table.Column<byte>(nullable: false),
                    Balcony = table.Column<byte>(nullable: false),
                    Furniture = table.Column<bool>(nullable: false),
                    Refrigerator = table.Column<bool>(nullable: false),
                    MicrowaveOven = table.Column<bool>(nullable: false),
                    Internet = table.Column<bool>(nullable: false),
                    WashingMachine = table.Column<bool>(nullable: false),
                    Price = table.Column<decimal>(type: "money", nullable: false),
                    Duration = table.Column<byte>(nullable: false),
                    Phone = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlatRents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FlatRents_YandexAddresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "YandexAddresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FlatRents_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FlatSales",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Created = table.Column<DateTime>(nullable: false),
                    LastModified = table.Column<DateTime>(nullable: false),
                    AppUserId = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    AddressId = table.Column<int>(nullable: false),
                    Floor = table.Column<int>(nullable: false),
                    AllFloor = table.Column<int>(nullable: false),
                    Rooms = table.Column<byte>(nullable: false),
                    FlatArea = table.Column<int>(nullable: false),
                    FlatLiveArea = table.Column<int>(nullable: false),
                    KitchenArea = table.Column<int>(nullable: false),
                    Balcony = table.Column<byte>(nullable: false),
                    Toilet = table.Column<byte>(nullable: false),
                    Price = table.Column<decimal>(type: "money", nullable: false),
                    Phone = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlatSales", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FlatSales_YandexAddresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "YandexAddresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FlatSales_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HouseRents",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Created = table.Column<DateTime>(nullable: false),
                    LastModified = table.Column<DateTime>(nullable: false),
                    AppUserId = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    AddressId = table.Column<int>(nullable: false),
                    Rooms = table.Column<byte>(nullable: false),
                    Furniture = table.Column<bool>(nullable: false),
                    Refrigerator = table.Column<bool>(nullable: false),
                    MicrowaveOven = table.Column<bool>(nullable: false),
                    Internet = table.Column<bool>(nullable: false),
                    WashingMachine = table.Column<bool>(nullable: false),
                    Bathhouse = table.Column<bool>(nullable: false),
                    Garage = table.Column<bool>(nullable: false),
                    Price = table.Column<decimal>(type: "money", nullable: false),
                    Duration = table.Column<byte>(nullable: false),
                    Phone = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HouseRents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HouseRents_YandexAddresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "YandexAddresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HouseRents_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HouseSales",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Created = table.Column<DateTime>(nullable: false),
                    LastModified = table.Column<DateTime>(nullable: false),
                    AppUserId = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    AddressId = table.Column<int>(nullable: false),
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
                        name: "FK_HouseSales_YandexAddresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "YandexAddresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HouseSales_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Image",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DeleteHash = table.Column<string>(nullable: true),
                    URL = table.Column<string>(nullable: true),
                    Uid = table.Column<string>(nullable: true),
                    Size = table.Column<long>(nullable: false),
                    FlatRentId = table.Column<int>(nullable: true),
                    FlatSaleId = table.Column<int>(nullable: true),
                    HouseRentId = table.Column<int>(nullable: true),
                    HouseSaleId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Image", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Image_FlatRents_FlatRentId",
                        column: x => x.FlatRentId,
                        principalTable: "FlatRents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Image_FlatSales_FlatSaleId",
                        column: x => x.FlatSaleId,
                        principalTable: "FlatSales",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Image_HouseRents_HouseRentId",
                        column: x => x.HouseRentId,
                        principalTable: "HouseRents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Image_HouseSales_HouseSaleId",
                        column: x => x.HouseSaleId,
                        principalTable: "HouseSales",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BoundedBy_EnvelopeId",
                table: "BoundedBy",
                column: "EnvelopeId");

            migrationBuilder.CreateIndex(
                name: "IX_Component_AddressId",
                table: "Component",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_FlatRents_AddressId",
                table: "FlatRents",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_FlatRents_AppUserId",
                table: "FlatRents",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_FlatSales_AddressId",
                table: "FlatSales",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_FlatSales_AppUserId",
                table: "FlatSales",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_GeocoderMetaData_AddressId",
                table: "GeocoderMetaData",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_GeoObject_BoundedById",
                table: "GeoObject",
                column: "BoundedById");

            migrationBuilder.CreateIndex(
                name: "IX_GeoObject_MetaDataPropertyId",
                table: "GeoObject",
                column: "MetaDataPropertyId");

            migrationBuilder.CreateIndex(
                name: "IX_GeoObject_PointId",
                table: "GeoObject",
                column: "PointId");

            migrationBuilder.CreateIndex(
                name: "IX_HouseRents_AddressId",
                table: "HouseRents",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_HouseRents_AppUserId",
                table: "HouseRents",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_HouseSales_AddressId",
                table: "HouseSales",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_HouseSales_AppUserId",
                table: "HouseSales",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Image_FlatRentId",
                table: "Image",
                column: "FlatRentId");

            migrationBuilder.CreateIndex(
                name: "IX_Image_FlatSaleId",
                table: "Image",
                column: "FlatSaleId");

            migrationBuilder.CreateIndex(
                name: "IX_Image_HouseRentId",
                table: "Image",
                column: "HouseRentId");

            migrationBuilder.CreateIndex(
                name: "IX_Image_HouseSaleId",
                table: "Image",
                column: "HouseSaleId");

            migrationBuilder.CreateIndex(
                name: "IX_MetaDataProperty_GeocoderMetaDataId",
                table: "MetaDataProperty",
                column: "GeocoderMetaDataId");

            migrationBuilder.CreateIndex(
                name: "IX_YandexAddresses_GeoObjectId",
                table: "YandexAddresses",
                column: "GeoObjectId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Component");

            migrationBuilder.DropTable(
                name: "Image");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "FlatRents");

            migrationBuilder.DropTable(
                name: "FlatSales");

            migrationBuilder.DropTable(
                name: "HouseRents");

            migrationBuilder.DropTable(
                name: "HouseSales");

            migrationBuilder.DropTable(
                name: "YandexAddresses");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "GeoObject");

            migrationBuilder.DropTable(
                name: "BoundedBy");

            migrationBuilder.DropTable(
                name: "MetaDataProperty");

            migrationBuilder.DropTable(
                name: "Point");

            migrationBuilder.DropTable(
                name: "Envelope");

            migrationBuilder.DropTable(
                name: "GeocoderMetaData");

            migrationBuilder.DropTable(
                name: "Address");
        }
    }
}
