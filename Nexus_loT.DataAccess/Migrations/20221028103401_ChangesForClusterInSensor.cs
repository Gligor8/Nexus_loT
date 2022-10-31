using Microsoft.EntityFrameworkCore.Migrations;

namespace Nexus_loT.DataAccess.Migrations
{
    public partial class ChangesForClusterInSensor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClusterSensor_Clusters_ClusterId",
                table: "ClusterSensor");

            migrationBuilder.DropForeignKey(
                name: "FK_ClusterSensor_Sensors_SensorId",
                table: "ClusterSensor");

            migrationBuilder.DropForeignKey(
                name: "FK_Readings_Sensors_SensorId",
                table: "Readings");

            migrationBuilder.DropColumn(
                name: "ClusterId",
                table: "Sensors");

            migrationBuilder.DropColumn(
                name: "SensorId",
                table: "Clusters");

            migrationBuilder.RenameColumn(
                name: "SensorId",
                table: "ClusterSensor",
                newName: "SensorsId");

            migrationBuilder.RenameColumn(
                name: "ClusterId",
                table: "ClusterSensor",
                newName: "ClustersId");

            migrationBuilder.RenameIndex(
                name: "IX_ClusterSensor_SensorId",
                table: "ClusterSensor",
                newName: "IX_ClusterSensor_SensorsId");

            migrationBuilder.AlterColumn<string>(
                name: "SensorId",
                table: "Readings",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ClusterSensor_Clusters_ClustersId",
                table: "ClusterSensor",
                column: "ClustersId",
                principalTable: "Clusters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ClusterSensor_Sensors_SensorsId",
                table: "ClusterSensor",
                column: "SensorsId",
                principalTable: "Sensors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Readings_Sensors_SensorId",
                table: "Readings",
                column: "SensorId",
                principalTable: "Sensors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClusterSensor_Clusters_ClustersId",
                table: "ClusterSensor");

            migrationBuilder.DropForeignKey(
                name: "FK_ClusterSensor_Sensors_SensorsId",
                table: "ClusterSensor");

            migrationBuilder.DropForeignKey(
                name: "FK_Readings_Sensors_SensorId",
                table: "Readings");

            migrationBuilder.RenameColumn(
                name: "SensorsId",
                table: "ClusterSensor",
                newName: "SensorId");

            migrationBuilder.RenameColumn(
                name: "ClustersId",
                table: "ClusterSensor",
                newName: "ClusterId");

            migrationBuilder.RenameIndex(
                name: "IX_ClusterSensor_SensorsId",
                table: "ClusterSensor",
                newName: "IX_ClusterSensor_SensorId");

            migrationBuilder.AddColumn<string>(
                name: "ClusterId",
                table: "Sensors",
                type: "text",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SensorId",
                table: "Readings",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<string>(
                name: "SensorId",
                table: "Clusters",
                type: "text",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ClusterSensor_Clusters_ClusterId",
                table: "ClusterSensor",
                column: "ClusterId",
                principalTable: "Clusters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ClusterSensor_Sensors_SensorId",
                table: "ClusterSensor",
                column: "SensorId",
                principalTable: "Sensors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Readings_Sensors_SensorId",
                table: "Readings",
                column: "SensorId",
                principalTable: "Sensors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
