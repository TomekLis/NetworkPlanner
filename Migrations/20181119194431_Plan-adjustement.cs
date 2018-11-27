using Microsoft.EntityFrameworkCore.Migrations;

namespace NetworkPlanner.Migrations
{
    public partial class Planadjustement : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "AntennaGain",
                table: "Plans",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "AreaType",
                table: "Plans",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "CableLoss",
                table: "Plans",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "CellRange",
                table: "Plans",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "ChannelMax",
                table: "Plans",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ChannelMin",
                table: "Plans",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "ChannelReuseDistnace",
                table: "Plans",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Cirf",
                table: "Plans",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "ClusterSize",
                table: "Plans",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Eirp",
                table: "Plans",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Latitude",
                table: "Plans",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Longitude",
                table: "Plans",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "RequiredCi",
                table: "Plans",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "SystemCapacity",
                table: "Plans",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "TransmitterPower",
                table: "Plans",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AntennaGain",
                table: "Plans");

            migrationBuilder.DropColumn(
                name: "AreaType",
                table: "Plans");

            migrationBuilder.DropColumn(
                name: "CableLoss",
                table: "Plans");

            migrationBuilder.DropColumn(
                name: "CellRange",
                table: "Plans");

            migrationBuilder.DropColumn(
                name: "ChannelMax",
                table: "Plans");

            migrationBuilder.DropColumn(
                name: "ChannelMin",
                table: "Plans");

            migrationBuilder.DropColumn(
                name: "ChannelReuseDistnace",
                table: "Plans");

            migrationBuilder.DropColumn(
                name: "Cirf",
                table: "Plans");

            migrationBuilder.DropColumn(
                name: "ClusterSize",
                table: "Plans");

            migrationBuilder.DropColumn(
                name: "Eirp",
                table: "Plans");

            migrationBuilder.DropColumn(
                name: "Latitude",
                table: "Plans");

            migrationBuilder.DropColumn(
                name: "Longitude",
                table: "Plans");

            migrationBuilder.DropColumn(
                name: "RequiredCi",
                table: "Plans");

            migrationBuilder.DropColumn(
                name: "SystemCapacity",
                table: "Plans");

            migrationBuilder.DropColumn(
                name: "TransmitterPower",
                table: "Plans");
        }
    }
}
