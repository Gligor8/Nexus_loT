using Microsoft.EntityFrameworkCore.Migrations;

namespace Nexus_loT.DataAccess.Migrations
{
    public partial class AddSensorTypeAndVendorToDbAndUpdateTheRestWithAdditionalProperties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SensorId",
                table: "Clusters",
                type: "text",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Vendor",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vendor", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SensorType",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    MeasurementUnitId = table.Column<string>(type: "text", nullable: true),
                    APIUrl = table.Column<string>(type: "text", nullable: true),
                    Configuration = table.Column<string>(type: "text", nullable: true),
                    VendorId = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SensorType", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SensorType_MeasurementUnits_MeasurementUnitId",
                        column: x => x.MeasurementUnitId,
                        principalTable: "MeasurementUnits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SensorType_Vendor_VendorId",
                        column: x => x.VendorId,
                        principalTable: "Vendor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Sensor",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    ClusterId = table.Column<string>(type: "text", nullable: true),
                    SensorTypeId = table.Column<string>(type: "text", nullable: true),
                    APIUrl = table.Column<string>(type: "text", nullable: true),
                    X = table.Column<double>(type: "double precision", nullable: false),
                    Y = table.Column<double>(type: "double precision", nullable: false),
                    Configuration = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sensor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sensor_SensorType_SensorTypeId",
                        column: x => x.SensorTypeId,
                        principalTable: "SensorType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ClusterSensor",
                columns: table => new
                {
                    ClusterId = table.Column<string>(type: "text", nullable: false),
                    SensorId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClusterSensor", x => new { x.ClusterId, x.SensorId });
                    table.ForeignKey(
                        name: "FK_ClusterSensor_Clusters_ClusterId",
                        column: x => x.ClusterId,
                        principalTable: "Clusters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClusterSensor_Sensor_SensorId",
                        column: x => x.SensorId,
                        principalTable: "Sensor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClusterSensor_SensorId",
                table: "ClusterSensor",
                column: "SensorId");

            migrationBuilder.CreateIndex(
                name: "IX_Sensor_SensorTypeId",
                table: "Sensor",
                column: "SensorTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_SensorType_MeasurementUnitId",
                table: "SensorType",
                column: "MeasurementUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_SensorType_VendorId",
                table: "SensorType",
                column: "VendorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClusterSensor");

            migrationBuilder.DropTable(
                name: "Sensor");

            migrationBuilder.DropTable(
                name: "SensorType");

            migrationBuilder.DropTable(
                name: "Vendor");

            migrationBuilder.DropColumn(
                name: "SensorId",
                table: "Clusters");
        }
    }
}
