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

        public UserService(PasswordService passwordService,IAuthRepository authRepository)
        {
            _passwordService = passwordService;
            _authRepository = authRepository;
            
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
       
    }

}
