namespace Managers;
public class PlayerManager
{
    private Repositories.PlayersRepository _pr;
    public PlayerManager(Repositories.PlayersRepository playersRepository)
    {
        _pr = playersRepository;
    }

    public void Main()
    {
        const String BACK = "b";
        var choice = String.Empty;
        while (choice != BACK)
        {
            choice = Helpers.InputHelper.Menu(" 1. Print All\n 2. Add One\n 3. Remove One\n\n b. BACK", "Main Menu > Players Management");
            switch (choice)
            {
                case "1": { PrintAll(); break; }
                case "2": { AddOne(); break; }
                case "3": { RemoveOne(); break; }
            };
        }
    }

    public void PrintAll()
    {
        Console.WriteLine("All Players:\n\n");
        foreach (var p in _pr.Collection.FindAll())
        {
            Console.WriteLine($"{p.Id} - {p.Name} - age {p.Age} - Skill {p.Skill}");
        }
        Helpers.InputHelper.EnterToContinue();
    }


    public void AddOne()
    {
        Console.Write("Player Name: > ");
        String name = Console.ReadLine();
        Console.Write("Player Age: > ");
        int age = Int32.Parse(Console.ReadLine());
        Console.Write("Skill: > ");
        int skill = Int32.Parse(Console.ReadLine());
        var t = new Models.Player() { Name = name ?? "Not Defined", Age = age, Skill = skill};
        _pr.Collection.Insert(t);
        Helpers.InputHelper.EnterToContinue();
    }


    public void RemoveOne()
    {
        Console.Write("Player Id: > ");
        String idString = Console.ReadLine();
        var id = new LiteDB.ObjectId(idString);
        if (_pr.Collection.Delete(id))
        {
            Console.Write("... DELETED Successfully");
        }
        else
        {
            Console.Write($"... Could not DELETE {id}");
        }
        Helpers.InputHelper.EnterToContinue();
    }


}
