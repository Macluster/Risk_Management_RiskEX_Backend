using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Risk_Management_RiskEX_Backend.Migrations
{
    /// <inheritdoc />
    public partial class DataEntry : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AssessmentsBasis",
                columns: new[] { "Id", "Basis", "CreatedAt", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, "Confidentiality", new DateTime(2024, 12, 26, 11, 18, 49, 814, DateTimeKind.Utc).AddTicks(8700), new DateTime(2024, 12, 26, 11, 18, 49, 814, DateTimeKind.Utc).AddTicks(8701) },
                    { 2, "Integrity", new DateTime(2024, 12, 26, 11, 18, 49, 814, DateTimeKind.Utc).AddTicks(8703), new DateTime(2024, 12, 26, 11, 18, 49, 814, DateTimeKind.Utc).AddTicks(8703) },
                    { 3, "Privacy", new DateTime(2024, 12, 26, 11, 18, 49, 814, DateTimeKind.Utc).AddTicks(8705), new DateTime(2024, 12, 26, 11, 18, 49, 814, DateTimeKind.Utc).AddTicks(8705) },
                    { 4, "Quality", new DateTime(2024, 12, 26, 11, 18, 49, 814, DateTimeKind.Utc).AddTicks(8707), new DateTime(2024, 12, 26, 11, 18, 49, 814, DateTimeKind.Utc).AddTicks(8707) }
                });

            migrationBuilder.InsertData(
                table: "AssessmentsMatrixImpact",
                columns: new[] { "Id", "AssessmentFactor", "CreatedAt", "Impact", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, "Low", new DateTime(2024, 12, 26, 11, 18, 49, 814, DateTimeKind.Utc).AddTicks(8759), 10.0, new DateTime(2024, 12, 26, 11, 18, 49, 814, DateTimeKind.Utc).AddTicks(8759) },
                    { 2, "Medium", new DateTime(2024, 12, 26, 11, 18, 49, 814, DateTimeKind.Utc).AddTicks(8761), 20.0, new DateTime(2024, 12, 26, 11, 18, 49, 814, DateTimeKind.Utc).AddTicks(8762) },
                    { 3, "High", new DateTime(2024, 12, 26, 11, 18, 49, 814, DateTimeKind.Utc).AddTicks(8763), 40.0, new DateTime(2024, 12, 26, 11, 18, 49, 814, DateTimeKind.Utc).AddTicks(8764) },
                    { 4, "Critical", new DateTime(2024, 12, 26, 11, 18, 49, 814, DateTimeKind.Utc).AddTicks(8765), 60.0, new DateTime(2024, 12, 26, 11, 18, 49, 814, DateTimeKind.Utc).AddTicks(8766) }
                });

            migrationBuilder.InsertData(
                table: "AssessmentsMatrixLikelihood",
                columns: new[] { "Id", "AssessmentFactor", "CreatedAt", "Likelihood", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, "Low", new DateTime(2024, 12, 26, 11, 18, 49, 814, DateTimeKind.Utc).AddTicks(8785), 0.10000000000000001, new DateTime(2024, 12, 26, 11, 18, 49, 814, DateTimeKind.Utc).AddTicks(8785) },
                    { 2, "Medium", new DateTime(2024, 12, 26, 11, 18, 49, 814, DateTimeKind.Utc).AddTicks(8787), 0.20000000000000001, new DateTime(2024, 12, 26, 11, 18, 49, 814, DateTimeKind.Utc).AddTicks(8788) },
                    { 3, "High", new DateTime(2024, 12, 26, 11, 18, 49, 814, DateTimeKind.Utc).AddTicks(8789), 0.40000000000000002, new DateTime(2024, 12, 26, 11, 18, 49, 814, DateTimeKind.Utc).AddTicks(8790) },
                    { 4, "Critical", new DateTime(2024, 12, 26, 11, 18, 49, 814, DateTimeKind.Utc).AddTicks(8791), 0.59999999999999998, new DateTime(2024, 12, 26, 11, 18, 49, 814, DateTimeKind.Utc).AddTicks(8792) }
                });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "CreatedAt", "DepartmentName", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 12, 26, 11, 18, 49, 814, DateTimeKind.Utc).AddTicks(8455), "SFM", new DateTime(2024, 12, 26, 11, 18, 49, 814, DateTimeKind.Utc).AddTicks(8458) },
                    { 2, new DateTime(2024, 12, 26, 11, 18, 49, 814, DateTimeKind.Utc).AddTicks(8460), "HR", new DateTime(2024, 12, 26, 11, 18, 49, 814, DateTimeKind.Utc).AddTicks(8461) },
                    { 3, new DateTime(2024, 12, 26, 11, 18, 49, 814, DateTimeKind.Utc).AddTicks(8463), "Finance", new DateTime(2024, 12, 26, 11, 18, 49, 814, DateTimeKind.Utc).AddTicks(8463) }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "CreatedById", "DepartmentId", "Email", "FullName", "IsActive", "Password", "UpdatedAt", "UpdatedById" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 12, 26, 11, 18, 49, 814, DateTimeKind.Utc).AddTicks(8673), null, 1, "admin@riskex.com", "System Admin", true, "Admin@123", new DateTime(2024, 12, 26, 11, 18, 49, 814, DateTimeKind.Utc).AddTicks(8673), null },
                    { 2, new DateTime(2024, 12, 26, 11, 18, 49, 814, DateTimeKind.Utc).AddTicks(8676), null, 1, "risk.manager@riskex.com", "Risk Manager", true, "Risk@123", new DateTime(2024, 12, 26, 11, 18, 49, 814, DateTimeKind.Utc).AddTicks(8677), null }
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "CreatedAt", "CreatedById", "DepartmentId", "Name", "UpdatedAt", "UpdatedById", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 12, 26, 11, 18, 49, 814, DateTimeKind.Utc).AddTicks(8730), 1, 1, "Data Center Migration", new DateTime(2024, 12, 26, 11, 18, 49, 814, DateTimeKind.Utc).AddTicks(8731), 1, 1 },
                    { 2, new DateTime(2024, 12, 26, 11, 18, 49, 814, DateTimeKind.Utc).AddTicks(8734), 1, 2, "HR Inventory", new DateTime(2024, 12, 26, 11, 18, 49, 814, DateTimeKind.Utc).AddTicks(8735), 1, 2 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AssessmentsBasis",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AssessmentsBasis",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AssessmentsBasis",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "AssessmentsBasis",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "AssessmentsMatrixImpact",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AssessmentsMatrixImpact",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AssessmentsMatrixImpact",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "AssessmentsMatrixImpact",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "AssessmentsMatrixLikelihood",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AssessmentsMatrixLikelihood",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AssessmentsMatrixLikelihood",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "AssessmentsMatrixLikelihood",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
