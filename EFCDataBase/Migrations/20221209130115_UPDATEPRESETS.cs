using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCDataBase.Migrations
{
    public partial class UPDATEPRESETS : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Co2Max",
                table: "Preset");

            migrationBuilder.DropColumn(
                name: "Co2Min",
                table: "Preset");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "Co2Max",
                table: "Preset",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "Co2Min",
                table: "Preset",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }
    }
}
