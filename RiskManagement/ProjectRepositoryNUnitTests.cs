using NUnit.Framework;
using Risk_Management_RiskEX_Backend.Data;
using Risk_Management_RiskEX_Backend.Repository;
using Risk_Management_RiskEX_Backend.Models;
using Risk_Management_RiskEX_Backend.Models.DTO;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Risk_Management_RiskEX_Backend.Tests
{
    [TestFixture]
    public class ProjectRepositoryTests
    {
        private ApplicationDBContext _dbContext;
        private ProjectRepository _repository;
        private IMapper _mapper;

        [SetUp]
        public void Setup()
        {
            // Setup in-memory database
            var options = new DbContextOptionsBuilder<ApplicationDBContext>()
                .UseInMemoryDatabase(databaseName: "TestDb")
                .Options;

            // Create a new in-memory context
            _dbContext = new ApplicationDBContext(options);

            // Setup AutoMapper (you can create a simple profile for testing purposes)
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ProjectDTO, Project>();
            });
            _mapper = config.CreateMapper();

            // Initialize repository with in-memory context and AutoMapper
            _repository = new ProjectRepository(_dbContext, _mapper);

            // Seed data for the tests
            SeedData();
        }

        [TearDown]
        public void TearDown()
        {
            // Dispose of the _dbContext after each test
            _dbContext?.Dispose();
        }

        private void SeedData()
        {
            // Seed departments
            var department = new Department
            {
                Id = 1,
                DepartmentName = "HR"
            };

            // Add to in-memory DbContext
            _dbContext.Departments.Add(department);

            // Seed projects
            var project = new Project
            {
                Id = 1,
                Name = "Project 1",
                DepartmentId = 1,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            _dbContext.Projects.Add(project);

            // Commit changes to the in-memory database
            _dbContext.SaveChanges();
        }

        [Test]
        public async Task GetProjectsByDepartment_ShouldReturnProjects_WhenDepartmentExists()
        {
            // Arrange
            var departmentName = "HR";

            // Act
            var result = await _repository.GetProjectsByDepartment(departmentName);

            // Assert
            Assert.IsNotNull(result);
            var project = result.FirstOrDefault();
            Assert.AreEqual("Project 1", ((ProjectDTO)project).ProjectName); // Cast to ProjectDTO
        }


        [Test]
        public async Task GetProjectsByDepartment_ShouldThrowException_WhenDepartmentDoesNotExist()
        {
            // Arrange
            var departmentName = "NonExistingDepartment";

            // Act & Assert
            var ex = Assert.ThrowsAsync<Exception>(async () => await _repository.GetProjectsByDepartment(departmentName));
            Assert.AreEqual("Department does not exist.", ex.Message);
        }

        [Test]
        public async Task AddProjectToDepartment_ShouldReturnTrue_WhenProjectIsAddedSuccessfully()
        {
            // Arrange
            var projectDto = new ProjectDTO
            {
                DepartmentName = "HR", // Make sure the department exists in the in-memory database
                ProjectName = "Project 2"
            };

            // Add the department to the in-memory database (Ensure "HR" exists)
            var options = new DbContextOptionsBuilder<ApplicationDBContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            using (var dbContext = new ApplicationDBContext(options))
            {
                dbContext.Departments.Add(new Department { DepartmentName = "HR" });
                await dbContext.SaveChangesAsync();

                var repository = new ProjectRepository(dbContext, _mapper); // Use the correct mapper

                // Act
                var result = await repository.AddProjectToDepartment(projectDto);

                // Assert
                Assert.IsTrue(result);

                var addedProject = await dbContext.Projects.FirstOrDefaultAsync(p => p.Name == "Project 2");
                Assert.NotNull(addedProject);
                Assert.AreEqual("Project 2", addedProject.Name);
            }
        }


        [Test]
        public async Task AddProjectToDepartment_ShouldReturnFalse_WhenDepartmentDoesNotExist()
        {
            // Arrange
            var projectDto = new ProjectDTO
            {
                DepartmentName = "NonExistingDepartment",
                ProjectName = "Project 3"
            };

            // Act
            var result = await _repository.AddProjectToDepartment(projectDto);

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public async Task AddProjectToDepartment_ShouldReturnFalse_WhenProjectAlreadyExists()
        {
            // Arrange
            var projectDto = new ProjectDTO
            {
                DepartmentName = "HR",
                ProjectName = "Project 1"
            };

            // Act
            var result = await _repository.AddProjectToDepartment(projectDto);

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public async Task AddProjectToDepartment_ShouldReturnFalse_WhenExceptionOccurs()
        {
            // Arrange
            var projectDto = new ProjectDTO
            {
                DepartmentName = "HR",
                ProjectName = "Project 4"
            };

            // Simulate an exception by modifying the DbContext
            _dbContext.Projects.Add(new Project { Name = "Project 4", DepartmentId = 1 });
            await _dbContext.SaveChangesAsync();

            // Act
            var result = await _repository.AddProjectToDepartment(projectDto);

            // Assert
            Assert.IsFalse(result);
        }
    }
}
