using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Risk_Management_RiskEX_Backend.Migrations
{
    /// <inheritdoc />
    public partial class RiskNameVarcharLength : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.AlterColumn<string>(
                name: "RiskName",
                table: "Risks",
                type: "character varying(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AssessmentsBasis",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 22, 4, 37, 4, 524, DateTimeKind.Utc).AddTicks(9355), new DateTime(2025, 1, 22, 4, 37, 4, 524, DateTimeKind.Utc).AddTicks(9356) });

            migrationBuilder.UpdateData(
                table: "AssessmentsBasis",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 22, 4, 37, 4, 524, DateTimeKind.Utc).AddTicks(9358), new DateTime(2025, 1, 22, 4, 37, 4, 524, DateTimeKind.Utc).AddTicks(9360) });

            migrationBuilder.UpdateData(
                table: "AssessmentsBasis",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 22, 4, 37, 4, 524, DateTimeKind.Utc).AddTicks(9362), new DateTime(2025, 1, 22, 4, 37, 4, 524, DateTimeKind.Utc).AddTicks(9363) });

            migrationBuilder.UpdateData(
                table: "AssessmentsBasis",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 22, 4, 37, 4, 524, DateTimeKind.Utc).AddTicks(9365), new DateTime(2025, 1, 22, 4, 37, 4, 524, DateTimeKind.Utc).AddTicks(9366) });

            migrationBuilder.UpdateData(
                table: "AssessmentsMatrixImpact",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 22, 4, 37, 4, 524, DateTimeKind.Utc).AddTicks(9516), new DateTime(2025, 1, 22, 4, 37, 4, 524, DateTimeKind.Utc).AddTicks(9517) });

            migrationBuilder.UpdateData(
                table: "AssessmentsMatrixImpact",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 22, 4, 37, 4, 524, DateTimeKind.Utc).AddTicks(9521), new DateTime(2025, 1, 22, 4, 37, 4, 524, DateTimeKind.Utc).AddTicks(9522) });

            migrationBuilder.UpdateData(
                table: "AssessmentsMatrixImpact",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 22, 4, 37, 4, 524, DateTimeKind.Utc).AddTicks(9524), new DateTime(2025, 1, 22, 4, 37, 4, 524, DateTimeKind.Utc).AddTicks(9525) });

            migrationBuilder.UpdateData(
                table: "AssessmentsMatrixImpact",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 22, 4, 37, 4, 524, DateTimeKind.Utc).AddTicks(9527), new DateTime(2025, 1, 22, 4, 37, 4, 524, DateTimeKind.Utc).AddTicks(9528) });

            migrationBuilder.UpdateData(
                table: "AssessmentsMatrixLikelihood",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 22, 4, 37, 4, 524, DateTimeKind.Utc).AddTicks(9570), new DateTime(2025, 1, 22, 4, 37, 4, 524, DateTimeKind.Utc).AddTicks(9571) });

            migrationBuilder.UpdateData(
                table: "AssessmentsMatrixLikelihood",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 22, 4, 37, 4, 524, DateTimeKind.Utc).AddTicks(9574), new DateTime(2025, 1, 22, 4, 37, 4, 524, DateTimeKind.Utc).AddTicks(9575) });

            migrationBuilder.UpdateData(
                table: "AssessmentsMatrixLikelihood",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 22, 4, 37, 4, 524, DateTimeKind.Utc).AddTicks(9578), new DateTime(2025, 1, 22, 4, 37, 4, 524, DateTimeKind.Utc).AddTicks(9579) });

            migrationBuilder.UpdateData(
                table: "AssessmentsMatrixLikelihood",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 22, 4, 37, 4, 524, DateTimeKind.Utc).AddTicks(9582), new DateTime(2025, 1, 22, 4, 37, 4, 524, DateTimeKind.Utc).AddTicks(9583) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 22, 4, 37, 4, 524, DateTimeKind.Utc).AddTicks(8890), new DateTime(2025, 1, 22, 4, 37, 4, 524, DateTimeKind.Utc).AddTicks(8897) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 22, 4, 37, 4, 524, DateTimeKind.Utc).AddTicks(8900), new DateTime(2025, 1, 22, 4, 37, 4, 524, DateTimeKind.Utc).AddTicks(8901) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 22, 4, 37, 4, 524, DateTimeKind.Utc).AddTicks(8904), new DateTime(2025, 1, 22, 4, 37, 4, 524, DateTimeKind.Utc).AddTicks(8905) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 22, 4, 37, 4, 524, DateTimeKind.Utc).AddTicks(8907), new DateTime(2025, 1, 22, 4, 37, 4, 524, DateTimeKind.Utc).AddTicks(8908) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 22, 4, 37, 4, 524, DateTimeKind.Utc).AddTicks(8910), new DateTime(2025, 1, 22, 4, 37, 4, 524, DateTimeKind.Utc).AddTicks(8911) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 22, 4, 37, 4, 524, DateTimeKind.Utc).AddTicks(8914), new DateTime(2025, 1, 22, 4, 37, 4, 524, DateTimeKind.Utc).AddTicks(8915) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 22, 4, 37, 4, 524, DateTimeKind.Utc).AddTicks(8917), new DateTime(2025, 1, 22, 4, 37, 4, 524, DateTimeKind.Utc).AddTicks(8918) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 22, 4, 37, 4, 524, DateTimeKind.Utc).AddTicks(8920), new DateTime(2025, 1, 22, 4, 37, 4, 524, DateTimeKind.Utc).AddTicks(8921) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 22, 4, 37, 4, 524, DateTimeKind.Utc).AddTicks(8923), new DateTime(2025, 1, 22, 4, 37, 4, 524, DateTimeKind.Utc).AddTicks(8924) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 22, 4, 37, 4, 524, DateTimeKind.Utc).AddTicks(8926), new DateTime(2025, 1, 22, 4, 37, 4, 524, DateTimeKind.Utc).AddTicks(8927) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 22, 4, 37, 4, 524, DateTimeKind.Utc).AddTicks(8929), new DateTime(2025, 1, 22, 4, 37, 4, 524, DateTimeKind.Utc).AddTicks(8930) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 22, 4, 37, 4, 524, DateTimeKind.Utc).AddTicks(8932), new DateTime(2025, 1, 22, 4, 37, 4, 524, DateTimeKind.Utc).AddTicks(8933) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 22, 4, 37, 4, 524, DateTimeKind.Utc).AddTicks(8936), new DateTime(2025, 1, 22, 4, 37, 4, 524, DateTimeKind.Utc).AddTicks(8937) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 22, 4, 37, 4, 524, DateTimeKind.Utc).AddTicks(8939), new DateTime(2025, 1, 22, 4, 37, 4, 524, DateTimeKind.Utc).AddTicks(8940) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 22, 4, 37, 4, 524, DateTimeKind.Utc).AddTicks(8942), new DateTime(2025, 1, 22, 4, 37, 4, 524, DateTimeKind.Utc).AddTicks(8950) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 22, 4, 37, 4, 524, DateTimeKind.Utc).AddTicks(8957), new DateTime(2025, 1, 22, 4, 37, 4, 524, DateTimeKind.Utc).AddTicks(8958) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 22, 4, 37, 4, 524, DateTimeKind.Utc).AddTicks(8960), new DateTime(2025, 1, 22, 4, 37, 4, 524, DateTimeKind.Utc).AddTicks(8961) });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 22, 4, 37, 4, 524, DateTimeKind.Utc).AddTicks(9416), new DateTime(2025, 1, 22, 4, 37, 4, 524, DateTimeKind.Utc).AddTicks(9417) });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 22, 4, 37, 4, 524, DateTimeKind.Utc).AddTicks(9421), new DateTime(2025, 1, 22, 4, 37, 4, 524, DateTimeKind.Utc).AddTicks(9422) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 22, 4, 37, 4, 524, DateTimeKind.Utc).AddTicks(9302), new DateTime(2025, 1, 22, 4, 37, 4, 524, DateTimeKind.Utc).AddTicks(9304) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "RiskName",
                table: "Risks",
                type: "character varying(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(500)",
                oldMaxLength: 500,
                oldNullable: true);

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

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "CreatedById", "DepartmentId", "Email", "FullName", "IsActive", "Password", "UpdatedAt", "UpdatedById" },
                values: new object[] { 2, new DateTime(2025, 1, 9, 16, 44, 10, 519, DateTimeKind.Utc).AddTicks(3467), null, 1, "risk.manager@riskex.com", "Risk Manager", true, "Risk@123", new DateTime(2025, 1, 9, 16, 44, 10, 519, DateTimeKind.Utc).AddTicks(3468), null });
        }
    }
}
