using System.Security.Claims;

namespace FishingLogMVC.Core
{
    public class DBPassword
    {

        private static readonly FishingLog.BLL.user _u = new FishingLog.BLL.user();
        public static string Login(string username, string password)
        { 
            return _u.GetUserId(username, password)??"" ;
        }
    }
}
