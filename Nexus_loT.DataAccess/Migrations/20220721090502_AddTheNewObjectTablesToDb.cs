using Microsoft.EntityFrameworkCore.Migrations;

namespace Nexus_loT.DataAccess.Migrations
{
    public partial class AddTheNewObjectTablesToDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClusterSensor_Sensor_SensorId",
                table: "ClusterSensor");

            migrationBuilder.DropForeignKey(
                name: "FK_Sensor_SensorType_SensorTypeId",
                table: "Sensor");

            migrationBuilder.DropForeignKey(
                name: "FK_SensorType_MeasurementUnits_MeasurementUnitId",
                table: "SensorType");

            migrationBuilder.DropForeignKey(
                name: "FK_SensorType_Vendor_VendorId",
                table: "SensorType");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Vendor",
                table: "Vendor");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SensorType",
                table: "SensorType");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Sensor",
                table: "Sensor");

            migrationBuilder.RenameTable(
                name: "Vendor",
                newName: "Vendors");

            migrationBuilder.RenameTable(
                name: "SensorType",
                newName: "SensorTypes");

            migrationBuilder.RenameTable(
                name: "Sensor",
                newName: "Sensors");

            migrationBuilder.RenameIndex(
                name: "IX_SensorType_VendorId",
                table: "SensorTypes",
                newName: "IX_SensorTypes_VendorId");

            migrationBuilder.RenameIndex(
                name: "IX_SensorType_MeasurementUnitId",
                table: "SensorTypes",
                newName: "IX_SensorTypes_MeasurementUnitId");

            migrationBuilder.RenameIndex(
                name: "IX_Sensor_SensorTypeId",
                table: "Sensors",
                newName: "IX_Sensors_SensorTypeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Vendors",
                table: "Vendors",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SensorTypes",
                table: "SensorTypes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Sensors",
                table: "Sensors",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ClusterSensor_Sensors_SensorId",
                table: "ClusterSensor",
                column: "SensorId",
                principalTable: "Sensors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sensors_SensorTypes_SensorTypeId",
                table: "Sensors",
                column: "SensorTypeId",
                principalTable: "SensorTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SensorTypes_MeasurementUnits_MeasurementUnitId",
                table: "SensorTypes",
                column: "MeasurementUnitId",
                principalTable: "MeasurementUnits",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SensorTypes_Vendors_VendorId",
                table: "SensorTypes",
                column: "VendorId",
                principalTable: "Vendors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClusterSensor_Sensors_SensorId",
                table: "ClusterSensor");

            migrationBuilder.DropForeignKey(
                name: "FK_Sensors_SensorTypes_SensorTypeId",
                table: "Sensors");

            migrationBuilder.DropForeignKey(
                name: "FK_SensorTypes_MeasurementUnits_MeasurementUnitId",
                table: "SensorTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_SensorTypes_Vendors_VendorId",
                table: "SensorTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Vendors",
                table: "Vendors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SensorTypes",
                table: "SensorTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Sensors",
                table: "Sensors");

            migrationBuilder.RenameTable(
                name: "Vendors",
                newName: "Vendor");

            migrationBuilder.RenameTable(
                name: "SensorTypes",
                newName: "SensorType");

            migrationBuilder.RenameTable(
                name: "Sensors",
                newName: "Sensor");

            migrationBuilder.RenameIndex(
                name: "IX_SensorTypes_VendorId",
                table: "SensorType",
                newName: "IX_SensorType_VendorId");

            migrationBuilder.RenameIndex(
                name: "IX_SensorTypes_MeasurementUnitId",
                table: "SensorType",
                newName: "IX_SensorType_MeasurementUnitId");

            migrationBuilder.RenameIndex(
                name: "IX_Sensors_SensorTypeId",
                table: "Sensor",
                newName: "IX_Sensor_SensorTypeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Vendor",
                table: "Vendor",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SensorType",
                table: "SensorType",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Sensor",
                table: "Sensor",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ClusterSensor_Sensor_SensorId",
                table: "ClusterSensor",
                column: "SensorId",
                principalTable: "Sensor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sensor_SensorType_SensorTypeId",
                table: "Sensor",
                column: "SensorTypeId",
                principalTable: "SensorType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SensorType_MeasurementUnits_MeasurementUnitId",
                table: "SensorType",
                column: "MeasurementUnitId",
                principalTable: "MeasurementUnits",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SensorType_Vendor_VendorId",
                table: "SensorType",
                column: "VendorId",
                principalTable: "Vendor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
