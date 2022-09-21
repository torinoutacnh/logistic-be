﻿// <auto-generated />
using System;
using FU.Repository.DbStore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace API.Migrations
{
    [DbContext(typeof(Store))]
    [Migration("20220921055110_update11")]
    partial class update11
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("FU.Domain.Entities.Car.CarEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CarColor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CarModel")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CarNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<Guid?>("CarsManagerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CreateBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("CreatedDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("ImagePath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("ServiceType")
                        .HasColumnType("int");

                    b.Property<decimal>("ShipPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Tel")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("TravelPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<Guid>("UpdateBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("UpdatedDate")
                        .HasColumnType("datetimeoffset");

                    b.HasKey("Id");

                    b.HasIndex("CarNumber")
                        .IsUnique();

                    b.HasIndex("CarsManagerId");

                    b.ToTable("Cars", (string)null);
                });

            modelBuilder.Entity("FU.Domain.Entities.CarsManager.CarsManagerEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CreateBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("CreatedDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("LogoPath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UpdateBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("UpdatedDate")
                        .HasColumnType("datetimeoffset");

                    b.HasKey("Id");

                    b.ToTable("CarsManagers", (string)null);
                });

            modelBuilder.Entity("FU.Domain.Entities.LocalLocation.CityEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<long>("Code")
                        .HasColumnType("bigint");

                    b.Property<string>("CodeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<Guid>("CreateBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("CreatedDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Division")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<long>("PhoneCode")
                        .HasColumnType("bigint");

                    b.Property<Guid>("UpdateBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("UpdatedDate")
                        .HasColumnType("datetimeoffset");

                    b.HasKey("Id");

                    b.HasIndex("Code")
                        .IsUnique();

                    b.HasIndex("CodeName")
                        .IsUnique();

                    b.HasIndex("Name")
                        .IsUnique();

                    b.HasIndex("PhoneCode")
                        .IsUnique();

                    b.ToTable("Cities", (string)null);
                });

            modelBuilder.Entity("FU.Domain.Entities.LocalLocation.DistrictEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CityId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<long>("Code")
                        .HasColumnType("bigint");

                    b.Property<string>("CodeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("CreateBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("CreatedDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Division")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ShortCodeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UpdateBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("UpdatedDate")
                        .HasColumnType("datetimeoffset");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.HasIndex("Code")
                        .IsUnique();

                    b.ToTable("Districts", (string)null);
                });

            modelBuilder.Entity("FU.Domain.Entities.LocalLocation.WardEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<long>("Code")
                        .HasColumnType("bigint");

                    b.Property<string>("CodeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("CreateBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("CreatedDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<Guid>("DistrictId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Division")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ShortCodeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UpdateBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("UpdatedDate")
                        .HasColumnType("datetimeoffset");

                    b.HasKey("Id");

                    b.HasIndex("Code")
                        .IsUnique();

                    b.HasIndex("DistrictId");

                    b.ToTable("Wards", (string)null);
                });

            modelBuilder.Entity("FU.Domain.Entities.Route.RouteEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CarId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CreateBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("CreatedDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTimeOffset>("DailyStartTime")
                        .HasColumnType("datetimeoffset");

                    b.Property<decimal>("Day")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("DistanceByKm")
                        .HasColumnType("decimal(18,2)");

                    b.Property<Guid>("FromId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Hour")
                        .HasColumnType("decimal(18,2)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<decimal>("Minute")
                        .HasColumnType("decimal(18,2)");

                    b.Property<Guid>("ToId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UpdateBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("UpdatedDate")
                        .HasColumnType("datetimeoffset");

                    b.HasKey("Id");

                    b.HasIndex("CarId");

                    b.HasIndex("FromId");

                    b.HasIndex("ToId");

                    b.ToTable("Routes", (string)null);
                });

            modelBuilder.Entity("FU.Domain.Entities.Seat.SeatEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CarId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Col")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("CreateBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("CreatedDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<int>("Floor")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Row")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<Guid>("UpdateBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("UpdatedDate")
                        .HasColumnType("datetimeoffset");

                    b.HasKey("Id");

                    b.HasIndex("CarId");

                    b.ToTable("Seats", (string)null);
                });

            modelBuilder.Entity("FU.Domain.Entities.StopPoint.StopPointEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CarId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CreateBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("CreatedDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<Guid>("UpdateBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("UpdatedDate")
                        .HasColumnType("datetimeoffset");

                    b.HasKey("Id");

                    b.HasIndex("CarId");

                    b.ToTable("StopPoints", (string)null);
                });

            modelBuilder.Entity("FU.Domain.Entities.Ticket.TicketEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CarId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CreateBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("CreatedDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<Guid>("RouteId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("TicketService")
                        .HasColumnType("int");

                    b.Property<Guid>("UpdateBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("UpdatedDate")
                        .HasColumnType("datetimeoffset");

                    b.HasKey("Id");

                    b.ToTable("Tickets", (string)null);
                });

            modelBuilder.Entity("FU.Domain.Entities.Car.CarEntity", b =>
                {
                    b.HasOne("FU.Domain.Entities.CarsManager.CarsManagerEntity", "CarsManager")
                        .WithMany("Cars")
                        .HasForeignKey("CarsManagerId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("CarsManager");
                });

            modelBuilder.Entity("FU.Domain.Entities.LocalLocation.DistrictEntity", b =>
                {
                    b.HasOne("FU.Domain.Entities.LocalLocation.CityEntity", "City")
                        .WithMany("Districts")
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("City");
                });

            modelBuilder.Entity("FU.Domain.Entities.LocalLocation.WardEntity", b =>
                {
                    b.HasOne("FU.Domain.Entities.LocalLocation.DistrictEntity", "District")
                        .WithMany("Wards")
                        .HasForeignKey("DistrictId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("District");
                });

            modelBuilder.Entity("FU.Domain.Entities.Route.RouteEntity", b =>
                {
                    b.HasOne("FU.Domain.Entities.Car.CarEntity", "Car")
                        .WithMany("Routes")
                        .HasForeignKey("CarId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("FU.Domain.Entities.StopPoint.StopPointEntity", "FromPoint")
                        .WithMany("FromRoutes")
                        .HasForeignKey("FromId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("FU.Domain.Entities.StopPoint.StopPointEntity", "ToPoint")
                        .WithMany("ToRoutes")
                        .HasForeignKey("ToId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.Navigation("Car");

                    b.Navigation("FromPoint");

                    b.Navigation("ToPoint");
                });

            modelBuilder.Entity("FU.Domain.Entities.Seat.SeatEntity", b =>
                {
                    b.HasOne("FU.Domain.Entities.Car.CarEntity", "Car")
                        .WithMany("Seats")
                        .HasForeignKey("CarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Car");
                });

            modelBuilder.Entity("FU.Domain.Entities.StopPoint.StopPointEntity", b =>
                {
                    b.HasOne("FU.Domain.Entities.Car.CarEntity", "Car")
                        .WithMany("StopPoints")
                        .HasForeignKey("CarId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.OwnsOne("FU.Domain.Entities.StopPoint.DetailLocation", "DetailLocation", b1 =>
                        {
                            b1.Property<Guid>("StopPointEntityId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Latitude")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("Latitude");

                            b1.Property<string>("Longitude")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("Longitude");

                            b1.HasKey("StopPointEntityId");

                            b1.ToTable("StopPoints");

                            b1.WithOwner()
                                .HasForeignKey("StopPointEntityId");
                        });

                    b.OwnsOne("FU.Domain.Entities.StopPoint.Location", "Location", b1 =>
                        {
                            b1.Property<Guid>("StopPointEntityId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<Guid>("CityId")
                                .HasColumnType("uniqueidentifier")
                                .HasColumnName("CityId");

                            b1.Property<Guid>("DistrictId")
                                .HasColumnType("uniqueidentifier")
                                .HasColumnName("DistrictId");

                            b1.Property<string>("HouseNumber")
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("HouseNumber");

                            b1.Property<string>("Street")
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("Street");

                            b1.Property<Guid>("WardId")
                                .HasColumnType("uniqueidentifier")
                                .HasColumnName("WardId");

                            b1.HasKey("StopPointEntityId");

                            b1.ToTable("StopPoints");

                            b1.WithOwner()
                                .HasForeignKey("StopPointEntityId");
                        });

                    b.Navigation("Car");

                    b.Navigation("DetailLocation");

                    b.Navigation("Location")
                        .IsRequired();
                });

            modelBuilder.Entity("FU.Domain.Entities.Ticket.TicketEntity", b =>
                {
                    b.OwnsOne("FU.Domain.Entities.Ticket.ItemDetail", "ItemDetail", b1 =>
                        {
                            b1.Property<Guid>("TicketEntityId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<decimal>("Deep")
                                .HasColumnType("decimal(18,2)")
                                .HasColumnName("Deep");

                            b1.Property<decimal>("Height")
                                .HasColumnType("decimal(18,2)")
                                .HasColumnName("Height");

                            b1.Property<string>("Note")
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("Note");

                            b1.Property<string>("Receiver")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("Receiver");

                            b1.Property<decimal>("WeightInKg")
                                .HasColumnType("decimal(18,2)")
                                .HasColumnName("WeightInKg");

                            b1.Property<decimal>("Width")
                                .HasColumnType("decimal(18,2)")
                                .HasColumnName("Width");

                            b1.HasKey("TicketEntityId");

                            b1.ToTable("Tickets");

                            b1.WithOwner()
                                .HasForeignKey("TicketEntityId");
                        });

                    b.Navigation("ItemDetail");
                });

            modelBuilder.Entity("FU.Domain.Entities.Car.CarEntity", b =>
                {
                    b.Navigation("Routes");

                    b.Navigation("Seats");

                    b.Navigation("StopPoints");
                });

            modelBuilder.Entity("FU.Domain.Entities.CarsManager.CarsManagerEntity", b =>
                {
                    b.Navigation("Cars");
                });

            modelBuilder.Entity("FU.Domain.Entities.LocalLocation.CityEntity", b =>
                {
                    b.Navigation("Districts");
                });

            modelBuilder.Entity("FU.Domain.Entities.LocalLocation.DistrictEntity", b =>
                {
                    b.Navigation("Wards");
                });

            modelBuilder.Entity("FU.Domain.Entities.StopPoint.StopPointEntity", b =>
                {
                    b.Navigation("FromRoutes");

                    b.Navigation("ToRoutes");
                });
#pragma warning restore 612, 618
        }
    }
}
