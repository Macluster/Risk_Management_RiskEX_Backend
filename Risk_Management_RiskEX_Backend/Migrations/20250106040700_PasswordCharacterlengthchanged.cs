using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Risk_Management_RiskEX_Backend.Migrations
{
    /// <inheritdoc />
    public partial class PasswordCharacterlengthchanged : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Users",
                type: "character varying(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(30)",
                oldMaxLength: 30,
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AssessmentsBasis",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 6, 4, 6, 59, 847, DateTimeKind.Utc).AddTicks(8552), new DateTime(2025, 1, 6, 4, 6, 59, 847, DateTimeKind.Utc).AddTicks(8552) });

            migrationBuilder.UpdateData(
                table: "AssessmentsBasis",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 6, 4, 6, 59, 847, DateTimeKind.Utc).AddTicks(8554), new DateTime(2025, 1, 6, 4, 6, 59, 847, DateTimeKind.Utc).AddTicks(8555) });

            migrationBuilder.UpdateData(
                table: "AssessmentsBasis",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 6, 4, 6, 59, 847, DateTimeKind.Utc).AddTicks(8556), new DateTime(2025, 1, 6, 4, 6, 59, 847, DateTimeKind.Utc).AddTicks(8557) });

            migrationBuilder.UpdateData(
                table: "AssessmentsBasis",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 6, 4, 6, 59, 847, DateTimeKind.Utc).AddTicks(8558), new DateTime(2025, 1, 6, 4, 6, 59, 847, DateTimeKind.Utc).AddTicks(8559) });

            migrationBuilder.UpdateData(
                table: "AssessmentsMatrixImpact",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 6, 4, 6, 59, 847, DateTimeKind.Utc).AddTicks(8611), new DateTime(2025, 1, 6, 4, 6, 59, 847, DateTimeKind.Utc).AddTicks(8612) });

            migrationBuilder.UpdateData(
                table: "AssessmentsMatrixImpact",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 6, 4, 6, 59, 847, DateTimeKind.Utc).AddTicks(8614), new DateTime(2025, 1, 6, 4, 6, 59, 847, DateTimeKind.Utc).AddTicks(8615) });

            migrationBuilder.UpdateData(
                table: "AssessmentsMatrixImpact",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 6, 4, 6, 59, 847, DateTimeKind.Utc).AddTicks(8616), new DateTime(2025, 1, 6, 4, 6, 59, 847, DateTimeKind.Utc).AddTicks(8617) });

            migrationBuilder.UpdateData(
                table: "AssessmentsMatrixImpact",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 6, 4, 6, 59, 847, DateTimeKind.Utc).AddTicks(8618), new DateTime(2025, 1, 6, 4, 6, 59, 847, DateTimeKind.Utc).AddTicks(8619) });

            migrationBuilder.UpdateData(
                table: "AssessmentsMatrixLikelihood",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 6, 4, 6, 59, 847, DateTimeKind.Utc).AddTicks(8640), new DateTime(2025, 1, 6, 4, 6, 59, 847, DateTimeKind.Utc).AddTicks(8641) });

            migrationBuilder.UpdateData(
                table: "AssessmentsMatrixLikelihood",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 6, 4, 6, 59, 847, DateTimeKind.Utc).AddTicks(8643), new DateTime(2025, 1, 6, 4, 6, 59, 847, DateTimeKind.Utc).AddTicks(8643) });

            migrationBuilder.UpdateData(
                table: "AssessmentsMatrixLikelihood",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 6, 4, 6, 59, 847, DateTimeKind.Utc).AddTicks(8699), new DateTime(2025, 1, 6, 4, 6, 59, 847, DateTimeKind.Utc).AddTicks(8700) });

            migrationBuilder.UpdateData(
                table: "AssessmentsMatrixLikelihood",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 6, 4, 6, 59, 847, DateTimeKind.Utc).AddTicks(8701), new DateTime(2025, 1, 6, 4, 6, 59, 847, DateTimeKind.Utc).AddTicks(8702) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 6, 4, 6, 59, 847, DateTimeKind.Utc).AddTicks(8234), new DateTime(2025, 1, 6, 4, 6, 59, 847, DateTimeKind.Utc).AddTicks(8238) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 6, 4, 6, 59, 847, DateTimeKind.Utc).AddTicks(8240), new DateTime(2025, 1, 6, 4, 6, 59, 847, DateTimeKind.Utc).AddTicks(8241) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 6, 4, 6, 59, 847, DateTimeKind.Utc).AddTicks(8242), new DateTime(2025, 1, 6, 4, 6, 59, 847, DateTimeKind.Utc).AddTicks(8243) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 6, 4, 6, 59, 847, DateTimeKind.Utc).AddTicks(8244), new DateTime(2025, 1, 6, 4, 6, 59, 847, DateTimeKind.Utc).AddTicks(8245) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 6, 4, 6, 59, 847, DateTimeKind.Utc).AddTicks(8246), new DateTime(2025, 1, 6, 4, 6, 59, 847, DateTimeKind.Utc).AddTicks(8247) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 6, 4, 6, 59, 847, DateTimeKind.Utc).AddTicks(8248), new DateTime(2025, 1, 6, 4, 6, 59, 847, DateTimeKind.Utc).AddTicks(8249) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 6, 4, 6, 59, 847, DateTimeKind.Utc).AddTicks(8250), new DateTime(2025, 1, 6, 4, 6, 59, 847, DateTimeKind.Utc).AddTicks(8251) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 6, 4, 6, 59, 847, DateTimeKind.Utc).AddTicks(8252), new DateTime(2025, 1, 6, 4, 6, 59, 847, DateTimeKind.Utc).AddTicks(8253) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 6, 4, 6, 59, 847, DateTimeKind.Utc).AddTicks(8254), new DateTime(2025, 1, 6, 4, 6, 59, 847, DateTimeKind.Utc).AddTicks(8255) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 6, 4, 6, 59, 847, DateTimeKind.Utc).AddTicks(8256), new DateTime(2025, 1, 6, 4, 6, 59, 847, DateTimeKind.Utc).AddTicks(8257) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 6, 4, 6, 59, 847, DateTimeKind.Utc).AddTicks(8258), new DateTime(2025, 1, 6, 4, 6, 59, 847, DateTimeKind.Utc).AddTicks(8259) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 6, 4, 6, 59, 847, DateTimeKind.Utc).AddTicks(8260), new DateTime(2025, 1, 6, 4, 6, 59, 847, DateTimeKind.Utc).AddTicks(8261) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 6, 4, 6, 59, 847, DateTimeKind.Utc).AddTicks(8262), new DateTime(2025, 1, 6, 4, 6, 59, 847, DateTimeKind.Utc).AddTicks(8263) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 6, 4, 6, 59, 847, DateTimeKind.Utc).AddTicks(8264), new DateTime(2025, 1, 6, 4, 6, 59, 847, DateTimeKind.Utc).AddTicks(8265) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 6, 4, 6, 59, 847, DateTimeKind.Utc).AddTicks(8267), new DateTime(2025, 1, 6, 4, 6, 59, 847, DateTimeKind.Utc).AddTicks(8267) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 6, 4, 6, 59, 847, DateTimeKind.Utc).AddTicks(8268), new DateTime(2025, 1, 6, 4, 6, 59, 847, DateTimeKind.Utc).AddTicks(8269) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 6, 4, 6, 59, 847, DateTimeKind.Utc).AddTicks(8270), new DateTime(2025, 1, 6, 4, 6, 59, 847, DateTimeKind.Utc).AddTicks(8271) });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 6, 4, 6, 59, 847, DateTimeKind.Utc).AddTicks(8583), new DateTime(2025, 1, 6, 4, 6, 59, 847, DateTimeKind.Utc).AddTicks(8584) });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 6, 4, 6, 59, 847, DateTimeKind.Utc).AddTicks(8587), new DateTime(2025, 1, 6, 4, 6, 59, 847, DateTimeKind.Utc).AddTicks(8588) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 6, 4, 6, 59, 847, DateTimeKind.Utc).AddTicks(8523), new DateTime(2025, 1, 6, 4, 6, 59, 847, DateTimeKind.Utc).AddTicks(8524) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 6, 4, 6, 59, 847, DateTimeKind.Utc).AddTicks(8526), new DateTime(2025, 1, 6, 4, 6, 59, 847, DateTimeKind.Utc).AddTicks(8527) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Users",
                type: "character varying(30)",
                maxLength: 30,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(200)",
                oldMaxLength: 200,
                oldNullable: true);

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
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 4, 7, 35, 26, 875, DateTimeKind.Utc).AddTicks(4071), new DateTime(2025, 1, 4, 7, 35, 26, 875, DateTimeKind.Utc).AddTicks(4072) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 4, 7, 35, 26, 875, DateTimeKind.Utc).AddTicks(4074), new DateTime(2025, 1, 4, 7, 35, 26, 875, DateTimeKind.Utc).AddTicks(4075) });
        }
    }
}
