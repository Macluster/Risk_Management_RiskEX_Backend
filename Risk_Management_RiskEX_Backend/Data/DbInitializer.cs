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

           
            // Seed Assessment Matrix Impact
            modelBuilder.Entity<AssessmentMatrixImpact>().HasData(
                new AssessmentMatrixImpact
                {
                    Id = 1,
                    AssessmentFactor = "Low",
                    Impact = 10.0, 
                    Definition = "The consequences of the risk are minimal, with negligible effects on the organization's operations, finances, or reputation.",
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new AssessmentMatrixImpact
                {
                    Id = 2,
                    AssessmentFactor = "Medium",
                    Impact = 20.0,  
                    Definition = "The consequences of the risk are moderate, causing some disruption or financial loss, but manageable without significant impact on key objectives.",
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new AssessmentMatrixImpact
                {
                    Id = 3,
                    AssessmentFactor = "High",
                    Impact = 40.0, 
                    Definition= "The consequences of the risk are significant, causing major disruptions, substantial financial losses, or harm to the organization’s reputation.",
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new AssessmentMatrixImpact
                {
                    Id = 4,
                    AssessmentFactor = "Critical",
                    Impact = 60.0,  
                    Definition = "The consequences of the risk are severe, potentially threatening the organization's ability to operate or causing irreparable harm.",
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
                    Definition = "The probability of the risk occurring is minimal, with little to no historical evidence or indication of occurrence.(Once in 3 Years)",
                    ChanceOfOccurance = "<=10%",
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new AssessmentMatrixLikelihood
                {
                    Id = 2,
                    AssessmentFactor = "Medium",
                    Likelihood = 0.2, 
                    Definition = "There is a moderate probability of the risk occurring. It may have occurred in the past under similar circumstances(Once a year)",
                    ChanceOfOccurance = "10-50%",
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new AssessmentMatrixLikelihood
                {
                    Id = 3,
                    AssessmentFactor = "High",
                    Likelihood = 0.4, 
                    Definition= "The probability of the risk occurring is significant, and it is likely to happen based on historical trends or current conditions.(Once a quarter)",
                    ChanceOfOccurance = "50-90%",
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new AssessmentMatrixLikelihood
                {
                    Id = 4,
                    AssessmentFactor = "Critical",
                    Likelihood = 0.6,  
                    Definition = "The risk is almost certain to occur, with a very high probability of materializing(Once a month)",
                    ChanceOfOccurance = ">=90%",
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
                   Example = "Changing a project scope to exclude a high-risk feature that could lead to technical challenges, Discontinuing a risky process or project."
               },
               new RiskResponseData
               {
                   Id = 2,
                   Name = "Mitigate",
                   Description = "Mitigation involves taking proactive steps to reduce the likelihood or impact of a risk. It focuses on minimizing the risk's negative effects while still allowing the project or function to move forward.",
                   Example = "Developing a backup system to reduce the impact of potential server failures, Implementing access controls, encryption, or training."
               },
                new RiskResponseData
                {
                    Id = 3,
                    Name = "Transfer",
                    Description =  "Transferring the risk involves shifting the responsibility for managing the risk to another party. This could be achieved through insurance, outsourcing, partnerships, or contracts.",
                    Example = "Purchasing insurance to cover financial losses due to unforeseen events, Purchasing cybersecurity insurance or outsourcing to a secure service provider."

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