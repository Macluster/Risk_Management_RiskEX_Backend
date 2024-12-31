using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Risk_Management_RiskEX_Backend.Data;
using Risk_Management_RiskEX_Backend.Models;
using Risk_Management_RiskEX_Backend.Repository;

namespace RiskManagement
{
    [TestFixture]
    public class AssessmentMatrixLikelihoodRepositoryNUnitTests
    {
        private ApplicationDBContext CreateInMemoryDbContext()
        {
            var options = new DbContextOptionsBuilder<ApplicationDBContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            var context = new ApplicationDBContext(options);

            // Seed data
            context.AssessmentsMatrixLikelihood.AddRange(
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
                    Definition = "50-74% chance of occurrence",
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

            context.SaveChanges();
            return context;
        }

        [Test]
        public async Task GetAllLikelyHoodData_ShouldReturnAllRecords()
        {
            // Arrange
            var dbContext = CreateInMemoryDbContext();
            var repository = new AssessmentMatrixLikelihoodRepository(dbContext);

            // Act
            var result = await repository.GetAllLikelyHoodData();

            // Assert
            Assert.NotNull(result);
            Assert.AreEqual(4, result.Count); 
        }

        [Test]
        public async Task GetAllLikelyHoodData_ShouldReturnCorrectData()
        {
            // Arrange
            var dbContext = CreateInMemoryDbContext();
            var repository = new AssessmentMatrixLikelihoodRepository(dbContext);

            // Act
            var result = await repository.GetAllLikelyHoodData();

            // Assert
            Assert.IsTrue(result.Any(r => r.AssessmentFactor == "Low" && r.Likelihood == 0.1));
            Assert.IsTrue(result.Any(r => r.AssessmentFactor == "Medium" && r.Likelihood == 0.2));
            Assert.IsTrue(result.Any(r => r.AssessmentFactor == "High" && r.Likelihood == 0.4));
            Assert.IsTrue(result.Any(r => r.AssessmentFactor == "Critical" && r.Likelihood == 0.6));
        }

        [Test]
        public async Task GetAllLikelyHoodData_ShouldHandleEmptyDatabase()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<ApplicationDBContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            using var dbContext = new ApplicationDBContext(options);
            var repository = new AssessmentMatrixLikelihoodRepository(dbContext);

            // Act
            var result = await repository.GetAllLikelyHoodData();

            // Assert
            Assert.NotNull(result);
            Assert.AreEqual(0, result.Count); // Ensure no records are returned when database is empty
        }

        [Test]
        public async Task GetAllLikelyHoodData_ShouldReturnDataWithCorrectStructure()
        {
            // Arrange
            var dbContext = CreateInMemoryDbContext();
            var repository = new AssessmentMatrixLikelihoodRepository(dbContext);

            // Act
            var result = await repository.GetAllLikelyHoodData();

            // Assert
            foreach (var item in result)
            {
                Assert.IsNotNull(item.AssessmentFactor);
                Assert.IsNotNull(item.Definition);
                Assert.IsTrue(item.Likelihood > 0); // Likelihood should always be greater than 0
            }
        }
    }
}
