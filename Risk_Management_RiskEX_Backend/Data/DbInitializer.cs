﻿using Microsoft.EntityFrameworkCore;
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
                new Department { Id = 1, DepartmentName = "Audits & Compliance", DepartmentCode = "ACE", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
                new Department { Id = 2, DepartmentName = "EMT", DepartmentCode = "EMT", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
                new Department { Id = 3, DepartmentName = "SFM", DepartmentCode = "SFM", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
                new Department { Id = 4, DepartmentName = "HR", DepartmentCode = "HR", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
                new Department { Id = 5, DepartmentName = "Admin & Purchase", DepartmentCode = "A&D", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
                new Department { Id = 6, DepartmentName = "DU1", DepartmentCode = "DU1", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
                new Department { Id = 7, DepartmentName = "DU2", DepartmentCode = "DU2", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
                new Department { Id = 8, DepartmentName = "DU3", DepartmentCode = "DU3", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
                new Department { Id = 9, DepartmentName = "DU4", DepartmentCode = "DU4", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
                new Department { Id = 10, DepartmentName = "DU5", DepartmentCode = "DU5", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
                new Department { Id = 11, DepartmentName = "DU6", DepartmentCode = "DU6", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
                new Department { Id = 12, DepartmentName = "Marketing", DepartmentCode = "MAR", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
                new Department { Id = 13, DepartmentName = "Learning & Development", DepartmentCode = "L&D", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
                new Department { Id = 14, DepartmentName = "Finance", DepartmentCode = "FIN", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow }


            );

            // Seed Users
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    Email = "riskex@experionglobal.com",
                    Password = "AQAAAAIAAYagAAAAEAaroqhRU1q5tzEl35QYww+8xRNB3KLD6rrlXLdANJ8N2kUrAXvLsEYOpWldjgmzMg==",
                    FullName = "System Admin",
                    DepartmentId = 1,
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new User
                {
                    Id = 2,
                    Email = "admin@gmail.com",
                    Password = "AQAAAAIAAYagAAAAEAaroqhRU1q5tzEl35QYww+8xRNB3KLD6rrlXLdANJ8N2kUrAXvLsEYOpWldjgmzMg==",
                    FullName = "System Admin",
                    DepartmentId = 1,
                    IsActive = true,
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
                    Basis = "Availability",
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new AssessmentBasis
                {
                    Id = 4,
                    Basis = "Privacy",
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
                    Impact = 10.0, 
                    Definition = "No slight effect on business",
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new AssessmentMatrixImpact
                {
                    Id = 2,
                    AssessmentFactor = "Medium",
                    Impact = 20.0,  
                    Definition = "Business objectives affected",
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new AssessmentMatrixImpact
                {
                    Id = 3,
                    AssessmentFactor = "High",
                    Impact = 40.0, 
                    Definition= "Business objectives undermined",
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new AssessmentMatrixImpact
                {
                    Id = 4,
                    AssessmentFactor = "Critical",
                    Impact = 60.0,  
                    Definition = "Business objectives not accomplished",
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
                    Likelihood = 0.1,  
                    Definition = "1-24% chance of occurrence",
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new AssessmentMatrixLikelihood
                {
                    Id = 2,
                    AssessmentFactor = "Medium",
                    Likelihood = 0.2, 
                    Definition = "25-49% chance of occurrence",
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new AssessmentMatrixLikelihood
                {
                    Id = 3,
                    AssessmentFactor = "High",
                    Likelihood = 0.4, 
                    Definition= "50-74% chance of occurrence",
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new AssessmentMatrixLikelihood
                {
                    Id = 4,
                    AssessmentFactor = "Critical",
                    Likelihood = 0.6,  
                    Definition = "75-99% chance of occurrence",
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                }
            );
            modelBuilder.Entity<RiskResponseData>().HasData(
               new RiskResponseData
               {
                   Id = 1,
                   Name = "Avoid",
                   Description = "This strategy aims to eliminate the risk entirely by taking actions that prevent the risk from occurring. It involves altering project plans or processes to steer clear of the risk's potential impact.",
                   Example = "Changing a project scope to exclude a high-risk feature that could lead to technical challenges."
               },
               new RiskResponseData
               {
                   Id = 2,
                   Name = "Mitigate",
                   Description = "Mitigation involves taking proactive steps to reduce the likelihood or impact of a risk. It focuses on minimizing the risk's negative effects while still allowing the project or function to move forward.",
                   Example =  "Developing a backup system to reduce the impact of potential server failures."
               },
                new RiskResponseData
                {
                    Id = 3,
                    Name = "Transfer",
                    Description =  "Transferring the risk involves shifting the responsibility for managing the risk to another party. This could be achieved through insurance, outsourcing, partnerships, or contracts.",
                    Example =  "Purchasing insurance to cover financial losses due to unforeseen events."

                },
                new RiskResponseData
                {
                    Id = 4,
                    Name = "Accept",
                    Description =  "Accepting the risk means acknowledging its existence and choosing not to take specific actions to mitigate or avoid it.",
                    Example =  "Deciding not to invest in additional security for a low-value system because the cost of mitigation exceeds the potential impact of the risk."
                }
             
        
               );


        }
    }
}