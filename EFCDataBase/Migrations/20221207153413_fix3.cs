using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCDataBase.Migrations
{
    public partial class fix3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Record_Box_BoxId",
                table: "Record");

            migrationBuilder.DropIndex(
                name: "IX_Record_BoxId",
                table: "Record");

            migrationBuilder.RenameColumn(
                name: "OwnedBy",
                table: "Box",
                newName: "UserId");

            migrationBuilder.CreateTable(
                name: "Preset",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    PresetName = table.Column<string>(type: "text", nullable: false),
                    TemperatureMax = table.Column<float>(type: "real", nullable: false),
                    HumidityMax = table.Column<float>(type: "real", nullable: false),
                    Co2Max = table.Column<float>(type: "real", nullable: false),
                    TemperatureMin = table.Column<float>(type: "real", nullable: false),
                    HumidityMin = table.Column<float>(type: "real", nullable: false),
                    Co2Min = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Preset", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Preset");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Box",
                newName: "OwnedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Record_BoxId",
                table: "Record",
                column: "BoxId");

            migrationBuilder.AddForeignKey(
                name: "FK_Record_Box_BoxId",
                table: "Record",
                column: "BoxId",
                principalTable: "Box",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
