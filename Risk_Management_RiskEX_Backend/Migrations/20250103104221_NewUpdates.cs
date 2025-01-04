using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Risk_Management_RiskEX_Backend.Migrations
{
    /// <inheritdoc />
    public partial class NewUpdates : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "OverallRiskRating",
                table: "Risks",
                newName: "OverallRiskRatingBefore");

            migrationBuilder.AddColumn<int>(
                name: "OverallRiskRatingAfter",
                table: "Risks",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "PercentageRedution",
                table: "Risks",
                type: "double precision",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ResidualRisk",
                table: "Risks",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ResidualValue",
                table: "Risks",
                type: "integer",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AssessmentsBasis",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 3, 10, 42, 20, 521, DateTimeKind.Utc).AddTicks(8014), new DateTime(2025, 1, 3, 10, 42, 20, 521, DateTimeKind.Utc).AddTicks(8015) });

            migrationBuilder.UpdateData(
                table: "AssessmentsBasis",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 3, 10, 42, 20, 521, DateTimeKind.Utc).AddTicks(8016), new DateTime(2025, 1, 3, 10, 42, 20, 521, DateTimeKind.Utc).AddTicks(8017) });

            migrationBuilder.UpdateData(
                table: "AssessmentsBasis",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 3, 10, 42, 20, 521, DateTimeKind.Utc).AddTicks(8018), new DateTime(2025, 1, 3, 10, 42, 20, 521, DateTimeKind.Utc).AddTicks(8018) });

            migrationBuilder.UpdateData(
                table: "AssessmentsBasis",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 3, 10, 42, 20, 521, DateTimeKind.Utc).AddTicks(8019), new DateTime(2025, 1, 3, 10, 42, 20, 521, DateTimeKind.Utc).AddTicks(8020) });

            migrationBuilder.UpdateData(
                table: "AssessmentsMatrixImpact",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 3, 10, 42, 20, 521, DateTimeKind.Utc).AddTicks(8060), new DateTime(2025, 1, 3, 10, 42, 20, 521, DateTimeKind.Utc).AddTicks(8061) });

            migrationBuilder.UpdateData(
                table: "AssessmentsMatrixImpact",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 3, 10, 42, 20, 521, DateTimeKind.Utc).AddTicks(8063), new DateTime(2025, 1, 3, 10, 42, 20, 521, DateTimeKind.Utc).AddTicks(8063) });

            migrationBuilder.UpdateData(
                table: "AssessmentsMatrixImpact",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 3, 10, 42, 20, 521, DateTimeKind.Utc).AddTicks(8064), new DateTime(2025, 1, 3, 10, 42, 20, 521, DateTimeKind.Utc).AddTicks(8065) });

            migrationBuilder.UpdateData(
                table: "AssessmentsMatrixImpact",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 3, 10, 42, 20, 521, DateTimeKind.Utc).AddTicks(8066), new DateTime(2025, 1, 3, 10, 42, 20, 521, DateTimeKind.Utc).AddTicks(8067) });

            migrationBuilder.UpdateData(
                table: "AssessmentsMatrixLikelihood",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 3, 10, 42, 20, 521, DateTimeKind.Utc).AddTicks(8088), new DateTime(2025, 1, 3, 10, 42, 20, 521, DateTimeKind.Utc).AddTicks(8088) });

            migrationBuilder.UpdateData(
                table: "AssessmentsMatrixLikelihood",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 3, 10, 42, 20, 521, DateTimeKind.Utc).AddTicks(8090), new DateTime(2025, 1, 3, 10, 42, 20, 521, DateTimeKind.Utc).AddTicks(8090) });

            migrationBuilder.UpdateData(
                table: "AssessmentsMatrixLikelihood",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 3, 10, 42, 20, 521, DateTimeKind.Utc).AddTicks(8092), new DateTime(2025, 1, 3, 10, 42, 20, 521, DateTimeKind.Utc).AddTicks(8092) });

            migrationBuilder.UpdateData(
                table: "AssessmentsMatrixLikelihood",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 3, 10, 42, 20, 521, DateTimeKind.Utc).AddTicks(8093), new DateTime(2025, 1, 3, 10, 42, 20, 521, DateTimeKind.Utc).AddTicks(8094) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 3, 10, 42, 20, 521, DateTimeKind.Utc).AddTicks(7835), new DateTime(2025, 1, 3, 10, 42, 20, 521, DateTimeKind.Utc).AddTicks(7840) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 3, 10, 42, 20, 521, DateTimeKind.Utc).AddTicks(7842), new DateTime(2025, 1, 3, 10, 42, 20, 521, DateTimeKind.Utc).AddTicks(7843) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 3, 10, 42, 20, 521, DateTimeKind.Utc).AddTicks(7844), new DateTime(2025, 1, 3, 10, 42, 20, 521, DateTimeKind.Utc).AddTicks(7844) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 3, 10, 42, 20, 521, DateTimeKind.Utc).AddTicks(7845), new DateTime(2025, 1, 3, 10, 42, 20, 521, DateTimeKind.Utc).AddTicks(7846) });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 3, 10, 42, 20, 521, DateTimeKind.Utc).AddTicks(8040), new DateTime(2025, 1, 3, 10, 42, 20, 521, DateTimeKind.Utc).AddTicks(8042) });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 3, 10, 42, 20, 521, DateTimeKind.Utc).AddTicks(8044), new DateTime(2025, 1, 3, 10, 42, 20, 521, DateTimeKind.Utc).AddTicks(8045) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 3, 10, 42, 20, 521, DateTimeKind.Utc).AddTicks(7991), new DateTime(2025, 1, 3, 10, 42, 20, 521, DateTimeKind.Utc).AddTicks(7992) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 3, 10, 42, 20, 521, DateTimeKind.Utc).AddTicks(7994), new DateTime(2025, 1, 3, 10, 42, 20, 521, DateTimeKind.Utc).AddTicks(7994) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OverallRiskRatingAfter",
                table: "Risks");

            migrationBuilder.DropColumn(
                name: "PercentageRedution",
                table: "Risks");

            migrationBuilder.DropColumn(
                name: "ResidualRisk",
                table: "Risks");

            migrationBuilder.DropColumn(
                name: "ResidualValue",
                table: "Risks");

            migrationBuilder.RenameColumn(
                name: "OverallRiskRatingBefore",
                table: "Risks",
                newName: "OverallRiskRating");

            migrationBuilder.UpdateData(
                table: "AssessmentsBasis",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 3, 3, 55, 4, 463, DateTimeKind.Utc).AddTicks(7412), new DateTime(2025, 1, 3, 3, 55, 4, 463, DateTimeKind.Utc).AddTicks(7413) });

            migrationBuilder.UpdateData(
                table: "AssessmentsBasis",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 3, 3, 55, 4, 463, DateTimeKind.Utc).AddTicks(7414), new DateTime(2025, 1, 3, 3, 55, 4, 463, DateTimeKind.Utc).AddTicks(7415) });

            migrationBuilder.UpdateData(
                table: "AssessmentsBasis",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 3, 3, 55, 4, 463, DateTimeKind.Utc).AddTicks(7416), new DateTime(2025, 1, 3, 3, 55, 4, 463, DateTimeKind.Utc).AddTicks(7416) });

            migrationBuilder.UpdateData(
                table: "AssessmentsBasis",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 3, 3, 55, 4, 463, DateTimeKind.Utc).AddTicks(7417), new DateTime(2025, 1, 3, 3, 55, 4, 463, DateTimeKind.Utc).AddTicks(7418) });

            migrationBuilder.UpdateData(
                table: "AssessmentsMatrixImpact",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 3, 3, 55, 4, 463, DateTimeKind.Utc).AddTicks(7454), new DateTime(2025, 1, 3, 3, 55, 4, 463, DateTimeKind.Utc).AddTicks(7454) });

            migrationBuilder.UpdateData(
                table: "AssessmentsMatrixImpact",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 3, 3, 55, 4, 463, DateTimeKind.Utc).AddTicks(7456), new DateTime(2025, 1, 3, 3, 55, 4, 463, DateTimeKind.Utc).AddTicks(7457) });

            migrationBuilder.UpdateData(
                table: "AssessmentsMatrixImpact",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 3, 3, 55, 4, 463, DateTimeKind.Utc).AddTicks(7458), new DateTime(2025, 1, 3, 3, 55, 4, 463, DateTimeKind.Utc).AddTicks(7458) });

            migrationBuilder.UpdateData(
                table: "AssessmentsMatrixImpact",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 3, 3, 55, 4, 463, DateTimeKind.Utc).AddTicks(7459), new DateTime(2025, 1, 3, 3, 55, 4, 463, DateTimeKind.Utc).AddTicks(7460) });

            migrationBuilder.UpdateData(
                table: "AssessmentsMatrixLikelihood",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 3, 3, 55, 4, 463, DateTimeKind.Utc).AddTicks(7511), new DateTime(2025, 1, 3, 3, 55, 4, 463, DateTimeKind.Utc).AddTicks(7511) });

            migrationBuilder.UpdateData(
                table: "AssessmentsMatrixLikelihood",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 3, 3, 55, 4, 463, DateTimeKind.Utc).AddTicks(7513), new DateTime(2025, 1, 3, 3, 55, 4, 463, DateTimeKind.Utc).AddTicks(7513) });

            migrationBuilder.UpdateData(
                table: "AssessmentsMatrixLikelihood",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 3, 3, 55, 4, 463, DateTimeKind.Utc).AddTicks(7515), new DateTime(2025, 1, 3, 3, 55, 4, 463, DateTimeKind.Utc).AddTicks(7515) });

            migrationBuilder.UpdateData(
                table: "AssessmentsMatrixLikelihood",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 3, 3, 55, 4, 463, DateTimeKind.Utc).AddTicks(7516), new DateTime(2025, 1, 3, 3, 55, 4, 463, DateTimeKind.Utc).AddTicks(7517) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 3, 3, 55, 4, 463, DateTimeKind.Utc).AddTicks(7238), new DateTime(2025, 1, 3, 3, 55, 4, 463, DateTimeKind.Utc).AddTicks(7241) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 3, 3, 55, 4, 463, DateTimeKind.Utc).AddTicks(7243), new DateTime(2025, 1, 3, 3, 55, 4, 463, DateTimeKind.Utc).AddTicks(7243) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 3, 3, 55, 4, 463, DateTimeKind.Utc).AddTicks(7245), new DateTime(2025, 1, 3, 3, 55, 4, 463, DateTimeKind.Utc).AddTicks(7245) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 3, 3, 55, 4, 463, DateTimeKind.Utc).AddTicks(7246), new DateTime(2025, 1, 3, 3, 55, 4, 463, DateTimeKind.Utc).AddTicks(7247) });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 3, 3, 55, 4, 463, DateTimeKind.Utc).AddTicks(7437), new DateTime(2025, 1, 3, 3, 55, 4, 463, DateTimeKind.Utc).AddTicks(7438) });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 3, 3, 55, 4, 463, DateTimeKind.Utc).AddTicks(7440), new DateTime(2025, 1, 3, 3, 55, 4, 463, DateTimeKind.Utc).AddTicks(7441) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 3, 3, 55, 4, 463, DateTimeKind.Utc).AddTicks(7387), new DateTime(2025, 1, 3, 3, 55, 4, 463, DateTimeKind.Utc).AddTicks(7387) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 3, 3, 55, 4, 463, DateTimeKind.Utc).AddTicks(7389), new DateTime(2025, 1, 3, 3, 55, 4, 463, DateTimeKind.Utc).AddTicks(7390) });
        }
    }
}
