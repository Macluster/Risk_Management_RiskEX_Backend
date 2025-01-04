using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Risk_Management_RiskEX_Backend.Migrations
{
    /// <inheritdoc />
    public partial class NewMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "CreatedAt", "DepartmentCode", "DepartmentName", "NewName", "UpdatedAt" },
                values: new object[,]
                {
                    { 5, new DateTime(2025, 1, 4, 4, 22, 56, 795, DateTimeKind.Utc).AddTicks(8993), null, "DU1", null, new DateTime(2025, 1, 4, 4, 22, 56, 795, DateTimeKind.Utc).AddTicks(8994) },
                    { 6, new DateTime(2025, 1, 4, 4, 22, 56, 795, DateTimeKind.Utc).AddTicks(8995), null, "DU2", null, new DateTime(2025, 1, 4, 4, 22, 56, 795, DateTimeKind.Utc).AddTicks(8996) },
                    { 7, new DateTime(2025, 1, 4, 4, 22, 56, 795, DateTimeKind.Utc).AddTicks(8997), null, "DU3", null, new DateTime(2025, 1, 4, 4, 22, 56, 795, DateTimeKind.Utc).AddTicks(8998) },
                    { 8, new DateTime(2025, 1, 4, 4, 22, 56, 795, DateTimeKind.Utc).AddTicks(8999), null, "DU4", null, new DateTime(2025, 1, 4, 4, 22, 56, 795, DateTimeKind.Utc).AddTicks(9000) },
                    { 9, new DateTime(2025, 1, 4, 4, 22, 56, 795, DateTimeKind.Utc).AddTicks(9001), null, "DU5", null, new DateTime(2025, 1, 4, 4, 22, 56, 795, DateTimeKind.Utc).AddTicks(9002) },
                    { 10, new DateTime(2025, 1, 4, 4, 22, 56, 795, DateTimeKind.Utc).AddTicks(9003), null, "DU6", null, new DateTime(2025, 1, 4, 4, 22, 56, 795, DateTimeKind.Utc).AddTicks(9004) },
                    { 11, new DateTime(2025, 1, 4, 4, 22, 56, 795, DateTimeKind.Utc).AddTicks(9005), null, "Data & Analytics", null, new DateTime(2025, 1, 4, 4, 22, 56, 795, DateTimeKind.Utc).AddTicks(9006) },
                    { 12, new DateTime(2025, 1, 4, 4, 22, 56, 795, DateTimeKind.Utc).AddTicks(9007), null, "Design Services", null, new DateTime(2025, 1, 4, 4, 22, 56, 795, DateTimeKind.Utc).AddTicks(9008) },
                    { 13, new DateTime(2025, 1, 4, 4, 22, 56, 795, DateTimeKind.Utc).AddTicks(9009), null, "Testing Services", null, new DateTime(2025, 1, 4, 4, 22, 56, 795, DateTimeKind.Utc).AddTicks(9010) },
                    { 14, new DateTime(2025, 1, 4, 4, 22, 56, 795, DateTimeKind.Utc).AddTicks(9011), null, "Marketing", null, new DateTime(2025, 1, 4, 4, 22, 56, 795, DateTimeKind.Utc).AddTicks(9011) },
                    { 15, new DateTime(2025, 1, 4, 4, 22, 56, 795, DateTimeKind.Utc).AddTicks(9013), null, "Business Solution Group", null, new DateTime(2025, 1, 4, 4, 22, 56, 795, DateTimeKind.Utc).AddTicks(9014) },
                    { 16, new DateTime(2025, 1, 4, 4, 22, 56, 795, DateTimeKind.Utc).AddTicks(9015), null, "Learning & Development", null, new DateTime(2025, 1, 4, 4, 22, 56, 795, DateTimeKind.Utc).AddTicks(9016) },
                    { 17, new DateTime(2025, 1, 4, 4, 22, 56, 795, DateTimeKind.Utc).AddTicks(9017), null, "Audits & Compliance", null, new DateTime(2025, 1, 4, 4, 22, 56, 795, DateTimeKind.Utc).AddTicks(9018) }
                });

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
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 4, 4, 22, 56, 795, DateTimeKind.Utc).AddTicks(9179), new DateTime(2025, 1, 4, 4, 22, 56, 795, DateTimeKind.Utc).AddTicks(9180) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 4, 4, 22, 56, 795, DateTimeKind.Utc).AddTicks(9183), new DateTime(2025, 1, 4, 4, 22, 56, 795, DateTimeKind.Utc).AddTicks(9184) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 14);

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
                values: new object[] { new DateTime(2025, 1, 3, 11, 26, 8, 788, DateTimeKind.Utc).AddTicks(8445), new DateTime(2025, 1, 3, 11, 26, 8, 788, DateTimeKind.Utc).AddTicks(8445) });

            migrationBuilder.UpdateData(
                table: "AssessmentsBasis",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 3, 11, 26, 8, 788, DateTimeKind.Utc).AddTicks(8447), new DateTime(2025, 1, 3, 11, 26, 8, 788, DateTimeKind.Utc).AddTicks(8447) });

            migrationBuilder.UpdateData(
                table: "AssessmentsBasis",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 3, 11, 26, 8, 788, DateTimeKind.Utc).AddTicks(8448), new DateTime(2025, 1, 3, 11, 26, 8, 788, DateTimeKind.Utc).AddTicks(8449) });

            migrationBuilder.UpdateData(
                table: "AssessmentsBasis",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 3, 11, 26, 8, 788, DateTimeKind.Utc).AddTicks(8450), new DateTime(2025, 1, 3, 11, 26, 8, 788, DateTimeKind.Utc).AddTicks(8450) });

            migrationBuilder.UpdateData(
                table: "AssessmentsMatrixImpact",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 3, 11, 26, 8, 788, DateTimeKind.Utc).AddTicks(8487), new DateTime(2025, 1, 3, 11, 26, 8, 788, DateTimeKind.Utc).AddTicks(8488) });

            migrationBuilder.UpdateData(
                table: "AssessmentsMatrixImpact",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 3, 11, 26, 8, 788, DateTimeKind.Utc).AddTicks(8490), new DateTime(2025, 1, 3, 11, 26, 8, 788, DateTimeKind.Utc).AddTicks(8490) });

            migrationBuilder.UpdateData(
                table: "AssessmentsMatrixImpact",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 3, 11, 26, 8, 788, DateTimeKind.Utc).AddTicks(8491), new DateTime(2025, 1, 3, 11, 26, 8, 788, DateTimeKind.Utc).AddTicks(8492) });

            migrationBuilder.UpdateData(
                table: "AssessmentsMatrixImpact",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 3, 11, 26, 8, 788, DateTimeKind.Utc).AddTicks(8493), new DateTime(2025, 1, 3, 11, 26, 8, 788, DateTimeKind.Utc).AddTicks(8494) });

            migrationBuilder.UpdateData(
                table: "AssessmentsMatrixLikelihood",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 3, 11, 26, 8, 788, DateTimeKind.Utc).AddTicks(8515), new DateTime(2025, 1, 3, 11, 26, 8, 788, DateTimeKind.Utc).AddTicks(8515) });

            migrationBuilder.UpdateData(
                table: "AssessmentsMatrixLikelihood",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 3, 11, 26, 8, 788, DateTimeKind.Utc).AddTicks(8517), new DateTime(2025, 1, 3, 11, 26, 8, 788, DateTimeKind.Utc).AddTicks(8517) });

            migrationBuilder.UpdateData(
                table: "AssessmentsMatrixLikelihood",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 3, 11, 26, 8, 788, DateTimeKind.Utc).AddTicks(8519), new DateTime(2025, 1, 3, 11, 26, 8, 788, DateTimeKind.Utc).AddTicks(8519) });

            migrationBuilder.UpdateData(
                table: "AssessmentsMatrixLikelihood",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 3, 11, 26, 8, 788, DateTimeKind.Utc).AddTicks(8520), new DateTime(2025, 1, 3, 11, 26, 8, 788, DateTimeKind.Utc).AddTicks(8521) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 3, 11, 26, 8, 788, DateTimeKind.Utc).AddTicks(8290), new DateTime(2025, 1, 3, 11, 26, 8, 788, DateTimeKind.Utc).AddTicks(8294) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 3, 11, 26, 8, 788, DateTimeKind.Utc).AddTicks(8296), new DateTime(2025, 1, 3, 11, 26, 8, 788, DateTimeKind.Utc).AddTicks(8296) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 3, 11, 26, 8, 788, DateTimeKind.Utc).AddTicks(8297), new DateTime(2025, 1, 3, 11, 26, 8, 788, DateTimeKind.Utc).AddTicks(8298) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 3, 11, 26, 8, 788, DateTimeKind.Utc).AddTicks(8299), new DateTime(2025, 1, 3, 11, 26, 8, 788, DateTimeKind.Utc).AddTicks(8299) });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 3, 11, 26, 8, 788, DateTimeKind.Utc).AddTicks(8470), new DateTime(2025, 1, 3, 11, 26, 8, 788, DateTimeKind.Utc).AddTicks(8471) });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 3, 11, 26, 8, 788, DateTimeKind.Utc).AddTicks(8473), new DateTime(2025, 1, 3, 11, 26, 8, 788, DateTimeKind.Utc).AddTicks(8474) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 3, 11, 26, 8, 788, DateTimeKind.Utc).AddTicks(8423), new DateTime(2025, 1, 3, 11, 26, 8, 788, DateTimeKind.Utc).AddTicks(8424) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 3, 11, 26, 8, 788, DateTimeKind.Utc).AddTicks(8426), new DateTime(2025, 1, 3, 11, 26, 8, 788, DateTimeKind.Utc).AddTicks(8427) });
        }
    }
}
