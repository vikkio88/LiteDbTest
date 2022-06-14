using Helpers;
using Database;

// var dbInstance = Db.GetInstance();
var dbInstance = Db2.Instance.Db;
var pRepo = new Repositories.PlayersRepository(dbInstance);
var tRepo = new Repositories.TeamRepository(dbInstance);

var teamManager = new Managers.TeamManager(tRepo);
var playerManager = new Managers.PlayerManager(pRepo);

var choice = String.Empty;
const String QUIT = "q";
while (choice != QUIT)
{
    choice = InputHelper.Menu("1. Teams\n2. Players\n\nq. QUIT", "Main Menu");
    switch (choice)
    {
        case "1": { teamManager.Main(); break; }
        case "2": { playerManager.Main(); break; }
    };
}

Console.WriteLine("Bye!\n\n");
