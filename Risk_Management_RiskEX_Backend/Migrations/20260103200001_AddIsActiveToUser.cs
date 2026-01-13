using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Risk_Management_RiskEX_Backend.Migrations
{
    /// <inheritdoc />
    public partial class AddIsActiveToUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Reviews",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "AssessmentsBasis",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 3, 20, 0, 1, 102, DateTimeKind.Utc).AddTicks(85), new DateTime(2026, 1, 3, 20, 0, 1, 102, DateTimeKind.Utc).AddTicks(86) });

            migrationBuilder.UpdateData(
                table: "AssessmentsBasis",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 3, 20, 0, 1, 102, DateTimeKind.Utc).AddTicks(87), new DateTime(2026, 1, 3, 20, 0, 1, 102, DateTimeKind.Utc).AddTicks(87) });

            migrationBuilder.UpdateData(
                table: "AssessmentsBasis",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 3, 20, 0, 1, 102, DateTimeKind.Utc).AddTicks(88), new DateTime(2026, 1, 3, 20, 0, 1, 102, DateTimeKind.Utc).AddTicks(89) });

            migrationBuilder.UpdateData(
                table: "AssessmentsBasis",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 3, 20, 0, 1, 102, DateTimeKind.Utc).AddTicks(90), new DateTime(2026, 1, 3, 20, 0, 1, 102, DateTimeKind.Utc).AddTicks(90) });

            migrationBuilder.UpdateData(
                table: "AssessmentsMatrixImpact",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 3, 20, 0, 1, 102, DateTimeKind.Utc).AddTicks(109), new DateTime(2026, 1, 3, 20, 0, 1, 102, DateTimeKind.Utc).AddTicks(109) });

            migrationBuilder.UpdateData(
                table: "AssessmentsMatrixImpact",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 3, 20, 0, 1, 102, DateTimeKind.Utc).AddTicks(111), new DateTime(2026, 1, 3, 20, 0, 1, 102, DateTimeKind.Utc).AddTicks(111) });

            migrationBuilder.UpdateData(
                table: "AssessmentsMatrixImpact",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 3, 20, 0, 1, 102, DateTimeKind.Utc).AddTicks(112), new DateTime(2026, 1, 3, 20, 0, 1, 102, DateTimeKind.Utc).AddTicks(113) });

            migrationBuilder.UpdateData(
                table: "AssessmentsMatrixImpact",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 3, 20, 0, 1, 102, DateTimeKind.Utc).AddTicks(114), new DateTime(2026, 1, 3, 20, 0, 1, 102, DateTimeKind.Utc).AddTicks(115) });

            migrationBuilder.UpdateData(
                table: "AssessmentsMatrixLikelihood",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 3, 20, 0, 1, 102, DateTimeKind.Utc).AddTicks(157), new DateTime(2026, 1, 3, 20, 0, 1, 102, DateTimeKind.Utc).AddTicks(157) });

            migrationBuilder.UpdateData(
                table: "AssessmentsMatrixLikelihood",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 3, 20, 0, 1, 102, DateTimeKind.Utc).AddTicks(159), new DateTime(2026, 1, 3, 20, 0, 1, 102, DateTimeKind.Utc).AddTicks(159) });

            migrationBuilder.UpdateData(
                table: "AssessmentsMatrixLikelihood",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 3, 20, 0, 1, 102, DateTimeKind.Utc).AddTicks(161), new DateTime(2026, 1, 3, 20, 0, 1, 102, DateTimeKind.Utc).AddTicks(161) });

            migrationBuilder.UpdateData(
                table: "AssessmentsMatrixLikelihood",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 3, 20, 0, 1, 102, DateTimeKind.Utc).AddTicks(163), new DateTime(2026, 1, 3, 20, 0, 1, 102, DateTimeKind.Utc).AddTicks(163) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 3, 20, 0, 1, 101, DateTimeKind.Utc).AddTicks(9820), new DateTime(2026, 1, 3, 20, 0, 1, 101, DateTimeKind.Utc).AddTicks(9823) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 3, 20, 0, 1, 101, DateTimeKind.Utc).AddTicks(9825), new DateTime(2026, 1, 3, 20, 0, 1, 101, DateTimeKind.Utc).AddTicks(9825) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 3, 20, 0, 1, 101, DateTimeKind.Utc).AddTicks(9827), new DateTime(2026, 1, 3, 20, 0, 1, 101, DateTimeKind.Utc).AddTicks(9827) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 3, 20, 0, 1, 101, DateTimeKind.Utc).AddTicks(9828), new DateTime(2026, 1, 3, 20, 0, 1, 101, DateTimeKind.Utc).AddTicks(9829) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 3, 20, 0, 1, 101, DateTimeKind.Utc).AddTicks(9830), new DateTime(2026, 1, 3, 20, 0, 1, 101, DateTimeKind.Utc).AddTicks(9830) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 3, 20, 0, 1, 101, DateTimeKind.Utc).AddTicks(9831), new DateTime(2026, 1, 3, 20, 0, 1, 101, DateTimeKind.Utc).AddTicks(9832) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 3, 20, 0, 1, 101, DateTimeKind.Utc).AddTicks(9833), new DateTime(2026, 1, 3, 20, 0, 1, 101, DateTimeKind.Utc).AddTicks(9833) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 3, 20, 0, 1, 101, DateTimeKind.Utc).AddTicks(9834), new DateTime(2026, 1, 3, 20, 0, 1, 101, DateTimeKind.Utc).AddTicks(9835) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 3, 20, 0, 1, 101, DateTimeKind.Utc).AddTicks(9836), new DateTime(2026, 1, 3, 20, 0, 1, 101, DateTimeKind.Utc).AddTicks(9837) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 3, 20, 0, 1, 101, DateTimeKind.Utc).AddTicks(9838), new DateTime(2026, 1, 3, 20, 0, 1, 101, DateTimeKind.Utc).AddTicks(9838) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 3, 20, 0, 1, 101, DateTimeKind.Utc).AddTicks(9839), new DateTime(2026, 1, 3, 20, 0, 1, 101, DateTimeKind.Utc).AddTicks(9840) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 3, 20, 0, 1, 101, DateTimeKind.Utc).AddTicks(9841), new DateTime(2026, 1, 3, 20, 0, 1, 101, DateTimeKind.Utc).AddTicks(9841) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 3, 20, 0, 1, 101, DateTimeKind.Utc).AddTicks(9842), new DateTime(2026, 1, 3, 20, 0, 1, 101, DateTimeKind.Utc).AddTicks(9843) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 3, 20, 0, 1, 101, DateTimeKind.Utc).AddTicks(9844), new DateTime(2026, 1, 3, 20, 0, 1, 101, DateTimeKind.Utc).AddTicks(9844) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 3, 20, 0, 1, 102, DateTimeKind.Utc).AddTicks(60), new DateTime(2026, 1, 3, 20, 0, 1, 102, DateTimeKind.Utc).AddTicks(60) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 3, 20, 0, 1, 102, DateTimeKind.Utc).AddTicks(62), new DateTime(2026, 1, 3, 20, 0, 1, 102, DateTimeKind.Utc).AddTicks(63) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Reviews");

            migrationBuilder.UpdateData(
                table: "AssessmentsBasis",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 24, 3, 26, 49, 316, DateTimeKind.Utc).AddTicks(1608), new DateTime(2025, 9, 24, 3, 26, 49, 316, DateTimeKind.Utc).AddTicks(1608) });

            migrationBuilder.UpdateData(
                table: "AssessmentsBasis",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 24, 3, 26, 49, 316, DateTimeKind.Utc).AddTicks(1610), new DateTime(2025, 9, 24, 3, 26, 49, 316, DateTimeKind.Utc).AddTicks(1611) });

            migrationBuilder.UpdateData(
                table: "AssessmentsBasis",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 24, 3, 26, 49, 316, DateTimeKind.Utc).AddTicks(1612), new DateTime(2025, 9, 24, 3, 26, 49, 316, DateTimeKind.Utc).AddTicks(1613) });

            migrationBuilder.UpdateData(
                table: "AssessmentsBasis",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 24, 3, 26, 49, 316, DateTimeKind.Utc).AddTicks(1614), new DateTime(2025, 9, 24, 3, 26, 49, 316, DateTimeKind.Utc).AddTicks(1615) });

            migrationBuilder.UpdateData(
                table: "AssessmentsMatrixImpact",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 24, 3, 26, 49, 316, DateTimeKind.Utc).AddTicks(1637), new DateTime(2025, 9, 24, 3, 26, 49, 316, DateTimeKind.Utc).AddTicks(1638) });

            migrationBuilder.UpdateData(
                table: "AssessmentsMatrixImpact",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 24, 3, 26, 49, 316, DateTimeKind.Utc).AddTicks(1640), new DateTime(2025, 9, 24, 3, 26, 49, 316, DateTimeKind.Utc).AddTicks(1641) });

            migrationBuilder.UpdateData(
                table: "AssessmentsMatrixImpact",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 24, 3, 26, 49, 316, DateTimeKind.Utc).AddTicks(1642), new DateTime(2025, 9, 24, 3, 26, 49, 316, DateTimeKind.Utc).AddTicks(1643) });

            migrationBuilder.UpdateData(
                table: "AssessmentsMatrixImpact",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 24, 3, 26, 49, 316, DateTimeKind.Utc).AddTicks(1645), new DateTime(2025, 9, 24, 3, 26, 49, 316, DateTimeKind.Utc).AddTicks(1645) });

            migrationBuilder.UpdateData(
                table: "AssessmentsMatrixLikelihood",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 24, 3, 26, 49, 316, DateTimeKind.Utc).AddTicks(1675), new DateTime(2025, 9, 24, 3, 26, 49, 316, DateTimeKind.Utc).AddTicks(1676) });

            migrationBuilder.UpdateData(
                table: "AssessmentsMatrixLikelihood",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 24, 3, 26, 49, 316, DateTimeKind.Utc).AddTicks(1678), new DateTime(2025, 9, 24, 3, 26, 49, 316, DateTimeKind.Utc).AddTicks(1679) });

            migrationBuilder.UpdateData(
                table: "AssessmentsMatrixLikelihood",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 24, 3, 26, 49, 316, DateTimeKind.Utc).AddTicks(1681), new DateTime(2025, 9, 24, 3, 26, 49, 316, DateTimeKind.Utc).AddTicks(1681) });

            migrationBuilder.UpdateData(
                table: "AssessmentsMatrixLikelihood",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 24, 3, 26, 49, 316, DateTimeKind.Utc).AddTicks(1683), new DateTime(2025, 9, 24, 3, 26, 49, 316, DateTimeKind.Utc).AddTicks(1684) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 24, 3, 26, 49, 316, DateTimeKind.Utc).AddTicks(1295), new DateTime(2025, 9, 24, 3, 26, 49, 316, DateTimeKind.Utc).AddTicks(1299) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 24, 3, 26, 49, 316, DateTimeKind.Utc).AddTicks(1301), new DateTime(2025, 9, 24, 3, 26, 49, 316, DateTimeKind.Utc).AddTicks(1302) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 24, 3, 26, 49, 316, DateTimeKind.Utc).AddTicks(1304), new DateTime(2025, 9, 24, 3, 26, 49, 316, DateTimeKind.Utc).AddTicks(1305) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 24, 3, 26, 49, 316, DateTimeKind.Utc).AddTicks(1306), new DateTime(2025, 9, 24, 3, 26, 49, 316, DateTimeKind.Utc).AddTicks(1307) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 24, 3, 26, 49, 316, DateTimeKind.Utc).AddTicks(1309), new DateTime(2025, 9, 24, 3, 26, 49, 316, DateTimeKind.Utc).AddTicks(1309) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 24, 3, 26, 49, 316, DateTimeKind.Utc).AddTicks(1311), new DateTime(2025, 9, 24, 3, 26, 49, 316, DateTimeKind.Utc).AddTicks(1312) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 24, 3, 26, 49, 316, DateTimeKind.Utc).AddTicks(1313), new DateTime(2025, 9, 24, 3, 26, 49, 316, DateTimeKind.Utc).AddTicks(1314) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 24, 3, 26, 49, 316, DateTimeKind.Utc).AddTicks(1315), new DateTime(2025, 9, 24, 3, 26, 49, 316, DateTimeKind.Utc).AddTicks(1316) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 24, 3, 26, 49, 316, DateTimeKind.Utc).AddTicks(1318), new DateTime(2025, 9, 24, 3, 26, 49, 316, DateTimeKind.Utc).AddTicks(1319) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 24, 3, 26, 49, 316, DateTimeKind.Utc).AddTicks(1320), new DateTime(2025, 9, 24, 3, 26, 49, 316, DateTimeKind.Utc).AddTicks(1321) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 24, 3, 26, 49, 316, DateTimeKind.Utc).AddTicks(1322), new DateTime(2025, 9, 24, 3, 26, 49, 316, DateTimeKind.Utc).AddTicks(1323) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 24, 3, 26, 49, 316, DateTimeKind.Utc).AddTicks(1325), new DateTime(2025, 9, 24, 3, 26, 49, 316, DateTimeKind.Utc).AddTicks(1325) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 24, 3, 26, 49, 316, DateTimeKind.Utc).AddTicks(1327), new DateTime(2025, 9, 24, 3, 26, 49, 316, DateTimeKind.Utc).AddTicks(1328) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 24, 3, 26, 49, 316, DateTimeKind.Utc).AddTicks(1329), new DateTime(2025, 9, 24, 3, 26, 49, 316, DateTimeKind.Utc).AddTicks(1330) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 24, 3, 26, 49, 316, DateTimeKind.Utc).AddTicks(1562), new DateTime(2025, 9, 24, 3, 26, 49, 316, DateTimeKind.Utc).AddTicks(1563) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 24, 3, 26, 49, 316, DateTimeKind.Utc).AddTicks(1566), new DateTime(2025, 9, 24, 3, 26, 49, 316, DateTimeKind.Utc).AddTicks(1567) });
        }
    }
}
