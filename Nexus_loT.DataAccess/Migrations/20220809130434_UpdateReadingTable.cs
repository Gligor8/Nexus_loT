using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Nexus_loT.DataAccess.Migrations
{
    public partial class UpdateReadingTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Timestamp",
                table: "Readings");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateRead",
                table: "Readings",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateRead",
                table: "Readings");

            migrationBuilder.AddColumn<double>(
                name: "Timestamp",
                table: "Readings",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
