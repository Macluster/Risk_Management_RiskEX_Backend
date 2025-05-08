using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Risk_Management_RiskEX_Backend.Migrations
{
    /// <inheritdoc />
    public partial class ProjectIdIssue : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Users_UserId",
                table: "Projects");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Projects_projectId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_projectId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Projects_UserId",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "ProjectId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "projectId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Projects");

            migrationBuilder.CreateTable(
                name: "ProjectUser",
                columns: table => new
                {
                    ProjectsId = table.Column<int>(type: "integer", nullable: false),
                    UsersId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectUser", x => new { x.ProjectsId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_ProjectUser_Projects_ProjectsId",
                        column: x => x.ProjectsId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectUser_Users_UsersId",
                        column: x => x.UsersId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AssessmentsBasis",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 9, 16, 44, 10, 519, DateTimeKind.Utc).AddTicks(3511), new DateTime(2025, 1, 9, 16, 44, 10, 519, DateTimeKind.Utc).AddTicks(3512) });

            migrationBuilder.UpdateData(
                table: "AssessmentsBasis",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 9, 16, 44, 10, 519, DateTimeKind.Utc).AddTicks(3514), new DateTime(2025, 1, 9, 16, 44, 10, 519, DateTimeKind.Utc).AddTicks(3515) });

            migrationBuilder.UpdateData(
                table: "AssessmentsBasis",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 9, 16, 44, 10, 519, DateTimeKind.Utc).AddTicks(3517), new DateTime(2025, 1, 9, 16, 44, 10, 519, DateTimeKind.Utc).AddTicks(3518) });

            migrationBuilder.UpdateData(
                table: "AssessmentsBasis",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 9, 16, 44, 10, 519, DateTimeKind.Utc).AddTicks(3519), new DateTime(2025, 1, 9, 16, 44, 10, 519, DateTimeKind.Utc).AddTicks(3520) });

            migrationBuilder.UpdateData(
                table: "AssessmentsMatrixImpact",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 9, 16, 44, 10, 519, DateTimeKind.Utc).AddTicks(3587), new DateTime(2025, 1, 9, 16, 44, 10, 519, DateTimeKind.Utc).AddTicks(3588) });

            migrationBuilder.UpdateData(
                table: "AssessmentsMatrixImpact",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 9, 16, 44, 10, 519, DateTimeKind.Utc).AddTicks(3590), new DateTime(2025, 1, 9, 16, 44, 10, 519, DateTimeKind.Utc).AddTicks(3591) });

            migrationBuilder.UpdateData(
                table: "AssessmentsMatrixImpact",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 9, 16, 44, 10, 519, DateTimeKind.Utc).AddTicks(3593), new DateTime(2025, 1, 9, 16, 44, 10, 519, DateTimeKind.Utc).AddTicks(3593) });

            migrationBuilder.UpdateData(
                table: "AssessmentsMatrixImpact",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 9, 16, 44, 10, 519, DateTimeKind.Utc).AddTicks(3595), new DateTime(2025, 1, 9, 16, 44, 10, 519, DateTimeKind.Utc).AddTicks(3596) });

            migrationBuilder.UpdateData(
                table: "AssessmentsMatrixLikelihood",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 9, 16, 44, 10, 519, DateTimeKind.Utc).AddTicks(3622), new DateTime(2025, 1, 9, 16, 44, 10, 519, DateTimeKind.Utc).AddTicks(3623) });

            migrationBuilder.UpdateData(
                table: "AssessmentsMatrixLikelihood",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 9, 16, 44, 10, 519, DateTimeKind.Utc).AddTicks(3625), new DateTime(2025, 1, 9, 16, 44, 10, 519, DateTimeKind.Utc).AddTicks(3626) });

            migrationBuilder.UpdateData(
                table: "AssessmentsMatrixLikelihood",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 9, 16, 44, 10, 519, DateTimeKind.Utc).AddTicks(3628), new DateTime(2025, 1, 9, 16, 44, 10, 519, DateTimeKind.Utc).AddTicks(3629) });

            migrationBuilder.UpdateData(
                table: "AssessmentsMatrixLikelihood",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 9, 16, 44, 10, 519, DateTimeKind.Utc).AddTicks(3631), new DateTime(2025, 1, 9, 16, 44, 10, 519, DateTimeKind.Utc).AddTicks(3631) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 9, 16, 44, 10, 519, DateTimeKind.Utc).AddTicks(3144), new DateTime(2025, 1, 9, 16, 44, 10, 519, DateTimeKind.Utc).AddTicks(3148) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 9, 16, 44, 10, 519, DateTimeKind.Utc).AddTicks(3150), new DateTime(2025, 1, 9, 16, 44, 10, 519, DateTimeKind.Utc).AddTicks(3151) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 9, 16, 44, 10, 519, DateTimeKind.Utc).AddTicks(3153), new DateTime(2025, 1, 9, 16, 44, 10, 519, DateTimeKind.Utc).AddTicks(3154) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 9, 16, 44, 10, 519, DateTimeKind.Utc).AddTicks(3155), new DateTime(2025, 1, 9, 16, 44, 10, 519, DateTimeKind.Utc).AddTicks(3156) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 9, 16, 44, 10, 519, DateTimeKind.Utc).AddTicks(3158), new DateTime(2025, 1, 9, 16, 44, 10, 519, DateTimeKind.Utc).AddTicks(3158) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 9, 16, 44, 10, 519, DateTimeKind.Utc).AddTicks(3160), new DateTime(2025, 1, 9, 16, 44, 10, 519, DateTimeKind.Utc).AddTicks(3160) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 9, 16, 44, 10, 519, DateTimeKind.Utc).AddTicks(3162), new DateTime(2025, 1, 9, 16, 44, 10, 519, DateTimeKind.Utc).AddTicks(3163) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 9, 16, 44, 10, 519, DateTimeKind.Utc).AddTicks(3164), new DateTime(2025, 1, 9, 16, 44, 10, 519, DateTimeKind.Utc).AddTicks(3165) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 9, 16, 44, 10, 519, DateTimeKind.Utc).AddTicks(3167), new DateTime(2025, 1, 9, 16, 44, 10, 519, DateTimeKind.Utc).AddTicks(3167) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 9, 16, 44, 10, 519, DateTimeKind.Utc).AddTicks(3169), new DateTime(2025, 1, 9, 16, 44, 10, 519, DateTimeKind.Utc).AddTicks(3170) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 9, 16, 44, 10, 519, DateTimeKind.Utc).AddTicks(3171), new DateTime(2025, 1, 9, 16, 44, 10, 519, DateTimeKind.Utc).AddTicks(3172) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 9, 16, 44, 10, 519, DateTimeKind.Utc).AddTicks(3173), new DateTime(2025, 1, 9, 16, 44, 10, 519, DateTimeKind.Utc).AddTicks(3174) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 9, 16, 44, 10, 519, DateTimeKind.Utc).AddTicks(3182), new DateTime(2025, 1, 9, 16, 44, 10, 519, DateTimeKind.Utc).AddTicks(3182) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 9, 16, 44, 10, 519, DateTimeKind.Utc).AddTicks(3184), new DateTime(2025, 1, 9, 16, 44, 10, 519, DateTimeKind.Utc).AddTicks(3185) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 9, 16, 44, 10, 519, DateTimeKind.Utc).AddTicks(3186), new DateTime(2025, 1, 9, 16, 44, 10, 519, DateTimeKind.Utc).AddTicks(3187) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 9, 16, 44, 10, 519, DateTimeKind.Utc).AddTicks(3188), new DateTime(2025, 1, 9, 16, 44, 10, 519, DateTimeKind.Utc).AddTicks(3189) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 9, 16, 44, 10, 519, DateTimeKind.Utc).AddTicks(3190), new DateTime(2025, 1, 9, 16, 44, 10, 519, DateTimeKind.Utc).AddTicks(3191) });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 9, 16, 44, 10, 519, DateTimeKind.Utc).AddTicks(3555), new DateTime(2025, 1, 9, 16, 44, 10, 519, DateTimeKind.Utc).AddTicks(3556) });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 9, 16, 44, 10, 519, DateTimeKind.Utc).AddTicks(3559), new DateTime(2025, 1, 9, 16, 44, 10, 519, DateTimeKind.Utc).AddTicks(3559) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 9, 16, 44, 10, 519, DateTimeKind.Utc).AddTicks(3463), new DateTime(2025, 1, 9, 16, 44, 10, 519, DateTimeKind.Utc).AddTicks(3464) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 9, 16, 44, 10, 519, DateTimeKind.Utc).AddTicks(3467), new DateTime(2025, 1, 9, 16, 44, 10, 519, DateTimeKind.Utc).AddTicks(3468) });

            migrationBuilder.CreateIndex(
                name: "IX_ProjectUser_UsersId",
                table: "ProjectUser",
                column: "UsersId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProjectUser");

            migrationBuilder.AddColumn<int>(
                name: "ProjectId",
                table: "Users",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "projectId",
                table: "Users",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Projects",
                type: "integer",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AssessmentsBasis",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 9, 13, 16, 47, 664, DateTimeKind.Utc).AddTicks(2546), new DateTime(2025, 1, 9, 13, 16, 47, 664, DateTimeKind.Utc).AddTicks(2547) });

            migrationBuilder.UpdateData(
                table: "AssessmentsBasis",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 9, 13, 16, 47, 664, DateTimeKind.Utc).AddTicks(2549), new DateTime(2025, 1, 9, 13, 16, 47, 664, DateTimeKind.Utc).AddTicks(2550) });

            migrationBuilder.UpdateData(
                table: "AssessmentsBasis",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 9, 13, 16, 47, 664, DateTimeKind.Utc).AddTicks(2552), new DateTime(2025, 1, 9, 13, 16, 47, 664, DateTimeKind.Utc).AddTicks(2552) });

            migrationBuilder.UpdateData(
                table: "AssessmentsBasis",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 9, 13, 16, 47, 664, DateTimeKind.Utc).AddTicks(2554), new DateTime(2025, 1, 9, 13, 16, 47, 664, DateTimeKind.Utc).AddTicks(2555) });

            migrationBuilder.UpdateData(
                table: "AssessmentsMatrixImpact",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 9, 13, 16, 47, 664, DateTimeKind.Utc).AddTicks(2623), new DateTime(2025, 1, 9, 13, 16, 47, 664, DateTimeKind.Utc).AddTicks(2624) });

            migrationBuilder.UpdateData(
                table: "AssessmentsMatrixImpact",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 9, 13, 16, 47, 664, DateTimeKind.Utc).AddTicks(2626), new DateTime(2025, 1, 9, 13, 16, 47, 664, DateTimeKind.Utc).AddTicks(2627) });

            migrationBuilder.UpdateData(
                table: "AssessmentsMatrixImpact",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 9, 13, 16, 47, 664, DateTimeKind.Utc).AddTicks(2629), new DateTime(2025, 1, 9, 13, 16, 47, 664, DateTimeKind.Utc).AddTicks(2629) });

            migrationBuilder.UpdateData(
                table: "AssessmentsMatrixImpact",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 9, 13, 16, 47, 664, DateTimeKind.Utc).AddTicks(2631), new DateTime(2025, 1, 9, 13, 16, 47, 664, DateTimeKind.Utc).AddTicks(2632) });

            migrationBuilder.UpdateData(
                table: "AssessmentsMatrixLikelihood",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 9, 13, 16, 47, 664, DateTimeKind.Utc).AddTicks(2663), new DateTime(2025, 1, 9, 13, 16, 47, 664, DateTimeKind.Utc).AddTicks(2664) });

            migrationBuilder.UpdateData(
                table: "AssessmentsMatrixLikelihood",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 9, 13, 16, 47, 664, DateTimeKind.Utc).AddTicks(2666), new DateTime(2025, 1, 9, 13, 16, 47, 664, DateTimeKind.Utc).AddTicks(2667) });

            migrationBuilder.UpdateData(
                table: "AssessmentsMatrixLikelihood",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 9, 13, 16, 47, 664, DateTimeKind.Utc).AddTicks(2669), new DateTime(2025, 1, 9, 13, 16, 47, 664, DateTimeKind.Utc).AddTicks(2670) });

            migrationBuilder.UpdateData(
                table: "AssessmentsMatrixLikelihood",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 9, 13, 16, 47, 664, DateTimeKind.Utc).AddTicks(2672), new DateTime(2025, 1, 9, 13, 16, 47, 664, DateTimeKind.Utc).AddTicks(2672) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 9, 13, 16, 47, 664, DateTimeKind.Utc).AddTicks(2044), new DateTime(2025, 1, 9, 13, 16, 47, 664, DateTimeKind.Utc).AddTicks(2047) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 9, 13, 16, 47, 664, DateTimeKind.Utc).AddTicks(2050), new DateTime(2025, 1, 9, 13, 16, 47, 664, DateTimeKind.Utc).AddTicks(2051) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 9, 13, 16, 47, 664, DateTimeKind.Utc).AddTicks(2053), new DateTime(2025, 1, 9, 13, 16, 47, 664, DateTimeKind.Utc).AddTicks(2054) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 9, 13, 16, 47, 664, DateTimeKind.Utc).AddTicks(2055), new DateTime(2025, 1, 9, 13, 16, 47, 664, DateTimeKind.Utc).AddTicks(2056) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 9, 13, 16, 47, 664, DateTimeKind.Utc).AddTicks(2058), new DateTime(2025, 1, 9, 13, 16, 47, 664, DateTimeKind.Utc).AddTicks(2059) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 9, 13, 16, 47, 664, DateTimeKind.Utc).AddTicks(2060), new DateTime(2025, 1, 9, 13, 16, 47, 664, DateTimeKind.Utc).AddTicks(2061) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 9, 13, 16, 47, 664, DateTimeKind.Utc).AddTicks(2062), new DateTime(2025, 1, 9, 13, 16, 47, 664, DateTimeKind.Utc).AddTicks(2063) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 9, 13, 16, 47, 664, DateTimeKind.Utc).AddTicks(2065), new DateTime(2025, 1, 9, 13, 16, 47, 664, DateTimeKind.Utc).AddTicks(2066) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 9, 13, 16, 47, 664, DateTimeKind.Utc).AddTicks(2067), new DateTime(2025, 1, 9, 13, 16, 47, 664, DateTimeKind.Utc).AddTicks(2068) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 9, 13, 16, 47, 664, DateTimeKind.Utc).AddTicks(2070), new DateTime(2025, 1, 9, 13, 16, 47, 664, DateTimeKind.Utc).AddTicks(2071) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 9, 13, 16, 47, 664, DateTimeKind.Utc).AddTicks(2073), new DateTime(2025, 1, 9, 13, 16, 47, 664, DateTimeKind.Utc).AddTicks(2074) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 9, 13, 16, 47, 664, DateTimeKind.Utc).AddTicks(2075), new DateTime(2025, 1, 9, 13, 16, 47, 664, DateTimeKind.Utc).AddTicks(2076) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 9, 13, 16, 47, 664, DateTimeKind.Utc).AddTicks(2168), new DateTime(2025, 1, 9, 13, 16, 47, 664, DateTimeKind.Utc).AddTicks(2169) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 9, 13, 16, 47, 664, DateTimeKind.Utc).AddTicks(2171), new DateTime(2025, 1, 9, 13, 16, 47, 664, DateTimeKind.Utc).AddTicks(2171) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 9, 13, 16, 47, 664, DateTimeKind.Utc).AddTicks(2173), new DateTime(2025, 1, 9, 13, 16, 47, 664, DateTimeKind.Utc).AddTicks(2174) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 9, 13, 16, 47, 664, DateTimeKind.Utc).AddTicks(2175), new DateTime(2025, 1, 9, 13, 16, 47, 664, DateTimeKind.Utc).AddTicks(2176) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 9, 13, 16, 47, 664, DateTimeKind.Utc).AddTicks(2177), new DateTime(2025, 1, 9, 13, 16, 47, 664, DateTimeKind.Utc).AddTicks(2178) });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 1, 9, 13, 16, 47, 664, DateTimeKind.Utc).AddTicks(2593), new DateTime(2025, 1, 9, 13, 16, 47, 664, DateTimeKind.Utc).AddTicks(2593), 1 });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2025, 1, 9, 13, 16, 47, 664, DateTimeKind.Utc).AddTicks(2597), new DateTime(2025, 1, 9, 13, 16, 47, 664, DateTimeKind.Utc).AddTicks(2598), 2 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "ProjectId", "UpdatedAt", "projectId" },
                values: new object[] { new DateTime(2025, 1, 9, 13, 16, 47, 664, DateTimeKind.Utc).AddTicks(2508), null, new DateTime(2025, 1, 9, 13, 16, 47, 664, DateTimeKind.Utc).AddTicks(2509), null });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "ProjectId", "UpdatedAt", "projectId" },
                values: new object[] { new DateTime(2025, 1, 9, 13, 16, 47, 664, DateTimeKind.Utc).AddTicks(2513), null, new DateTime(2025, 1, 9, 13, 16, 47, 664, DateTimeKind.Utc).AddTicks(2513), null });

            migrationBuilder.CreateIndex(
                name: "IX_Users_projectId",
                table: "Users",
                column: "projectId");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_UserId",
                table: "Projects",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Users_UserId",
                table: "Projects",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Projects_projectId",
                table: "Users",
                column: "projectId",
                principalTable: "Projects",
                principalColumn: "Id");
        }
    }
}
