using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCDataBase.Migrations
{
    public partial class UpdateSensorEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BoxId",
                table: "Sensors");

            migrationBuilder.RenameColumn(
                name: "Co2",
                table: "Sensors",
                newName: "CO2");

            migrationBuilder.AddColumn<float>(
                name: "DewPt",
                table: "Sensors",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "Humidity",
                table: "Sensors",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DewPt",
                table: "Sensors");

            migrationBuilder.DropColumn(
                name: "Humidity",
                table: "Sensors");

            migrationBuilder.RenameColumn(
                name: "CO2",
                table: "Sensors",
                newName: "Co2");

            migrationBuilder.AddColumn<string>(
                name: "BoxId",
                table: "Sensors",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
