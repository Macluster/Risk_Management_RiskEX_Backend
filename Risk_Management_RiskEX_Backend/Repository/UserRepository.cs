using AutoMapper;
using Risk_Management_RiskEX_Backend.Data;
using Risk_Management_RiskEX_Backend.Interfaces;
using Risk_Management_RiskEX_Backend.Models.DTO;
using Risk_Management_RiskEX_Backend.Models;
using Microsoft.EntityFrameworkCore;
using Risk_Management_RiskEX_Backend.Services;
using Risk_Management_RiskEX_Backend.congig;

namespace Risk_Management_RiskEX_Backend.Repository
{
    public class UserRepository : IUserRepository
    {
        private const string DEFAULT_PASSWORD = "experion@123";
        private readonly ApplicationDBContext _db;
        private readonly IMapper _mapper;
        private readonly ILogger<UserRepository> _logger;
        private readonly IEmailService _emailService;
        private readonly UserService _userService;


        public UserRepository(ApplicationDBContext db, IMapper mapper, ILogger<UserRepository> logger, IEmailService emailService, UserService userService)
        {
            _db = db;
            _mapper = mapper;
            _logger = logger;
            _emailService = emailService;
            _userService = userService;
        }

        public class UserOperationException : Exception
        {
            public UserOperationException(string message) : base(message) { }
        }

