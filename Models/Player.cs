namespace Models;
public class Player
{
    private int _skill = 0;
    [LiteDB.BsonId]
    public LiteDB.ObjectId Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public int Skill { get => _skill; set { _skill = value switch { >= 100 => 100, <= 0 => 0, _ => value }; } }

}
