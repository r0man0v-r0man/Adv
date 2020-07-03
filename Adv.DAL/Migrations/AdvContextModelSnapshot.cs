﻿// <auto-generated />
using System;
using Adv.DAL.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Adv.DAL.Migrations
{
    [DbContext(typeof(AdvContext))]
    partial class AdvContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("Adv.DAL.Entities.Address.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Country_code")
                        .HasColumnType("text");

                    b.Property<string>("Formatted")
                        .HasColumnType("text");

                    b.Property<string>("Postal_code")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Address");
                });

            modelBuilder.Entity("Adv.DAL.Entities.Address.BoundedBy", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("EnvelopeId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("EnvelopeId");

                    b.ToTable("BoundedBy");
                });

            modelBuilder.Entity("Adv.DAL.Entities.Address.Component", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int?>("AddressId")
                        .HasColumnType("integer");

                    b.Property<string>("Kind")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.ToTable("Component");
                });

            modelBuilder.Entity("Adv.DAL.Entities.Address.Envelope", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("LowerCorner")
                        .HasColumnType("text");

                    b.Property<string>("UpperCorner")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Envelope");
                });

            modelBuilder.Entity("Adv.DAL.Entities.Address.GeoObject", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("BoundedById")
                        .HasColumnType("integer");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<int>("MetaDataPropertyId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<int>("PointId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("BoundedById");

                    b.HasIndex("MetaDataPropertyId");

                    b.HasIndex("PointId");

                    b.ToTable("GeoObject");
                });

            modelBuilder.Entity("Adv.DAL.Entities.Address.GeocoderMetaData", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("AddressId")
                        .HasColumnType("integer");

                    b.Property<string>("Kind")
                        .HasColumnType("text");

                    b.Property<string>("Precision")
                        .HasColumnType("text");

                    b.Property<string>("Text")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.ToTable("GeocoderMetaData");
                });

            modelBuilder.Entity("Adv.DAL.Entities.Address.MetaDataProperty", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("GeocoderMetaDataId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("GeocoderMetaDataId");

                    b.ToTable("MetaDataProperty");
                });

            modelBuilder.Entity("Adv.DAL.Entities.Address.Point", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Pos")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Point");
                });

            modelBuilder.Entity("Adv.DAL.Entities.Address.YandexAddress", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("GeoObjectId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("GeoObjectId");

                    b.ToTable("YandexAddresses");
                });

            modelBuilder.Entity("Adv.DAL.Entities.Adverts.FlatRent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("AddressId")
                        .HasColumnType("integer");

                    b.Property<int>("AllFloor")
                        .HasColumnType("integer");

                    b.Property<string>("AppUserId")
                        .HasColumnType("text");

                    b.Property<byte>("Balcony")
                        .HasColumnType("smallint");

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<byte>("Duration")
                        .HasColumnType("smallint");

                    b.Property<int>("Floor")
                        .HasColumnType("integer");

                    b.Property<bool>("Furniture")
                        .HasColumnType("boolean");

                    b.Property<bool>("Internet")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("LastModified")
                        .HasColumnType("timestamp without time zone");

                    b.Property<bool>("MicrowaveOven")
                        .HasColumnType("boolean");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("Price")
                        .HasColumnType("money");

                    b.Property<bool>("Refrigerator")
                        .HasColumnType("boolean");

                    b.Property<byte>("Rooms")
                        .HasColumnType("smallint");

                    b.Property<bool>("WashingMachine")
                        .HasColumnType("boolean");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.HasIndex("AppUserId");

                    b.ToTable("FlatRents");
                });

            modelBuilder.Entity("Adv.DAL.Entities.Adverts.FlatSale", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("AddressId")
                        .HasColumnType("integer");

                    b.Property<int>("AllFloor")
                        .HasColumnType("integer");

                    b.Property<string>("AppUserId")
                        .HasColumnType("text");

                    b.Property<byte>("Balcony")
                        .HasColumnType("smallint");

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("FlatArea")
                        .HasColumnType("integer");

                    b.Property<int>("FlatLiveArea")
                        .HasColumnType("integer");

                    b.Property<int>("Floor")
                        .HasColumnType("integer");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<int>("KitchenArea")
                        .HasColumnType("integer");

                    b.Property<DateTime>("LastModified")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("Price")
                        .HasColumnType("money");

                    b.Property<byte>("Rooms")
                        .HasColumnType("smallint");

                    b.Property<byte>("Toilet")
                        .HasColumnType("smallint");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.HasIndex("AppUserId");

                    b.ToTable("FlatSales");
                });

            modelBuilder.Entity("Adv.DAL.Entities.Adverts.HouseRent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("AddressId")
                        .HasColumnType("integer");

                    b.Property<string>("AppUserId")
                        .HasColumnType("text");

                    b.Property<bool>("Bathhouse")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<byte>("Duration")
                        .HasColumnType("smallint");

                    b.Property<bool>("Furniture")
                        .HasColumnType("boolean");

                    b.Property<bool>("Garage")
                        .HasColumnType("boolean");

                    b.Property<bool>("Internet")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("LastModified")
                        .HasColumnType("timestamp without time zone");

                    b.Property<bool>("MicrowaveOven")
                        .HasColumnType("boolean");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("Price")
                        .HasColumnType("money");

                    b.Property<bool>("Refrigerator")
                        .HasColumnType("boolean");

                    b.Property<byte>("Rooms")
                        .HasColumnType("smallint");

                    b.Property<bool>("WashingMachine")
                        .HasColumnType("boolean");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.HasIndex("AppUserId");

                    b.ToTable("HouseRents");
                });

            modelBuilder.Entity("Adv.DAL.Entities.Adverts.HouseSale", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("AddressId")
                        .HasColumnType("integer");

                    b.Property<string>("AppUserId")
                        .HasColumnType("text");

                    b.Property<bool>("Bathhouse")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("Electricity")
                        .HasColumnType("boolean");

                    b.Property<bool>("Garage")
                        .HasColumnType("boolean");

                    b.Property<bool>("Gas")
                        .HasColumnType("boolean");

                    b.Property<bool>("Heating")
                        .HasColumnType("boolean");

                    b.Property<int>("HouseArea")
                        .HasColumnType("integer");

                    b.Property<int>("HouseLiveArea")
                        .HasColumnType("integer");

                    b.Property<int>("HousePlotArea")
                        .HasColumnType("integer");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<int>("KitchenArea")
                        .HasColumnType("integer");

                    b.Property<DateTime>("LastModified")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("Price")
                        .HasColumnType("money");

                    b.Property<bool>("Sewage")
                        .HasColumnType("boolean");

                    b.Property<bool>("Water")
                        .HasColumnType("boolean");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.HasIndex("AppUserId");

                    b.ToTable("HouseSales");
                });

            modelBuilder.Entity("Adv.DAL.Entities.AppUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("integer");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasColumnType("character varying(256)")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("boolean");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("boolean");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("character varying(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("character varying(256)")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("text");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("boolean");

                    b.Property<string>("UserName")
                        .HasColumnType("character varying(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Adv.DAL.Entities.Images.Image", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("DeleteHash")
                        .HasColumnType("text");

                    b.Property<int?>("FlatRentId")
                        .HasColumnType("integer");

                    b.Property<int?>("FlatSaleId")
                        .HasColumnType("integer");

                    b.Property<int?>("HouseRentId")
                        .HasColumnType("integer");

                    b.Property<int?>("HouseSaleId")
                        .HasColumnType("integer");

                    b.Property<long>("Size")
                        .HasColumnType("bigint");

                    b.Property<string>("URL")
                        .HasColumnType("text");

                    b.Property<string>("Uid")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("FlatRentId");

                    b.HasIndex("FlatSaleId");

                    b.HasIndex("HouseRentId");

                    b.HasIndex("HouseSaleId");

                    b.ToTable("Image");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("character varying(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasColumnType("character varying(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("text");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .HasColumnType("text");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Value")
                        .HasColumnType("text");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Adv.DAL.Entities.Address.BoundedBy", b =>
                {
                    b.HasOne("Adv.DAL.Entities.Address.Envelope", "Envelope")
                        .WithMany()
                        .HasForeignKey("EnvelopeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Adv.DAL.Entities.Address.Component", b =>
                {
                    b.HasOne("Adv.DAL.Entities.Address.Address", null)
                        .WithMany("Components")
                        .HasForeignKey("AddressId");
                });

            modelBuilder.Entity("Adv.DAL.Entities.Address.GeoObject", b =>
                {
                    b.HasOne("Adv.DAL.Entities.Address.BoundedBy", "BoundedBy")
                        .WithMany()
                        .HasForeignKey("BoundedById")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Adv.DAL.Entities.Address.MetaDataProperty", "MetaDataProperty")
                        .WithMany()
                        .HasForeignKey("MetaDataPropertyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Adv.DAL.Entities.Address.Point", "Point")
                        .WithMany()
                        .HasForeignKey("PointId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Adv.DAL.Entities.Address.GeocoderMetaData", b =>
                {
                    b.HasOne("Adv.DAL.Entities.Address.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Adv.DAL.Entities.Address.MetaDataProperty", b =>
                {
                    b.HasOne("Adv.DAL.Entities.Address.GeocoderMetaData", "GeocoderMetaData")
                        .WithMany()
                        .HasForeignKey("GeocoderMetaDataId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Adv.DAL.Entities.Address.YandexAddress", b =>
                {
                    b.HasOne("Adv.DAL.Entities.Address.GeoObject", "GeoObject")
                        .WithMany()
                        .HasForeignKey("GeoObjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Adv.DAL.Entities.Adverts.FlatRent", b =>
                {
                    b.HasOne("Adv.DAL.Entities.Address.YandexAddress", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Adv.DAL.Entities.AppUser", "AppUser")
                        .WithMany("FlatRents")
                        .HasForeignKey("AppUserId");
                });

            modelBuilder.Entity("Adv.DAL.Entities.Adverts.FlatSale", b =>
                {
                    b.HasOne("Adv.DAL.Entities.Address.YandexAddress", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Adv.DAL.Entities.AppUser", "AppUser")
                        .WithMany("FlatSales")
                        .HasForeignKey("AppUserId");
                });

            modelBuilder.Entity("Adv.DAL.Entities.Adverts.HouseRent", b =>
                {
                    b.HasOne("Adv.DAL.Entities.Address.YandexAddress", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Adv.DAL.Entities.AppUser", "AppUser")
                        .WithMany("HouseRents")
                        .HasForeignKey("AppUserId");
                });

            modelBuilder.Entity("Adv.DAL.Entities.Adverts.HouseSale", b =>
                {
                    b.HasOne("Adv.DAL.Entities.Address.YandexAddress", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Adv.DAL.Entities.AppUser", "AppUser")
                        .WithMany("HouseSales")
                        .HasForeignKey("AppUserId");
                });

            modelBuilder.Entity("Adv.DAL.Entities.Images.Image", b =>
                {
                    b.HasOne("Adv.DAL.Entities.Adverts.FlatRent", "FlatRent")
                        .WithMany("Images")
                        .HasForeignKey("FlatRentId");

                    b.HasOne("Adv.DAL.Entities.Adverts.FlatSale", "FlatSale")
                        .WithMany("Images")
                        .HasForeignKey("FlatSaleId");

                    b.HasOne("Adv.DAL.Entities.Adverts.HouseRent", "HouseRent")
                        .WithMany("Images")
                        .HasForeignKey("HouseRentId");

                    b.HasOne("Adv.DAL.Entities.Adverts.HouseSale", "HouseSale")
                        .WithMany("Images")
                        .HasForeignKey("HouseSaleId");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Adv.DAL.Entities.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Adv.DAL.Entities.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Adv.DAL.Entities.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Adv.DAL.Entities.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
