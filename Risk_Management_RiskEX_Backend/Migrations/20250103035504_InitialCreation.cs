﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Risk_Management_RiskEX_Backend.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    UserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: true),
                    SecurityStamp = table.Column<string>(type: "text", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AssessmentsBasis",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Basis = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamptz", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamptz", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssessmentsBasis", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AssessmentsMatrixImpact",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AssessmentFactor = table.Column<string>(type: "text", nullable: false),
                    Impact = table.Column<double>(type: "double precision", nullable: false),
                    Definition = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamptz", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamptz", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssessmentsMatrixImpact", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AssessmentsMatrixLikelihood",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AssessmentFactor = table.Column<string>(type: "text", nullable: false),
                    Likelihood = table.Column<double>(type: "double precision", nullable: false),
                    Definition = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamptz", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamptz", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssessmentsMatrixLikelihood", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DepartmentName = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamptz", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamptz", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RiskResponseDatas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Example = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RiskResponseDatas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoleId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    ProviderKey = table.Column<string>(type: "text", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "text", nullable: false),
                    RoleId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "text", nullable: false),
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: true),
                    FullName = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    DepartmentId = table.Column<int>(type: "integer", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamptz", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamptz", nullable: true),
                    CreatedById = table.Column<int>(type: "integer", nullable: true),
                    UpdatedById = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Users_Users_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Users_Users_UpdatedById",
                        column: x => x.UpdatedById,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ExternalReviewers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FullName = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    DepartmentId = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamptz", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamptz", nullable: true),
                    CreatedById = table.Column<int>(type: "integer", nullable: true),
                    UpdatedById = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExternalReviewers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExternalReviewers_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExternalReviewers_Users_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ExternalReviewers_Users_UpdatedById",
                        column: x => x.UpdatedById,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    DepartmentId = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamptz", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamptz", nullable: true),
                    CreatedById = table.Column<int>(type: "integer", nullable: true),
                    UpdatedById = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Projects_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Projects_Users_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Projects_Users_UpdatedById",
                        column: x => x.UpdatedById,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Projects_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: true),
                    ExternalReviewerId = table.Column<int>(type: "integer", nullable: true),
                    Comments = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: true),
                    ReviewStatus = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamptz", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamptz", nullable: true),
                    CreatedById = table.Column<int>(type: "integer", nullable: true),
                    UpdatedById = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reviews_ExternalReviewers_ExternalReviewerId",
                        column: x => x.ExternalReviewerId,
                        principalTable: "ExternalReviewers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Reviews_Users_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Reviews_Users_UpdatedById",
                        column: x => x.UpdatedById,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Reviews_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Risks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RiskId = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    RiskName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false),
                    RiskType = table.Column<int>(type: "integer", nullable: false),
                    Impact = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false),
                    Mitigation = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false),
                    Contingency = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    OverallRiskRating = table.Column<int>(type: "integer", nullable: false),
                    ResponsibleUserId = table.Column<int>(type: "integer", nullable: false),
                    PlannedActionDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ClosedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    RiskStatus = table.Column<int>(type: "integer", nullable: false),
                    RiskResponseId = table.Column<int>(type: "integer", nullable: true),
                    Remarks = table.Column<string>(type: "text", nullable: true),
                    DepartmentId = table.Column<int>(type: "integer", nullable: false),
                    ProjectId = table.Column<int>(type: "integer", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamptz", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamptz", nullable: true),
                    CreatedById = table.Column<int>(type: "integer", nullable: true),
                    UpdatedById = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Risks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Risks_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Risks_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Risks_RiskResponseDatas_RiskResponseId",
                        column: x => x.RiskResponseId,
                        principalTable: "RiskResponseDatas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Risks_Users_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Risks_Users_ResponsibleUserId",
                        column: x => x.ResponsibleUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Risks_Users_UpdatedById",
                        column: x => x.UpdatedById,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Assessments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Likelihood = table.Column<int>(type: "integer", nullable: false),
                    Impact = table.Column<int>(type: "integer", nullable: false),
                    AssessmentBasisId = table.Column<int>(type: "integer", nullable: true),
                    RiskId = table.Column<int>(type: "integer", nullable: false),
                    RiskFactor = table.Column<int>(type: "integer", nullable: false),
                    IsMitigated = table.Column<bool>(type: "boolean", nullable: false),
                    ReviewId = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamptz", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamptz", nullable: true),
                    CreatedById = table.Column<int>(type: "integer", nullable: true),
                    UpdatedById = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assessments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Assessments_AssessmentsBasis_AssessmentBasisId",
                        column: x => x.AssessmentBasisId,
                        principalTable: "AssessmentsBasis",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Assessments_AssessmentsMatrixImpact_Impact",
                        column: x => x.Impact,
                        principalTable: "AssessmentsMatrixImpact",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Assessments_AssessmentsMatrixLikelihood_Likelihood",
                        column: x => x.Likelihood,
                        principalTable: "AssessmentsMatrixLikelihood",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Assessments_Reviews_ReviewId",
                        column: x => x.ReviewId,
                        principalTable: "Reviews",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Assessments_Risks_RiskId",
                        column: x => x.RiskId,
                        principalTable: "Risks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Assessments_Users_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Assessments_Users_UpdatedById",
                        column: x => x.UpdatedById,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "AssessmentsBasis",
                columns: new[] { "Id", "Basis", "CreatedAt", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, "Confidentiality", new DateTime(2025, 1, 3, 3, 55, 4, 463, DateTimeKind.Utc).AddTicks(7412), new DateTime(2025, 1, 3, 3, 55, 4, 463, DateTimeKind.Utc).AddTicks(7413) },
                    { 2, "Integrity", new DateTime(2025, 1, 3, 3, 55, 4, 463, DateTimeKind.Utc).AddTicks(7414), new DateTime(2025, 1, 3, 3, 55, 4, 463, DateTimeKind.Utc).AddTicks(7415) },
                    { 3, "Privacy", new DateTime(2025, 1, 3, 3, 55, 4, 463, DateTimeKind.Utc).AddTicks(7416), new DateTime(2025, 1, 3, 3, 55, 4, 463, DateTimeKind.Utc).AddTicks(7416) },
                    { 4, "Quality", new DateTime(2025, 1, 3, 3, 55, 4, 463, DateTimeKind.Utc).AddTicks(7417), new DateTime(2025, 1, 3, 3, 55, 4, 463, DateTimeKind.Utc).AddTicks(7418) }
                });

            migrationBuilder.InsertData(
                table: "AssessmentsMatrixImpact",
                columns: new[] { "Id", "AssessmentFactor", "CreatedAt", "Definition", "Impact", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, "Low", new DateTime(2025, 1, 3, 3, 55, 4, 463, DateTimeKind.Utc).AddTicks(7454), "No/slight effect on business", 10.0, new DateTime(2025, 1, 3, 3, 55, 4, 463, DateTimeKind.Utc).AddTicks(7454) },
                    { 2, "Medium", new DateTime(2025, 1, 3, 3, 55, 4, 463, DateTimeKind.Utc).AddTicks(7456), "business objectives affected", 20.0, new DateTime(2025, 1, 3, 3, 55, 4, 463, DateTimeKind.Utc).AddTicks(7457) },
                    { 3, "High", new DateTime(2025, 1, 3, 3, 55, 4, 463, DateTimeKind.Utc).AddTicks(7458), "business objectives undermined", 40.0, new DateTime(2025, 1, 3, 3, 55, 4, 463, DateTimeKind.Utc).AddTicks(7458) },
                    { 4, "Critical", new DateTime(2025, 1, 3, 3, 55, 4, 463, DateTimeKind.Utc).AddTicks(7459), "business objectives not accomplished", 60.0, new DateTime(2025, 1, 3, 3, 55, 4, 463, DateTimeKind.Utc).AddTicks(7460) }
                });

            migrationBuilder.InsertData(
                table: "AssessmentsMatrixLikelihood",
                columns: new[] { "Id", "AssessmentFactor", "CreatedAt", "Definition", "Likelihood", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, "Low", new DateTime(2025, 1, 3, 3, 55, 4, 463, DateTimeKind.Utc).AddTicks(7511), "1-24% chance of occurrence", 0.10000000000000001, new DateTime(2025, 1, 3, 3, 55, 4, 463, DateTimeKind.Utc).AddTicks(7511) },
                    { 2, "Medium", new DateTime(2025, 1, 3, 3, 55, 4, 463, DateTimeKind.Utc).AddTicks(7513), "25-49% chance of occurrence", 0.20000000000000001, new DateTime(2025, 1, 3, 3, 55, 4, 463, DateTimeKind.Utc).AddTicks(7513) },
                    { 3, "High", new DateTime(2025, 1, 3, 3, 55, 4, 463, DateTimeKind.Utc).AddTicks(7515), "50-74% chance of occurrence", 0.40000000000000002, new DateTime(2025, 1, 3, 3, 55, 4, 463, DateTimeKind.Utc).AddTicks(7515) },
                    { 4, "Critical", new DateTime(2025, 1, 3, 3, 55, 4, 463, DateTimeKind.Utc).AddTicks(7516), "75-99% chance of occurrence", 0.59999999999999998, new DateTime(2025, 1, 3, 3, 55, 4, 463, DateTimeKind.Utc).AddTicks(7517) }
                });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "CreatedAt", "DepartmentName", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 1, 3, 3, 55, 4, 463, DateTimeKind.Utc).AddTicks(7238), "SFM", new DateTime(2025, 1, 3, 3, 55, 4, 463, DateTimeKind.Utc).AddTicks(7241) },
                    { 2, new DateTime(2025, 1, 3, 3, 55, 4, 463, DateTimeKind.Utc).AddTicks(7243), "HR", new DateTime(2025, 1, 3, 3, 55, 4, 463, DateTimeKind.Utc).AddTicks(7243) },
                    { 3, new DateTime(2025, 1, 3, 3, 55, 4, 463, DateTimeKind.Utc).AddTicks(7245), "Finance", new DateTime(2025, 1, 3, 3, 55, 4, 463, DateTimeKind.Utc).AddTicks(7245) },
                    { 4, new DateTime(2025, 1, 3, 3, 55, 4, 463, DateTimeKind.Utc).AddTicks(7246), "Admin & Purchase", new DateTime(2025, 1, 3, 3, 55, 4, 463, DateTimeKind.Utc).AddTicks(7247) }
                });

            migrationBuilder.InsertData(
                table: "RiskResponseDatas",
                columns: new[] { "Id", "Description", "Example", "Name" },
                values: new object[,]
                {
                    { 1, "This strategy aims to eliminate the risk entirely by taking actions that prevent the risk from occurring. It involves altering project plans or processes to steer clear of the risk's potential impact.", "Changing a project scope to exclude a high-risk feature that could lead to technical challenges.", "Avoid" },
                    { 2, "Mitigation involves taking proactive steps to reduce the likelihood or impact of a risk. It focuses on minimizing the risk's negative effects while still allowing the project or function to move forward.", "Developing a backup system to reduce the impact of potential server failures.", "Mitigate" },
                    { 3, "Transferring the risk involves shifting the responsibility for managing the risk to another party. This could be achieved through insurance, outsourcing, partnerships, or contracts.", "Purchasing insurance to cover financial losses due to unforeseen events.", "Transfer" },
                    { 4, "Accepting the risk means acknowledging its existence and choosing not to take specific actions to mitigate or avoid it.", "Deciding not to invest in additional security for a low-value system because the cost of mitigation exceeds the potential impact of the risk.", "Accept" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "CreatedById", "DepartmentId", "Email", "FullName", "IsActive", "Password", "UpdatedAt", "UpdatedById" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 1, 3, 3, 55, 4, 463, DateTimeKind.Utc).AddTicks(7387), null, 1, "admin@gmail.com", "System Admin", true, "admin@123", new DateTime(2025, 1, 3, 3, 55, 4, 463, DateTimeKind.Utc).AddTicks(7387), null },
                    { 2, new DateTime(2025, 1, 3, 3, 55, 4, 463, DateTimeKind.Utc).AddTicks(7389), null, 1, "risk.manager@riskex.com", "Risk Manager", true, "Risk@123", new DateTime(2025, 1, 3, 3, 55, 4, 463, DateTimeKind.Utc).AddTicks(7390), null }
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "CreatedAt", "CreatedById", "DepartmentId", "Name", "UpdatedAt", "UpdatedById", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 1, 3, 3, 55, 4, 463, DateTimeKind.Utc).AddTicks(7437), 1, 1, "Data Center Migration", new DateTime(2025, 1, 3, 3, 55, 4, 463, DateTimeKind.Utc).AddTicks(7438), 1, 1 },
                    { 2, new DateTime(2025, 1, 3, 3, 55, 4, 463, DateTimeKind.Utc).AddTicks(7440), 1, 2, "HR Inventory", new DateTime(2025, 1, 3, 3, 55, 4, 463, DateTimeKind.Utc).AddTicks(7441), 1, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Assessments_AssessmentBasisId",
                table: "Assessments",
                column: "AssessmentBasisId");

            migrationBuilder.CreateIndex(
                name: "IX_Assessments_CreatedById",
                table: "Assessments",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Assessments_Impact",
                table: "Assessments",
                column: "Impact");

            migrationBuilder.CreateIndex(
                name: "IX_Assessments_Likelihood",
                table: "Assessments",
                column: "Likelihood");

            migrationBuilder.CreateIndex(
                name: "IX_Assessments_ReviewId",
                table: "Assessments",
                column: "ReviewId");

            migrationBuilder.CreateIndex(
                name: "IX_Assessments_RiskId",
                table: "Assessments",
                column: "RiskId");

            migrationBuilder.CreateIndex(
                name: "IX_Assessments_UpdatedById",
                table: "Assessments",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_ExternalReviewers_CreatedById",
                table: "ExternalReviewers",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_ExternalReviewers_DepartmentId",
                table: "ExternalReviewers",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_ExternalReviewers_UpdatedById",
                table: "ExternalReviewers",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_CreatedById",
                table: "Projects",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_DepartmentId",
                table: "Projects",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_UpdatedById",
                table: "Projects",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_UserId",
                table: "Projects",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_CreatedById",
                table: "Reviews",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_ExternalReviewerId",
                table: "Reviews",
                column: "ExternalReviewerId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_UpdatedById",
                table: "Reviews",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_UserId",
                table: "Reviews",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Risks_CreatedById",
                table: "Risks",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Risks_DepartmentId",
                table: "Risks",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Risks_ProjectId",
                table: "Risks",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Risks_ResponsibleUserId",
                table: "Risks",
                column: "ResponsibleUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Risks_RiskResponseId",
                table: "Risks",
                column: "RiskResponseId");

            migrationBuilder.CreateIndex(
                name: "IX_Risks_UpdatedById",
                table: "Risks",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Users_CreatedById",
                table: "Users",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Users_DepartmentId",
                table: "Users",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_UpdatedById",
                table: "Users",
                column: "UpdatedById");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Assessments");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "AssessmentsBasis");

            migrationBuilder.DropTable(
                name: "AssessmentsMatrixImpact");

            migrationBuilder.DropTable(
                name: "AssessmentsMatrixLikelihood");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "Risks");

            migrationBuilder.DropTable(
                name: "ExternalReviewers");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "RiskResponseDatas");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Departments");
        }
    }
}
