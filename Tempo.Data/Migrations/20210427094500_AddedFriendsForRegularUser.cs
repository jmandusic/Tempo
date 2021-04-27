using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Tempo.Data.Migrations
{
    public partial class AddedFriendsForRegularUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RegularUserId",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "PayedOn",
                table: "GymUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_Users_RegularUserId",
                table: "Users",
                column: "RegularUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Users_RegularUserId",
                table: "Users",
                column: "RegularUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Users_RegularUserId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_RegularUserId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "RegularUserId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "PayedOn",
                table: "GymUsers");
        }
    }
}
