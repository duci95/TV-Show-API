using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EFDataAccess.Migrations
{
    public partial class removedshowvoteandcommentvotechangedlinktocategoryandsomeconfigurationupdates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Shows_Links_LinkId",
                table: "Shows");

            migrationBuilder.DropTable(
                name: "CommentVote");

            migrationBuilder.DropTable(
                name: "Reports");

            migrationBuilder.DropTable(
                name: "ShowVote");

            migrationBuilder.DropTable(
                name: "Sponsors");

            migrationBuilder.DropIndex(
                name: "IX_Links_LinkTitle",
                table: "Links");

            migrationBuilder.DropColumn(
                name: "ShowDislike",
                table: "Shows");

            migrationBuilder.DropColumn(
                name: "ShowLike",
                table: "Shows");

            migrationBuilder.DropColumn(
                name: "LinkTitle",
                table: "Links");

            migrationBuilder.DropColumn(
                name: "Parent",
                table: "Links");

            migrationBuilder.DropColumn(
                name: "CommentDislike",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "CommentLike",
                table: "Comments");

            migrationBuilder.RenameColumn(
                name: "LinkId",
                table: "Shows",
                newName: "CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Shows_LinkId",
                table: "Shows",
                newName: "IX_Shows_CategoryId");

            migrationBuilder.RenameColumn(
                name: "Path",
                table: "Links",
                newName: "CategoryTitle");

            migrationBuilder.RenameIndex(
                name: "IX_Links_Path",
                table: "Links",
                newName: "IX_Links_CategoryTitle");

            migrationBuilder.AddForeignKey(
                name: "FK_Shows_Links_CategoryId",
                table: "Shows",
                column: "CategoryId",
                principalTable: "Links",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Shows_Links_CategoryId",
                table: "Shows");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "Shows",
                newName: "LinkId");

            migrationBuilder.RenameIndex(
                name: "IX_Shows_CategoryId",
                table: "Shows",
                newName: "IX_Shows_LinkId");

            migrationBuilder.RenameColumn(
                name: "CategoryTitle",
                table: "Links",
                newName: "Path");

            migrationBuilder.RenameIndex(
                name: "IX_Links_CategoryTitle",
                table: "Links",
                newName: "IX_Links_Path");

            migrationBuilder.AddColumn<int>(
                name: "ShowDislike",
                table: "Shows",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ShowLike",
                table: "Shows",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "LinkTitle",
                table: "Links",
                maxLength: 30,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Parent",
                table: "Links",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CommentDislike",
                table: "Comments",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CommentLike",
                table: "Comments",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "CommentVote",
                columns: table => new
                {
                    CommentId = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommentVote", x => new { x.CommentId, x.UserId });
                    table.ForeignKey(
                        name: "FK_CommentVote_Comments_CommentId",
                        column: x => x.CommentId,
                        principalTable: "Comments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CommentVote_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reports",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Activity = table.Column<string>(maxLength: 100, nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false, defaultValueSql: "GETDATE()"),
                    Deleted = table.Column<bool>(nullable: false, defaultValue: false),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reports", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reports_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShowVote",
                columns: table => new
                {
                    ShowId = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShowVote", x => new { x.ShowId, x.UserId });
                    table.ForeignKey(
                        name: "FK_ShowVote_Shows_ShowId",
                        column: x => x.ShowId,
                        principalTable: "Shows",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShowVote_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sponsors",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedAt = table.Column<DateTime>(nullable: false, defaultValueSql: "GETDATE()"),
                    Deleted = table.Column<bool>(nullable: false, defaultValue: false),
                    SponsorPicturePath = table.Column<string>(maxLength: 120, nullable: false),
                    SponsorURL = table.Column<string>(maxLength: 70, nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sponsors", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Links_LinkTitle",
                table: "Links",
                column: "LinkTitle",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CommentVote_UserId",
                table: "CommentVote",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Reports_UserId",
                table: "Reports",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ShowVote_UserId",
                table: "ShowVote",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Sponsors_SponsorURL",
                table: "Sponsors",
                column: "SponsorURL",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Shows_Links_LinkId",
                table: "Shows",
                column: "LinkId",
                principalTable: "Links",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
