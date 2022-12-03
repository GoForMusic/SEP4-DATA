using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCDataBase.Migrations
{
    public partial class reFixThemMigrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "boxId",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "locked",
                table: "Box",
                newName: "Locked");

            migrationBuilder.RenameColumn(
                name: "light",
                table: "Box",
                newName: "Light");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Box",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "Box",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Username",
                table: "Box",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Box_UserId1_Username",
                table: "Box",
                columns: new[] { "UserId1", "Username" });

            migrationBuilder.AddForeignKey(
                name: "FK_Box_Users_UserId1_Username",
                table: "Box",
                columns: new[] { "UserId1", "Username" },
                principalTable: "Users",
                principalColumns: new[] { "Id", "Username" },
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Box_Users_UserId1_Username",
                table: "Box");

            migrationBuilder.DropIndex(
                name: "IX_Box_UserId1_Username",
                table: "Box");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Box");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "Box");

            migrationBuilder.DropColumn(
                name: "Username",
                table: "Box");

            migrationBuilder.RenameColumn(
                name: "Locked",
                table: "Box",
                newName: "locked");

            migrationBuilder.RenameColumn(
                name: "Light",
                table: "Box",
                newName: "light");

            migrationBuilder.AddColumn<string>(
                name: "boxId",
                table: "Users",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
