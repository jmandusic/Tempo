﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Tempo.Data.Entities;

namespace Tempo.Data.Migrations
{
    [DbContext(typeof(TempoDbContext))]
    partial class TempoDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Tempo.Data.Entities.Models.Gym", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AdminId")
                        .HasColumnType("int");

                    b.Property<int>("Capacity")
                        .HasColumnType("int");

                    b.Property<string>("ContactEmail")
                        .HasColumnType("nvarchar(max)");

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

                    b.HasKey("Id");

                    b.HasIndex("AdminId");

                    b.ToTable("Gyms");
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

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
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

                    b.HasDiscriminator().HasValue(2);
                });

            modelBuilder.Entity("Tempo.Data.Entities.Models.Gym", b =>
                {
                    b.HasOne("Tempo.Data.Entities.Models.Admin", "Admin")
                        .WithMany()
                        .HasForeignKey("AdminId");

                    b.Navigation("Admin");
                });

            modelBuilder.Entity("Tempo.Data.Entities.Models.GymUser", b =>
                {
                    b.HasOne("Tempo.Data.Entities.Models.Gym", "Gym")
                        .WithMany("GymUsers")
                        .HasForeignKey("GymId");

                    b.HasOne("Tempo.Data.Entities.Models.RegularUser", "RegularUser")
                        .WithMany()
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
                    b.Navigation("Schedules");
                });
#pragma warning restore 612, 618
        }
    }
}
