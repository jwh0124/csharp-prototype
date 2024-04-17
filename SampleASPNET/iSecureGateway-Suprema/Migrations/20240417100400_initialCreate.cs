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
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
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
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccessSchedule", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "AccessLevel",
                columns: table => new
                {
                    Code = table.Column<string>(type: "text", nullable: false),
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
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
                name: "AccessGroupAccessLevel",
                columns: table => new
                {
                    AccessGroupsCode = table.Column<string>(type: "text", nullable: false),
                    AccessLevelsCode = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccessGroupAccessLevel", x => new { x.AccessGroupsCode, x.AccessLevelsCode });
                    table.ForeignKey(
                        name: "FK_AccessGroupAccessLevel_AccessGroup_AccessGroupsCode",
                        column: x => x.AccessGroupsCode,
                        principalTable: "AccessGroup",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AccessGroupAccessLevel_AccessLevel_AccessLevelsCode",
                        column: x => x.AccessLevelsCode,
                        principalTable: "AccessLevel",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AccessGroupAccessLevel_AccessLevelsCode",
                table: "AccessGroupAccessLevel",
                column: "AccessLevelsCode");

            migrationBuilder.CreateIndex(
                name: "IX_AccessLevel_AccessScheduleCode",
                table: "AccessLevel",
                column: "AccessScheduleCode");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccessGroupAccessLevel");

            migrationBuilder.DropTable(
                name: "AccessGroup");

            migrationBuilder.DropTable(
                name: "AccessLevel");

            migrationBuilder.DropTable(
                name: "AccessSchedule");
        }
    }
}
