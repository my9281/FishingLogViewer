using FishingLogMVC.Interfaces;
using LiteDB;

namespace FishingLogMVC.Core
{
    public class NoSQLDBService<T> : INoSQLDB<T>
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly static LiteDatabase innerdb = new LiteDatabase("NoSQLData.DB");
        public NoSQLDBService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        } 
        public LiteDatabase GetDB()
        {
            return innerdb;
        }
    }
}
