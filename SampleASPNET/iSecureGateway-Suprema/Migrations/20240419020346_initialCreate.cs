using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace iSecureGateway_Suprema.Migrations
{
    /// <inheritdoc />
    public partial class initialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AccessGroup",
                columns: table => new
                {
                    Code = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccessGroup", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "AccessSchedule",
                columns: table => new
                {
                    Code = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccessSchedule", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "Author",
                columns: table => new
                {
                    Code = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Author", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "Post",
                columns: table => new
                {
                    Code = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Post", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "AccessLevel",
                columns: table => new
                {
                    Code = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    AccessScheduleCode = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccessLevel", x => x.Code);
                    table.ForeignKey(
                        name: "FK_AccessLevel_AccessSchedule_AccessScheduleCode",
                        column: x => x.AccessScheduleCode,
                        principalTable: "AccessSchedule",
                        principalColumn: "Code");
                });

            migrationBuilder.CreateTable(
                name: "PostAuthor",
                columns: table => new
                {
                    PostCode = table.Column<string>(type: "text", nullable: false),
                    AuthorCode = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostAuthor", x => new { x.AuthorCode, x.PostCode });
                    table.ForeignKey(
                        name: "FK_PostAuthor_Author_AuthorCode",
                        column: x => x.AuthorCode,
                        principalTable: "Author",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PostAuthor_Post_PostCode",
                        column: x => x.PostCode,
                        principalTable: "Post",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AccessGroupAccessLevels",
                columns: table => new
                {
                    AccessGroupCode = table.Column<string>(type: "text", nullable: false),
                    AccessLevelCode = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccessGroupAccessLevels", x => new { x.AccessGroupCode, x.AccessLevelCode });
                    table.ForeignKey(
                        name: "FK_AccessGroupAccessLevels_AccessGroup_AccessGroupCode",
                        column: x => x.AccessGroupCode,
                        principalTable: "AccessGroup",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AccessGroupAccessLevels_AccessLevel_AccessLevelCode",
                        column: x => x.AccessLevelCode,
                        principalTable: "AccessLevel",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AccessGroupAccessLevels_AccessLevelCode",
                table: "AccessGroupAccessLevels",
                column: "AccessLevelCode");

            migrationBuilder.CreateIndex(
                name: "IX_AccessLevel_AccessScheduleCode",
                table: "AccessLevel",
                column: "AccessScheduleCode");

            migrationBuilder.CreateIndex(
                name: "IX_PostAuthor_PostCode",
                table: "PostAuthor",
                column: "PostCode");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccessGroupAccessLevels");

            migrationBuilder.DropTable(
                name: "PostAuthor");

            migrationBuilder.DropTable(
                name: "AccessGroup");

            migrationBuilder.DropTable(
                name: "AccessLevel");

            migrationBuilder.DropTable(
                name: "Author");

            migrationBuilder.DropTable(
                name: "Post");

            migrationBuilder.DropTable(
                name: "AccessSchedule");
        }
    }
}
