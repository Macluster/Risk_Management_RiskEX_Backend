using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Risk_Management_RiskEX_Backend.Migrations
{
    /// <inheritdoc />
    public partial class ProjectIdColumAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProjectId",
                table: "Users",
                type: "integer",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AssessmentsBasis",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 6, 4, 26, 4, 375, DateTimeKind.Utc).AddTicks(8542), new DateTime(2025, 1, 6, 4, 26, 4, 375, DateTimeKind.Utc).AddTicks(8543) });

            migrationBuilder.UpdateData(
                table: "AssessmentsBasis",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 6, 4, 26, 4, 375, DateTimeKind.Utc).AddTicks(8545), new DateTime(2025, 1, 6, 4, 26, 4, 375, DateTimeKind.Utc).AddTicks(8545) });

            migrationBuilder.UpdateData(
                table: "AssessmentsBasis",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 6, 4, 26, 4, 375, DateTimeKind.Utc).AddTicks(8547), new DateTime(2025, 1, 6, 4, 26, 4, 375, DateTimeKind.Utc).AddTicks(8547) });

            migrationBuilder.UpdateData(
                table: "AssessmentsBasis",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 6, 4, 26, 4, 375, DateTimeKind.Utc).AddTicks(8548), new DateTime(2025, 1, 6, 4, 26, 4, 375, DateTimeKind.Utc).AddTicks(8549) });

            migrationBuilder.UpdateData(
                table: "AssessmentsMatrixImpact",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 6, 4, 26, 4, 375, DateTimeKind.Utc).AddTicks(8597), new DateTime(2025, 1, 6, 4, 26, 4, 375, DateTimeKind.Utc).AddTicks(8598) });

            migrationBuilder.UpdateData(
                table: "AssessmentsMatrixImpact",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 6, 4, 26, 4, 375, DateTimeKind.Utc).AddTicks(8600), new DateTime(2025, 1, 6, 4, 26, 4, 375, DateTimeKind.Utc).AddTicks(8600) });

            migrationBuilder.UpdateData(
                table: "AssessmentsMatrixImpact",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 6, 4, 26, 4, 375, DateTimeKind.Utc).AddTicks(8602), new DateTime(2025, 1, 6, 4, 26, 4, 375, DateTimeKind.Utc).AddTicks(8603) });

            migrationBuilder.UpdateData(
                table: "AssessmentsMatrixImpact",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 6, 4, 26, 4, 375, DateTimeKind.Utc).AddTicks(8645), new DateTime(2025, 1, 6, 4, 26, 4, 375, DateTimeKind.Utc).AddTicks(8646) });

            migrationBuilder.UpdateData(
                table: "AssessmentsMatrixLikelihood",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 6, 4, 26, 4, 375, DateTimeKind.Utc).AddTicks(8669), new DateTime(2025, 1, 6, 4, 26, 4, 375, DateTimeKind.Utc).AddTicks(8670) });

            migrationBuilder.UpdateData(
                table: "AssessmentsMatrixLikelihood",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 6, 4, 26, 4, 375, DateTimeKind.Utc).AddTicks(8672), new DateTime(2025, 1, 6, 4, 26, 4, 375, DateTimeKind.Utc).AddTicks(8673) });

            migrationBuilder.UpdateData(
                table: "AssessmentsMatrixLikelihood",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 6, 4, 26, 4, 375, DateTimeKind.Utc).AddTicks(8674), new DateTime(2025, 1, 6, 4, 26, 4, 375, DateTimeKind.Utc).AddTicks(8675) });

            migrationBuilder.UpdateData(
                table: "AssessmentsMatrixLikelihood",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 6, 4, 26, 4, 375, DateTimeKind.Utc).AddTicks(8676), new DateTime(2025, 1, 6, 4, 26, 4, 375, DateTimeKind.Utc).AddTicks(8677) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 6, 4, 26, 4, 375, DateTimeKind.Utc).AddTicks(8223), new DateTime(2025, 1, 6, 4, 26, 4, 375, DateTimeKind.Utc).AddTicks(8234) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 6, 4, 26, 4, 375, DateTimeKind.Utc).AddTicks(8236), new DateTime(2025, 1, 6, 4, 26, 4, 375, DateTimeKind.Utc).AddTicks(8237) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 6, 4, 26, 4, 375, DateTimeKind.Utc).AddTicks(8238), new DateTime(2025, 1, 6, 4, 26, 4, 375, DateTimeKind.Utc).AddTicks(8239) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 6, 4, 26, 4, 375, DateTimeKind.Utc).AddTicks(8240), new DateTime(2025, 1, 6, 4, 26, 4, 375, DateTimeKind.Utc).AddTicks(8241) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 6, 4, 26, 4, 375, DateTimeKind.Utc).AddTicks(8242), new DateTime(2025, 1, 6, 4, 26, 4, 375, DateTimeKind.Utc).AddTicks(8243) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 6, 4, 26, 4, 375, DateTimeKind.Utc).AddTicks(8244), new DateTime(2025, 1, 6, 4, 26, 4, 375, DateTimeKind.Utc).AddTicks(8245) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 6, 4, 26, 4, 375, DateTimeKind.Utc).AddTicks(8246), new DateTime(2025, 1, 6, 4, 26, 4, 375, DateTimeKind.Utc).AddTicks(8247) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 6, 4, 26, 4, 375, DateTimeKind.Utc).AddTicks(8248), new DateTime(2025, 1, 6, 4, 26, 4, 375, DateTimeKind.Utc).AddTicks(8249) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 6, 4, 26, 4, 375, DateTimeKind.Utc).AddTicks(8250), new DateTime(2025, 1, 6, 4, 26, 4, 375, DateTimeKind.Utc).AddTicks(8251) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 6, 4, 26, 4, 375, DateTimeKind.Utc).AddTicks(8252), new DateTime(2025, 1, 6, 4, 26, 4, 375, DateTimeKind.Utc).AddTicks(8253) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 6, 4, 26, 4, 375, DateTimeKind.Utc).AddTicks(8254), new DateTime(2025, 1, 6, 4, 26, 4, 375, DateTimeKind.Utc).AddTicks(8255) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 6, 4, 26, 4, 375, DateTimeKind.Utc).AddTicks(8256), new DateTime(2025, 1, 6, 4, 26, 4, 375, DateTimeKind.Utc).AddTicks(8257) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 6, 4, 26, 4, 375, DateTimeKind.Utc).AddTicks(8258), new DateTime(2025, 1, 6, 4, 26, 4, 375, DateTimeKind.Utc).AddTicks(8259) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 6, 4, 26, 4, 375, DateTimeKind.Utc).AddTicks(8260), new DateTime(2025, 1, 6, 4, 26, 4, 375, DateTimeKind.Utc).AddTicks(8261) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 6, 4, 26, 4, 375, DateTimeKind.Utc).AddTicks(8263), new DateTime(2025, 1, 6, 4, 26, 4, 375, DateTimeKind.Utc).AddTicks(8263) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 6, 4, 26, 4, 375, DateTimeKind.Utc).AddTicks(8264), new DateTime(2025, 1, 6, 4, 26, 4, 375, DateTimeKind.Utc).AddTicks(8265) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 6, 4, 26, 4, 375, DateTimeKind.Utc).AddTicks(8266), new DateTime(2025, 1, 6, 4, 26, 4, 375, DateTimeKind.Utc).AddTicks(8267) });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 6, 4, 26, 4, 375, DateTimeKind.Utc).AddTicks(8573), new DateTime(2025, 1, 6, 4, 26, 4, 375, DateTimeKind.Utc).AddTicks(8574) });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 6, 4, 26, 4, 375, DateTimeKind.Utc).AddTicks(8576), new DateTime(2025, 1, 6, 4, 26, 4, 375, DateTimeKind.Utc).AddTicks(8577) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "ProjectId", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 6, 4, 26, 4, 375, DateTimeKind.Utc).AddTicks(8506), null, new DateTime(2025, 1, 6, 4, 26, 4, 375, DateTimeKind.Utc).AddTicks(8506) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "ProjectId", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 6, 4, 26, 4, 375, DateTimeKind.Utc).AddTicks(8509), null, new DateTime(2025, 1, 6, 4, 26, 4, 375, DateTimeKind.Utc).AddTicks(8510) });

            migrationBuilder.CreateIndex(
                name: "IX_Users_ProjectId",
                table: "Users",
                column: "ProjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Projects_ProjectId",
                table: "Users",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Projects_ProjectId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_ProjectId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ProjectId",
                table: "Users");

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
    }
}
