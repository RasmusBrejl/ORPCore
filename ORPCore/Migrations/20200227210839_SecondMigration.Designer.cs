﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ORPCore.Models.Context;

namespace ORPCore.Migrations
{
    [DbContext(typeof(OrpContext))]
    [Migration("20200227210839_SecondMigration")]
    partial class SecondMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ORP.Models.City", b =>
                {
                    b.Property<int>("CityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumberOfHits")
                        .HasColumnType("int");

                    b.Property<float>("PricePenalty")
                        .HasColumnType("real");

                    b.Property<bool>("Valid")
                        .HasColumnType("bit");

                    b.HasKey("CityId");

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("ORP.Models.Clearance", b =>
                {
                    b.Property<int>("ClearanceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Level")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ClearanceId");

                    b.ToTable("Clearances");
                });

            modelBuilder.Entity("ORP.Models.Connection", b =>
                {
                    b.Property<int>("ConnectionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CityOneCityId")
                        .HasColumnType("int");

                    b.Property<int?>("CityTwoCityId")
                        .HasColumnType("int");

                    b.Property<int>("ConnectionType")
                        .HasColumnType("int");

                    b.HasKey("ConnectionId");

                    b.HasIndex("CityOneCityId");

                    b.HasIndex("CityTwoCityId");

                    b.ToTable("Connections");
                });

            modelBuilder.Entity("ORP.Models.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CityFromCityId")
                        .HasColumnType("int");

                    b.Property<int?>("CityToCityId")
                        .HasColumnType("int");

                    b.Property<float>("Duration")
                        .HasColumnType("real");

                    b.Property<DateTime>("OrderTime")
                        .HasColumnType("datetime2");

                    b.Property<int?>("ParcelId")
                        .HasColumnType("int");

                    b.Property<float>("Price")
                        .HasColumnType("real");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("OrderId");

                    b.HasIndex("CityFromCityId");

                    b.HasIndex("CityToCityId");

                    b.HasIndex("ParcelId");

                    b.HasIndex("UserId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("ORP.Models.Parcel", b =>
                {
                    b.Property<int>("ParcelId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<float>("Height")
                        .HasColumnType("real");

                    b.Property<float>("Length")
                        .HasColumnType("real");

                    b.Property<float>("Weight")
                        .HasColumnType("real");

                    b.Property<float>("Width")
                        .HasColumnType("real");

                    b.HasKey("ParcelId");

                    b.ToTable("Parcels");
                });

            modelBuilder.Entity("ORP.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ClearanceId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.HasIndex("ClearanceId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("ORP.Models.Connection", b =>
                {
                    b.HasOne("ORP.Models.City", "CityOne")
                        .WithMany()
                        .HasForeignKey("CityOneCityId");

                    b.HasOne("ORP.Models.City", "CityTwo")
                        .WithMany()
                        .HasForeignKey("CityTwoCityId");
                });

            modelBuilder.Entity("ORP.Models.Order", b =>
                {
                    b.HasOne("ORP.Models.City", "CityFrom")
                        .WithMany()
                        .HasForeignKey("CityFromCityId");

                    b.HasOne("ORP.Models.City", "CityTo")
                        .WithMany()
                        .HasForeignKey("CityToCityId");

                    b.HasOne("ORP.Models.Parcel", "Parcel")
                        .WithMany()
                        .HasForeignKey("ParcelId");

                    b.HasOne("ORP.Models.User", null)
                        .WithMany("Orders")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("ORP.Models.User", b =>
                {
                    b.HasOne("ORP.Models.Clearance", "Clearance")
                        .WithMany()
                        .HasForeignKey("ClearanceId");
                });
#pragma warning restore 612, 618
        }
    }
}
