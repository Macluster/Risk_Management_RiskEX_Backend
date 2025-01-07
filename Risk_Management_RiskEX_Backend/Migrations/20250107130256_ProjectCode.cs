using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Risk_Management_RiskEX_Backend.Migrations
{
    /// <inheritdoc />
    public partial class ProjectCode : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Projects_ProjectId",
                table: "Users");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.RenameColumn(
                name: "ProjectId",
                table: "Users",
                newName: "projectId");

            migrationBuilder.RenameIndex(
                name: "IX_Users_ProjectId",
                table: "Users",
                newName: "IX_Users_projectId");

            migrationBuilder.AddColumn<string>(
                name: "ProjectCode",
                table: "Projects",
                type: "text",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AssessmentsBasis",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 7, 13, 2, 55, 833, DateTimeKind.Utc).AddTicks(4132), new DateTime(2025, 1, 7, 13, 2, 55, 833, DateTimeKind.Utc).AddTicks(4133) });

            migrationBuilder.UpdateData(
                table: "AssessmentsBasis",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 7, 13, 2, 55, 833, DateTimeKind.Utc).AddTicks(4134), new DateTime(2025, 1, 7, 13, 2, 55, 833, DateTimeKind.Utc).AddTicks(4134) });

            migrationBuilder.UpdateData(
                table: "AssessmentsBasis",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Basis", "CreatedAt", "UpdatedAt" },
                values: new object[] { "Availability", new DateTime(2025, 1, 7, 13, 2, 55, 833, DateTimeKind.Utc).AddTicks(4135), new DateTime(2025, 1, 7, 13, 2, 55, 833, DateTimeKind.Utc).AddTicks(4136) });

            migrationBuilder.UpdateData(
                table: "AssessmentsBasis",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Basis", "CreatedAt", "UpdatedAt" },
                values: new object[] { "Privacy", new DateTime(2025, 1, 7, 13, 2, 55, 833, DateTimeKind.Utc).AddTicks(4137), new DateTime(2025, 1, 7, 13, 2, 55, 833, DateTimeKind.Utc).AddTicks(4137) });

            migrationBuilder.UpdateData(
                table: "AssessmentsMatrixImpact",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 7, 13, 2, 55, 833, DateTimeKind.Utc).AddTicks(4182), new DateTime(2025, 1, 7, 13, 2, 55, 833, DateTimeKind.Utc).AddTicks(4183) });

            migrationBuilder.UpdateData(
                table: "AssessmentsMatrixImpact",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 7, 13, 2, 55, 833, DateTimeKind.Utc).AddTicks(4184), new DateTime(2025, 1, 7, 13, 2, 55, 833, DateTimeKind.Utc).AddTicks(4185) });

            migrationBuilder.UpdateData(
                table: "AssessmentsMatrixImpact",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 7, 13, 2, 55, 833, DateTimeKind.Utc).AddTicks(4186), new DateTime(2025, 1, 7, 13, 2, 55, 833, DateTimeKind.Utc).AddTicks(4187) });

            migrationBuilder.UpdateData(
                table: "AssessmentsMatrixImpact",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 7, 13, 2, 55, 833, DateTimeKind.Utc).AddTicks(4188), new DateTime(2025, 1, 7, 13, 2, 55, 833, DateTimeKind.Utc).AddTicks(4188) });

            migrationBuilder.UpdateData(
                table: "AssessmentsMatrixLikelihood",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 7, 13, 2, 55, 833, DateTimeKind.Utc).AddTicks(4209), new DateTime(2025, 1, 7, 13, 2, 55, 833, DateTimeKind.Utc).AddTicks(4209) });

            migrationBuilder.UpdateData(
                table: "AssessmentsMatrixLikelihood",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 7, 13, 2, 55, 833, DateTimeKind.Utc).AddTicks(4211), new DateTime(2025, 1, 7, 13, 2, 55, 833, DateTimeKind.Utc).AddTicks(4211) });

            migrationBuilder.UpdateData(
                table: "AssessmentsMatrixLikelihood",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 7, 13, 2, 55, 833, DateTimeKind.Utc).AddTicks(4213), new DateTime(2025, 1, 7, 13, 2, 55, 833, DateTimeKind.Utc).AddTicks(4213) });

            migrationBuilder.UpdateData(
                table: "AssessmentsMatrixLikelihood",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 7, 13, 2, 55, 833, DateTimeKind.Utc).AddTicks(4214), new DateTime(2025, 1, 7, 13, 2, 55, 833, DateTimeKind.Utc).AddTicks(4215) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 7, 13, 2, 55, 833, DateTimeKind.Utc).AddTicks(3783), new DateTime(2025, 1, 7, 13, 2, 55, 833, DateTimeKind.Utc).AddTicks(3787) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 7, 13, 2, 55, 833, DateTimeKind.Utc).AddTicks(3840), new DateTime(2025, 1, 7, 13, 2, 55, 833, DateTimeKind.Utc).AddTicks(3841) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 7, 13, 2, 55, 833, DateTimeKind.Utc).AddTicks(3842), new DateTime(2025, 1, 7, 13, 2, 55, 833, DateTimeKind.Utc).AddTicks(3842) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 7, 13, 2, 55, 833, DateTimeKind.Utc).AddTicks(3843), new DateTime(2025, 1, 7, 13, 2, 55, 833, DateTimeKind.Utc).AddTicks(3844) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 7, 13, 2, 55, 833, DateTimeKind.Utc).AddTicks(3845), new DateTime(2025, 1, 7, 13, 2, 55, 833, DateTimeKind.Utc).AddTicks(3846) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 7, 13, 2, 55, 833, DateTimeKind.Utc).AddTicks(3847), new DateTime(2025, 1, 7, 13, 2, 55, 833, DateTimeKind.Utc).AddTicks(3847) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 7, 13, 2, 55, 833, DateTimeKind.Utc).AddTicks(3848), new DateTime(2025, 1, 7, 13, 2, 55, 833, DateTimeKind.Utc).AddTicks(3849) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 7, 13, 2, 55, 833, DateTimeKind.Utc).AddTicks(3850), new DateTime(2025, 1, 7, 13, 2, 55, 833, DateTimeKind.Utc).AddTicks(3850) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 7, 13, 2, 55, 833, DateTimeKind.Utc).AddTicks(3851), new DateTime(2025, 1, 7, 13, 2, 55, 833, DateTimeKind.Utc).AddTicks(3852) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 7, 13, 2, 55, 833, DateTimeKind.Utc).AddTicks(3853), new DateTime(2025, 1, 7, 13, 2, 55, 833, DateTimeKind.Utc).AddTicks(3853) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 7, 13, 2, 55, 833, DateTimeKind.Utc).AddTicks(3854), new DateTime(2025, 1, 7, 13, 2, 55, 833, DateTimeKind.Utc).AddTicks(3855) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 7, 13, 2, 55, 833, DateTimeKind.Utc).AddTicks(3856), new DateTime(2025, 1, 7, 13, 2, 55, 833, DateTimeKind.Utc).AddTicks(3856) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 7, 13, 2, 55, 833, DateTimeKind.Utc).AddTicks(3857), new DateTime(2025, 1, 7, 13, 2, 55, 833, DateTimeKind.Utc).AddTicks(3858) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 7, 13, 2, 55, 833, DateTimeKind.Utc).AddTicks(3859), new DateTime(2025, 1, 7, 13, 2, 55, 833, DateTimeKind.Utc).AddTicks(3859) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 7, 13, 2, 55, 833, DateTimeKind.Utc).AddTicks(3860), new DateTime(2025, 1, 7, 13, 2, 55, 833, DateTimeKind.Utc).AddTicks(3861) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 7, 13, 2, 55, 833, DateTimeKind.Utc).AddTicks(3862), new DateTime(2025, 1, 7, 13, 2, 55, 833, DateTimeKind.Utc).AddTicks(3862) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 7, 13, 2, 55, 833, DateTimeKind.Utc).AddTicks(3863), new DateTime(2025, 1, 7, 13, 2, 55, 833, DateTimeKind.Utc).AddTicks(3864) });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "ProjectCode", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 7, 13, 2, 55, 833, DateTimeKind.Utc).AddTicks(4163), null, new DateTime(2025, 1, 7, 13, 2, 55, 833, DateTimeKind.Utc).AddTicks(4163) });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "ProjectCode", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 7, 13, 2, 55, 833, DateTimeKind.Utc).AddTicks(4165), null, new DateTime(2025, 1, 7, 13, 2, 55, 833, DateTimeKind.Utc).AddTicks(4166) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 7, 13, 2, 55, 833, DateTimeKind.Utc).AddTicks(4094), new DateTime(2025, 1, 7, 13, 2, 55, 833, DateTimeKind.Utc).AddTicks(4101) });

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Projects_projectId",
                table: "Users",
                column: "projectId",
                principalTable: "Projects",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Projects_projectId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ProjectCode",
                table: "Projects");

            migrationBuilder.RenameColumn(
                name: "projectId",
                table: "Users",
                newName: "ProjectId");

            migrationBuilder.RenameIndex(
                name: "IX_Users_projectId",
                table: "Users",
                newName: "IX_Users_ProjectId");

            migrationBuilder.UpdateData(
                table: "AssessmentsBasis",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 6, 4, 26, 4, 375, DateTimeKind.Utc).AddTicks(8542), new DateTime(2025, 1, 6, 4, 26, 4, 375, DateTimeKind.Utc).AddTicks(8543) });

            migrationBuilder.UpdateData(
                table: "AssessmentsBasis",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 6, 4, 26, 4, 375, DateTimeKind.Utc).AddTicks(8545), new DateTime(2025, 1, 6, 4, 26, 4, 375, DateTimeKind.Utc).AddTicks(8545) });

            migrationBuilder.UpdateData(
                table: "AssessmentsBasis",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Basis", "CreatedAt", "UpdatedAt" },
                values: new object[] { "Privacy", new DateTime(2025, 1, 6, 4, 26, 4, 375, DateTimeKind.Utc).AddTicks(8547), new DateTime(2025, 1, 6, 4, 26, 4, 375, DateTimeKind.Utc).AddTicks(8547) });

            migrationBuilder.UpdateData(
                table: "AssessmentsBasis",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Basis", "CreatedAt", "UpdatedAt" },
                values: new object[] { "Quality", new DateTime(2025, 1, 6, 4, 26, 4, 375, DateTimeKind.Utc).AddTicks(8548), new DateTime(2025, 1, 6, 4, 26, 4, 375, DateTimeKind.Utc).AddTicks(8549) });

            migrationBuilder.UpdateData(
                table: "AssessmentsMatrixImpact",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 6, 4, 26, 4, 375, DateTimeKind.Utc).AddTicks(8597), new DateTime(2025, 1, 6, 4, 26, 4, 375, DateTimeKind.Utc).AddTicks(8598) });

            migrationBuilder.UpdateData(
                table: "AssessmentsMatrixImpact",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 6, 4, 26, 4, 375, DateTimeKind.Utc).AddTicks(8600), new DateTime(2025, 1, 6, 4, 26, 4, 375, DateTimeKind.Utc).AddTicks(8600) });

            migrationBuilder.UpdateData(
                table: "AssessmentsMatrixImpact",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 6, 4, 26, 4, 375, DateTimeKind.Utc).AddTicks(8602), new DateTime(2025, 1, 6, 4, 26, 4, 375, DateTimeKind.Utc).AddTicks(8603) });

            migrationBuilder.UpdateData(
                table: "AssessmentsMatrixImpact",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 6, 4, 26, 4, 375, DateTimeKind.Utc).AddTicks(8645), new DateTime(2025, 1, 6, 4, 26, 4, 375, DateTimeKind.Utc).AddTicks(8646) });

            migrationBuilder.UpdateData(
                table: "AssessmentsMatrixLikelihood",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 6, 4, 26, 4, 375, DateTimeKind.Utc).AddTicks(8669), new DateTime(2025, 1, 6, 4, 26, 4, 375, DateTimeKind.Utc).AddTicks(8670) });

            migrationBuilder.UpdateData(
                table: "AssessmentsMatrixLikelihood",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 6, 4, 26, 4, 375, DateTimeKind.Utc).AddTicks(8672), new DateTime(2025, 1, 6, 4, 26, 4, 375, DateTimeKind.Utc).AddTicks(8673) });

            migrationBuilder.UpdateData(
                table: "AssessmentsMatrixLikelihood",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 6, 4, 26, 4, 375, DateTimeKind.Utc).AddTicks(8674), new DateTime(2025, 1, 6, 4, 26, 4, 375, DateTimeKind.Utc).AddTicks(8675) });

            migrationBuilder.UpdateData(
                table: "AssessmentsMatrixLikelihood",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 6, 4, 26, 4, 375, DateTimeKind.Utc).AddTicks(8676), new DateTime(2025, 1, 6, 4, 26, 4, 375, DateTimeKind.Utc).AddTicks(8677) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 6, 4, 26, 4, 375, DateTimeKind.Utc).AddTicks(8223), new DateTime(2025, 1, 6, 4, 26, 4, 375, DateTimeKind.Utc).AddTicks(8234) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 6, 4, 26, 4, 375, DateTimeKind.Utc).AddTicks(8236), new DateTime(2025, 1, 6, 4, 26, 4, 375, DateTimeKind.Utc).AddTicks(8237) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 6, 4, 26, 4, 375, DateTimeKind.Utc).AddTicks(8238), new DateTime(2025, 1, 6, 4, 26, 4, 375, DateTimeKind.Utc).AddTicks(8239) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 6, 4, 26, 4, 375, DateTimeKind.Utc).AddTicks(8240), new DateTime(2025, 1, 6, 4, 26, 4, 375, DateTimeKind.Utc).AddTicks(8241) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 6, 4, 26, 4, 375, DateTimeKind.Utc).AddTicks(8242), new DateTime(2025, 1, 6, 4, 26, 4, 375, DateTimeKind.Utc).AddTicks(8243) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 6, 4, 26, 4, 375, DateTimeKind.Utc).AddTicks(8244), new DateTime(2025, 1, 6, 4, 26, 4, 375, DateTimeKind.Utc).AddTicks(8245) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 6, 4, 26, 4, 375, DateTimeKind.Utc).AddTicks(8246), new DateTime(2025, 1, 6, 4, 26, 4, 375, DateTimeKind.Utc).AddTicks(8247) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 6, 4, 26, 4, 375, DateTimeKind.Utc).AddTicks(8248), new DateTime(2025, 1, 6, 4, 26, 4, 375, DateTimeKind.Utc).AddTicks(8249) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 6, 4, 26, 4, 375, DateTimeKind.Utc).AddTicks(8250), new DateTime(2025, 1, 6, 4, 26, 4, 375, DateTimeKind.Utc).AddTicks(8251) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 6, 4, 26, 4, 375, DateTimeKind.Utc).AddTicks(8252), new DateTime(2025, 1, 6, 4, 26, 4, 375, DateTimeKind.Utc).AddTicks(8253) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 6, 4, 26, 4, 375, DateTimeKind.Utc).AddTicks(8254), new DateTime(2025, 1, 6, 4, 26, 4, 375, DateTimeKind.Utc).AddTicks(8255) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 6, 4, 26, 4, 375, DateTimeKind.Utc).AddTicks(8256), new DateTime(2025, 1, 6, 4, 26, 4, 375, DateTimeKind.Utc).AddTicks(8257) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 6, 4, 26, 4, 375, DateTimeKind.Utc).AddTicks(8258), new DateTime(2025, 1, 6, 4, 26, 4, 375, DateTimeKind.Utc).AddTicks(8259) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 6, 4, 26, 4, 375, DateTimeKind.Utc).AddTicks(8260), new DateTime(2025, 1, 6, 4, 26, 4, 375, DateTimeKind.Utc).AddTicks(8261) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 6, 4, 26, 4, 375, DateTimeKind.Utc).AddTicks(8263), new DateTime(2025, 1, 6, 4, 26, 4, 375, DateTimeKind.Utc).AddTicks(8263) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 6, 4, 26, 4, 375, DateTimeKind.Utc).AddTicks(8264), new DateTime(2025, 1, 6, 4, 26, 4, 375, DateTimeKind.Utc).AddTicks(8265) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 6, 4, 26, 4, 375, DateTimeKind.Utc).AddTicks(8266), new DateTime(2025, 1, 6, 4, 26, 4, 375, DateTimeKind.Utc).AddTicks(8267) });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 6, 4, 26, 4, 375, DateTimeKind.Utc).AddTicks(8573), new DateTime(2025, 1, 6, 4, 26, 4, 375, DateTimeKind.Utc).AddTicks(8574) });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 6, 4, 26, 4, 375, DateTimeKind.Utc).AddTicks(8576), new DateTime(2025, 1, 6, 4, 26, 4, 375, DateTimeKind.Utc).AddTicks(8577) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 6, 4, 26, 4, 375, DateTimeKind.Utc).AddTicks(8506), new DateTime(2025, 1, 6, 4, 26, 4, 375, DateTimeKind.Utc).AddTicks(8506) });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "CreatedById", "DepartmentId", "Email", "FullName", "IsActive", "Password", "ProjectId", "UpdatedAt", "UpdatedById" },
                values: new object[] { 2, new DateTime(2025, 1, 6, 4, 26, 4, 375, DateTimeKind.Utc).AddTicks(8509), null, 1, "risk.manager@riskex.com", "Risk Manager", true, "Risk@123", null, new DateTime(2025, 1, 6, 4, 26, 4, 375, DateTimeKind.Utc).AddTicks(8510), null });

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Projects_ProjectId",
                table: "Users",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id");
        }
    }
}
