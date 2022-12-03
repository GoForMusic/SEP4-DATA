using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCDataBase.Migrations
{
    public partial class reFixThemMigrations2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Box_Users_UserId1_Username",
                table: "Box");

            migrationBuilder.DropIndex(
                name: "IX_Box_UserId1_Username",
                table: "Box");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "Box");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Box",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<string>(
                name: "Username1",
                table: "Box",
                type: "text",
                nullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Box_Users_UserId_Username1",
                table: "Box");

            migrationBuilder.DropIndex(
                name: "IX_Box_UserId_Username1",
                table: "Box");

            migrationBuilder.DropColumn(
                name: "Username1",
                table: "Box");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Box",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
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
    }
}
