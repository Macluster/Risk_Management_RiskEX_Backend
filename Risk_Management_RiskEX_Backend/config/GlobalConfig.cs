namespace Risk_Management_RiskEX_Backend.config
{
    public class GlobalConfig
    {

        public static readonly HashSet<string> AdminEmails = new(StringComparer.OrdinalIgnoreCase)
        {
            
            "riskex@experionglobal.com",
            "admin@gmail.com",
            "superadmin@example.com"
        };

        public static bool IsAdmin(string email) => AdminEmails.Contains(email);
    }
}
