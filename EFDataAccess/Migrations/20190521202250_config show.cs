using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EFDataAccess.Migrations
{
    public partial class configshow : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ShowTitle",
                table: "Shows",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ShowText",
                table: "Shows",
                maxLength: 800,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ShowPicturePath",
                table: "Shows",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ShowLike",
                table: "Shows",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "ShowDislike",
                table: "Shows",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<bool>(
                name: "Deleted",
                table: "Shows",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Shows",
                nullable: false,
                defaultValueSql: "GETDATE()",
                oldClrType: typeof(DateTime));

            migrationBuilder.CreateIndex(
                name: "IX_Shows_ShowPicturePath",
                table: "Shows",
                column: "ShowPicturePath",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Shows_ShowTitle",
                table: "Shows",
                column: "ShowTitle",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Shows_ShowPicturePath",
                table: "Shows");

            migrationBuilder.DropIndex(
                name: "IX_Shows_ShowTitle",
                table: "Shows");

            migrationBuilder.AlterColumn<string>(
                name: "ShowTitle",
                table: "Shows",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "ShowText",
                table: "Shows",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 800);

            migrationBuilder.AlterColumn<string>(
                name: "ShowPicturePath",
                table: "Shows",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 150);

            migrationBuilder.AlterColumn<int>(
                name: "ShowLike",
                table: "Shows",
                nullable: false,
                oldClrType: typeof(int),
                oldDefaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "ShowDislike",
                table: "Shows",
                nullable: false,
                oldClrType: typeof(int),
                oldDefaultValue: 0);

            migrationBuilder.AlterColumn<bool>(
                name: "Deleted",
                table: "Shows",
                nullable: false,
                oldClrType: typeof(bool),
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Shows",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldDefaultValueSql: "GETDATE()");
        }
    }
}
