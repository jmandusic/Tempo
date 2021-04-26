using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Tempo.Data.Migrations
{
    public partial class InitialDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Adresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StreetNumber = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adresses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Gyms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rating = table.Column<float>(type: "real", nullable: false),
                    ContactEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MembershipFee = table.Column<float>(type: "real", nullable: false),
                    Longitude = table.Column<float>(type: "real", nullable: false),
                    Latitude = table.Column<float>(type: "real", nullable: false),
                    Capacity = table.Column<int>(type: "int", nullable: false),
                    StartOfWork = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndOfWork = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AdressId = table.Column<int>(type: "int", nullable: true),
                    AdminId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gyms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Gyms_Adresses_AdressId",
                        column: x => x.AdressId,
                        principalTable: "Adresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Oib = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Role = table.Column<int>(type: "int", nullable: false),
                    HiredOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PricePerHour = table.Column<float>(type: "real", nullable: true),
                    EmployeeRole = table.Column<int>(type: "int", nullable: true),
                    GymId = table.Column<int>(type: "int", nullable: true),
                    Height = table.Column<float>(type: "real", nullable: true),
                    Weight = table.Column<float>(type: "real", nullable: true),
                    Age = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Gyms_GymId",
                        column: x => x.GymId,
                        principalTable: "Gyms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GymUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GymId = table.Column<int>(type: "int", nullable: true),
                    RegularUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GymUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GymUsers_Gyms_GymId",
                        column: x => x.GymId,
                        principalTable: "Gyms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GymUsers_Users_RegularUserId",
                        column: x => x.RegularUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Notificiations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SentOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notificiations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notificiations_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Schedules",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RegularUserId = table.Column<int>(type: "int", nullable: true),
                    GymId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schedules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Schedules_Gyms_GymId",
                        column: x => x.GymId,
                        principalTable: "Gyms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Schedules_Users_RegularUserId",
                        column: x => x.RegularUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Adresses",
                columns: new[] { "Id", "City", "Street", "StreetNumber" },
                values: new object[,]
                {
                    { 1, "Split", "Put Brodarice", 6 },
                    { 2, "Split", "Ul. Bilice II", 53 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Name", "Oib", "Password", "Role" },
                values: new object[,]
                {
                    { 1, "adminJ@mail.com", "Mate", "28903610827", "adminJoker", 0 },
                    { 2, "adminG@mail.com", "Ivan", "10927489362", "adminGuliver", 0 }
                });

            migrationBuilder.InsertData(
                table: "Gyms",
                columns: new[] { "Id", "AdminId", "AdressId", "Capacity", "ContactEmail", "EndOfWork", "Latitude", "Longitude", "MembershipFee", "Name", "Rating", "StartOfWork" },
                values: new object[] { 1, 1, 1, 120, "joker@mail.com", new DateTime(1, 1, 1, 0, 0, 0, 165, DateTimeKind.Unspecified).AddTicks(6000), 43.51985f, 16.447258f, 250f, "Fitness Centar Joker", 4.6f, new DateTime(1, 1, 1, 0, 0, 0, 57, DateTimeKind.Unspecified).AddTicks(6000) });

            migrationBuilder.InsertData(
                table: "Gyms",
                columns: new[] { "Id", "AdminId", "AdressId", "Capacity", "ContactEmail", "EndOfWork", "Latitude", "Longitude", "MembershipFee", "Name", "Rating", "StartOfWork" },
                values: new object[] { 2, 2, 2, 200, "guliver@mail.com", new DateTime(1, 1, 1, 0, 0, 0, 165, DateTimeKind.Unspecified).AddTicks(6000), 43.529247f, 16.491226f, 200f, "Guliver energija", 4.7f, new DateTime(1, 1, 1, 0, 0, 0, 57, DateTimeKind.Unspecified).AddTicks(6000) });

            migrationBuilder.CreateIndex(
                name: "IX_Gyms_AdminId",
                table: "Gyms",
                column: "AdminId");

            migrationBuilder.CreateIndex(
                name: "IX_Gyms_AdressId",
                table: "Gyms",
                column: "AdressId");

            migrationBuilder.CreateIndex(
                name: "IX_GymUsers_GymId",
                table: "GymUsers",
                column: "GymId");

            migrationBuilder.CreateIndex(
                name: "IX_GymUsers_RegularUserId",
                table: "GymUsers",
                column: "RegularUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Notificiations_UserId",
                table: "Notificiations",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Schedules_GymId",
                table: "Schedules",
                column: "GymId");

            migrationBuilder.CreateIndex(
                name: "IX_Schedules_RegularUserId",
                table: "Schedules",
                column: "RegularUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_GymId",
                table: "Users",
                column: "GymId");

            migrationBuilder.AddForeignKey(
                name: "FK_Gyms_Users_AdminId",
                table: "Gyms",
                column: "AdminId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Gyms_Adresses_AdressId",
                table: "Gyms");

            migrationBuilder.DropForeignKey(
                name: "FK_Gyms_Users_AdminId",
                table: "Gyms");

            migrationBuilder.DropTable(
                name: "GymUsers");

            migrationBuilder.DropTable(
                name: "Notificiations");

            migrationBuilder.DropTable(
                name: "Schedules");

            migrationBuilder.DropTable(
                name: "Adresses");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Gyms");
        }
    }
}
