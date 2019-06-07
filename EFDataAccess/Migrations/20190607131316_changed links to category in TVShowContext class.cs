using Microsoft.EntityFrameworkCore.Migrations;

namespace EFDataAccess.Migrations
{
    public partial class changedlinkstocategoryinTVShowContextclass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Shows_Links_CategoryId",
                table: "Shows");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Links",
                table: "Links");

            migrationBuilder.RenameTable(
                name: "Links",
                newName: "Categories");

            migrationBuilder.RenameIndex(
                name: "IX_Links_CategoryTitle",
                table: "Categories",
                newName: "IX_Categories_CategoryTitle");

            migrationBuilder.AlterColumn<string>(
                name: "CityName",
                table: "Cities",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categories",
                table: "Categories",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Shows_Categories_CategoryId",
                table: "Shows",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Shows_Categories_CategoryId",
                table: "Shows");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Categories",
                table: "Categories");

            migrationBuilder.RenameTable(
                name: "Categories",
                newName: "Links");

            migrationBuilder.RenameIndex(
                name: "IX_Categories_CategoryTitle",
                table: "Links",
                newName: "IX_Links_CategoryTitle");

            migrationBuilder.AlterColumn<string>(
                name: "CityName",
                table: "Cities",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 30);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Links",
                table: "Links",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Shows_Links_CategoryId",
                table: "Shows",
                column: "CategoryId",
                principalTable: "Links",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
