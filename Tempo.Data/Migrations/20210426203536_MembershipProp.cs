using Microsoft.EntityFrameworkCore.Migrations;

namespace Tempo.Data.Migrations
{
    public partial class MembershipProp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "isMembershipPayed",
                table: "GymUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isMembershipPayed",
                table: "GymUsers");
        }
    }
}
