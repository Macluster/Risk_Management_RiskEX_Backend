using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Risk_Management_RiskEX_Backend.Migrations
{
    /// <inheritdoc />
    public partial class deparments : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AssessmentsBasis",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 12, 26, 15, 0, 29, 793, DateTimeKind.Utc).AddTicks(9057), new DateTime(2024, 12, 26, 15, 0, 29, 793, DateTimeKind.Utc).AddTicks(9058) });

            migrationBuilder.UpdateData(
                table: "AssessmentsBasis",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 12, 26, 15, 0, 29, 793, DateTimeKind.Utc).AddTicks(9060), new DateTime(2024, 12, 26, 15, 0, 29, 793, DateTimeKind.Utc).AddTicks(9061) });

            migrationBuilder.UpdateData(
                table: "AssessmentsBasis",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 12, 26, 15, 0, 29, 793, DateTimeKind.Utc).AddTicks(9062), new DateTime(2024, 12, 26, 15, 0, 29, 793, DateTimeKind.Utc).AddTicks(9063) });

            migrationBuilder.UpdateData(
                table: "AssessmentsBasis",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 12, 26, 15, 0, 29, 793, DateTimeKind.Utc).AddTicks(9065), new DateTime(2024, 12, 26, 15, 0, 29, 793, DateTimeKind.Utc).AddTicks(9066) });

            migrationBuilder.UpdateData(
                table: "AssessmentsMatrixImpact",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 12, 26, 15, 0, 29, 793, DateTimeKind.Utc).AddTicks(9197), new DateTime(2024, 12, 26, 15, 0, 29, 793, DateTimeKind.Utc).AddTicks(9198) });

            migrationBuilder.UpdateData(
                table: "AssessmentsMatrixImpact",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 12, 26, 15, 0, 29, 793, DateTimeKind.Utc).AddTicks(9200), new DateTime(2024, 12, 26, 15, 0, 29, 793, DateTimeKind.Utc).AddTicks(9201) });

            migrationBuilder.UpdateData(
                table: "AssessmentsMatrixImpact",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 12, 26, 15, 0, 29, 793, DateTimeKind.Utc).AddTicks(9203), new DateTime(2024, 12, 26, 15, 0, 29, 793, DateTimeKind.Utc).AddTicks(9204) });

            migrationBuilder.UpdateData(
                table: "AssessmentsMatrixImpact",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 12, 26, 15, 0, 29, 793, DateTimeKind.Utc).AddTicks(9206), new DateTime(2024, 12, 26, 15, 0, 29, 793, DateTimeKind.Utc).AddTicks(9207) });

            migrationBuilder.UpdateData(
                table: "AssessmentsMatrixLikelihood",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 12, 26, 15, 0, 29, 793, DateTimeKind.Utc).AddTicks(9238), new DateTime(2024, 12, 26, 15, 0, 29, 793, DateTimeKind.Utc).AddTicks(9239) });

            migrationBuilder.UpdateData(
                table: "AssessmentsMatrixLikelihood",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 12, 26, 15, 0, 29, 793, DateTimeKind.Utc).AddTicks(9242), new DateTime(2024, 12, 26, 15, 0, 29, 793, DateTimeKind.Utc).AddTicks(9242) });

            migrationBuilder.UpdateData(
                table: "AssessmentsMatrixLikelihood",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 12, 26, 15, 0, 29, 793, DateTimeKind.Utc).AddTicks(9244), new DateTime(2024, 12, 26, 15, 0, 29, 793, DateTimeKind.Utc).AddTicks(9245) });

            migrationBuilder.UpdateData(
                table: "AssessmentsMatrixLikelihood",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 12, 26, 15, 0, 29, 793, DateTimeKind.Utc).AddTicks(9247), new DateTime(2024, 12, 26, 15, 0, 29, 793, DateTimeKind.Utc).AddTicks(9247) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 12, 26, 15, 0, 29, 793, DateTimeKind.Utc).AddTicks(8600), new DateTime(2024, 12, 26, 15, 0, 29, 793, DateTimeKind.Utc).AddTicks(8605) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 12, 26, 15, 0, 29, 793, DateTimeKind.Utc).AddTicks(8608), new DateTime(2024, 12, 26, 15, 0, 29, 793, DateTimeKind.Utc).AddTicks(8609) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 12, 26, 15, 0, 29, 793, DateTimeKind.Utc).AddTicks(8611), new DateTime(2024, 12, 26, 15, 0, 29, 793, DateTimeKind.Utc).AddTicks(8611) });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "CreatedAt", "DepartmentName", "UpdatedAt" },
                values: new object[,]
                {
                    { 4, new DateTime(2024, 12, 26, 15, 0, 29, 793, DateTimeKind.Utc).AddTicks(8613), "IT", new DateTime(2024, 12, 26, 15, 0, 29, 793, DateTimeKind.Utc).AddTicks(8614) },
                    { 5, new DateTime(2024, 12, 26, 15, 0, 29, 793, DateTimeKind.Utc).AddTicks(8616), "Marketing", new DateTime(2024, 12, 26, 15, 0, 29, 793, DateTimeKind.Utc).AddTicks(8617) },
                    { 6, new DateTime(2024, 12, 26, 15, 0, 29, 793, DateTimeKind.Utc).AddTicks(8619), "Sales", new DateTime(2024, 12, 26, 15, 0, 29, 793, DateTimeKind.Utc).AddTicks(8621) },
                    { 7, new DateTime(2024, 12, 26, 15, 0, 29, 793, DateTimeKind.Utc).AddTicks(8622), "Customer Support", new DateTime(2024, 12, 26, 15, 0, 29, 793, DateTimeKind.Utc).AddTicks(8623) },
                    { 8, new DateTime(2024, 12, 26, 15, 0, 29, 793, DateTimeKind.Utc).AddTicks(8625), "Operations", new DateTime(2024, 12, 26, 15, 0, 29, 793, DateTimeKind.Utc).AddTicks(8626) },
                    { 9, new DateTime(2024, 12, 26, 15, 0, 29, 793, DateTimeKind.Utc).AddTicks(8627), "Legal", new DateTime(2024, 12, 26, 15, 0, 29, 793, DateTimeKind.Utc).AddTicks(8628) },
                    { 10, new DateTime(2024, 12, 26, 15, 0, 29, 793, DateTimeKind.Utc).AddTicks(8630), "Research & Development", new DateTime(2024, 12, 26, 15, 0, 29, 793, DateTimeKind.Utc).AddTicks(8631) },
                    { 11, new DateTime(2024, 12, 26, 15, 0, 29, 793, DateTimeKind.Utc).AddTicks(8633), "Procurement", new DateTime(2024, 12, 26, 15, 0, 29, 793, DateTimeKind.Utc).AddTicks(8634) },
                    { 12, new DateTime(2024, 12, 26, 15, 0, 29, 793, DateTimeKind.Utc).AddTicks(8635), "Quality Assurance", new DateTime(2024, 12, 26, 15, 0, 29, 793, DateTimeKind.Utc).AddTicks(8636) },
                    { 13, new DateTime(2024, 12, 26, 15, 0, 29, 793, DateTimeKind.Utc).AddTicks(8638), "Training", new DateTime(2024, 12, 26, 15, 0, 29, 793, DateTimeKind.Utc).AddTicks(8638) },
                    { 14, new DateTime(2024, 12, 26, 15, 0, 29, 793, DateTimeKind.Utc).AddTicks(8640), "Public Relations", new DateTime(2024, 12, 26, 15, 0, 29, 793, DateTimeKind.Utc).AddTicks(8641) }
                });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 12, 26, 15, 0, 29, 793, DateTimeKind.Utc).AddTicks(9162), new DateTime(2024, 12, 26, 15, 0, 29, 793, DateTimeKind.Utc).AddTicks(9163) });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 12, 26, 15, 0, 29, 793, DateTimeKind.Utc).AddTicks(9167), new DateTime(2024, 12, 26, 15, 0, 29, 793, DateTimeKind.Utc).AddTicks(9168) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 12, 26, 15, 0, 29, 793, DateTimeKind.Utc).AddTicks(9003), new DateTime(2024, 12, 26, 15, 0, 29, 793, DateTimeKind.Utc).AddTicks(9009) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 12, 26, 15, 0, 29, 793, DateTimeKind.Utc).AddTicks(9015), new DateTime(2024, 12, 26, 15, 0, 29, 793, DateTimeKind.Utc).AddTicks(9015) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 4);

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

            migrationBuilder.UpdateData(
                table: "AssessmentsBasis",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 12, 26, 11, 43, 21, 452, DateTimeKind.Utc).AddTicks(4726), new DateTime(2024, 12, 26, 11, 43, 21, 452, DateTimeKind.Utc).AddTicks(4726) });

            migrationBuilder.UpdateData(
                table: "AssessmentsBasis",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 12, 26, 11, 43, 21, 452, DateTimeKind.Utc).AddTicks(4729), new DateTime(2024, 12, 26, 11, 43, 21, 452, DateTimeKind.Utc).AddTicks(4729) });

            migrationBuilder.UpdateData(
                table: "AssessmentsBasis",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 12, 26, 11, 43, 21, 452, DateTimeKind.Utc).AddTicks(4731), new DateTime(2024, 12, 26, 11, 43, 21, 452, DateTimeKind.Utc).AddTicks(4732) });

            migrationBuilder.UpdateData(
                table: "AssessmentsBasis",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 12, 26, 11, 43, 21, 452, DateTimeKind.Utc).AddTicks(4733), new DateTime(2024, 12, 26, 11, 43, 21, 452, DateTimeKind.Utc).AddTicks(4734) });

            migrationBuilder.UpdateData(
                table: "AssessmentsMatrixImpact",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 12, 26, 11, 43, 21, 452, DateTimeKind.Utc).AddTicks(4805), new DateTime(2024, 12, 26, 11, 43, 21, 452, DateTimeKind.Utc).AddTicks(4806) });

            migrationBuilder.UpdateData(
                table: "AssessmentsMatrixImpact",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 12, 26, 11, 43, 21, 452, DateTimeKind.Utc).AddTicks(4808), new DateTime(2024, 12, 26, 11, 43, 21, 452, DateTimeKind.Utc).AddTicks(4809) });

            migrationBuilder.UpdateData(
                table: "AssessmentsMatrixImpact",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 12, 26, 11, 43, 21, 452, DateTimeKind.Utc).AddTicks(4811), new DateTime(2024, 12, 26, 11, 43, 21, 452, DateTimeKind.Utc).AddTicks(4812) });

            migrationBuilder.UpdateData(
                table: "AssessmentsMatrixImpact",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 12, 26, 11, 43, 21, 452, DateTimeKind.Utc).AddTicks(4814), new DateTime(2024, 12, 26, 11, 43, 21, 452, DateTimeKind.Utc).AddTicks(4814) });

            migrationBuilder.UpdateData(
                table: "AssessmentsMatrixLikelihood",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 12, 26, 11, 43, 21, 452, DateTimeKind.Utc).AddTicks(4912), new DateTime(2024, 12, 26, 11, 43, 21, 452, DateTimeKind.Utc).AddTicks(4913) });

            migrationBuilder.UpdateData(
                table: "AssessmentsMatrixLikelihood",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 12, 26, 11, 43, 21, 452, DateTimeKind.Utc).AddTicks(4915), new DateTime(2024, 12, 26, 11, 43, 21, 452, DateTimeKind.Utc).AddTicks(4916) });

            migrationBuilder.UpdateData(
                table: "AssessmentsMatrixLikelihood",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 12, 26, 11, 43, 21, 452, DateTimeKind.Utc).AddTicks(4919), new DateTime(2024, 12, 26, 11, 43, 21, 452, DateTimeKind.Utc).AddTicks(4920) });

            migrationBuilder.UpdateData(
                table: "AssessmentsMatrixLikelihood",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 12, 26, 11, 43, 21, 452, DateTimeKind.Utc).AddTicks(4921), new DateTime(2024, 12, 26, 11, 43, 21, 452, DateTimeKind.Utc).AddTicks(4922) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 12, 26, 11, 43, 21, 452, DateTimeKind.Utc).AddTicks(4416), new DateTime(2024, 12, 26, 11, 43, 21, 452, DateTimeKind.Utc).AddTicks(4420) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 12, 26, 11, 43, 21, 452, DateTimeKind.Utc).AddTicks(4423), new DateTime(2024, 12, 26, 11, 43, 21, 452, DateTimeKind.Utc).AddTicks(4426) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 12, 26, 11, 43, 21, 452, DateTimeKind.Utc).AddTicks(4428), new DateTime(2024, 12, 26, 11, 43, 21, 452, DateTimeKind.Utc).AddTicks(4429) });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 12, 26, 11, 43, 21, 452, DateTimeKind.Utc).AddTicks(4772), new DateTime(2024, 12, 26, 11, 43, 21, 452, DateTimeKind.Utc).AddTicks(4773) });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 12, 26, 11, 43, 21, 452, DateTimeKind.Utc).AddTicks(4777), new DateTime(2024, 12, 26, 11, 43, 21, 452, DateTimeKind.Utc).AddTicks(4778) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 12, 26, 11, 43, 21, 452, DateTimeKind.Utc).AddTicks(4685), new DateTime(2024, 12, 26, 11, 43, 21, 452, DateTimeKind.Utc).AddTicks(4686) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 12, 26, 11, 43, 21, 452, DateTimeKind.Utc).AddTicks(4689), new DateTime(2024, 12, 26, 11, 43, 21, 452, DateTimeKind.Utc).AddTicks(4690) });
        }
    }
}
