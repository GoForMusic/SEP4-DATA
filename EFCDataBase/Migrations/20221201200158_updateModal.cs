using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCDataBase.Migrations
{
    public partial class updateModal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sensors");

            migrationBuilder.AddColumn<string>(
                name: "boxId",
                table: "Users",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Box",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    light = table.Column<bool>(type: "boolean", nullable: false),
                    locked = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Box", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Record",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Timestamp = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Temperature = table.Column<float>(type: "real", nullable: false),
                    Humidity = table.Column<float>(type: "real", nullable: false),
                    CO2 = table.Column<float>(type: "real", nullable: false),
                    DewPt = table.Column<float>(type: "real", nullable: false),
                    BoxId = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Record", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Record_Box_BoxId",
                        column: x => x.BoxId,
                        principalTable: "Box",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Record_BoxId",
                table: "Record",
                column: "BoxId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Record");

            migrationBuilder.DropTable(
                name: "Box");

            migrationBuilder.DropColumn(
                name: "boxId",
                table: "Users");

            migrationBuilder.CreateTable(
                name: "Sensors",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    CO2 = table.Column<float>(type: "real", nullable: false),
                    DewPt = table.Column<float>(type: "real", nullable: false),
                    Humidity = table.Column<float>(type: "real", nullable: false),
                    Temperature = table.Column<float>(type: "real", nullable: false),
                    Timestamp = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sensors", x => x.Id);
                });
        }
    }
}
