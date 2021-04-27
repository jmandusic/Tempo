﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Tempo.Data.Entities;

namespace Tempo.Data.Migrations
{
    [DbContext(typeof(TempoDbContext))]
    [Migration("20210426203536_MembershipProp")]
    partial class MembershipProp
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Tempo.Data.Entities.Models.Adress", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Street")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StreetNumber")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Adresses");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            City = "Split",
                            Street = "Put Brodarice",
                            StreetNumber = 6
                        },
                        new
                        {
                            Id = 2,
                            City = "Split",
                            Street = "Ul. Bilice II",
                            StreetNumber = 53
                        });
                });

            modelBuilder.Entity("Tempo.Data.Entities.Models.Gym", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AdminId")
                        .HasColumnType("int");

                    b.Property<int?>("AdressId")
                        .HasColumnType("int");

                    b.Property<int>("Capacity")
                        .HasColumnType("int");

                    b.Property<string>("ContactEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EndOfWork")
                        .HasColumnType("datetime2");

                    b.Property<float>("Latitude")
                        .HasColumnType("real");

                    b.Property<float>("Longitude")
                        .HasColumnType("real");

                    b.Property<float>("MembershipFee")
                        .HasColumnType("real");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Rating")
                        .HasColumnType("real");

                    b.Property<DateTime>("StartOfWork")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("AdminId");

                    b.HasIndex("AdressId");

                    b.ToTable("Gyms");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AdminId = 1,
                            AdressId = 1,
                            Capacity = 120,
                            ContactEmail = "joker@mail.com",
                            EndOfWork = new DateTime(1, 1, 1, 0, 0, 0, 165, DateTimeKind.Unspecified).AddTicks(6000),
                            Latitude = 43.51985f,
                            Longitude = 16.447258f,
                            MembershipFee = 250f,
                            Name = "Fitness Centar Joker",
                            Rating = 4.6f,
                            StartOfWork = new DateTime(1, 1, 1, 0, 0, 0, 57, DateTimeKind.Unspecified).AddTicks(6000)
                        },
                        new
                        {
                            Id = 2,
                            AdminId = 2,
                            AdressId = 2,
                            Capacity = 200,
                            ContactEmail = "guliver@mail.com",
                            EndOfWork = new DateTime(1, 1, 1, 0, 0, 0, 165, DateTimeKind.Unspecified).AddTicks(6000),
                            Latitude = 43.529247f,
                            Longitude = 16.491226f,
                            MembershipFee = 200f,
                            Name = "Guliver energija",
                            Rating = 4.7f,
                            StartOfWork = new DateTime(1, 1, 1, 0, 0, 0, 57, DateTimeKind.Unspecified).AddTicks(6000)
                        });
                });

            modelBuilder.Entity("Tempo.Data.Entities.Models.GymUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("GymId")
                        .HasColumnType("int");

                    b.Property<int?>("RegularUserId")
                        .HasColumnType("int");

                    b.Property<bool>("isMembershipPayed")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("GymId");

                    b.HasIndex("RegularUserId");

                    b.ToTable("GymUsers");
                });

            modelBuilder.Entity("Tempo.Data.Entities.Models.Notificiation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Message")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("SentOn")
                        .HasColumnType("datetime2");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Notificiations");
                });

            modelBuilder.Entity("Tempo.Data.Entities.Models.Schedule", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("GymId")
                        .HasColumnType("int");

                    b.Property<int?>("RegularUserId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Time")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("GymId");

                    b.HasIndex("RegularUserId");

                    b.ToTable("Schedules");
                });

            modelBuilder.Entity("Tempo.Data.Entities.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Oib")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasDiscriminator<int>("Role");
                });

            modelBuilder.Entity("Tempo.Data.Entities.Models.Admin", b =>
                {
                    b.HasBaseType("Tempo.Data.Entities.Models.User");

                    b.HasDiscriminator().HasValue(0);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "adminJ@mail.com",
                            Name = "Mate",
                            Oib = "28903610827",
                            Password = "adminJoker",
                            Role = 0
                        },
                        new
                        {
                            Id = 2,
                            Email = "adminG@mail.com",
                            Name = "Ivan",
                            Oib = "10927489362",
                            Password = "adminGuliver",
                            Role = 0
                        });
                });

            modelBuilder.Entity("Tempo.Data.Entities.Models.Employee", b =>
                {
                    b.HasBaseType("Tempo.Data.Entities.Models.User");

                    b.Property<int>("EmployeeRole")
                        .HasColumnType("int");

                    b.Property<int?>("GymId")
                        .HasColumnType("int");

                    b.Property<DateTime>("HiredOn")
                        .HasColumnType("datetime2");

                    b.Property<float>("PricePerHour")
                        .HasColumnType("real");

                    b.HasIndex("GymId");

                    b.HasDiscriminator().HasValue(1);
                });

            modelBuilder.Entity("Tempo.Data.Entities.Models.RegularUser", b =>
                {
                    b.HasBaseType("Tempo.Data.Entities.Models.User");

                    b.Property<int?>("Age")
                        .HasColumnType("int");

                    b.Property<float?>("Height")
                        .HasColumnType("real");

                    b.Property<float?>("Weight")
                        .HasColumnType("real");

                    b.HasDiscriminator().HasValue(2);
                });

            modelBuilder.Entity("Tempo.Data.Entities.Models.Gym", b =>
                {
                    b.HasOne("Tempo.Data.Entities.Models.Admin", "Admin")
                        .WithMany()
                        .HasForeignKey("AdminId");

                    b.HasOne("Tempo.Data.Entities.Models.Adress", "Adress")
                        .WithMany()
                        .HasForeignKey("AdressId");

                    b.Navigation("Admin");

                    b.Navigation("Adress");
                });

            modelBuilder.Entity("Tempo.Data.Entities.Models.GymUser", b =>
                {
                    b.HasOne("Tempo.Data.Entities.Models.Gym", "Gym")
                        .WithMany("GymUsers")
                        .HasForeignKey("GymId");

                    b.HasOne("Tempo.Data.Entities.Models.RegularUser", "RegularUser")
                        .WithMany("GymUsers")
                        .HasForeignKey("RegularUserId");

                    b.Navigation("Gym");

                    b.Navigation("RegularUser");
                });

            modelBuilder.Entity("Tempo.Data.Entities.Models.Notificiation", b =>
                {
                    b.HasOne("Tempo.Data.Entities.Models.User", "User")
                        .WithMany("Notificiations")
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Tempo.Data.Entities.Models.Schedule", b =>
                {
                    b.HasOne("Tempo.Data.Entities.Models.Gym", "Gym")
                        .WithMany("Schedules")
                        .HasForeignKey("GymId");

                    b.HasOne("Tempo.Data.Entities.Models.RegularUser", "RegularUSer")
                        .WithMany("Schedules")
                        .HasForeignKey("RegularUserId");

                    b.Navigation("Gym");

                    b.Navigation("RegularUSer");
                });

            modelBuilder.Entity("Tempo.Data.Entities.Models.Employee", b =>
                {
                    b.HasOne("Tempo.Data.Entities.Models.Gym", "Gym")
                        .WithMany("Employees")
                        .HasForeignKey("GymId");

                    b.Navigation("Gym");
                });

            modelBuilder.Entity("Tempo.Data.Entities.Models.Gym", b =>
                {
                    b.Navigation("Employees");

                    b.Navigation("GymUsers");

                    b.Navigation("Schedules");
                });

            modelBuilder.Entity("Tempo.Data.Entities.Models.User", b =>
                {
                    b.Navigation("Notificiations");
                });

            modelBuilder.Entity("Tempo.Data.Entities.Models.RegularUser", b =>
                {
                    b.Navigation("GymUsers");

                    b.Navigation("Schedules");
                });
#pragma warning restore 612, 618
        }
    }
}
