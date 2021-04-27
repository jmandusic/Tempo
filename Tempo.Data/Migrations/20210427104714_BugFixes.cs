using Microsoft.EntityFrameworkCore.Migrations;

namespace Tempo.Data.Migrations
{
    public partial class BugFixes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserNotifications_Notificiations_NotificiationId",
                table: "UserNotifications");

            migrationBuilder.DropIndex(
                name: "IX_UserNotifications_NotificiationId",
                table: "UserNotifications");

            migrationBuilder.DropColumn(
                name: "NotificiationId",
                table: "UserNotifications");

            migrationBuilder.CreateIndex(
                name: "IX_UserNotifications_NotificationId",
                table: "UserNotifications",
                column: "NotificationId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserNotifications_Notificiations_NotificationId",
                table: "UserNotifications",
                column: "NotificationId",
                principalTable: "Notificiations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserNotifications_Notificiations_NotificationId",
                table: "UserNotifications");

            migrationBuilder.DropIndex(
                name: "IX_UserNotifications_NotificationId",
                table: "UserNotifications");

            migrationBuilder.AddColumn<int>(
                name: "NotificiationId",
                table: "UserNotifications",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserNotifications_NotificiationId",
                table: "UserNotifications",
                column: "NotificiationId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserNotifications_Notificiations_NotificiationId",
                table: "UserNotifications",
                column: "NotificiationId",
                principalTable: "Notificiations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
