using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Risk_Management_RiskEX_Backend.Migrations
{
    /// <inheritdoc />
    public partial class AddIsHideToRisk : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsHide",
                table: "Risks",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "AssessmentsBasis",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 25, 14, 20, 16, 655, DateTimeKind.Utc).AddTicks(9198), new DateTime(2026, 1, 25, 14, 20, 16, 655, DateTimeKind.Utc).AddTicks(9199) });

            migrationBuilder.UpdateData(
                table: "AssessmentsBasis",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 25, 14, 20, 16, 655, DateTimeKind.Utc).AddTicks(9200), new DateTime(2026, 1, 25, 14, 20, 16, 655, DateTimeKind.Utc).AddTicks(9200) });

            migrationBuilder.UpdateData(
                table: "AssessmentsBasis",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 25, 14, 20, 16, 655, DateTimeKind.Utc).AddTicks(9201), new DateTime(2026, 1, 25, 14, 20, 16, 655, DateTimeKind.Utc).AddTicks(9202) });

            migrationBuilder.UpdateData(
                table: "AssessmentsBasis",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 25, 14, 20, 16, 655, DateTimeKind.Utc).AddTicks(9203), new DateTime(2026, 1, 25, 14, 20, 16, 655, DateTimeKind.Utc).AddTicks(9203) });

            migrationBuilder.UpdateData(
                table: "AssessmentsMatrixImpact",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 25, 14, 20, 16, 655, DateTimeKind.Utc).AddTicks(9221), new DateTime(2026, 1, 25, 14, 20, 16, 655, DateTimeKind.Utc).AddTicks(9221) });

            migrationBuilder.UpdateData(
                table: "AssessmentsMatrixImpact",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 25, 14, 20, 16, 655, DateTimeKind.Utc).AddTicks(9223), new DateTime(2026, 1, 25, 14, 20, 16, 655, DateTimeKind.Utc).AddTicks(9223) });

            migrationBuilder.UpdateData(
                table: "AssessmentsMatrixImpact",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 25, 14, 20, 16, 655, DateTimeKind.Utc).AddTicks(9224), new DateTime(2026, 1, 25, 14, 20, 16, 655, DateTimeKind.Utc).AddTicks(9225) });

            migrationBuilder.UpdateData(
                table: "AssessmentsMatrixImpact",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 25, 14, 20, 16, 655, DateTimeKind.Utc).AddTicks(9226), new DateTime(2026, 1, 25, 14, 20, 16, 655, DateTimeKind.Utc).AddTicks(9226) });

            migrationBuilder.UpdateData(
                table: "AssessmentsMatrixLikelihood",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 25, 14, 20, 16, 655, DateTimeKind.Utc).AddTicks(9241), new DateTime(2026, 1, 25, 14, 20, 16, 655, DateTimeKind.Utc).AddTicks(9241) });

            migrationBuilder.UpdateData(
                table: "AssessmentsMatrixLikelihood",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 25, 14, 20, 16, 655, DateTimeKind.Utc).AddTicks(9243), new DateTime(2026, 1, 25, 14, 20, 16, 655, DateTimeKind.Utc).AddTicks(9243) });

            migrationBuilder.UpdateData(
                table: "AssessmentsMatrixLikelihood",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 25, 14, 20, 16, 655, DateTimeKind.Utc).AddTicks(9245), new DateTime(2026, 1, 25, 14, 20, 16, 655, DateTimeKind.Utc).AddTicks(9245) });

            migrationBuilder.UpdateData(
                table: "AssessmentsMatrixLikelihood",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 25, 14, 20, 16, 655, DateTimeKind.Utc).AddTicks(9246), new DateTime(2026, 1, 25, 14, 20, 16, 655, DateTimeKind.Utc).AddTicks(9247) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 25, 14, 20, 16, 655, DateTimeKind.Utc).AddTicks(8894), new DateTime(2026, 1, 25, 14, 20, 16, 655, DateTimeKind.Utc).AddTicks(8898) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 25, 14, 20, 16, 655, DateTimeKind.Utc).AddTicks(8900), new DateTime(2026, 1, 25, 14, 20, 16, 655, DateTimeKind.Utc).AddTicks(8900) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 25, 14, 20, 16, 655, DateTimeKind.Utc).AddTicks(8902), new DateTime(2026, 1, 25, 14, 20, 16, 655, DateTimeKind.Utc).AddTicks(8902) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 25, 14, 20, 16, 655, DateTimeKind.Utc).AddTicks(8903), new DateTime(2026, 1, 25, 14, 20, 16, 655, DateTimeKind.Utc).AddTicks(8903) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 25, 14, 20, 16, 655, DateTimeKind.Utc).AddTicks(8904), new DateTime(2026, 1, 25, 14, 20, 16, 655, DateTimeKind.Utc).AddTicks(8905) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 25, 14, 20, 16, 655, DateTimeKind.Utc).AddTicks(8906), new DateTime(2026, 1, 25, 14, 20, 16, 655, DateTimeKind.Utc).AddTicks(8906) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 25, 14, 20, 16, 655, DateTimeKind.Utc).AddTicks(8907), new DateTime(2026, 1, 25, 14, 20, 16, 655, DateTimeKind.Utc).AddTicks(8908) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 25, 14, 20, 16, 655, DateTimeKind.Utc).AddTicks(8909), new DateTime(2026, 1, 25, 14, 20, 16, 655, DateTimeKind.Utc).AddTicks(8909) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 25, 14, 20, 16, 655, DateTimeKind.Utc).AddTicks(8910), new DateTime(2026, 1, 25, 14, 20, 16, 655, DateTimeKind.Utc).AddTicks(8911) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 25, 14, 20, 16, 655, DateTimeKind.Utc).AddTicks(8912), new DateTime(2026, 1, 25, 14, 20, 16, 655, DateTimeKind.Utc).AddTicks(8912) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 25, 14, 20, 16, 655, DateTimeKind.Utc).AddTicks(8913), new DateTime(2026, 1, 25, 14, 20, 16, 655, DateTimeKind.Utc).AddTicks(8914) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 25, 14, 20, 16, 655, DateTimeKind.Utc).AddTicks(8915), new DateTime(2026, 1, 25, 14, 20, 16, 655, DateTimeKind.Utc).AddTicks(8915) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 25, 14, 20, 16, 655, DateTimeKind.Utc).AddTicks(8916), new DateTime(2026, 1, 25, 14, 20, 16, 655, DateTimeKind.Utc).AddTicks(8917) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 25, 14, 20, 16, 655, DateTimeKind.Utc).AddTicks(8918), new DateTime(2026, 1, 25, 14, 20, 16, 655, DateTimeKind.Utc).AddTicks(8918) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 25, 14, 20, 16, 655, DateTimeKind.Utc).AddTicks(9119), new DateTime(2026, 1, 25, 14, 20, 16, 655, DateTimeKind.Utc).AddTicks(9119) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 25, 14, 20, 16, 655, DateTimeKind.Utc).AddTicks(9174), new DateTime(2026, 1, 25, 14, 20, 16, 655, DateTimeKind.Utc).AddTicks(9174) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsHide",
                table: "Risks");

            migrationBuilder.UpdateData(
                table: "AssessmentsBasis",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 25, 5, 20, 35, 844, DateTimeKind.Utc).AddTicks(5308), new DateTime(2026, 1, 25, 5, 20, 35, 844, DateTimeKind.Utc).AddTicks(5309) });

            migrationBuilder.UpdateData(
                table: "AssessmentsBasis",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 25, 5, 20, 35, 844, DateTimeKind.Utc).AddTicks(5310), new DateTime(2026, 1, 25, 5, 20, 35, 844, DateTimeKind.Utc).AddTicks(5311) });

            migrationBuilder.UpdateData(
                table: "AssessmentsBasis",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 25, 5, 20, 35, 844, DateTimeKind.Utc).AddTicks(5312), new DateTime(2026, 1, 25, 5, 20, 35, 844, DateTimeKind.Utc).AddTicks(5313) });

            migrationBuilder.UpdateData(
                table: "AssessmentsBasis",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 25, 5, 20, 35, 844, DateTimeKind.Utc).AddTicks(5314), new DateTime(2026, 1, 25, 5, 20, 35, 844, DateTimeKind.Utc).AddTicks(5315) });

            migrationBuilder.UpdateData(
                table: "AssessmentsMatrixImpact",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 25, 5, 20, 35, 844, DateTimeKind.Utc).AddTicks(5338), new DateTime(2026, 1, 25, 5, 20, 35, 844, DateTimeKind.Utc).AddTicks(5338) });

            migrationBuilder.UpdateData(
                table: "AssessmentsMatrixImpact",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 25, 5, 20, 35, 844, DateTimeKind.Utc).AddTicks(5340), new DateTime(2026, 1, 25, 5, 20, 35, 844, DateTimeKind.Utc).AddTicks(5341) });

            migrationBuilder.UpdateData(
                table: "AssessmentsMatrixImpact",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 25, 5, 20, 35, 844, DateTimeKind.Utc).AddTicks(5343), new DateTime(2026, 1, 25, 5, 20, 35, 844, DateTimeKind.Utc).AddTicks(5343) });

            migrationBuilder.UpdateData(
                table: "AssessmentsMatrixImpact",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 25, 5, 20, 35, 844, DateTimeKind.Utc).AddTicks(5345), new DateTime(2026, 1, 25, 5, 20, 35, 844, DateTimeKind.Utc).AddTicks(5345) });

            migrationBuilder.UpdateData(
                table: "AssessmentsMatrixLikelihood",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 25, 5, 20, 35, 844, DateTimeKind.Utc).AddTicks(5368), new DateTime(2026, 1, 25, 5, 20, 35, 844, DateTimeKind.Utc).AddTicks(5369) });

            migrationBuilder.UpdateData(
                table: "AssessmentsMatrixLikelihood",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 25, 5, 20, 35, 844, DateTimeKind.Utc).AddTicks(5371), new DateTime(2026, 1, 25, 5, 20, 35, 844, DateTimeKind.Utc).AddTicks(5372) });

            migrationBuilder.UpdateData(
                table: "AssessmentsMatrixLikelihood",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 25, 5, 20, 35, 844, DateTimeKind.Utc).AddTicks(5373), new DateTime(2026, 1, 25, 5, 20, 35, 844, DateTimeKind.Utc).AddTicks(5374) });

            migrationBuilder.UpdateData(
                table: "AssessmentsMatrixLikelihood",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 25, 5, 20, 35, 844, DateTimeKind.Utc).AddTicks(5376), new DateTime(2026, 1, 25, 5, 20, 35, 844, DateTimeKind.Utc).AddTicks(5376) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 25, 5, 20, 35, 844, DateTimeKind.Utc).AddTicks(4978), new DateTime(2026, 1, 25, 5, 20, 35, 844, DateTimeKind.Utc).AddTicks(4982) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 25, 5, 20, 35, 844, DateTimeKind.Utc).AddTicks(4984), new DateTime(2026, 1, 25, 5, 20, 35, 844, DateTimeKind.Utc).AddTicks(4985) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 25, 5, 20, 35, 844, DateTimeKind.Utc).AddTicks(4987), new DateTime(2026, 1, 25, 5, 20, 35, 844, DateTimeKind.Utc).AddTicks(4988) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 25, 5, 20, 35, 844, DateTimeKind.Utc).AddTicks(4989), new DateTime(2026, 1, 25, 5, 20, 35, 844, DateTimeKind.Utc).AddTicks(4990) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 25, 5, 20, 35, 844, DateTimeKind.Utc).AddTicks(4991), new DateTime(2026, 1, 25, 5, 20, 35, 844, DateTimeKind.Utc).AddTicks(4992) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 25, 5, 20, 35, 844, DateTimeKind.Utc).AddTicks(4993), new DateTime(2026, 1, 25, 5, 20, 35, 844, DateTimeKind.Utc).AddTicks(4994) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 25, 5, 20, 35, 844, DateTimeKind.Utc).AddTicks(4995), new DateTime(2026, 1, 25, 5, 20, 35, 844, DateTimeKind.Utc).AddTicks(4996) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 25, 5, 20, 35, 844, DateTimeKind.Utc).AddTicks(4997), new DateTime(2026, 1, 25, 5, 20, 35, 844, DateTimeKind.Utc).AddTicks(4998) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 25, 5, 20, 35, 844, DateTimeKind.Utc).AddTicks(5000), new DateTime(2026, 1, 25, 5, 20, 35, 844, DateTimeKind.Utc).AddTicks(5000) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 25, 5, 20, 35, 844, DateTimeKind.Utc).AddTicks(5002), new DateTime(2026, 1, 25, 5, 20, 35, 844, DateTimeKind.Utc).AddTicks(5002) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 25, 5, 20, 35, 844, DateTimeKind.Utc).AddTicks(5004), new DateTime(2026, 1, 25, 5, 20, 35, 844, DateTimeKind.Utc).AddTicks(5004) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 25, 5, 20, 35, 844, DateTimeKind.Utc).AddTicks(5006), new DateTime(2026, 1, 25, 5, 20, 35, 844, DateTimeKind.Utc).AddTicks(5007) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 25, 5, 20, 35, 844, DateTimeKind.Utc).AddTicks(5008), new DateTime(2026, 1, 25, 5, 20, 35, 844, DateTimeKind.Utc).AddTicks(5009) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 25, 5, 20, 35, 844, DateTimeKind.Utc).AddTicks(5039), new DateTime(2026, 1, 25, 5, 20, 35, 844, DateTimeKind.Utc).AddTicks(5040) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 25, 5, 20, 35, 844, DateTimeKind.Utc).AddTicks(5271), new DateTime(2026, 1, 25, 5, 20, 35, 844, DateTimeKind.Utc).AddTicks(5272) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 25, 5, 20, 35, 844, DateTimeKind.Utc).AddTicks(5275), new DateTime(2026, 1, 25, 5, 20, 35, 844, DateTimeKind.Utc).AddTicks(5275) });
        }
    }
}
