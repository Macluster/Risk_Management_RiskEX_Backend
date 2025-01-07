using AutoMapper;
using Risk_Management_RiskEX_Backend.Data;
using Risk_Management_RiskEX_Backend.Interfaces;
using Risk_Management_RiskEX_Backend.Models.DTO;
using Risk_Management_RiskEX_Backend.Models;
using Microsoft.EntityFrameworkCore;
using Risk_Management_RiskEX_Backend.Services;

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

        public async Task<int> AddUserToDepartment(UsersDTO userDto)
        {
            try
            {
                // Begin transaction
                await using var transaction = await _db.Database.BeginTransactionAsync();
                try
                {
                    // Input validation
                    if (string.IsNullOrWhiteSpace(userDto.Email))
                    {
                        _logger.LogError("User email cannot be empty.");
                        return 0;
                    }

                    // Check for existing user
                    var existingUser = await _db.Users.FirstOrDefaultAsync(u => u.Email == userDto.Email);
                    if (existingUser != null)
                    {
                        _logger.LogError($"User with email {userDto.Email} already exists.");
                        return 0;
                    }

                    // Validate and get department
                    var department = await _db.Departments
                                    .FirstOrDefaultAsync(d => d.DepartmentName.ToLower() == userDto.DepartmentName.ToLower());
                    if (department == null)
                    {
                        _logger.LogError($"Department with name {userDto.DepartmentName} not found.");
                        return 0;
                    }

                    // Create new User entity using AutoMapper
                    var user = _mapper.Map<User>(userDto);
                    user.DepartmentId = department.Id;
                    user.CreatedAt = DateTime.UtcNow;
                    user.UpdatedAt = DateTime.UtcNow;
                    user.IsActive = true;
                    var hashedPassword = _userService.GetHashedPassword(DEFAULT_PASSWORD);
                    user.Password = hashedPassword;

                    // Handle project associations if provided
                    if (userDto.ProjectNames != null && userDto.ProjectNames.Any())
                    {
                        var projects = await _db.Projects
                            .Where(p => userDto.ProjectNames.Contains(p.Name))
                            .ToListAsync();

                        // Verify all project names were found
                        var foundProjectNames = projects.Select(p => p.Name).ToList();
                        var missingProjects = userDto.ProjectNames
                            .Where(name => !foundProjectNames.Contains(name, StringComparer.OrdinalIgnoreCase))
                            .ToList();

                        if (missingProjects.Any())
                        {
                            _logger.LogError($"Projects not found: {string.Join(", ", missingProjects)}");
                            return 0;
                        }
                        user.Projects = projects;
                    }

                    // Add user to database
                    await _db.Users.AddAsync(user);
                    await _db.SaveChangesAsync();

                    // Important: Commit the transaction before sending email
                    await transaction.CommitAsync();

                    // Send welcome email after transaction is committed
                    try
                    {
                        await _emailService.SendEmail(
                            user.Email,
                            "Your Account Credentials",
                            $"Welcome to the system!\n\n" +
                            $"Your account has been created with the following credentials:\n" +
                            $"Username: {user.Email}\n" +
                            $"Password: {DEFAULT_PASSWORD}\n\n" +
                            "Please change your password upon first login for security purposes."
                        );
                    }
                    catch (Exception emailEx)
                    {
                        _logger.LogWarning($"Failed to send welcome email: {emailEx.Message}");
                        // Don't rollback transaction for email failure
                    }

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
                .Where(u => u.Department.DepartmentName == departmentName) 
                .ToListAsync();
        }


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
    }
}











