using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Risk_Management_RiskEX_Backend.Data;
using Risk_Management_RiskEX_Backend.Interfaces;
using Risk_Management_RiskEX_Backend.Models.DTO;
using Risk_Management_RiskEX_Backend.Models;
using Risk_Management_RiskEX_Backend.Repository;
using Microsoft.AspNetCore.Http;


namespace RiskManagement
{
    [TestFixture]
    public class UserRepositoryNUnitTests
    {
        private ApplicationDBContext _context;
        private IMapper _mapper;
        private ILogger<UserRepository> _logger;
        private IEmailService _emailService;
        private UserRepository _userRepository;
        private Department _testDepartment;
        private Project _testProject;

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            // AutoMapper configuration
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<UsersDTO, User>()
                    .ForMember(dest => dest.Department, opt => opt.Ignore())
                    .ForMember(dest => dest.Projects, opt => opt.Ignore());
                cfg.CreateMap<User, AssigneeResponseDTO>();
            });
            _mapper = config.CreateMapper();
        }

        [SetUp]
        public async Task Setup()
        {
            // Create in-memory database with sensitive data logging
            var options = new DbContextOptionsBuilder<ApplicationDBContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .EnableSensitiveDataLogging()
                .Options;
            var httpContextAccessor = new HttpContextAccessor();

            _context = new ApplicationDBContext(options, httpContextAccessor);

            // Create logger
            var loggerFactory = LoggerFactory.Create(builder => builder.AddConsole());
            _logger = loggerFactory.CreateLogger<UserRepository>();

            // Create simple email service
            _emailService = new SimpleEmailService();

            _userRepository = new UserRepository(_context, _mapper, _logger, _emailService);

            // Seed test data
            await SeedTestData();
        }

        [TearDown]
        public void TearDown()
        {
            _context.Database.EnsureDeleted();
            _context.Dispose();
        }

        private async Task SeedTestData()
        {
            // Create Department
            _testDepartment = new Department
            {
                DepartmentName = "IT",
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };
            await _context.Departments.AddAsync(_testDepartment);

            // Create Project
            _testProject = new Project
            {
                Name = "Test Project",
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };
            await _context.Projects.AddAsync(_testProject);

            // Create existing user
            var user = new User
            {
                FullName = "Test User",
                Email = "existing@test.com",
                Department = _testDepartment,
                IsActive = true,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };
            await _context.Users.AddAsync(user);

            // Create Risk
            var risk = new Risk
            {
                RiskId = "RISK-001",
                RiskName = "Test Risk",
                Description = "Test Risk Description",
                Impact = "High",
                Mitigation = "Test Mitigation",
                ResponsibleUser = user,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };
            await _context.Risks.AddAsync(risk);

            await _context.SaveChangesAsync();
        }

     

        [Test]
        public async Task AddUserToDepartment_InvalidDepartment_ReturnsZero()
        {
            // Arrange
            var userDto = new UsersDTO
            {
                FullName = "New User",
                Email = "new@test.com",
                DepartmentName = "Non-Existent Department",
                ProjectNames = new List<string> { "Test Project" }
            };

            // Act
            var result = await _userRepository.AddUserToDepartment(userDto);

            // Assert
            Assert.That(result, Is.EqualTo(0));
        }

        [Test]
        public async Task AddUserToDepartment_InvalidProject_ReturnsZero()
        {
            // Arrange
            var department = await _context.Departments.FirstOrDefaultAsync();
            var userDto = new UsersDTO
            {
                FullName = "New User",
                Email = "new@test.com",
                DepartmentName = department.DepartmentName,
                ProjectNames = new List<string> { "Non-Existent Project" }
            };

            // Act
            var result = await _userRepository.AddUserToDepartment(userDto);

            // Assert
            Assert.That(result, Is.EqualTo(0));
        }

        [Test]
        public async Task AddUserToDepartment_ExistingEmail_ReturnsZero()
        {
            // Arrange
            var userDto = new UsersDTO
            {
                FullName = "Duplicate User",
                Email = "existing@test.com",
                DepartmentName = "IT"
            };

            // Act
            var result = await _userRepository.AddUserToDepartment(userDto);

            // Assert
            Assert.That(result, Is.EqualTo(0));
        }

        [Test]
        public async Task ChangeUserActiveStatus_ValidUser_ReturnsTrue()
        {
            // Act
            var result = await _userRepository.ChangeUserActiveStatus(1, false);

            // Assert
            Assert.That(result, Is.True);
            var user = await _context.Users.FindAsync(1);
            Assert.That(user.IsActive, Is.False);
        }

        [Test]
        public async Task GetNameAndEmailOfAUser_ValidId_ReturnsUserInfo()
        {
            // Act
            dynamic result = await _userRepository.GetNameAndEmailOfAUser(1);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(result, Is.Not.Null);
                string fullName = result.GetType().GetProperty("FullName").GetValue(result);
                string email = result.GetType().GetProperty("Email").GetValue(result);
                Assert.That(fullName, Is.EqualTo("Test User"));
                Assert.That(email, Is.EqualTo("existing@test.com"));
            });
        }

        [Test]
        public async Task GetInfoOfAssigneeByRiskId_ValidRiskId_ReturnsAssigneeInfo()
        {
            // Act
            dynamic result = await _userRepository.GetInfoOfAssigneeByRiskId(1);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(result, Is.Not.Null);
                string fullName = result.GetType().GetProperty("FullName").GetValue(result);
                string email = result.GetType().GetProperty("Email").GetValue(result);
                Assert.That(fullName, Is.EqualTo("Test User"));
                Assert.That(email, Is.EqualTo("existing@test.com"));
            });
        }

        // Alternative approach using explicit type
        [Test]
        public async Task GetNameAndEmailOfAUser_ValidId_ReturnsUserInfo_Alternative()
        {
            // Act
            var result = await _userRepository.GetNameAndEmailOfAUser(1);
            var resultDict = result.GetType().GetProperties()
                .ToDictionary(prop => prop.Name, prop => prop.GetValue(result));

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(resultDict, Does.ContainKey("FullName"));
                Assert.That(resultDict, Does.ContainKey("Email"));
                Assert.That(resultDict["FullName"], Is.EqualTo("Test User"));
                Assert.That(resultDict["Email"], Is.EqualTo("existing@test.com"));
            });
        }

        [Test]
        public async Task GetInfoOfAssigneeByRiskId_ValidRiskId_ReturnsAssigneeInfo_Alternative()
        {
            // Act
            var result = await _userRepository.GetInfoOfAssigneeByRiskId(1);
            var resultDict = result.GetType().GetProperties()
                .ToDictionary(prop => prop.Name, prop => prop.GetValue(result));

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(resultDict, Does.ContainKey("FullName"));
                Assert.That(resultDict, Does.ContainKey("Email"));
                Assert.That(resultDict["FullName"], Is.EqualTo("Test User"));
                Assert.That(resultDict["Email"], Is.EqualTo("existing@test.com"));
            });
        }

        [Test]
        public async Task GetAllUsersWithDetailsAsync_ReturnsAllUsers()
        {
            // Act
            var users = await _userRepository.GetAllUsersWithDetailsAsync();

            // Assert
            Assert.That(users, Is.Not.Null);
            Assert.That(users.Count, Is.EqualTo(1));
            Assert.That(users[0].Department, Is.Not.Null);
        }

        [Test]
        public async Task GetUsersByDepartmentNameAsync_ValidDepartment_ReturnsUsers()
        {
            // Act
            var users = await _userRepository.GetUsersByDepartmentNameAsync("IT");

            // Assert
            Assert.That(users, Is.Not.Null);
            Assert.That(users.Count, Is.EqualTo(1));
            Assert.That(users[0].Department.DepartmentName, Is.EqualTo("IT"));
        }
    }

    // Simple implementation of IEmailService for testing
    public class SimpleEmailService : IEmailService
    {
        public Task SendEmail(string to, string subject, string body)
        {
            return Task.CompletedTask;
        }
    }
}
