using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Risk_Management_RiskEX_Backend.Migrations
{
    /// <inheritdoc />
    public partial class SeedDataUpdated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ChanceOfOccurance",
                table: "AssessmentsMatrixLikelihood",
                type: "text",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AssessmentsBasis",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 12, 5, 5, 53, 10, DateTimeKind.Utc).AddTicks(5564), new DateTime(2025, 8, 12, 5, 5, 53, 10, DateTimeKind.Utc).AddTicks(5565) });

            migrationBuilder.UpdateData(
                table: "AssessmentsBasis",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 12, 5, 5, 53, 10, DateTimeKind.Utc).AddTicks(5567), new DateTime(2025, 8, 12, 5, 5, 53, 10, DateTimeKind.Utc).AddTicks(5568) });

            migrationBuilder.UpdateData(
                table: "AssessmentsBasis",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 12, 5, 5, 53, 10, DateTimeKind.Utc).AddTicks(5570), new DateTime(2025, 8, 12, 5, 5, 53, 10, DateTimeKind.Utc).AddTicks(5571) });

            migrationBuilder.UpdateData(
                table: "AssessmentsBasis",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 12, 5, 5, 53, 10, DateTimeKind.Utc).AddTicks(5572), new DateTime(2025, 8, 12, 5, 5, 53, 10, DateTimeKind.Utc).AddTicks(5573) });

            migrationBuilder.UpdateData(
                table: "AssessmentsMatrixImpact",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Definition", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 12, 5, 5, 53, 10, DateTimeKind.Utc).AddTicks(5973), "The consequences of the risk are minimal, with negligible effects on the organization's operations, finances, or reputation.", new DateTime(2025, 8, 12, 5, 5, 53, 10, DateTimeKind.Utc).AddTicks(5974) });

            migrationBuilder.UpdateData(
                table: "AssessmentsMatrixImpact",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Definition", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 12, 5, 5, 53, 10, DateTimeKind.Utc).AddTicks(5977), "The consequences of the risk are moderate, causing some disruption or financial loss, but manageable without significant impact on key objectives.", new DateTime(2025, 8, 12, 5, 5, 53, 10, DateTimeKind.Utc).AddTicks(5978) });

            migrationBuilder.UpdateData(
                table: "AssessmentsMatrixImpact",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Definition", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 12, 5, 5, 53, 10, DateTimeKind.Utc).AddTicks(5980), "The consequences of the risk are significant, causing major disruptions, substantial financial losses, or harm to the organization’s reputation.", new DateTime(2025, 8, 12, 5, 5, 53, 10, DateTimeKind.Utc).AddTicks(5981) });

            migrationBuilder.UpdateData(
                table: "AssessmentsMatrixImpact",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "Definition", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 12, 5, 5, 53, 10, DateTimeKind.Utc).AddTicks(5983), "The consequences of the risk are severe, potentially threatening the organization's ability to operate or causing irreparable harm.", new DateTime(2025, 8, 12, 5, 5, 53, 10, DateTimeKind.Utc).AddTicks(5984) });

            migrationBuilder.UpdateData(
                table: "AssessmentsMatrixLikelihood",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ChanceOfOccurance", "CreatedAt", "Definition", "UpdatedAt" },
                values: new object[] { "<=10%", new DateTime(2025, 8, 12, 5, 5, 53, 10, DateTimeKind.Utc).AddTicks(6026), "The probability of the risk occurring is minimal, with little to no historical evidence or indication of occurrence.(Once in 3 Years)", new DateTime(2025, 8, 12, 5, 5, 53, 10, DateTimeKind.Utc).AddTicks(6027) });

            migrationBuilder.UpdateData(
                table: "AssessmentsMatrixLikelihood",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ChanceOfOccurance", "CreatedAt", "Definition", "UpdatedAt" },
                values: new object[] { "10-50%", new DateTime(2025, 8, 12, 5, 5, 53, 10, DateTimeKind.Utc).AddTicks(6029), "There is a moderate probability of the risk occurring. It may have occurred in the past under similar circumstances(Once a year)", new DateTime(2025, 8, 12, 5, 5, 53, 10, DateTimeKind.Utc).AddTicks(6030) });

            migrationBuilder.UpdateData(
                table: "AssessmentsMatrixLikelihood",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ChanceOfOccurance", "CreatedAt", "Definition", "UpdatedAt" },
                values: new object[] { "50-90%", new DateTime(2025, 8, 12, 5, 5, 53, 10, DateTimeKind.Utc).AddTicks(6032), "The probability of the risk occurring is significant, and it is likely to happen based on historical trends or current conditions.(Once a quarter)", new DateTime(2025, 8, 12, 5, 5, 53, 10, DateTimeKind.Utc).AddTicks(6032) });

            migrationBuilder.UpdateData(
                table: "AssessmentsMatrixLikelihood",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ChanceOfOccurance", "CreatedAt", "Definition", "UpdatedAt" },
                values: new object[] { ">=90%", new DateTime(2025, 8, 12, 5, 5, 53, 10, DateTimeKind.Utc).AddTicks(6034), "The risk is almost certain to occur, with a very high probability of materializing(Once a month)", new DateTime(2025, 8, 12, 5, 5, 53, 10, DateTimeKind.Utc).AddTicks(6035) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 12, 5, 5, 53, 10, DateTimeKind.Utc).AddTicks(5199), new DateTime(2025, 8, 12, 5, 5, 53, 10, DateTimeKind.Utc).AddTicks(5204) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 12, 5, 5, 53, 10, DateTimeKind.Utc).AddTicks(5206), new DateTime(2025, 8, 12, 5, 5, 53, 10, DateTimeKind.Utc).AddTicks(5207) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 12, 5, 5, 53, 10, DateTimeKind.Utc).AddTicks(5209), new DateTime(2025, 8, 12, 5, 5, 53, 10, DateTimeKind.Utc).AddTicks(5210) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 12, 5, 5, 53, 10, DateTimeKind.Utc).AddTicks(5212), new DateTime(2025, 8, 12, 5, 5, 53, 10, DateTimeKind.Utc).AddTicks(5213) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 12, 5, 5, 53, 10, DateTimeKind.Utc).AddTicks(5214), new DateTime(2025, 8, 12, 5, 5, 53, 10, DateTimeKind.Utc).AddTicks(5215) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 12, 5, 5, 53, 10, DateTimeKind.Utc).AddTicks(5216), new DateTime(2025, 8, 12, 5, 5, 53, 10, DateTimeKind.Utc).AddTicks(5217) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 12, 5, 5, 53, 10, DateTimeKind.Utc).AddTicks(5223), new DateTime(2025, 8, 12, 5, 5, 53, 10, DateTimeKind.Utc).AddTicks(5224) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 12, 5, 5, 53, 10, DateTimeKind.Utc).AddTicks(5226), new DateTime(2025, 8, 12, 5, 5, 53, 10, DateTimeKind.Utc).AddTicks(5226) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 12, 5, 5, 53, 10, DateTimeKind.Utc).AddTicks(5228), new DateTime(2025, 8, 12, 5, 5, 53, 10, DateTimeKind.Utc).AddTicks(5229) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 12, 5, 5, 53, 10, DateTimeKind.Utc).AddTicks(5231), new DateTime(2025, 8, 12, 5, 5, 53, 10, DateTimeKind.Utc).AddTicks(5232) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 12, 5, 5, 53, 10, DateTimeKind.Utc).AddTicks(5233), new DateTime(2025, 8, 12, 5, 5, 53, 10, DateTimeKind.Utc).AddTicks(5234) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 12, 5, 5, 53, 10, DateTimeKind.Utc).AddTicks(5236), new DateTime(2025, 8, 12, 5, 5, 53, 10, DateTimeKind.Utc).AddTicks(5237) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 12, 5, 5, 53, 10, DateTimeKind.Utc).AddTicks(5238), new DateTime(2025, 8, 12, 5, 5, 53, 10, DateTimeKind.Utc).AddTicks(5239) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 12, 5, 5, 53, 10, DateTimeKind.Utc).AddTicks(5240), new DateTime(2025, 8, 12, 5, 5, 53, 10, DateTimeKind.Utc).AddTicks(5241) });

            migrationBuilder.UpdateData(
                table: "RiskResponseDatas",
                keyColumn: "Id",
                keyValue: 1,
                column: "Example",
                value: "Changing a project scope to exclude a high-risk feature that could lead to technical challenges, Discontinuing a risky process or project.");

            migrationBuilder.UpdateData(
                table: "RiskResponseDatas",
                keyColumn: "Id",
                keyValue: 2,
                column: "Example",
                value: "Developing a backup system to reduce the impact of potential server failures, Implementing access controls, encryption, or training.");

            migrationBuilder.UpdateData(
                table: "RiskResponseDatas",
                keyColumn: "Id",
                keyValue: 3,
                column: "Example",
                value: "Purchasing insurance to cover financial losses due to unforeseen events, Purchasing cybersecurity insurance or outsourcing to a secure service provider.");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 12, 5, 5, 53, 10, DateTimeKind.Utc).AddTicks(5514), new DateTime(2025, 8, 12, 5, 5, 53, 10, DateTimeKind.Utc).AddTicks(5516) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 12, 5, 5, 53, 10, DateTimeKind.Utc).AddTicks(5519), new DateTime(2025, 8, 12, 5, 5, 53, 10, DateTimeKind.Utc).AddTicks(5520) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ChanceOfOccurance",
                table: "AssessmentsMatrixLikelihood");

            migrationBuilder.UpdateData(
                table: "AssessmentsBasis",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 5, 10, 3, 37, 253, DateTimeKind.Utc).AddTicks(8967), new DateTime(2025, 8, 5, 10, 3, 37, 253, DateTimeKind.Utc).AddTicks(8968) });

            migrationBuilder.UpdateData(
                table: "AssessmentsBasis",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 5, 10, 3, 37, 253, DateTimeKind.Utc).AddTicks(8969), new DateTime(2025, 8, 5, 10, 3, 37, 253, DateTimeKind.Utc).AddTicks(8970) });

            migrationBuilder.UpdateData(
                table: "AssessmentsBasis",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 5, 10, 3, 37, 253, DateTimeKind.Utc).AddTicks(8971), new DateTime(2025, 8, 5, 10, 3, 37, 253, DateTimeKind.Utc).AddTicks(8971) });

            migrationBuilder.UpdateData(
                table: "AssessmentsBasis",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 5, 10, 3, 37, 253, DateTimeKind.Utc).AddTicks(8973), new DateTime(2025, 8, 5, 10, 3, 37, 253, DateTimeKind.Utc).AddTicks(8973) });

            migrationBuilder.UpdateData(
                table: "AssessmentsMatrixImpact",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Definition", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 5, 10, 3, 37, 253, DateTimeKind.Utc).AddTicks(8992), "No slight effect on business", new DateTime(2025, 8, 5, 10, 3, 37, 253, DateTimeKind.Utc).AddTicks(8993) });

            migrationBuilder.UpdateData(
                table: "AssessmentsMatrixImpact",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Definition", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 5, 10, 3, 37, 253, DateTimeKind.Utc).AddTicks(8994), "Business objectives affected", new DateTime(2025, 8, 5, 10, 3, 37, 253, DateTimeKind.Utc).AddTicks(8995) });

            migrationBuilder.UpdateData(
                table: "AssessmentsMatrixImpact",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Definition", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 5, 10, 3, 37, 253, DateTimeKind.Utc).AddTicks(8996), "Business objectives undermined", new DateTime(2025, 8, 5, 10, 3, 37, 253, DateTimeKind.Utc).AddTicks(8997) });

            migrationBuilder.UpdateData(
                table: "AssessmentsMatrixImpact",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "Definition", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 5, 10, 3, 37, 253, DateTimeKind.Utc).AddTicks(8998), "Business objectives not accomplished", new DateTime(2025, 8, 5, 10, 3, 37, 253, DateTimeKind.Utc).AddTicks(8998) });

            migrationBuilder.UpdateData(
                table: "AssessmentsMatrixLikelihood",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Definition", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 5, 10, 3, 37, 253, DateTimeKind.Utc).AddTicks(9020), "1-24% chance of occurrence", new DateTime(2025, 8, 5, 10, 3, 37, 253, DateTimeKind.Utc).AddTicks(9021) });

            migrationBuilder.UpdateData(
                table: "AssessmentsMatrixLikelihood",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Definition", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 5, 10, 3, 37, 253, DateTimeKind.Utc).AddTicks(9022), "25-49% chance of occurrence", new DateTime(2025, 8, 5, 10, 3, 37, 253, DateTimeKind.Utc).AddTicks(9023) });

            migrationBuilder.UpdateData(
                table: "AssessmentsMatrixLikelihood",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Definition", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 5, 10, 3, 37, 253, DateTimeKind.Utc).AddTicks(9024), "50-74% chance of occurrence", new DateTime(2025, 8, 5, 10, 3, 37, 253, DateTimeKind.Utc).AddTicks(9025) });

            migrationBuilder.UpdateData(
                table: "AssessmentsMatrixLikelihood",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "Definition", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 5, 10, 3, 37, 253, DateTimeKind.Utc).AddTicks(9026), "75-99% chance of occurrence", new DateTime(2025, 8, 5, 10, 3, 37, 253, DateTimeKind.Utc).AddTicks(9027) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 5, 10, 3, 37, 253, DateTimeKind.Utc).AddTicks(8729), new DateTime(2025, 8, 5, 10, 3, 37, 253, DateTimeKind.Utc).AddTicks(8733) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 5, 10, 3, 37, 253, DateTimeKind.Utc).AddTicks(8734), new DateTime(2025, 8, 5, 10, 3, 37, 253, DateTimeKind.Utc).AddTicks(8735) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 5, 10, 3, 37, 253, DateTimeKind.Utc).AddTicks(8737), new DateTime(2025, 8, 5, 10, 3, 37, 253, DateTimeKind.Utc).AddTicks(8737) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 5, 10, 3, 37, 253, DateTimeKind.Utc).AddTicks(8774), new DateTime(2025, 8, 5, 10, 3, 37, 253, DateTimeKind.Utc).AddTicks(8774) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 5, 10, 3, 37, 253, DateTimeKind.Utc).AddTicks(8775), new DateTime(2025, 8, 5, 10, 3, 37, 253, DateTimeKind.Utc).AddTicks(8776) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 5, 10, 3, 37, 253, DateTimeKind.Utc).AddTicks(8777), new DateTime(2025, 8, 5, 10, 3, 37, 253, DateTimeKind.Utc).AddTicks(8778) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 5, 10, 3, 37, 253, DateTimeKind.Utc).AddTicks(8779), new DateTime(2025, 8, 5, 10, 3, 37, 253, DateTimeKind.Utc).AddTicks(8780) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 5, 10, 3, 37, 253, DateTimeKind.Utc).AddTicks(8781), new DateTime(2025, 8, 5, 10, 3, 37, 253, DateTimeKind.Utc).AddTicks(8781) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 5, 10, 3, 37, 253, DateTimeKind.Utc).AddTicks(8782), new DateTime(2025, 8, 5, 10, 3, 37, 253, DateTimeKind.Utc).AddTicks(8783) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 5, 10, 3, 37, 253, DateTimeKind.Utc).AddTicks(8784), new DateTime(2025, 8, 5, 10, 3, 37, 253, DateTimeKind.Utc).AddTicks(8785) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 5, 10, 3, 37, 253, DateTimeKind.Utc).AddTicks(8786), new DateTime(2025, 8, 5, 10, 3, 37, 253, DateTimeKind.Utc).AddTicks(8786) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 5, 10, 3, 37, 253, DateTimeKind.Utc).AddTicks(8788), new DateTime(2025, 8, 5, 10, 3, 37, 253, DateTimeKind.Utc).AddTicks(8788) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 5, 10, 3, 37, 253, DateTimeKind.Utc).AddTicks(8789), new DateTime(2025, 8, 5, 10, 3, 37, 253, DateTimeKind.Utc).AddTicks(8790) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 5, 10, 3, 37, 253, DateTimeKind.Utc).AddTicks(8791), new DateTime(2025, 8, 5, 10, 3, 37, 253, DateTimeKind.Utc).AddTicks(8791) });

            migrationBuilder.UpdateData(
                table: "RiskResponseDatas",
                keyColumn: "Id",
                keyValue: 1,
                column: "Example",
                value: "Changing a project scope to exclude a high-risk feature that could lead to technical challenges.");

            migrationBuilder.UpdateData(
                table: "RiskResponseDatas",
                keyColumn: "Id",
                keyValue: 2,
                column: "Example",
                value: "Developing a backup system to reduce the impact of potential server failures.");

            migrationBuilder.UpdateData(
                table: "RiskResponseDatas",
                keyColumn: "Id",
                keyValue: 3,
                column: "Example",
                value: "Purchasing insurance to cover financial losses due to unforeseen events.");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 5, 10, 3, 37, 253, DateTimeKind.Utc).AddTicks(8939), new DateTime(2025, 8, 5, 10, 3, 37, 253, DateTimeKind.Utc).AddTicks(8939) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 5, 10, 3, 37, 253, DateTimeKind.Utc).AddTicks(8941), new DateTime(2025, 8, 5, 10, 3, 37, 253, DateTimeKind.Utc).AddTicks(8942) });
        }
    }
}
