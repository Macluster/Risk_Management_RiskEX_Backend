using Microsoft.EntityFrameworkCore;
using Risk_Management_RiskEX_Backend.Data;
using Risk_Management_RiskEX_Backend.Interfaces;
using Risk_Management_RiskEX_Backend.Models.DTO;
using Risk_Management_RiskEX_Backend.Repository;

namespace Risk_Management_RiskEX_Backend.Services
{
    public class UserService
    {
        private readonly PasswordService _passwordService;
        private IAuthRepository _authRepository;
        private readonly ApplicationDBContext _context;

        public UserService(PasswordService passwordService,IAuthRepository authRepository, ApplicationDBContext context)
        {
            _passwordService = passwordService;
            _authRepository = authRepository;
            _context = context;
        }

        // Register new user
        public  string Register(LoginRequestDTO model)
        {
            // Hash the password before storing it
            string hashedPassword = _passwordService.HashPassword(model.Password);
            return hashedPassword;
           

            // Store username and hashedPassword in the database
            // Example: Save username and hashedPassword in the Users table
        }

        public string GetHashedPassword(string password)
        {
            // Hash the password before storing it
            string hashedPassword = _passwordService.HashPassword(password);
            return hashedPassword;


            // Store username and hashedPassword in the database
            // Example: Save username and hashedPassword in the Users table
        }

        // Verify user login
        public async Task<LoginResponseDTO> Login( LoginRequestDTO model)
        {
            // Hash the password before storing it
       
            
            var loginResponse = await _authRepository.LoginUser(model,_passwordService);

            return loginResponse;

            // Store username and hashedPassword in the database
            // Example: Save username and hashedPassword in the Users table
        }
        public async Task<int?> GetDepartmentIdByUserIdAsync(string userId)
        {
            if (!int.TryParse(userId, out int parsedUserId))
                return null;

            var user = await _context.Users
                .AsNoTracking()
                .Where(u => u.Id == parsedUserId && u.IsActive)
                .Select(u => u.DepartmentId)
                .FirstOrDefaultAsync();

            return user;
        }

        public async Task<List<int>> GetProjectIdsByUserIdAsync(string userId)
        {
            if (!int.TryParse(userId, out int parsedUserId))
                return new List<int>();

            return await _context.Users
                .Where(u => u.Id == parsedUserId)
                .SelectMany(u => u.Projects.Select(p => p.Id))
                .ToListAsync();
        }
    }

}
