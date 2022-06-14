namespace Database;


public class Db
{
    private static LiteDB.ILiteDatabase _db = null;
    private static readonly object _classLock = typeof(LiteDB.ILiteDatabase);
    private static readonly object _locker = new object();

    private Db()
    {}

    public static LiteDB.ILiteDatabase GetInstance()
    {
        lock (_classLock)
        {
            if (_db == null)
            {
                _db = new LiteDB.LiteDatabase("Some.db");
            }
        }

        return _db;
    }
}
