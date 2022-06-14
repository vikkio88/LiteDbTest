namespace Managers;
public class TeamManager
{
    private Repositories.TeamRepository _tr;
    public TeamManager(Repositories.TeamRepository teamRepository)
    {
        _tr = teamRepository;
    }

    public void Main()
    {
        const String BACK = "b";
        var choice = String.Empty;
        while (choice != BACK)
        {
            choice = Helpers.InputHelper.Menu(" 1. Print All\n 2. Add One\n 3. Remove One\n 4. Print Roster For One\n\n b. BACK", "Main Menu > Teams Management");
            switch (choice)
            {
                case "1": { PrintAll(); break; }
                case "2": { AddOne(); break; }
                case "3": { RemoveOne(); break; }
                case "4": { PrintRosterForOne(); break; }
            };
        }
    }

    public void PrintAll()
    {
        Console.WriteLine("All Teams:\n\n");
        foreach (var t in _tr.Collection.FindAll())
        {
            Console.WriteLine($"{t.Id} - {t.Name}");
        }
        Helpers.InputHelper.EnterToContinue();
    }


    public void AddOne()
    {
        Console.Write("Team Name: > ");
        String name = Console.ReadLine();
        var t = new Models.Team() { Name = name ?? "Not Defined" };
        _tr.Collection.Insert(t);
        Helpers.InputHelper.EnterToContinue();
    }


    public void RemoveOne()
    {
        Console.Write("Team Id: > ");
        String idString = Console.ReadLine();
        var id = new LiteDB.ObjectId(idString);
        if (_tr.Collection.Delete(id))
        {
            Console.Write("... DELETED Successfully");
        }
        else
        {
            Console.Write($"... Could not DELETE {id}");
        }
        Helpers.InputHelper.EnterToContinue();
    }

    public void PrintRosterForOne()
    {
        Console.Write("Team Id: > ");
        String idString = Console.ReadLine();
        var id = new LiteDB.ObjectId(idString);
        var team = _tr.Collection.Include(x => x.Roster).FindById(id);
        Console.WriteLine($"Team: {team.Name} - Roster");
        foreach (var p in team.Roster)
        {
            Console.WriteLine($"{p.Id} - {p.Name}");
        }

        Helpers.InputHelper.EnterToContinue();
    }
}
