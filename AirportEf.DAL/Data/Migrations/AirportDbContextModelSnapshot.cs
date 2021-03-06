﻿// <auto-generated />
using System;
using AirportEf.DAL.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AirportEf.DAL.Data.Migrations
{
    [DbContext(typeof(AirportDbContext))]
    partial class AirportDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.0-rtm-30799")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AirportEf.DAL.Entities.Plane", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreationDate");

                    b.Property<TimeSpan>("LifeTime");

                    b.Property<int>("PlaneTypeId");

                    b.HasKey("Id");

                    b.HasIndex("PlaneTypeId");

                    b.ToTable("Planes");
                });

            modelBuilder.Entity("AirportEf.DAL.Entities.PlaneType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("MaxCarryingCapacityKg");

                    b.Property<int>("MaxNumberOfPlaces");

                    b.Property<string>("PlaneModel");

                    b.HasKey("Id");

                    b.ToTable("PlaneTypes");
                });

            modelBuilder.Entity("AirportEf.DAL.Entities.Plane", b =>
                {
                    b.HasOne("AirportEf.DAL.Entities.PlaneType", "PlaneType")
                        .WithMany()
                        .HasForeignKey("PlaneTypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
