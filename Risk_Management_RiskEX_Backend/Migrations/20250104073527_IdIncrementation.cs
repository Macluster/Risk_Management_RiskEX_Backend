using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Risk_Management_RiskEX_Backend.Migrations
{
    /// <inheritdoc />
    public partial class IdIncrementation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AssessmentsBasis",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 4, 7, 35, 26, 875, DateTimeKind.Utc).AddTicks(4157), new DateTime(2025, 1, 4, 7, 35, 26, 875, DateTimeKind.Utc).AddTicks(4158) });

            migrationBuilder.UpdateData(
                table: "AssessmentsBasis",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 4, 7, 35, 26, 875, DateTimeKind.Utc).AddTicks(4159), new DateTime(2025, 1, 4, 7, 35, 26, 875, DateTimeKind.Utc).AddTicks(4160) });

            migrationBuilder.UpdateData(
                table: "AssessmentsBasis",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 4, 7, 35, 26, 875, DateTimeKind.Utc).AddTicks(4161), new DateTime(2025, 1, 4, 7, 35, 26, 875, DateTimeKind.Utc).AddTicks(4162) });

            migrationBuilder.UpdateData(
                table: "AssessmentsBasis",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 4, 7, 35, 26, 875, DateTimeKind.Utc).AddTicks(4163), new DateTime(2025, 1, 4, 7, 35, 26, 875, DateTimeKind.Utc).AddTicks(4164) });

            migrationBuilder.UpdateData(
                table: "AssessmentsMatrixImpact",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 4, 7, 35, 26, 875, DateTimeKind.Utc).AddTicks(4215), new DateTime(2025, 1, 4, 7, 35, 26, 875, DateTimeKind.Utc).AddTicks(4216) });

            migrationBuilder.UpdateData(
                table: "AssessmentsMatrixImpact",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 4, 7, 35, 26, 875, DateTimeKind.Utc).AddTicks(4218), new DateTime(2025, 1, 4, 7, 35, 26, 875, DateTimeKind.Utc).AddTicks(4218) });

            migrationBuilder.UpdateData(
                table: "AssessmentsMatrixImpact",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 4, 7, 35, 26, 875, DateTimeKind.Utc).AddTicks(4220), new DateTime(2025, 1, 4, 7, 35, 26, 875, DateTimeKind.Utc).AddTicks(4221) });

            migrationBuilder.UpdateData(
                table: "AssessmentsMatrixImpact",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 4, 7, 35, 26, 875, DateTimeKind.Utc).AddTicks(4222), new DateTime(2025, 1, 4, 7, 35, 26, 875, DateTimeKind.Utc).AddTicks(4223) });

            migrationBuilder.UpdateData(
                table: "AssessmentsMatrixLikelihood",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 4, 7, 35, 26, 875, DateTimeKind.Utc).AddTicks(4245), new DateTime(2025, 1, 4, 7, 35, 26, 875, DateTimeKind.Utc).AddTicks(4246) });

            migrationBuilder.UpdateData(
                table: "AssessmentsMatrixLikelihood",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 4, 7, 35, 26, 875, DateTimeKind.Utc).AddTicks(4248), new DateTime(2025, 1, 4, 7, 35, 26, 875, DateTimeKind.Utc).AddTicks(4248) });

            migrationBuilder.UpdateData(
                table: "AssessmentsMatrixLikelihood",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 4, 7, 35, 26, 875, DateTimeKind.Utc).AddTicks(4250), new DateTime(2025, 1, 4, 7, 35, 26, 875, DateTimeKind.Utc).AddTicks(4250) });

            migrationBuilder.UpdateData(
                table: "AssessmentsMatrixLikelihood",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 4, 7, 35, 26, 875, DateTimeKind.Utc).AddTicks(4252), new DateTime(2025, 1, 4, 7, 35, 26, 875, DateTimeKind.Utc).AddTicks(4253) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 4, 7, 35, 26, 875, DateTimeKind.Utc).AddTicks(3817), new DateTime(2025, 1, 4, 7, 35, 26, 875, DateTimeKind.Utc).AddTicks(3820) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 4, 7, 35, 26, 875, DateTimeKind.Utc).AddTicks(3822), new DateTime(2025, 1, 4, 7, 35, 26, 875, DateTimeKind.Utc).AddTicks(3823) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 4, 7, 35, 26, 875, DateTimeKind.Utc).AddTicks(3825), new DateTime(2025, 1, 4, 7, 35, 26, 875, DateTimeKind.Utc).AddTicks(3825) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 4, 7, 35, 26, 875, DateTimeKind.Utc).AddTicks(3827), new DateTime(2025, 1, 4, 7, 35, 26, 875, DateTimeKind.Utc).AddTicks(3827) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 4, 7, 35, 26, 875, DateTimeKind.Utc).AddTicks(3829), new DateTime(2025, 1, 4, 7, 35, 26, 875, DateTimeKind.Utc).AddTicks(3829) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 4, 7, 35, 26, 875, DateTimeKind.Utc).AddTicks(3831), new DateTime(2025, 1, 4, 7, 35, 26, 875, DateTimeKind.Utc).AddTicks(3831) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 4, 7, 35, 26, 875, DateTimeKind.Utc).AddTicks(3833), new DateTime(2025, 1, 4, 7, 35, 26, 875, DateTimeKind.Utc).AddTicks(3833) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 4, 7, 35, 26, 875, DateTimeKind.Utc).AddTicks(3835), new DateTime(2025, 1, 4, 7, 35, 26, 875, DateTimeKind.Utc).AddTicks(3835) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 4, 7, 35, 26, 875, DateTimeKind.Utc).AddTicks(3837), new DateTime(2025, 1, 4, 7, 35, 26, 875, DateTimeKind.Utc).AddTicks(3837) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 4, 7, 35, 26, 875, DateTimeKind.Utc).AddTicks(3839), new DateTime(2025, 1, 4, 7, 35, 26, 875, DateTimeKind.Utc).AddTicks(3839) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 4, 7, 35, 26, 875, DateTimeKind.Utc).AddTicks(3840), new DateTime(2025, 1, 4, 7, 35, 26, 875, DateTimeKind.Utc).AddTicks(3841) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 4, 7, 35, 26, 875, DateTimeKind.Utc).AddTicks(3842), new DateTime(2025, 1, 4, 7, 35, 26, 875, DateTimeKind.Utc).AddTicks(3843) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 4, 7, 35, 26, 875, DateTimeKind.Utc).AddTicks(3844), new DateTime(2025, 1, 4, 7, 35, 26, 875, DateTimeKind.Utc).AddTicks(3845) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 4, 7, 35, 26, 875, DateTimeKind.Utc).AddTicks(3846), new DateTime(2025, 1, 4, 7, 35, 26, 875, DateTimeKind.Utc).AddTicks(3847) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 4, 7, 35, 26, 875, DateTimeKind.Utc).AddTicks(3850), new DateTime(2025, 1, 4, 7, 35, 26, 875, DateTimeKind.Utc).AddTicks(3850) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 4, 7, 35, 26, 875, DateTimeKind.Utc).AddTicks(3851), new DateTime(2025, 1, 4, 7, 35, 26, 875, DateTimeKind.Utc).AddTicks(3852) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 4, 7, 35, 26, 875, DateTimeKind.Utc).AddTicks(3853), new DateTime(2025, 1, 4, 7, 35, 26, 875, DateTimeKind.Utc).AddTicks(3854) });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 4, 7, 35, 26, 875, DateTimeKind.Utc).AddTicks(4190), new DateTime(2025, 1, 4, 7, 35, 26, 875, DateTimeKind.Utc).AddTicks(4191) });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 4, 7, 35, 26, 875, DateTimeKind.Utc).AddTicks(4194), new DateTime(2025, 1, 4, 7, 35, 26, 875, DateTimeKind.Utc).AddTicks(4194) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "DepartmentId", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 4, 7, 35, 26, 875, DateTimeKind.Utc).AddTicks(4071), 17, new DateTime(2025, 1, 4, 7, 35, 26, 875, DateTimeKind.Utc).AddTicks(4072) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 4, 7, 35, 26, 875, DateTimeKind.Utc).AddTicks(4074), new DateTime(2025, 1, 4, 7, 35, 26, 875, DateTimeKind.Utc).AddTicks(4075) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AssessmentsBasis",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 4, 4, 22, 56, 795, DateTimeKind.Utc).AddTicks(9209), new DateTime(2025, 1, 4, 4, 22, 56, 795, DateTimeKind.Utc).AddTicks(9209) });

            migrationBuilder.UpdateData(
                table: "AssessmentsBasis",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 4, 4, 22, 56, 795, DateTimeKind.Utc).AddTicks(9211), new DateTime(2025, 1, 4, 4, 22, 56, 795, DateTimeKind.Utc).AddTicks(9212) });

            migrationBuilder.UpdateData(
                table: "AssessmentsBasis",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 4, 4, 22, 56, 795, DateTimeKind.Utc).AddTicks(9213), new DateTime(2025, 1, 4, 4, 22, 56, 795, DateTimeKind.Utc).AddTicks(9213) });

            migrationBuilder.UpdateData(
                table: "AssessmentsBasis",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 4, 4, 22, 56, 795, DateTimeKind.Utc).AddTicks(9215), new DateTime(2025, 1, 4, 4, 22, 56, 795, DateTimeKind.Utc).AddTicks(9215) });

            migrationBuilder.UpdateData(
                table: "AssessmentsMatrixImpact",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 4, 4, 22, 56, 795, DateTimeKind.Utc).AddTicks(9269), new DateTime(2025, 1, 4, 4, 22, 56, 795, DateTimeKind.Utc).AddTicks(9270) });

            migrationBuilder.UpdateData(
                table: "AssessmentsMatrixImpact",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 4, 4, 22, 56, 795, DateTimeKind.Utc).AddTicks(9272), new DateTime(2025, 1, 4, 4, 22, 56, 795, DateTimeKind.Utc).AddTicks(9272) });

            migrationBuilder.UpdateData(
                table: "AssessmentsMatrixImpact",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 4, 4, 22, 56, 795, DateTimeKind.Utc).AddTicks(9274), new DateTime(2025, 1, 4, 4, 22, 56, 795, DateTimeKind.Utc).AddTicks(9275) });

            migrationBuilder.UpdateData(
                table: "AssessmentsMatrixImpact",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 4, 4, 22, 56, 795, DateTimeKind.Utc).AddTicks(9276), new DateTime(2025, 1, 4, 4, 22, 56, 795, DateTimeKind.Utc).AddTicks(9277) });

            migrationBuilder.UpdateData(
                table: "AssessmentsMatrixLikelihood",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 4, 4, 22, 56, 795, DateTimeKind.Utc).AddTicks(9298), new DateTime(2025, 1, 4, 4, 22, 56, 795, DateTimeKind.Utc).AddTicks(9299) });

            migrationBuilder.UpdateData(
                table: "AssessmentsMatrixLikelihood",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 4, 4, 22, 56, 795, DateTimeKind.Utc).AddTicks(9301), new DateTime(2025, 1, 4, 4, 22, 56, 795, DateTimeKind.Utc).AddTicks(9302) });

            migrationBuilder.UpdateData(
                table: "AssessmentsMatrixLikelihood",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 4, 4, 22, 56, 795, DateTimeKind.Utc).AddTicks(9303), new DateTime(2025, 1, 4, 4, 22, 56, 795, DateTimeKind.Utc).AddTicks(9304) });

            migrationBuilder.UpdateData(
                table: "AssessmentsMatrixLikelihood",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 4, 4, 22, 56, 795, DateTimeKind.Utc).AddTicks(9305), new DateTime(2025, 1, 4, 4, 22, 56, 795, DateTimeKind.Utc).AddTicks(9306) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 4, 4, 22, 56, 795, DateTimeKind.Utc).AddTicks(8980), new DateTime(2025, 1, 4, 4, 22, 56, 795, DateTimeKind.Utc).AddTicks(8985) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 4, 4, 22, 56, 795, DateTimeKind.Utc).AddTicks(8987), new DateTime(2025, 1, 4, 4, 22, 56, 795, DateTimeKind.Utc).AddTicks(8987) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 4, 4, 22, 56, 795, DateTimeKind.Utc).AddTicks(8989), new DateTime(2025, 1, 4, 4, 22, 56, 795, DateTimeKind.Utc).AddTicks(8990) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 4, 4, 22, 56, 795, DateTimeKind.Utc).AddTicks(8991), new DateTime(2025, 1, 4, 4, 22, 56, 795, DateTimeKind.Utc).AddTicks(8992) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 4, 4, 22, 56, 795, DateTimeKind.Utc).AddTicks(8993), new DateTime(2025, 1, 4, 4, 22, 56, 795, DateTimeKind.Utc).AddTicks(8994) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 4, 4, 22, 56, 795, DateTimeKind.Utc).AddTicks(8995), new DateTime(2025, 1, 4, 4, 22, 56, 795, DateTimeKind.Utc).AddTicks(8996) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 4, 4, 22, 56, 795, DateTimeKind.Utc).AddTicks(8997), new DateTime(2025, 1, 4, 4, 22, 56, 795, DateTimeKind.Utc).AddTicks(8998) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 4, 4, 22, 56, 795, DateTimeKind.Utc).AddTicks(8999), new DateTime(2025, 1, 4, 4, 22, 56, 795, DateTimeKind.Utc).AddTicks(9000) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 4, 4, 22, 56, 795, DateTimeKind.Utc).AddTicks(9001), new DateTime(2025, 1, 4, 4, 22, 56, 795, DateTimeKind.Utc).AddTicks(9002) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 4, 4, 22, 56, 795, DateTimeKind.Utc).AddTicks(9003), new DateTime(2025, 1, 4, 4, 22, 56, 795, DateTimeKind.Utc).AddTicks(9004) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 4, 4, 22, 56, 795, DateTimeKind.Utc).AddTicks(9005), new DateTime(2025, 1, 4, 4, 22, 56, 795, DateTimeKind.Utc).AddTicks(9006) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 4, 4, 22, 56, 795, DateTimeKind.Utc).AddTicks(9007), new DateTime(2025, 1, 4, 4, 22, 56, 795, DateTimeKind.Utc).AddTicks(9008) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 4, 4, 22, 56, 795, DateTimeKind.Utc).AddTicks(9009), new DateTime(2025, 1, 4, 4, 22, 56, 795, DateTimeKind.Utc).AddTicks(9010) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 4, 4, 22, 56, 795, DateTimeKind.Utc).AddTicks(9011), new DateTime(2025, 1, 4, 4, 22, 56, 795, DateTimeKind.Utc).AddTicks(9011) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 4, 4, 22, 56, 795, DateTimeKind.Utc).AddTicks(9013), new DateTime(2025, 1, 4, 4, 22, 56, 795, DateTimeKind.Utc).AddTicks(9014) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 4, 4, 22, 56, 795, DateTimeKind.Utc).AddTicks(9015), new DateTime(2025, 1, 4, 4, 22, 56, 795, DateTimeKind.Utc).AddTicks(9016) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 4, 4, 22, 56, 795, DateTimeKind.Utc).AddTicks(9017), new DateTime(2025, 1, 4, 4, 22, 56, 795, DateTimeKind.Utc).AddTicks(9018) });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 4, 4, 22, 56, 795, DateTimeKind.Utc).AddTicks(9242), new DateTime(2025, 1, 4, 4, 22, 56, 795, DateTimeKind.Utc).AddTicks(9244) });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 4, 4, 22, 56, 795, DateTimeKind.Utc).AddTicks(9247), new DateTime(2025, 1, 4, 4, 22, 56, 795, DateTimeKind.Utc).AddTicks(9248) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "DepartmentId", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 4, 4, 22, 56, 795, DateTimeKind.Utc).AddTicks(9179), 1, new DateTime(2025, 1, 4, 4, 22, 56, 795, DateTimeKind.Utc).AddTicks(9180) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 4, 4, 22, 56, 795, DateTimeKind.Utc).AddTicks(9183), new DateTime(2025, 1, 4, 4, 22, 56, 795, DateTimeKind.Utc).AddTicks(9184) });
        }
    }
}
