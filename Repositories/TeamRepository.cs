namespace Repositories;
public class TeamRepository : Repository<Models.Team>
{
    protected override String _repoName { get => "teams"; }
    public TeamRepository(LiteDB.ILiteDatabase db) : base(db) { }

}
