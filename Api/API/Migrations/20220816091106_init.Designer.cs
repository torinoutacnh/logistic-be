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
    [Migration("20220816091106_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("FU.Domain.Entities.Form.FormEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CreateBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("CreatedDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<Guid>("UpdateBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("UpdatedDate")
                        .HasColumnType("datetimeoffset");

                    b.HasKey("Id");

                    b.ToTable("Form", (string)null);
                });

            modelBuilder.Entity("FU.Domain.Entities.FormAttribute.FormAttributeEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CreateBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("CreatedDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<Guid>("FormId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UpdateBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("UpdatedDate")
                        .HasColumnType("datetimeoffset");

                    b.HasKey("Id");

                    b.HasIndex("FormId");

                    b.ToTable("FormAttribute", (string)null);
                });

            modelBuilder.Entity("FU.Domain.Entities.Form.FormEntity", b =>
                {
                    b.OwnsOne("FU.Domain.Entities.Form.FormInfo", "Info", b1 =>
                        {
                            b1.Property<Guid>("FormEntityId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Code")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Name")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Number")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("FormEntityId");

                            b1.ToTable("Form");

                            b1.WithOwner()
                                .HasForeignKey("FormEntityId");
                        });

                    b.Navigation("Info")
                        .IsRequired();
                });

            modelBuilder.Entity("FU.Domain.Entities.FormAttribute.FormAttributeEntity", b =>
                {
                    b.HasOne("FU.Domain.Entities.Form.FormEntity", "Form")
                        .WithMany("Attributes")
                        .HasForeignKey("FormId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("FU.Domain.Entities.FormAttribute.FormAttributeDisplay", "Display", b1 =>
                        {
                            b1.Property<Guid>("FormAttributeEntityId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<int?>("Col")
                                .HasColumnType("int");

                            b1.Property<string>("ContentClass")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<int?>("ContentCol")
                                .HasColumnType("int");

                            b1.Property<int?>("ContentRow")
                                .HasColumnType("int");

                            b1.Property<string>("ContentStyle")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("LabelClass")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<int?>("LabelCol")
                                .HasColumnType("int");

                            b1.Property<int?>("LabelPosition")
                                .HasColumnType("int");

                            b1.Property<int?>("LabelRow")
                                .HasColumnType("int");

                            b1.Property<string>("LabelStyle")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<int?>("Row")
                                .HasColumnType("int");

                            b1.HasKey("FormAttributeEntityId");

                            b1.ToTable("FormAttribute");

                            b1.WithOwner()
                                .HasForeignKey("FormAttributeEntityId");
                        });

                    b.OwnsOne("FU.Domain.Entities.FormAttribute.FormAttributeInfo", "Info", b1 =>
                        {
                            b1.Property<Guid>("FormAttributeEntityId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("DefaultValue")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Label")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("MapCode")
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("FormAttributeEntityId");

                            b1.ToTable("FormAttribute");

                            b1.WithOwner()
                                .HasForeignKey("FormAttributeEntityId");
                        });

                    b.OwnsOne("FU.Domain.Entities.FormAttribute.FormAttributeModify", "Modify", b1 =>
                        {
                            b1.Property<Guid>("FormAttributeEntityId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<int>("ControlType")
                                .HasColumnType("int");

                            b1.Property<int>("DataType")
                                .HasColumnType("int");

                            b1.Property<string>("DropDownValues")
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("FormAttributeEntityId");

                            b1.ToTable("FormAttribute");

                            b1.WithOwner()
                                .HasForeignKey("FormAttributeEntityId");
                        });

                    b.Navigation("Display");

                    b.Navigation("Form");

                    b.Navigation("Info")
                        .IsRequired();

                    b.Navigation("Modify")
                        .IsRequired();
                });

            modelBuilder.Entity("FU.Domain.Entities.Form.FormEntity", b =>
                {
                    b.Navigation("Attributes");
                });
#pragma warning restore 612, 618
        }
    }
}
