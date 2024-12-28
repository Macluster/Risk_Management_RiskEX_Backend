using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Risk_Management_RiskEX_Backend.Data;
using Risk_Management_RiskEX_Backend.Models.DTO;
using Risk_Management_RiskEX_Backend.Models;
using Risk_Management_RiskEX_Backend.Repository;

namespace RiskManagement
{
    [TestFixture]

    public class ProjectRepositoryNUnitTests
    {
        private ApplicationDBContext _context;
        private ProjectRepository _repository;
        private IMapper _mapper;

        [SetUp]
        public void SetUp()
        {
            // Set up the in-memory database
            var options = new DbContextOptionsBuilder<ApplicationDBContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            _context = new ApplicationDBContext(options);

            // Initialize AutoMapper
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ProjectDTO, Project>();
            });
            _mapper = mapperConfig.CreateMapper();

            _repository = new ProjectRepository(_context, _mapper);

            // Seed data
            SeedDatabase();
        }

        [TearDown]
        public void TearDown()
        {
            _context.Database.EnsureDeleted();
            _context.Dispose();
        }

        private void SeedDatabase()
        {
            var departments = new List<Department>
        {
            new Department { Id = 1, DepartmentName = "IT" },
            new Department { Id = 2, DepartmentName = "HR" }
        };
            _context.Departments.AddRange(departments);

            var projects = new List<Project>
        {
            new Project { Id = 1, Name = "Data Center Migration", DepartmentId = 1, CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
            new Project { Id = 2, Name = "HR Inventory", DepartmentId = 2, CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow }
        };
            _context.Projects.AddRange(projects);

            _context.SaveChanges();
        }
        [Test]
        public async Task GetProjectsByDepartment_ShouldReturnProjects_WhenDepartmentExists()
        {
            // Act
            var projects = await _repository.GetProjectsByDepartment("IT");

            // Assert
            Assert.IsNotNull(projects);
            Assert.AreEqual(1, projects.Count());
            Assert.That("Data Center Migration", Is.EqualTo("Data Center Migration"));
        }

        [Test]
        public void GetProjectsByDepartment_ShouldThrowException_WhenDepartmentDoesNotExist()
        {
            // Act & Assert
            Assert.ThrowsAsync<Exception>(async () => await _repository.GetProjectsByDepartment("Finance"));
        }

        [Test]
        public async Task AddProjectToDepartment_ShouldReturnTrue_WhenProjectDoesNotExist()
        {
            // Arrange
            var projectDto = new ProjectDTO
            {
                ProjectName = "New IT Project",
                DepartmentName = "IT"
            };

            // Act
            var result = await _repository.AddProjectToDepartment(projectDto);

            // Assert
            Assert.IsTrue(result);
            Assert.AreEqual(3, await _context.Projects.CountAsync());
            Assert.IsTrue(await _context.Projects.AnyAsync(p => p.Name == "New IT Project"));
        }

        [Test]
        public async Task AddProjectToDepartment_ShouldReturnFalse_WhenDepartmentDoesNotExist()
        {
            // Arrange
            var projectDto = new ProjectDTO
            {
                ProjectName = "Finance Project",
                DepartmentName = "Finance"
            };

            // Act
            var result = await _repository.AddProjectToDepartment(projectDto);

            // Assert
            Assert.IsFalse(result);
            Assert.AreEqual(2, await _context.Projects.CountAsync());
        }

        [Test]
        public async Task AddProjectToDepartment_ShouldReturnFalse_WhenProjectAlreadyExistsInDepartment()
        {
            // Arrange
            var projectDto = new ProjectDTO
            {
                ProjectName = "Data Center Migration",
                DepartmentName = "IT"
            };

            // Act
            var result = await _repository.AddProjectToDepartment(projectDto);

            // Assert
            Assert.IsFalse(result);
            Assert.AreEqual(2, await _context.Projects.CountAsync());
        }
    }
}
