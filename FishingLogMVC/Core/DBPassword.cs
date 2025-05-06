using System.Security.Claims;

namespace FishingLogMVC.Core
{
    public class DBPassword
    {
        public static string Login(string username, string password)
        {
            if (username == password)
            {
                return "1";
            }
            return "";
        }

        internal static object GetUserByID(string userId)
        {
            return userId == "1" ? "1" : null;
        }
    }
}
