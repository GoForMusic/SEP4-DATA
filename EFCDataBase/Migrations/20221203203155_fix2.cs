using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCDataBase.Migrations
{
    public partial class fix2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Box_Users_UserId_Username1",
                table: "Box");

            migrationBuilder.DropIndex(
                name: "IX_Box_UserId_Username1",
                table: "Box");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Box");

            migrationBuilder.DropColumn(
                name: "Username",
                table: "Box");

            migrationBuilder.RenameColumn(
                name: "Username1",
                table: "Box",
                newName: "OwnedBy");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "OwnedBy",
                table: "Box",
                newName: "Username1");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Box",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Username",
                table: "Box",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Box_UserId_Username1",
                table: "Box",
                columns: new[] { "UserId", "Username1" });

            migrationBuilder.AddForeignKey(
                name: "FK_Box_Users_UserId_Username1",
                table: "Box",
                columns: new[] { "UserId", "Username1" },
                principalTable: "Users",
                principalColumns: new[] { "Id", "Username" });
        }
    }
}
