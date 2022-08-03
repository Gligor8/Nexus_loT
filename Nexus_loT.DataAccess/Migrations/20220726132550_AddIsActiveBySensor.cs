using Microsoft.EntityFrameworkCore.Migrations;

namespace Nexus_loT.DataAccess.Migrations
{
    public partial class AddIsActiveBySensor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Sensors",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Sensors");
        }
    }
}
