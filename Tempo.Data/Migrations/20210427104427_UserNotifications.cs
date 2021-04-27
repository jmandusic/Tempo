using Microsoft.EntityFrameworkCore.Migrations;

namespace Tempo.Data.Migrations
{
    public partial class UserNotifications : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notificiations_Users_UserId",
                table: "Notificiations");

            migrationBuilder.DropIndex(
                name: "IX_Notificiations_UserId",
                table: "Notificiations");

            migrationBuilder.DropColumn(
                name: "Opened",
                table: "Notificiations");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Notificiations");

            migrationBuilder.CreateTable(
                name: "UserNotifications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Opened = table.Column<bool>(type: "bit", nullable: false),
                    NotificationId = table.Column<int>(type: "int", nullable: true),
                    NotificiationId = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserNotifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserNotifications_Notificiations_NotificiationId",
                        column: x => x.NotificiationId,
                        principalTable: "Notificiations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserNotifications_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserNotifications_NotificiationId",
                table: "UserNotifications",
                column: "NotificiationId");

            migrationBuilder.CreateIndex(
                name: "IX_UserNotifications_UserId",
                table: "UserNotifications",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserNotifications");

            migrationBuilder.AddColumn<bool>(
                name: "Opened",
                table: "Notificiations",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Notificiations",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Notificiations_UserId",
                table: "Notificiations",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Notificiations_Users_UserId",
                table: "Notificiations",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
