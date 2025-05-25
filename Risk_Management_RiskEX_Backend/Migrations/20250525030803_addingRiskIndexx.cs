using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Risk_Management_RiskEX_Backend.Migrations
{
    /// <inheritdoc />
    public partial class addingRiskIndexx : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.UpdateData(
                table: "AssessmentsBasis",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 25, 3, 8, 2, 643, DateTimeKind.Utc).AddTicks(1731), new DateTime(2025, 5, 25, 3, 8, 2, 643, DateTimeKind.Utc).AddTicks(1732) });

            migrationBuilder.UpdateData(
                table: "AssessmentsBasis",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 25, 3, 8, 2, 643, DateTimeKind.Utc).AddTicks(1733), new DateTime(2025, 5, 25, 3, 8, 2, 643, DateTimeKind.Utc).AddTicks(1734) });

            migrationBuilder.UpdateData(
                table: "AssessmentsBasis",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 25, 3, 8, 2, 643, DateTimeKind.Utc).AddTicks(1735), new DateTime(2025, 5, 25, 3, 8, 2, 643, DateTimeKind.Utc).AddTicks(1735) });

            migrationBuilder.UpdateData(
                table: "AssessmentsBasis",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 25, 3, 8, 2, 643, DateTimeKind.Utc).AddTicks(1736), new DateTime(2025, 5, 25, 3, 8, 2, 643, DateTimeKind.Utc).AddTicks(1737) });

            migrationBuilder.UpdateData(
                table: "AssessmentsMatrixImpact",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Definition", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 25, 3, 8, 2, 643, DateTimeKind.Utc).AddTicks(1787), "No slight effect on business", new DateTime(2025, 5, 25, 3, 8, 2, 643, DateTimeKind.Utc).AddTicks(1788) });

            migrationBuilder.UpdateData(
                table: "AssessmentsMatrixImpact",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Definition", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 25, 3, 8, 2, 643, DateTimeKind.Utc).AddTicks(1789), "Business objectives affected", new DateTime(2025, 5, 25, 3, 8, 2, 643, DateTimeKind.Utc).AddTicks(1790) });

            migrationBuilder.UpdateData(
                table: "AssessmentsMatrixImpact",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Definition", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 25, 3, 8, 2, 643, DateTimeKind.Utc).AddTicks(1791), "Business objectives undermined", new DateTime(2025, 5, 25, 3, 8, 2, 643, DateTimeKind.Utc).AddTicks(1791) });

            migrationBuilder.UpdateData(
                table: "AssessmentsMatrixImpact",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "Definition", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 25, 3, 8, 2, 643, DateTimeKind.Utc).AddTicks(1793), "Business objectives not accomplished", new DateTime(2025, 5, 25, 3, 8, 2, 643, DateTimeKind.Utc).AddTicks(1793) });

            migrationBuilder.UpdateData(
                table: "AssessmentsMatrixLikelihood",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 25, 3, 8, 2, 643, DateTimeKind.Utc).AddTicks(1813), new DateTime(2025, 5, 25, 3, 8, 2, 643, DateTimeKind.Utc).AddTicks(1814) });

            migrationBuilder.UpdateData(
                table: "AssessmentsMatrixLikelihood",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 25, 3, 8, 2, 643, DateTimeKind.Utc).AddTicks(1816), new DateTime(2025, 5, 25, 3, 8, 2, 643, DateTimeKind.Utc).AddTicks(1816) });

            migrationBuilder.UpdateData(
                table: "AssessmentsMatrixLikelihood",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 25, 3, 8, 2, 643, DateTimeKind.Utc).AddTicks(1818), new DateTime(2025, 5, 25, 3, 8, 2, 643, DateTimeKind.Utc).AddTicks(1818) });

            migrationBuilder.UpdateData(
                table: "AssessmentsMatrixLikelihood",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 25, 3, 8, 2, 643, DateTimeKind.Utc).AddTicks(1819), new DateTime(2025, 5, 25, 3, 8, 2, 643, DateTimeKind.Utc).AddTicks(1820) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "DepartmentCode", "DepartmentName", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 25, 3, 8, 2, 643, DateTimeKind.Utc).AddTicks(1401), "ACE", "Audits & Compliance", new DateTime(2025, 5, 25, 3, 8, 2, 643, DateTimeKind.Utc).AddTicks(1406) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "DepartmentCode", "DepartmentName", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 25, 3, 8, 2, 643, DateTimeKind.Utc).AddTicks(1408), "EMT", "EMT", new DateTime(2025, 5, 25, 3, 8, 2, 643, DateTimeKind.Utc).AddTicks(1408) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "DepartmentCode", "DepartmentName", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 25, 3, 8, 2, 643, DateTimeKind.Utc).AddTicks(1410), "SFM", "SFM", new DateTime(2025, 5, 25, 3, 8, 2, 643, DateTimeKind.Utc).AddTicks(1410) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "DepartmentCode", "DepartmentName", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 25, 3, 8, 2, 643, DateTimeKind.Utc).AddTicks(1411), "HR", "HR", new DateTime(2025, 5, 25, 3, 8, 2, 643, DateTimeKind.Utc).AddTicks(1412) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "DepartmentCode", "DepartmentName", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 25, 3, 8, 2, 643, DateTimeKind.Utc).AddTicks(1413), "A&D", "Admin & Purchase", new DateTime(2025, 5, 25, 3, 8, 2, 643, DateTimeKind.Utc).AddTicks(1413) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "DepartmentCode", "DepartmentName", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 25, 3, 8, 2, 643, DateTimeKind.Utc).AddTicks(1415), "DU1", "DU1", new DateTime(2025, 5, 25, 3, 8, 2, 643, DateTimeKind.Utc).AddTicks(1415) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "DepartmentCode", "DepartmentName", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 25, 3, 8, 2, 643, DateTimeKind.Utc).AddTicks(1416), "DU2", "DU2", new DateTime(2025, 5, 25, 3, 8, 2, 643, DateTimeKind.Utc).AddTicks(1417) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "DepartmentCode", "DepartmentName", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 25, 3, 8, 2, 643, DateTimeKind.Utc).AddTicks(1418), "DU3", "DU3", new DateTime(2025, 5, 25, 3, 8, 2, 643, DateTimeKind.Utc).AddTicks(1419) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "DepartmentCode", "DepartmentName", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 25, 3, 8, 2, 643, DateTimeKind.Utc).AddTicks(1477), "DU4", "DU4", new DateTime(2025, 5, 25, 3, 8, 2, 643, DateTimeKind.Utc).AddTicks(1477) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "DepartmentCode", "DepartmentName", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 25, 3, 8, 2, 643, DateTimeKind.Utc).AddTicks(1479), "DU5", "DU5", new DateTime(2025, 5, 25, 3, 8, 2, 643, DateTimeKind.Utc).AddTicks(1479) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAt", "DepartmentCode", "DepartmentName", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 25, 3, 8, 2, 643, DateTimeKind.Utc).AddTicks(1481), "DU6", "DU6", new DateTime(2025, 5, 25, 3, 8, 2, 643, DateTimeKind.Utc).AddTicks(1481) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAt", "DepartmentCode", "DepartmentName", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 25, 3, 8, 2, 643, DateTimeKind.Utc).AddTicks(1482), "MAR", "Marketing", new DateTime(2025, 5, 25, 3, 8, 2, 643, DateTimeKind.Utc).AddTicks(1483) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedAt", "DepartmentCode", "DepartmentName", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 25, 3, 8, 2, 643, DateTimeKind.Utc).AddTicks(1484), "L&D", "Learning & Development", new DateTime(2025, 5, 25, 3, 8, 2, 643, DateTimeKind.Utc).AddTicks(1484) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedAt", "DepartmentCode", "DepartmentName", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 25, 3, 8, 2, 643, DateTimeKind.Utc).AddTicks(1485), "FIN", "Finance", new DateTime(2025, 5, 25, 3, 8, 2, 643, DateTimeKind.Utc).AddTicks(1486) });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 25, 3, 8, 2, 643, DateTimeKind.Utc).AddTicks(1763), new DateTime(2025, 5, 25, 3, 8, 2, 643, DateTimeKind.Utc).AddTicks(1764) });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 25, 3, 8, 2, 643, DateTimeKind.Utc).AddTicks(1766), new DateTime(2025, 5, 25, 3, 8, 2, 643, DateTimeKind.Utc).AddTicks(1767) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "DepartmentId", "Email", "Password", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 25, 3, 8, 2, 643, DateTimeKind.Utc).AddTicks(1701), 1, "riskex@experionglobal.com", "AQAAAAIAAYagAAAAEAaroqhRU1q5tzEl35QYww+8xRNB3KLD6rrlXLdANJ8N2kUrAXvLsEYOpWldjgmzMg==", new DateTime(2025, 5, 25, 3, 8, 2, 643, DateTimeKind.Utc).AddTicks(1702) });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "CreatedById", "DepartmentId", "Email", "FullName", "IsActive", "Password", "UpdatedAt", "UpdatedById" },
                values: new object[] { 2, new DateTime(2025, 5, 25, 3, 8, 2, 643, DateTimeKind.Utc).AddTicks(1704), null, 1, "admin@gmail.com", "System Admin", true, "AQAAAAIAAYagAAAAEAaroqhRU1q5tzEl35QYww+8xRNB3KLD6rrlXLdANJ8N2kUrAXvLsEYOpWldjgmzMg==", new DateTime(2025, 5, 25, 3, 8, 2, 643, DateTimeKind.Utc).AddTicks(1705), null });

            migrationBuilder.CreateIndex(
                name: "IX_Risks_DepartmentId_RiskStatus",
                table: "Risks",
                columns: new[] { "DepartmentId", "RiskStatus" });

            migrationBuilder.CreateIndex(
                name: "IX_Risks_RiskStatus",
                table: "Risks",
                column: "RiskStatus");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Risks_DepartmentId_RiskStatus",
                table: "Risks");

            migrationBuilder.DropIndex(
                name: "IX_Risks_RiskStatus",
                table: "Risks");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.UpdateData(
                table: "AssessmentsBasis",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 2, 5, 7, 18, 1, 476, DateTimeKind.Utc).AddTicks(5542), new DateTime(2025, 2, 5, 7, 18, 1, 476, DateTimeKind.Utc).AddTicks(5542) });

            migrationBuilder.UpdateData(
                table: "AssessmentsBasis",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 2, 5, 7, 18, 1, 476, DateTimeKind.Utc).AddTicks(5543), new DateTime(2025, 2, 5, 7, 18, 1, 476, DateTimeKind.Utc).AddTicks(5544) });

            migrationBuilder.UpdateData(
                table: "AssessmentsBasis",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 2, 5, 7, 18, 1, 476, DateTimeKind.Utc).AddTicks(5585), new DateTime(2025, 2, 5, 7, 18, 1, 476, DateTimeKind.Utc).AddTicks(5585) });

            migrationBuilder.UpdateData(
                table: "AssessmentsBasis",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 2, 5, 7, 18, 1, 476, DateTimeKind.Utc).AddTicks(5586), new DateTime(2025, 2, 5, 7, 18, 1, 476, DateTimeKind.Utc).AddTicks(5587) });

            migrationBuilder.UpdateData(
                table: "AssessmentsMatrixImpact",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Definition", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 2, 5, 7, 18, 1, 476, DateTimeKind.Utc).AddTicks(5630), "No/slight effect on business", new DateTime(2025, 2, 5, 7, 18, 1, 476, DateTimeKind.Utc).AddTicks(5631) });

            migrationBuilder.UpdateData(
                table: "AssessmentsMatrixImpact",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Definition", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 2, 5, 7, 18, 1, 476, DateTimeKind.Utc).AddTicks(5632), "business objectives affected", new DateTime(2025, 2, 5, 7, 18, 1, 476, DateTimeKind.Utc).AddTicks(5633) });

            migrationBuilder.UpdateData(
                table: "AssessmentsMatrixImpact",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Definition", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 2, 5, 7, 18, 1, 476, DateTimeKind.Utc).AddTicks(5634), "business objectives undermined", new DateTime(2025, 2, 5, 7, 18, 1, 476, DateTimeKind.Utc).AddTicks(5635) });

            migrationBuilder.UpdateData(
                table: "AssessmentsMatrixImpact",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "Definition", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 2, 5, 7, 18, 1, 476, DateTimeKind.Utc).AddTicks(5636), "business objectives not accomplished", new DateTime(2025, 2, 5, 7, 18, 1, 476, DateTimeKind.Utc).AddTicks(5636) });

            migrationBuilder.UpdateData(
                table: "AssessmentsMatrixLikelihood",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 2, 5, 7, 18, 1, 476, DateTimeKind.Utc).AddTicks(5655), new DateTime(2025, 2, 5, 7, 18, 1, 476, DateTimeKind.Utc).AddTicks(5656) });

            migrationBuilder.UpdateData(
                table: "AssessmentsMatrixLikelihood",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 2, 5, 7, 18, 1, 476, DateTimeKind.Utc).AddTicks(5657), new DateTime(2025, 2, 5, 7, 18, 1, 476, DateTimeKind.Utc).AddTicks(5657) });

            migrationBuilder.UpdateData(
                table: "AssessmentsMatrixLikelihood",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 2, 5, 7, 18, 1, 476, DateTimeKind.Utc).AddTicks(5659), new DateTime(2025, 2, 5, 7, 18, 1, 476, DateTimeKind.Utc).AddTicks(5659) });

            migrationBuilder.UpdateData(
                table: "AssessmentsMatrixLikelihood",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 2, 5, 7, 18, 1, 476, DateTimeKind.Utc).AddTicks(5660), new DateTime(2025, 2, 5, 7, 18, 1, 476, DateTimeKind.Utc).AddTicks(5661) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "DepartmentCode", "DepartmentName", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 2, 5, 7, 18, 1, 476, DateTimeKind.Utc).AddTicks(5320), null, "SFM", new DateTime(2025, 2, 5, 7, 18, 1, 476, DateTimeKind.Utc).AddTicks(5324) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "DepartmentCode", "DepartmentName", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 2, 5, 7, 18, 1, 476, DateTimeKind.Utc).AddTicks(5325), null, "HR", new DateTime(2025, 2, 5, 7, 18, 1, 476, DateTimeKind.Utc).AddTicks(5326) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "DepartmentCode", "DepartmentName", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 2, 5, 7, 18, 1, 476, DateTimeKind.Utc).AddTicks(5327), null, "Finance", new DateTime(2025, 2, 5, 7, 18, 1, 476, DateTimeKind.Utc).AddTicks(5327) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "DepartmentCode", "DepartmentName", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 2, 5, 7, 18, 1, 476, DateTimeKind.Utc).AddTicks(5329), null, "Admin & Purchase", new DateTime(2025, 2, 5, 7, 18, 1, 476, DateTimeKind.Utc).AddTicks(5329) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "DepartmentCode", "DepartmentName", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 2, 5, 7, 18, 1, 476, DateTimeKind.Utc).AddTicks(5330), null, "DU1", new DateTime(2025, 2, 5, 7, 18, 1, 476, DateTimeKind.Utc).AddTicks(5331) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "DepartmentCode", "DepartmentName", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 2, 5, 7, 18, 1, 476, DateTimeKind.Utc).AddTicks(5332), null, "DU2", new DateTime(2025, 2, 5, 7, 18, 1, 476, DateTimeKind.Utc).AddTicks(5332) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "DepartmentCode", "DepartmentName", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 2, 5, 7, 18, 1, 476, DateTimeKind.Utc).AddTicks(5333), null, "DU3", new DateTime(2025, 2, 5, 7, 18, 1, 476, DateTimeKind.Utc).AddTicks(5333) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "DepartmentCode", "DepartmentName", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 2, 5, 7, 18, 1, 476, DateTimeKind.Utc).AddTicks(5334), null, "DU4", new DateTime(2025, 2, 5, 7, 18, 1, 476, DateTimeKind.Utc).AddTicks(5335) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "DepartmentCode", "DepartmentName", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 2, 5, 7, 18, 1, 476, DateTimeKind.Utc).AddTicks(5336), null, "DU5", new DateTime(2025, 2, 5, 7, 18, 1, 476, DateTimeKind.Utc).AddTicks(5336) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "DepartmentCode", "DepartmentName", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 2, 5, 7, 18, 1, 476, DateTimeKind.Utc).AddTicks(5337), null, "DU6", new DateTime(2025, 2, 5, 7, 18, 1, 476, DateTimeKind.Utc).AddTicks(5338) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAt", "DepartmentCode", "DepartmentName", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 2, 5, 7, 18, 1, 476, DateTimeKind.Utc).AddTicks(5339), null, "Data & Analytics", new DateTime(2025, 2, 5, 7, 18, 1, 476, DateTimeKind.Utc).AddTicks(5339) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAt", "DepartmentCode", "DepartmentName", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 2, 5, 7, 18, 1, 476, DateTimeKind.Utc).AddTicks(5340), null, "Design Services", new DateTime(2025, 2, 5, 7, 18, 1, 476, DateTimeKind.Utc).AddTicks(5341) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedAt", "DepartmentCode", "DepartmentName", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 2, 5, 7, 18, 1, 476, DateTimeKind.Utc).AddTicks(5343), null, "Testing Services", new DateTime(2025, 2, 5, 7, 18, 1, 476, DateTimeKind.Utc).AddTicks(5343) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedAt", "DepartmentCode", "DepartmentName", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 2, 5, 7, 18, 1, 476, DateTimeKind.Utc).AddTicks(5344), null, "Marketing", new DateTime(2025, 2, 5, 7, 18, 1, 476, DateTimeKind.Utc).AddTicks(5344) });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "CreatedAt", "DepartmentCode", "DepartmentName", "NewName", "UpdatedAt" },
                values: new object[,]
                {
                    { 15, new DateTime(2025, 2, 5, 7, 18, 1, 476, DateTimeKind.Utc).AddTicks(5345), null, "Business Solution Group", null, new DateTime(2025, 2, 5, 7, 18, 1, 476, DateTimeKind.Utc).AddTicks(5346) },
                    { 16, new DateTime(2025, 2, 5, 7, 18, 1, 476, DateTimeKind.Utc).AddTicks(5347), null, "Learning & Development", null, new DateTime(2025, 2, 5, 7, 18, 1, 476, DateTimeKind.Utc).AddTicks(5347) },
                    { 17, new DateTime(2025, 2, 5, 7, 18, 1, 476, DateTimeKind.Utc).AddTicks(5348), null, "Audits & Compliance", null, new DateTime(2025, 2, 5, 7, 18, 1, 476, DateTimeKind.Utc).AddTicks(5349) }
                });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 2, 5, 7, 18, 1, 476, DateTimeKind.Utc).AddTicks(5609), new DateTime(2025, 2, 5, 7, 18, 1, 476, DateTimeKind.Utc).AddTicks(5609) });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 2, 5, 7, 18, 1, 476, DateTimeKind.Utc).AddTicks(5611), new DateTime(2025, 2, 5, 7, 18, 1, 476, DateTimeKind.Utc).AddTicks(5612) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "DepartmentId", "Email", "Password", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 2, 5, 7, 18, 1, 476, DateTimeKind.Utc).AddTicks(5519), 17, "admin@gmail.com", "admin@123", new DateTime(2025, 2, 5, 7, 18, 1, 476, DateTimeKind.Utc).AddTicks(5520) });
        }
    }
}
