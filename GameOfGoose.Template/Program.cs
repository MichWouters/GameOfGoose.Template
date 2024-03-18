using GameOfGoose.Template;
using GameOfGoose.Template.Business.Game;

var startup = new Startup();
var game = startup.SetupGame();

PrintTitle();
uint amountOfPlayers = GetPlayers(game);
game.PlayGame(amountOfPlayers);
uint GetPlayers(Game game)
{
    Console.WriteLine("How many players are playing?");

    if (uint.TryParse(Console.ReadLine(), out uint amountOfPlayers))
    {
        if (amountOfPlayers is 0 or > 4)
        {
            Console.WriteLine("Game needs between one and four players. Try again");
            return GetPlayers(game);
        }

        return amountOfPlayers;
    }
    else
    {
        Console.WriteLine("Invalid number. Please try again");
        return GetPlayers(game);
    }
}

void PrintTitle()
{
    string text =
        """
          ________                               ________
         /  _____/  ____   ____  ______ ____    /  _____/_____    _____   ____
        /   \  ___ /  _ \ /  _ \/  ___// __ \  /   \  ___\__  \  /     \_/ __ \
        \    \_\  (  <_> |  <_> )___ \\  ___/  \    \_\  \/ __ \|  Y Y  \  ___/
         \______  /\____/ \____/____  >\___  >  \______  (____  /__|_|  /\___  >
                \/                  \/     \/          \/     \/      \/     \/
        """;

    var randomColor = new Random().Next(0, 16);
    Console.ForegroundColor = (ConsoleColor)randomColor;

    Console.WriteLine(text);
    Console.ResetColor();
}