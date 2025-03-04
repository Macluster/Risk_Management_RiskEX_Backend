namespace Risk_Management_RiskEX_Backend.congig
{
    public class GlobalConfig
    {

        public static readonly HashSet<string> AdminEmails = new(StringComparer.OrdinalIgnoreCase)
        {
            "admin@gmail.com",
            "riskex@experionglobal.com",
            "superadmin@example.com",
            "anotheradmin@example.com"
        };

        // Utility method for checking admin status
        public static bool IsAdmin(string email) => AdminEmails.Contains(email);
    }
}
