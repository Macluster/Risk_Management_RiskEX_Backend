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
    public class RiskResponseDataNUnitTests
    {
        public class RiskResponseRepositoryTests
        {
            private ApplicationDBContext CreateInMemoryDbContext()
            {
                var options = new DbContextOptionsBuilder<ApplicationDBContext>()
                    .UseInMemoryDatabase(Guid.NewGuid().ToString())
                    .Options;

                var context = new ApplicationDBContext(options);

                // Seed RiskResponseData
                context.RiskResponseDatas.AddRange(
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
                        Example = "Developing a backup system to reduce the impact of potential server failures."
                    },
                    new RiskResponseData
                    {
                        Id = 3,
                        Name = "Transfer",
                        Description = "Transferring the risk involves shifting the responsibility for managing the risk to another party. This could be achieved through insurance, outsourcing, partnerships, or contracts.",
                        Example = "Purchasing insurance to cover financial losses due to unforeseen events."
                    },
                    new RiskResponseData
                    {
                        Id = 4,
                        Name = "Accept",
                        Description = "Accepting the risk means acknowledging its existence and choosing not to take specific actions to mitigate or avoid it.",
                        Example = "Deciding not to invest in additional security for a low-value system because the cost of mitigation exceeds the potential impact of the risk."
                    }
                );

                context.SaveChanges();
                return context;
            }

            [Test]
            public async Task GedtAllRiskResponse_ShouldReturnAllRiskResponses()
            {
                // Arrange
                var dbContext = CreateInMemoryDbContext();
                var repository = new RiskResponseRepository(dbContext);

                // Act
                var result = await repository.GedtAllRiskResponse();

                // Assert
                Assert.NotNull(result);
                Assert.AreEqual(4, result.Count); // Four RiskResponseData records exist in the seeded data
            }

            [Test]
            public async Task GedtAllRiskResponse_ShouldReturnCorrectData()
            {
                // Arrange
                var dbContext = CreateInMemoryDbContext();
                var repository = new RiskResponseRepository(dbContext);

                // Act
                var result = await repository.GedtAllRiskResponse();
                var riskResponse = result.FirstOrDefault(r => r.Id == 1);

                // Assert
                Assert.NotNull(riskResponse);
                Assert.AreEqual("Avoid", riskResponse.Name);
                Assert.AreEqual("This strategy aims to eliminate the risk entirely by taking actions that prevent the risk from occurring. It involves altering project plans or processes to steer clear of the risk's potential impact.", riskResponse.Description);
                Assert.AreEqual("Changing a project scope to exclude a high-risk feature that could lead to technical challenges.", riskResponse.Example);
            }

            [Test]
            public async Task GedtAllRiskResponse_ShouldReturnEmptyListIfNoDataExists()
            {
                // Arrange
                var options = new DbContextOptionsBuilder<ApplicationDBContext>()
                    .UseInMemoryDatabase(Guid.NewGuid().ToString())
                    .Options;
                var dbContext = new ApplicationDBContext(options);
                var repository = new RiskResponseRepository(dbContext);

                // Act
                var result = await repository.GedtAllRiskResponse();

                // Assert
                Assert.NotNull(result);
                Assert.AreEqual(0, result.Count); // No records exist in the database
            }
        }
        }
}
