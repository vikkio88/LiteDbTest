namespace Models;

public class Team
{
    public LiteDB.ObjectId Id { get; set; }
    public string Name { get; set; }
    
    [LiteDB.BsonRef("players")]
    public List<Player> Roster { get; set; }

}