        public async Task<int> AddUserToDepartment(UsersDTO userDto)
        {
            try
            {
                await using var transaction = await _db.Database.BeginTransactionAsync();
                try
                {
                    if (string.IsNullOrWhiteSpace(userDto.Email))
                    {
                        _logger.LogError("User email cannot be empty.");
                        return 0;
                    }

                    var existingUser = await _db.Users.FirstOrDefaultAsync(u => u.Email == userDto.Email);
                    if (existingUser != null)
                    {
                        _logger.LogError($"User with email {userDto.Email} already exists.");
                        return 0;
                    }

                    var department = await _db.Departments
                                    .FirstOrDefaultAsync(d => d.DepartmentName.ToLower() == userDto.DepartmentName.ToLower());
                    if (department == null)
                    {
                        _logger.LogError($"Department with name {userDto.DepartmentName} not found.");
                        return 0;
                    }

                    var user = _mapper.Map<User>(userDto);
                    user.DepartmentId = department.Id;
                    user.CreatedAt = DateTime.UtcNow;
                    user.UpdatedAt = DateTime.UtcNow;
                    user.IsActive = true;
                    var hashedPassword = _userService.GetHashedPassword(DEFAULT_PASSWORD);
                    user.Password = hashedPassword;

                    if (userDto.ProjectIds != null && userDto.ProjectIds.Any())
                    {
                        var projects = await _db.Projects
                            .Where(p => userDto.ProjectIds.Contains(p.Id))
                            .ToListAsync();

                        var foundProjectIds = projects.Select(p => p.Id).ToList();
                        var missingProjects = userDto.ProjectIds
                            .Where(Id => !foundProjectIds.Contains(Id))
                            .ToList();

                        if (missingProjects.Any())
                        {
                            _logger.LogError($"Projects not found: {string.Join(", ", missingProjects)}");
                            return 0;
                        }
                        user.Projects = projects;
                    }

                    await _db.Users.AddAsync(user);
                    await _db.SaveChangesAsync();

                    await transaction.CommitAsync();

                    return user.Id;
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    _logger.LogError(ex, "Error in transaction while adding user");
                    throw;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error adding user to department");
                return 0;
            }
        }


        public async Task<bool> UpdateUser(int userId, UsersDTO userDto)
        {
            try
            {
                var user = await _db.Users
                    .Include(u => u.Projects)
                    .FirstOrDefaultAsync(u => u.Id == userId);

                if (user == null)
                {
                    _logger.LogError($"User with ID {userId} not found.");
                    return false;
                }

                if (!string.IsNullOrWhiteSpace(userDto.FullName))
                {
                    user.FullName = userDto.FullName;
                }

                if (!string.IsNullOrWhiteSpace(userDto.DepartmentName))
                {
                    var department = await _db.Departments.FirstOrDefaultAsync(d => d.DepartmentName == userDto.DepartmentName);
                    if (department != null)
                    {
                        user.DepartmentId = department.Id; 
                    }
                    else
                    {
                        _logger.LogError($"Department '{userDto.DepartmentName}' not found.");
                        return false;
                    }
                }

                // Handle project updates (including removal)
                if (userDto.ProjectIds != null)
                {
                    if (userDto.ProjectIds.Any()) // If project list is not empty, update the projects
                    {
                        var projects = await _db.Projects
                            .Where(p => userDto.ProjectIds.Contains(p.Id))
                            .ToListAsync();

                        var foundProjectIds = projects.Select(p => p.Id).ToList();
                        var missingProjects = userDto.ProjectIds
                            .Where(id => !foundProjectIds.Contains(id))
                            .ToList();

                        if (missingProjects.Any())
                        {
                            _logger.LogError($"Projects not found: {string.Join(", ", missingProjects)}");
                            return false;
                        }

                        user.Projects = projects;
                    }
                    else // If an empty list is passed, remove all projects
                    {
                        user.Projects.Clear();
                    }
                }

                // Allow email update only if it's unique
                if (!string.IsNullOrWhiteSpace(userDto.Email) && userDto.Email != user.Email)
                {
                    var emailExists = await _db.Users.AnyAsync(u => u.Email == userDto.Email && u.Id != userId);
                    if (emailExists)
                    {
                        _logger.LogError($"Email {userDto.Email} is already in use.");
                        return false;
                    }
                    user.Email = userDto.Email;
                }

                user.UpdatedAt = DateTime.UtcNow;

                _db.Users.Update(user);
                await _db.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating user.");
                return false;
            }
        }



        public async Task<bool> ChangeUserActiveStatus(int id,bool isActive)
        {
            var user=await _db.Users.FirstOrDefaultAsync(u => u.Id == id);
            if(user!=null)
            {
                user.IsActive = isActive;

                _db.Users.Update(user);
                await _db.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }

          
           
        }

        public async Task<Object> GetNameAndEmailOfAUser(int userId)
        {
            var User=  await _db.Users.FirstOrDefaultAsync(e=>e.Id==userId);

            AssigneeResponseDTO assigneeResponseDTO=  _mapper.Map<AssigneeResponseDTO>(User);

            return new
            {
                User.FullName,
                User.Email
                
            };
        }

        public async Task<Object> GetInfoOfAssigneeByRiskId(int riskId)
        {
            var risks = await _db.Risks.Include(e=>e.ResponsibleUser).FirstOrDefaultAsync(e => e.Id == riskId);

           

            return new
            {
                FullName=risks.ResponsibleUser.FullName,
                Email=risks.ResponsibleUser.Email

            };
        }


        public async Task<List<User>> GetAllUsersWithDetailsAsync()
        {
            return await _db.Users
                .Include(u => u.Department)
                .Include(u => u.Projects)
                .ToListAsync();
        }

        public async Task<List<User>> GetUsersByDepartmentNameAsync(string departmentName)
        {
            return await _db.Users
                .Include(u => u.Department)  
                .Include(u => u.Projects)   
                .Where(u => u.Department.DepartmentName == departmentName && !GlobalConfig.AdminEmails.Contains(u.Email)) 
                .ToListAsync();
        }
        public async Task<List<User>> GetUsersByDepartmentIdAsync(int departmentId)
        {
            return await _db.Users
                .Include(u => u.Department)
                .Include(u => u.Projects)
                .Where(u => u.Department.Id == departmentId &&
                            u.IsActive &&
                            !GlobalConfig.AdminEmails.Contains(u.Email))
                .ToListAsync();
        }
        //public async Task<List<User>> GetUsersByDepartmentIdAsync(int departmentId)
        //{
        //    return await _db.Users
        //        .Include(u => u.Department)
        //        .Include(u => u.Projects)
        //        .Where(u => u.Department.Id == departmentId && !GlobalConfig.AdminEmails.Contains(u.Email))
        //        .ToListAsync();
        //}

        public async Task<List<dynamic>> GetUsersByProjects(int[] projectIds)
        {
            var users = await _db.Users
        .Where(u => u.Projects.Any(p => projectIds.Contains(p.Id))) // Filter users by project IDs
        .Select(u => new
        {
            id = u.Id,
            fullName = u.FullName,
            email = u.Email,
            isActive = u.IsActive,
            department = u.Department.DepartmentName,
            projects = u.Projects.Select(p => p.Name).ToList()
        })
        .ToListAsync();

            return users.Cast<dynamic>().ToList(); // Cast to dynamic
        }



        public async Task<object> GetNameAndEmailOfAUserbyRiskid(int riskId)
        {
            if (riskId == null)
            {
                return new List<GetUserDTO>();
            }

            var user = await _db.Risks
                .Where(r => r.Id == riskId)
                .Include(r => r.CreatedBy)
                .Select(r => new 
                {
                    Id = r.CreatedBy.Id,
                    Name = r.CreatedBy.FullName,
                    Email = r.CreatedBy.Email,

                })
                .ToListAsync();

            return user;

        }

        public async Task<string> GetCreatedByUserNameAsync(string riskId)
        {
            var risk = await _db.Risks
                .FirstOrDefaultAsync(r => r.RiskId == riskId);

            if (risk == null || risk.CreatedById == null)
            {
                return "User Not Found";
            }

            var user = await _db.Users
                .FirstOrDefaultAsync(u => u.Id == risk.CreatedById);

            return user?.FullName ?? "User Not Found";
        }


    }
}











