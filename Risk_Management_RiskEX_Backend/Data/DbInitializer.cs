using Microsoft.EntityFrameworkCore;
using Risk_Management_RiskEX_Backend.Models;
using System;

namespace Risk_Management_RiskEX_Backend.Data
{
    public static class DbInitializer
    {
        public static void SeedData(ModelBuilder modelBuilder)
        {
            // Seed Departments
            modelBuilder.Entity<Department>().HasData(
                new Department { Id = 1, DepartmentName = "SFM", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
                new Department {Id = 2, DepartmentName = "HR", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
                new Department {Id = 3, DepartmentName = "Finance", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
                new Department { Id = 4, DepartmentName = "IT", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
new Department { Id = 5, DepartmentName = "Marketing", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
new Department { Id = 6, DepartmentName = "Sales", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
new Department { Id = 7, DepartmentName = "Customer Support", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
new Department { Id = 8, DepartmentName = "Operations", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
new Department { Id = 9, DepartmentName = "Legal", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
new Department { Id = 10, DepartmentName = "Research & Development", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
new Department { Id = 11, DepartmentName = "Procurement", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
new Department { Id = 12, DepartmentName = "Quality Assurance", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
new Department { Id = 13, DepartmentName = "Training", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
new Department { Id = 14, DepartmentName = "Public Relations", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow }

            );

            // Seed Users
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    Email = "admin@riskex.com",
                    Password = "Admin@123", // In production, use hashed passwords
                    FullName = "System Admin",
                    DepartmentId = 1,
                    IsActive = true,
                    //CreatedBy = 1,
                    //UpdatedBy = 1,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new User
                {
                    Id = 2,
                    Email = "risk.manager@riskex.com",
                    Password = "Risk@123",
                    FullName = "Risk Manager",
                    DepartmentId = 1,
                    IsActive = true,
                    //CreatedBy = 1,
                    //UpdatedBy = 1,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                }
            );

            // Seed Assessment Basis
            modelBuilder.Entity<AssessmentBasis>().HasData(
                new AssessmentBasis
                {
                    Id = 1,
                    Basis = "Confidentiality",
               
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new AssessmentBasis
                {
                    Id = 2,
                    Basis = "Integrity",
    
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new AssessmentBasis
                {
                    Id = 3,
                    Basis = "Privacy",
 
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new AssessmentBasis
                {
                    Id = 4,
                    Basis = "Quality",

                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                }
            );

            // Seed Projects
            modelBuilder.Entity<Project>().HasData(
                new Project
                {
                    Id = 1,
                    Name = "Data Center Migration",
                    DepartmentId = 1,
                    UserId = 1,
                    CreatedById = 1,
                    UpdatedById = 1,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new Project
                {
                    Id = 2,
                    Name = "HR Inventory",
                    DepartmentId = 2,
                    UserId = 2,
                    CreatedById = 1,
                    UpdatedById = 1,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                }
            );
            // Seed Assessment Matrix Impact
            modelBuilder.Entity<AssessmentMatrixImpact>().HasData(
                new AssessmentMatrixImpact
                {
                    Id = 1,
                    AssessmentFactor = "Low",
                    Impact = 10.0,  // Updated value

                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new AssessmentMatrixImpact
                {
                    Id = 2,
                    AssessmentFactor = "Medium",
                    Impact = 20.0,  // Updated value

                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new AssessmentMatrixImpact
                {
                    Id = 3,
                    AssessmentFactor = "High",
                    Impact = 40.0,  // Updated value

                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new AssessmentMatrixImpact
                {
                    Id = 4,
                    AssessmentFactor = "Critical",
                    Impact = 60.0,  // Updated value

                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                }
            );

            // Seed Assessment Matrix Likelihood
            modelBuilder.Entity<AssessmentMatrixLikelihood>().HasData(
                new AssessmentMatrixLikelihood
                {
                    Id = 1,
                    AssessmentFactor = "Low",
                    Likelihood = 0.1,  // Updated value

                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new AssessmentMatrixLikelihood
                {
                    Id = 2,
                    AssessmentFactor = "Medium",
                    Likelihood = 0.2,  // Updated value

                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new AssessmentMatrixLikelihood
                {
                    Id = 3,
                    AssessmentFactor = "High",
                    Likelihood = 0.4,  // Updated value

                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new AssessmentMatrixLikelihood
                {
                    Id = 4,
                    AssessmentFactor = "Critical",
                    Likelihood = 0.6,  // Updated value

                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                }
            );
          
        }
    }
}