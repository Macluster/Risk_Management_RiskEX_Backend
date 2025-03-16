using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Risk_Management_RiskEX_Backend.Migrations
{
    /// <inheritdoc />
    public partial class ResetPasss : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PasswordResetTokens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Email = table.Column<string>(type: "text", nullable: true),
                    Token = table.Column<string>(type: "text", nullable: true),
                    ExpiryDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PasswordResetTokens", x => x.Id);
                });

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
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 2, 5, 7, 18, 1, 476, DateTimeKind.Utc).AddTicks(5630), new DateTime(2025, 2, 5, 7, 18, 1, 476, DateTimeKind.Utc).AddTicks(5631) });

            migrationBuilder.UpdateData(
                table: "AssessmentsMatrixImpact",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 2, 5, 7, 18, 1, 476, DateTimeKind.Utc).AddTicks(5632), new DateTime(2025, 2, 5, 7, 18, 1, 476, DateTimeKind.Utc).AddTicks(5633) });

            migrationBuilder.UpdateData(
                table: "AssessmentsMatrixImpact",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 2, 5, 7, 18, 1, 476, DateTimeKind.Utc).AddTicks(5634), new DateTime(2025, 2, 5, 7, 18, 1, 476, DateTimeKind.Utc).AddTicks(5635) });

            migrationBuilder.UpdateData(
                table: "AssessmentsMatrixImpact",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 2, 5, 7, 18, 1, 476, DateTimeKind.Utc).AddTicks(5636), new DateTime(2025, 2, 5, 7, 18, 1, 476, DateTimeKind.Utc).AddTicks(5636) });

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
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 2, 5, 7, 18, 1, 476, DateTimeKind.Utc).AddTicks(5320), new DateTime(2025, 2, 5, 7, 18, 1, 476, DateTimeKind.Utc).AddTicks(5324) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 2, 5, 7, 18, 1, 476, DateTimeKind.Utc).AddTicks(5325), new DateTime(2025, 2, 5, 7, 18, 1, 476, DateTimeKind.Utc).AddTicks(5326) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 2, 5, 7, 18, 1, 476, DateTimeKind.Utc).AddTicks(5327), new DateTime(2025, 2, 5, 7, 18, 1, 476, DateTimeKind.Utc).AddTicks(5327) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 2, 5, 7, 18, 1, 476, DateTimeKind.Utc).AddTicks(5329), new DateTime(2025, 2, 5, 7, 18, 1, 476, DateTimeKind.Utc).AddTicks(5329) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 2, 5, 7, 18, 1, 476, DateTimeKind.Utc).AddTicks(5330), new DateTime(2025, 2, 5, 7, 18, 1, 476, DateTimeKind.Utc).AddTicks(5331) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 2, 5, 7, 18, 1, 476, DateTimeKind.Utc).AddTicks(5332), new DateTime(2025, 2, 5, 7, 18, 1, 476, DateTimeKind.Utc).AddTicks(5332) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 2, 5, 7, 18, 1, 476, DateTimeKind.Utc).AddTicks(5333), new DateTime(2025, 2, 5, 7, 18, 1, 476, DateTimeKind.Utc).AddTicks(5333) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 2, 5, 7, 18, 1, 476, DateTimeKind.Utc).AddTicks(5334), new DateTime(2025, 2, 5, 7, 18, 1, 476, DateTimeKind.Utc).AddTicks(5335) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 2, 5, 7, 18, 1, 476, DateTimeKind.Utc).AddTicks(5336), new DateTime(2025, 2, 5, 7, 18, 1, 476, DateTimeKind.Utc).AddTicks(5336) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 2, 5, 7, 18, 1, 476, DateTimeKind.Utc).AddTicks(5337), new DateTime(2025, 2, 5, 7, 18, 1, 476, DateTimeKind.Utc).AddTicks(5338) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 2, 5, 7, 18, 1, 476, DateTimeKind.Utc).AddTicks(5339), new DateTime(2025, 2, 5, 7, 18, 1, 476, DateTimeKind.Utc).AddTicks(5339) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 2, 5, 7, 18, 1, 476, DateTimeKind.Utc).AddTicks(5340), new DateTime(2025, 2, 5, 7, 18, 1, 476, DateTimeKind.Utc).AddTicks(5341) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 2, 5, 7, 18, 1, 476, DateTimeKind.Utc).AddTicks(5343), new DateTime(2025, 2, 5, 7, 18, 1, 476, DateTimeKind.Utc).AddTicks(5343) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 2, 5, 7, 18, 1, 476, DateTimeKind.Utc).AddTicks(5344), new DateTime(2025, 2, 5, 7, 18, 1, 476, DateTimeKind.Utc).AddTicks(5344) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 2, 5, 7, 18, 1, 476, DateTimeKind.Utc).AddTicks(5345), new DateTime(2025, 2, 5, 7, 18, 1, 476, DateTimeKind.Utc).AddTicks(5346) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 2, 5, 7, 18, 1, 476, DateTimeKind.Utc).AddTicks(5347), new DateTime(2025, 2, 5, 7, 18, 1, 476, DateTimeKind.Utc).AddTicks(5347) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 2, 5, 7, 18, 1, 476, DateTimeKind.Utc).AddTicks(5348), new DateTime(2025, 2, 5, 7, 18, 1, 476, DateTimeKind.Utc).AddTicks(5349) });

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
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 2, 5, 7, 18, 1, 476, DateTimeKind.Utc).AddTicks(5519), new DateTime(2025, 2, 5, 7, 18, 1, 476, DateTimeKind.Utc).AddTicks(5520) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PasswordResetTokens");

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
    }
}
