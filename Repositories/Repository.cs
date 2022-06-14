namespace Repositories;
abstract public class Repository<T>
{
    protected virtual String _repoName { get => String.Empty; }
    private LiteDB.ILiteCollection<T> _collection;

    public LiteDB.ILiteCollection<T> Collection { get => _collection; }
    public Repository(LiteDB.ILiteDatabase db)
    {
        _collection = db.GetCollection<T>(_repoName);
    }
}
