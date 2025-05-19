namespace Risk_Management_RiskEX_Backend.Interfaces
{
    public interface IPasswordService
    {
        public string HashPassword(string password);
        public bool VerifyPassword(string hashedPassword, string passwordToCheck);
    }
}
