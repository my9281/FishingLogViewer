using LiteDB;

namespace FishingLogMVC.Interfaces
{
    public interface INoSQLDB<T>
    {
        LiteDatabase GetDB();
    }
}