using Microsoft.EntityFrameworkCore;
using Risk_Management_RiskEX_Backend.Data;
using Risk_Management_RiskEX_Backend.Interfaces;
using Risk_Management_RiskEX_Backend.Models;

namespace Risk_Management_RiskEX_Backend.Repository
{
    /// <summary>
    /// To do Db opreation on Account
    /// </summary>
    public class AccountRepository: IAccountRepository
    {
        private readonly ApplicationDBContext _db;

        /// <summary>
        /// Initializes <see cref="AccountRepository"/>
        /// </summary>
        /// <param name="db">The database context instance</param>
        public AccountRepository(ApplicationDBContext db)
        {
            _db = db;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<User> GetUserByIdAsync(int userId)
        {
            return await _db.Users.FirstOrDefaultAsync(u => u.Id == userId);
        }

        public async Task UpdateUserPasswordAsync(User user)
        {
            _db.Users.Update(user);
            await _db.SaveChangesAsync();
        }
    }
}
