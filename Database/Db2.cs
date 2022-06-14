namespace Database;


public class Db2 : Singleton<Db2>
{
    private LiteDB.ILiteDatabase _db;
    public LiteDB.ILiteDatabase Db { get => _db; }

    public Db2()
    {
        _db = new LiteDB.LiteDatabase("Some.db");
    }
}
