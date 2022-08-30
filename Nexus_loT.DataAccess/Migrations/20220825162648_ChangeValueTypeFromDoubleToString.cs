using Microsoft.EntityFrameworkCore.Migrations;

namespace Nexus_loT.DataAccess.Migrations
{
    public partial class ChangeValueTypeFromDoubleToString : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Value",
                table: "Readings",
                type: "text",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "double precision");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Value",
                table: "Readings",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);
        }
    }
}
