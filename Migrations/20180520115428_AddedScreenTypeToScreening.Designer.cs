﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;
using viacinema.Data;

namespace viacinema.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20180520115428_AddedScreenTypeToScreening")]
    partial class AddedScreenTypeToScreening
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.2-rtm-10011")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("viacinema.Models.Movie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description")
                        .HasMaxLength(1500);

                    b.Property<int>("DurationInSeconds");

                    b.Property<string>("Genre")
                        .IsRequired()
                        .HasMaxLength(25);

                    b.Property<string>("ImageUrl")
                        .IsRequired();

                    b.Property<byte>("Rating");

                    b.Property<DateTime>("ReleaseDate");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("Movies");
                });

            modelBuilder.Entity("viacinema.Models.Room", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("availableSeats");

                    b.Property<int>("roomNo");

                    b.Property<int>("totalSeats");

                    b.HasKey("Id");

                    b.ToTable("Rooms");
                });

            modelBuilder.Entity("viacinema.Models.Screening", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("MovieId");

                    b.Property<int>("RoomNo");

                    b.Property<DateTime>("StartTime");

                    b.Property<string>("screenType")
                        .IsRequired()
                        .HasMaxLength(5);

                    b.HasKey("Id");

                    b.ToTable("Screenings");
                });

            modelBuilder.Entity("viacinema.Models.Seat", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Occupied");

                    b.Property<double>("Price");

                    b.Property<int>("RoomNo");

                    b.Property<int>("RowNo");

                    b.Property<int>("SeatNo");

                    b.HasKey("Id");

                    b.ToTable("Seats");
                });
#pragma warning restore 612, 618
        }
    }
}
