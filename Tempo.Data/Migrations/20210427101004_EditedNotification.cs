using Microsoft.EntityFrameworkCore.Migrations;

namespace Tempo.Data.Migrations
{
    public partial class EditedNotification : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Opened",
                table: "Notificiations",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Opened",
                table: "Notificiations");
        }
    }
}
