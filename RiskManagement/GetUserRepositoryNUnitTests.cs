//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using AutoMapper;
//using Microsoft.EntityFrameworkCore;
//using Moq;
//using Risk_Management_RiskEX_Backend.Data;
//using Risk_Management_RiskEX_Backend.Models;
//using Risk_Management_RiskEX_Backend.Repository;

//namespace RiskManagement
//{
//    public class GetUserRepositoryNUnitTests
//    {
//        private Mock<IMapper> _mockMapper;
//        private ApplicationDBContext _dbContext;
//        private GetUserRepository _userRepository;

//        [SetUp]
//        public void Setup()
//        {
//            var options = new DbContextOptionsBuilder<ApplicationDBContext>()
//                .UseInMemoryDatabase(databaseName: "TestDb")
//                .Options;

//            _dbContext = new ApplicationDBContext(options);
//            _mockMapper = new Mock<IMapper>();
//            _userRepository = new GetUserRepository(_dbContext, _mockMapper.Object);

//            SeedDatabase();
//        }

//        private void SeedDatabase()
//        {
//            // Adding sample data to Users
//            var department = new Department { Id = 1, DepartmentName = "IT" };
//            _dbContext.Departments.Add(department);

//            var user1 = new User
//            {
//                Id = 1,
//                Email = "user1@example.com",
//                FullName = "User One",
//                DepartmentId = 1,
//                IsActive = true,
//                Department = department
//            };

//            var user2 = new User
//            {
//                Id = 2,
//                Email = "user2@example.com",
//                FullName = "User Two",
//                DepartmentId = 1,
//                IsActive = true,
//                Department = department
//            };

//            _dbContext.Users.Add(user1);
//            _dbContext.Users.Add(user2);
//            _dbContext.SaveChanges();
//        }

//        [Test]
//        public async Task GetAllUsers_ShouldReturnAllUsers()
//        {
//            // Act
//            var result = await _userRepository.GetAllUsers();

//            // Assert
//            Assert.AreEqual(2, result.Count());
//            Assert.IsTrue(result.Any(u => u.FullName == "User One"));
//            Assert.IsTrue(result.Any(u => u.FullName == "User Two"));
//        }

//        [Test]
//        public async Task GetUserById_ShouldReturnUserWithValidId()
//        {
//            // Act
//            var result = await _userRepository.GetUserById(1);

//            // Assert
//            Assert.IsNotNull(result);
//            Assert.AreEqual(1, result.Id);
//            Assert.AreEqual("User One", result.FullName);
//        }

//        [Test]
//        public async Task GetUserById_ShouldReturnNullForInvalidId()
//        {
//            // Act
//            var result = await _userRepository.GetUserById(99);

//            // Assert
//            Assert.IsNull(result);
//        }

//        [Test]
//        public void GetUsersByDepartment_ShouldReturnUsersInSameDepartment()
//        {
//            // Act
//            var result = _userRepository.GetUsersByDepartment(1);

//            // Assert
//            Assert.AreEqual(2, result.Count());
//            Assert.IsTrue(result.Any(u => u.FullName == "User One"));
//            Assert.IsTrue(result.Any(u => u.FullName == "User Two"));
//        }

//        [Test]
//        public void GetUsersByProject_ShouldReturnUsersAssignedToProject()
//        {
//            // Assuming you have a project with users assigned to it, you'd update this test accordingly.
//            // Here we mock the Project entity if required.

//            var result = _userRepository.GetUsersByProject(1); // Adjust based on your project id

//            // Assert
//            Assert.IsNotNull(result);
//            // You can further assert based on your project relations
//        }
    
//}
//}
