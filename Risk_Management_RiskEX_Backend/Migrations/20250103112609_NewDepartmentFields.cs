using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Risk_Management_RiskEX_Backend.Migrations
{
    /// <inheritdoc />
    public partial class NewDepartmentFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DepartmentCode",
                table: "Departments",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NewName",
                table: "Departments",
                type: "text",
                nullable: true);

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
                columns: new[] { "CreatedAt", "DepartmentCode", "NewName", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 3, 11, 26, 8, 788, DateTimeKind.Utc).AddTicks(8290), null, null, new DateTime(2025, 1, 3, 11, 26, 8, 788, DateTimeKind.Utc).AddTicks(8294) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "DepartmentCode", "NewName", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 3, 11, 26, 8, 788, DateTimeKind.Utc).AddTicks(8296), null, null, new DateTime(2025, 1, 3, 11, 26, 8, 788, DateTimeKind.Utc).AddTicks(8296) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "DepartmentCode", "NewName", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 3, 11, 26, 8, 788, DateTimeKind.Utc).AddTicks(8297), null, null, new DateTime(2025, 1, 3, 11, 26, 8, 788, DateTimeKind.Utc).AddTicks(8298) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "DepartmentCode", "NewName", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 3, 11, 26, 8, 788, DateTimeKind.Utc).AddTicks(8299), null, null, new DateTime(2025, 1, 3, 11, 26, 8, 788, DateTimeKind.Utc).AddTicks(8299) });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DepartmentCode",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "NewName",
                table: "Departments");

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
    }
}
