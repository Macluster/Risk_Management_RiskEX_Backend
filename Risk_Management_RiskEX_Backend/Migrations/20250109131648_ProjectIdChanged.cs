using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Risk_Management_RiskEX_Backend.Migrations
{
    /// <inheritdoc />
    public partial class ProjectIdChanged : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "FullName",
                table: "Users",
                type: "character varying(30)",
                maxLength: 30,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(30)",
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Users",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<int>(
                name: "ProjectId",
                table: "Users",
                type: "integer",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "RiskName",
                table: "Risks",
                type: "character varying(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "RiskId",
                table: "Risks",
                type: "character varying(20)",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "Mitigation",
                table: "Risks",
                type: "character varying(1000)",
                maxLength: 1000,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(1000)",
                oldMaxLength: 1000);

            migrationBuilder.AlterColumn<string>(
                name: "Impact",
                table: "Risks",
                type: "character varying(1000)",
                maxLength: 1000,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(1000)",
                oldMaxLength: 1000);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Risks",
                type: "character varying(1000)",
                maxLength: 1000,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(1000)",
                oldMaxLength: 1000);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "RiskResponseDatas",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Projects",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "FullName",
                table: "ExternalReviewers",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "ExternalReviewers",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "DepartmentName",
                table: "Departments",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "AssessmentFactor",
                table: "AssessmentsMatrixLikelihood",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "AssessmentFactor",
                table: "AssessmentsMatrixImpact",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Basis",
                table: "AssessmentsBasis",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.UpdateData(
                table: "AssessmentsBasis",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 9, 13, 16, 47, 664, DateTimeKind.Utc).AddTicks(2546), new DateTime(2025, 1, 9, 13, 16, 47, 664, DateTimeKind.Utc).AddTicks(2547) });

            migrationBuilder.UpdateData(
                table: "AssessmentsBasis",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 9, 13, 16, 47, 664, DateTimeKind.Utc).AddTicks(2549), new DateTime(2025, 1, 9, 13, 16, 47, 664, DateTimeKind.Utc).AddTicks(2550) });

            migrationBuilder.UpdateData(
                table: "AssessmentsBasis",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 9, 13, 16, 47, 664, DateTimeKind.Utc).AddTicks(2552), new DateTime(2025, 1, 9, 13, 16, 47, 664, DateTimeKind.Utc).AddTicks(2552) });

            migrationBuilder.UpdateData(
                table: "AssessmentsBasis",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 9, 13, 16, 47, 664, DateTimeKind.Utc).AddTicks(2554), new DateTime(2025, 1, 9, 13, 16, 47, 664, DateTimeKind.Utc).AddTicks(2555) });

            migrationBuilder.UpdateData(
                table: "AssessmentsMatrixImpact",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 9, 13, 16, 47, 664, DateTimeKind.Utc).AddTicks(2623), new DateTime(2025, 1, 9, 13, 16, 47, 664, DateTimeKind.Utc).AddTicks(2624) });

            migrationBuilder.UpdateData(
                table: "AssessmentsMatrixImpact",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 9, 13, 16, 47, 664, DateTimeKind.Utc).AddTicks(2626), new DateTime(2025, 1, 9, 13, 16, 47, 664, DateTimeKind.Utc).AddTicks(2627) });

            migrationBuilder.UpdateData(
                table: "AssessmentsMatrixImpact",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 9, 13, 16, 47, 664, DateTimeKind.Utc).AddTicks(2629), new DateTime(2025, 1, 9, 13, 16, 47, 664, DateTimeKind.Utc).AddTicks(2629) });

            migrationBuilder.UpdateData(
                table: "AssessmentsMatrixImpact",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 9, 13, 16, 47, 664, DateTimeKind.Utc).AddTicks(2631), new DateTime(2025, 1, 9, 13, 16, 47, 664, DateTimeKind.Utc).AddTicks(2632) });

            migrationBuilder.UpdateData(
                table: "AssessmentsMatrixLikelihood",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 9, 13, 16, 47, 664, DateTimeKind.Utc).AddTicks(2663), new DateTime(2025, 1, 9, 13, 16, 47, 664, DateTimeKind.Utc).AddTicks(2664) });

            migrationBuilder.UpdateData(
                table: "AssessmentsMatrixLikelihood",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 9, 13, 16, 47, 664, DateTimeKind.Utc).AddTicks(2666), new DateTime(2025, 1, 9, 13, 16, 47, 664, DateTimeKind.Utc).AddTicks(2667) });

            migrationBuilder.UpdateData(
                table: "AssessmentsMatrixLikelihood",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 9, 13, 16, 47, 664, DateTimeKind.Utc).AddTicks(2669), new DateTime(2025, 1, 9, 13, 16, 47, 664, DateTimeKind.Utc).AddTicks(2670) });

            migrationBuilder.UpdateData(
                table: "AssessmentsMatrixLikelihood",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 9, 13, 16, 47, 664, DateTimeKind.Utc).AddTicks(2672), new DateTime(2025, 1, 9, 13, 16, 47, 664, DateTimeKind.Utc).AddTicks(2672) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 9, 13, 16, 47, 664, DateTimeKind.Utc).AddTicks(2044), new DateTime(2025, 1, 9, 13, 16, 47, 664, DateTimeKind.Utc).AddTicks(2047) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 9, 13, 16, 47, 664, DateTimeKind.Utc).AddTicks(2050), new DateTime(2025, 1, 9, 13, 16, 47, 664, DateTimeKind.Utc).AddTicks(2051) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 9, 13, 16, 47, 664, DateTimeKind.Utc).AddTicks(2053), new DateTime(2025, 1, 9, 13, 16, 47, 664, DateTimeKind.Utc).AddTicks(2054) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 9, 13, 16, 47, 664, DateTimeKind.Utc).AddTicks(2055), new DateTime(2025, 1, 9, 13, 16, 47, 664, DateTimeKind.Utc).AddTicks(2056) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 9, 13, 16, 47, 664, DateTimeKind.Utc).AddTicks(2058), new DateTime(2025, 1, 9, 13, 16, 47, 664, DateTimeKind.Utc).AddTicks(2059) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 9, 13, 16, 47, 664, DateTimeKind.Utc).AddTicks(2060), new DateTime(2025, 1, 9, 13, 16, 47, 664, DateTimeKind.Utc).AddTicks(2061) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 9, 13, 16, 47, 664, DateTimeKind.Utc).AddTicks(2062), new DateTime(2025, 1, 9, 13, 16, 47, 664, DateTimeKind.Utc).AddTicks(2063) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 9, 13, 16, 47, 664, DateTimeKind.Utc).AddTicks(2065), new DateTime(2025, 1, 9, 13, 16, 47, 664, DateTimeKind.Utc).AddTicks(2066) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 9, 13, 16, 47, 664, DateTimeKind.Utc).AddTicks(2067), new DateTime(2025, 1, 9, 13, 16, 47, 664, DateTimeKind.Utc).AddTicks(2068) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 9, 13, 16, 47, 664, DateTimeKind.Utc).AddTicks(2070), new DateTime(2025, 1, 9, 13, 16, 47, 664, DateTimeKind.Utc).AddTicks(2071) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 9, 13, 16, 47, 664, DateTimeKind.Utc).AddTicks(2073), new DateTime(2025, 1, 9, 13, 16, 47, 664, DateTimeKind.Utc).AddTicks(2074) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 9, 13, 16, 47, 664, DateTimeKind.Utc).AddTicks(2075), new DateTime(2025, 1, 9, 13, 16, 47, 664, DateTimeKind.Utc).AddTicks(2076) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 9, 13, 16, 47, 664, DateTimeKind.Utc).AddTicks(2168), new DateTime(2025, 1, 9, 13, 16, 47, 664, DateTimeKind.Utc).AddTicks(2169) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 9, 13, 16, 47, 664, DateTimeKind.Utc).AddTicks(2171), new DateTime(2025, 1, 9, 13, 16, 47, 664, DateTimeKind.Utc).AddTicks(2171) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 9, 13, 16, 47, 664, DateTimeKind.Utc).AddTicks(2173), new DateTime(2025, 1, 9, 13, 16, 47, 664, DateTimeKind.Utc).AddTicks(2174) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 9, 13, 16, 47, 664, DateTimeKind.Utc).AddTicks(2175), new DateTime(2025, 1, 9, 13, 16, 47, 664, DateTimeKind.Utc).AddTicks(2176) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 9, 13, 16, 47, 664, DateTimeKind.Utc).AddTicks(2177), new DateTime(2025, 1, 9, 13, 16, 47, 664, DateTimeKind.Utc).AddTicks(2178) });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 9, 13, 16, 47, 664, DateTimeKind.Utc).AddTicks(2593), new DateTime(2025, 1, 9, 13, 16, 47, 664, DateTimeKind.Utc).AddTicks(2593) });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 9, 13, 16, 47, 664, DateTimeKind.Utc).AddTicks(2597), new DateTime(2025, 1, 9, 13, 16, 47, 664, DateTimeKind.Utc).AddTicks(2598) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "ProjectId", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 9, 13, 16, 47, 664, DateTimeKind.Utc).AddTicks(2508), null, new DateTime(2025, 1, 9, 13, 16, 47, 664, DateTimeKind.Utc).AddTicks(2509) });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "CreatedById", "DepartmentId", "Email", "FullName", "IsActive", "Password", "ProjectId", "UpdatedAt", "UpdatedById", "projectId" },
                values: new object[] { 2, new DateTime(2025, 1, 9, 13, 16, 47, 664, DateTimeKind.Utc).AddTicks(2513), null, 1, "risk.manager@riskex.com", "Risk Manager", true, "Risk@123", null, new DateTime(2025, 1, 9, 13, 16, 47, 664, DateTimeKind.Utc).AddTicks(2513), null, null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DropColumn(
                name: "ProjectId",
                table: "Users");

            migrationBuilder.AlterColumn<string>(
                name: "FullName",
                table: "Users",
                type: "character varying(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "character varying(30)",
                oldMaxLength: 30,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Users",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "RiskName",
                table: "Risks",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "RiskId",
                table: "Risks",
                type: "character varying(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "character varying(20)",
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Mitigation",
                table: "Risks",
                type: "character varying(1000)",
                maxLength: 1000,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "character varying(1000)",
                oldMaxLength: 1000,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Impact",
                table: "Risks",
                type: "character varying(1000)",
                maxLength: 1000,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "character varying(1000)",
                oldMaxLength: 1000,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Risks",
                type: "character varying(1000)",
                maxLength: 1000,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "character varying(1000)",
                oldMaxLength: 1000,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "RiskResponseDatas",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Projects",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FullName",
                table: "ExternalReviewers",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "ExternalReviewers",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DepartmentName",
                table: "Departments",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AssessmentFactor",
                table: "AssessmentsMatrixLikelihood",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AssessmentFactor",
                table: "AssessmentsMatrixImpact",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Basis",
                table: "AssessmentsBasis",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AssessmentsBasis",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 7, 13, 2, 55, 833, DateTimeKind.Utc).AddTicks(4132), new DateTime(2025, 1, 7, 13, 2, 55, 833, DateTimeKind.Utc).AddTicks(4133) });

            migrationBuilder.UpdateData(
                table: "AssessmentsBasis",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 7, 13, 2, 55, 833, DateTimeKind.Utc).AddTicks(4134), new DateTime(2025, 1, 7, 13, 2, 55, 833, DateTimeKind.Utc).AddTicks(4134) });

            migrationBuilder.UpdateData(
                table: "AssessmentsBasis",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 7, 13, 2, 55, 833, DateTimeKind.Utc).AddTicks(4135), new DateTime(2025, 1, 7, 13, 2, 55, 833, DateTimeKind.Utc).AddTicks(4136) });

            migrationBuilder.UpdateData(
                table: "AssessmentsBasis",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 7, 13, 2, 55, 833, DateTimeKind.Utc).AddTicks(4137), new DateTime(2025, 1, 7, 13, 2, 55, 833, DateTimeKind.Utc).AddTicks(4137) });

            migrationBuilder.UpdateData(
                table: "AssessmentsMatrixImpact",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 7, 13, 2, 55, 833, DateTimeKind.Utc).AddTicks(4182), new DateTime(2025, 1, 7, 13, 2, 55, 833, DateTimeKind.Utc).AddTicks(4183) });

            migrationBuilder.UpdateData(
                table: "AssessmentsMatrixImpact",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 7, 13, 2, 55, 833, DateTimeKind.Utc).AddTicks(4184), new DateTime(2025, 1, 7, 13, 2, 55, 833, DateTimeKind.Utc).AddTicks(4185) });

            migrationBuilder.UpdateData(
                table: "AssessmentsMatrixImpact",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 7, 13, 2, 55, 833, DateTimeKind.Utc).AddTicks(4186), new DateTime(2025, 1, 7, 13, 2, 55, 833, DateTimeKind.Utc).AddTicks(4187) });

            migrationBuilder.UpdateData(
                table: "AssessmentsMatrixImpact",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 7, 13, 2, 55, 833, DateTimeKind.Utc).AddTicks(4188), new DateTime(2025, 1, 7, 13, 2, 55, 833, DateTimeKind.Utc).AddTicks(4188) });

            migrationBuilder.UpdateData(
                table: "AssessmentsMatrixLikelihood",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 7, 13, 2, 55, 833, DateTimeKind.Utc).AddTicks(4209), new DateTime(2025, 1, 7, 13, 2, 55, 833, DateTimeKind.Utc).AddTicks(4209) });

            migrationBuilder.UpdateData(
                table: "AssessmentsMatrixLikelihood",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 7, 13, 2, 55, 833, DateTimeKind.Utc).AddTicks(4211), new DateTime(2025, 1, 7, 13, 2, 55, 833, DateTimeKind.Utc).AddTicks(4211) });

            migrationBuilder.UpdateData(
                table: "AssessmentsMatrixLikelihood",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 7, 13, 2, 55, 833, DateTimeKind.Utc).AddTicks(4213), new DateTime(2025, 1, 7, 13, 2, 55, 833, DateTimeKind.Utc).AddTicks(4213) });

            migrationBuilder.UpdateData(
                table: "AssessmentsMatrixLikelihood",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 7, 13, 2, 55, 833, DateTimeKind.Utc).AddTicks(4214), new DateTime(2025, 1, 7, 13, 2, 55, 833, DateTimeKind.Utc).AddTicks(4215) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 7, 13, 2, 55, 833, DateTimeKind.Utc).AddTicks(3783), new DateTime(2025, 1, 7, 13, 2, 55, 833, DateTimeKind.Utc).AddTicks(3787) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 7, 13, 2, 55, 833, DateTimeKind.Utc).AddTicks(3840), new DateTime(2025, 1, 7, 13, 2, 55, 833, DateTimeKind.Utc).AddTicks(3841) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 7, 13, 2, 55, 833, DateTimeKind.Utc).AddTicks(3842), new DateTime(2025, 1, 7, 13, 2, 55, 833, DateTimeKind.Utc).AddTicks(3842) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 7, 13, 2, 55, 833, DateTimeKind.Utc).AddTicks(3843), new DateTime(2025, 1, 7, 13, 2, 55, 833, DateTimeKind.Utc).AddTicks(3844) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 7, 13, 2, 55, 833, DateTimeKind.Utc).AddTicks(3845), new DateTime(2025, 1, 7, 13, 2, 55, 833, DateTimeKind.Utc).AddTicks(3846) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 7, 13, 2, 55, 833, DateTimeKind.Utc).AddTicks(3847), new DateTime(2025, 1, 7, 13, 2, 55, 833, DateTimeKind.Utc).AddTicks(3847) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 7, 13, 2, 55, 833, DateTimeKind.Utc).AddTicks(3848), new DateTime(2025, 1, 7, 13, 2, 55, 833, DateTimeKind.Utc).AddTicks(3849) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 7, 13, 2, 55, 833, DateTimeKind.Utc).AddTicks(3850), new DateTime(2025, 1, 7, 13, 2, 55, 833, DateTimeKind.Utc).AddTicks(3850) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 7, 13, 2, 55, 833, DateTimeKind.Utc).AddTicks(3851), new DateTime(2025, 1, 7, 13, 2, 55, 833, DateTimeKind.Utc).AddTicks(3852) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 7, 13, 2, 55, 833, DateTimeKind.Utc).AddTicks(3853), new DateTime(2025, 1, 7, 13, 2, 55, 833, DateTimeKind.Utc).AddTicks(3853) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 7, 13, 2, 55, 833, DateTimeKind.Utc).AddTicks(3854), new DateTime(2025, 1, 7, 13, 2, 55, 833, DateTimeKind.Utc).AddTicks(3855) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 7, 13, 2, 55, 833, DateTimeKind.Utc).AddTicks(3856), new DateTime(2025, 1, 7, 13, 2, 55, 833, DateTimeKind.Utc).AddTicks(3856) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 7, 13, 2, 55, 833, DateTimeKind.Utc).AddTicks(3857), new DateTime(2025, 1, 7, 13, 2, 55, 833, DateTimeKind.Utc).AddTicks(3858) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 7, 13, 2, 55, 833, DateTimeKind.Utc).AddTicks(3859), new DateTime(2025, 1, 7, 13, 2, 55, 833, DateTimeKind.Utc).AddTicks(3859) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 7, 13, 2, 55, 833, DateTimeKind.Utc).AddTicks(3860), new DateTime(2025, 1, 7, 13, 2, 55, 833, DateTimeKind.Utc).AddTicks(3861) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 7, 13, 2, 55, 833, DateTimeKind.Utc).AddTicks(3862), new DateTime(2025, 1, 7, 13, 2, 55, 833, DateTimeKind.Utc).AddTicks(3862) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 7, 13, 2, 55, 833, DateTimeKind.Utc).AddTicks(3863), new DateTime(2025, 1, 7, 13, 2, 55, 833, DateTimeKind.Utc).AddTicks(3864) });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 7, 13, 2, 55, 833, DateTimeKind.Utc).AddTicks(4163), new DateTime(2025, 1, 7, 13, 2, 55, 833, DateTimeKind.Utc).AddTicks(4163) });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 7, 13, 2, 55, 833, DateTimeKind.Utc).AddTicks(4165), new DateTime(2025, 1, 7, 13, 2, 55, 833, DateTimeKind.Utc).AddTicks(4166) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 7, 13, 2, 55, 833, DateTimeKind.Utc).AddTicks(4094), new DateTime(2025, 1, 7, 13, 2, 55, 833, DateTimeKind.Utc).AddTicks(4101) });
        }
    }
}
