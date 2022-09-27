﻿// <auto-generated />
using System;
using FU.Repository.DbStore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace API.Migrations
{
    [DbContext(typeof(Store))]
    partial class StoreModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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
                        .HasColumnType("nvarchar(max)");

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

            modelBuilder.Entity("FU.Domain.Entities.Mapping.CarRouteMappingEntity", b =>
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

                    b.Property<Guid>("RouteId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("Starttime")
                        .HasColumnType("datetimeoffset");

                    b.Property<Guid>("UpdateBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("UpdatedDate")
                        .HasColumnType("datetimeoffset");

                    b.HasKey("Id");

                    b.HasIndex("CarId");

                    b.HasIndex("RouteId");

                    b.ToTable("CarRouteMapping", (string)null);
                });

            modelBuilder.Entity("FU.Domain.Entities.Route.RouteEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CreateBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("CreatedDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<decimal>("Day")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("DistanceByKm")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Hour")
                        .HasColumnType("decimal(18,2)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<decimal>("Minute")
                        .HasColumnType("decimal(18,2)");

                    b.Property<Guid>("UpdateBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("UpdatedDate")
                        .HasColumnType("datetimeoffset");

                    b.HasKey("Id");

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

                    b.Property<Guid>("SeatId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("TicketService")
                        .HasColumnType("int");

                    b.Property<Guid>("UpdateBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("UpdatedDate")
                        .HasColumnType("datetimeoffset");

                    b.HasKey("Id");

                    b.HasIndex("SeatId");

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

            modelBuilder.Entity("FU.Domain.Entities.Mapping.CarRouteMappingEntity", b =>
                {
                    b.HasOne("FU.Domain.Entities.Car.CarEntity", "Car")
                        .WithMany("CarRouteMappings")
                        .HasForeignKey("CarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FU.Domain.Entities.Route.RouteEntity", "Route")
                        .WithMany("CarRouteMappings")
                        .HasForeignKey("RouteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Car");

                    b.Navigation("Route");
                });

            modelBuilder.Entity("FU.Domain.Entities.Route.RouteEntity", b =>
                {
                    b.OwnsOne("FU.Domain.Entities.Route.Location", "From", b1 =>
                        {
                            b1.Property<Guid>("RouteEntityId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<Guid>("CityId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<Guid>("DistrictId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("HouseNumber")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Street")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<Guid>("WardId")
                                .HasColumnType("uniqueidentifier");

                            b1.HasKey("RouteEntityId");

                            b1.ToTable("Routes");

                            b1.WithOwner()
                                .HasForeignKey("RouteEntityId");
                        });

                    b.OwnsOne("FU.Domain.Entities.Route.Location", "To", b1 =>
                        {
                            b1.Property<Guid>("RouteEntityId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<Guid>("CityId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<Guid>("DistrictId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("HouseNumber")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Street")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<Guid>("WardId")
                                .HasColumnType("uniqueidentifier");

                            b1.HasKey("RouteEntityId");

                            b1.ToTable("Routes");

                            b1.WithOwner()
                                .HasForeignKey("RouteEntityId");
                        });

                    b.Navigation("From")
                        .IsRequired();

                    b.Navigation("To")
                        .IsRequired();
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

            modelBuilder.Entity("FU.Domain.Entities.Ticket.TicketEntity", b =>
                {
                    b.HasOne("FU.Domain.Entities.Seat.SeatEntity", "Seat")
                        .WithMany("Tickets")
                        .HasForeignKey("SeatId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

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

                    b.Navigation("Seat");
                });

            modelBuilder.Entity("FU.Domain.Entities.Car.CarEntity", b =>
                {
                    b.Navigation("CarRouteMappings");

                    b.Navigation("Seats");
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

            modelBuilder.Entity("FU.Domain.Entities.Route.RouteEntity", b =>
                {
                    b.Navigation("CarRouteMappings");
                });

            modelBuilder.Entity("FU.Domain.Entities.Seat.SeatEntity", b =>
                {
                    b.Navigation("Tickets");
                });
#pragma warning restore 612, 618
        }
    }
}
