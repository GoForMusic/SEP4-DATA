using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCDataBase.Migrations
{
    public partial class addboxID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Record_Box_BoxId",
                table: "Record");

            migrationBuilder.AlterColumn<string>(
                name: "BoxId",
                table: "Record",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Record_Box_BoxId",
                table: "Record",
                column: "BoxId",
                principalTable: "Box",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Record_Box_BoxId",
                table: "Record");

            migrationBuilder.AlterColumn<string>(
                name: "BoxId",
                table: "Record",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddForeignKey(
                name: "FK_Record_Box_BoxId",
                table: "Record",
                column: "BoxId",
                principalTable: "Box",
                principalColumn: "Id");
        }
    }
}
