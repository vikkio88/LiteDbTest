namespace Repositories;
public class PlayersRepository : Repository<Models.Player>
{
    protected override String _repoName { get => "players"; }
    public PlayersRepository(LiteDB.ILiteDatabase db) : base(db) { }

}
