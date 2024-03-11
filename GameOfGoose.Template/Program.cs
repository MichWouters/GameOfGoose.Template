using GameOfGoose.Template;
using GameOfGoose.Template.Business.Boards;
using GameOfGoose.Template.Business.Factories;
using GameOfGoose.Template.Business.Game;
using Microsoft.Extensions.DependencyInjection;

var serviceProvider = new ServiceCollection()
        .AddSingleton<IGameBoard, GameBoard>()
        .AddTransient<ISquareFactory, SquareFactory>()
        .AddTransient<IPlayerFactory, PlayerFactory>()
        .AddTransient<IDiceRoller, DiceRoller>()
        .AddTransient<ILogger, Logger>()
        .AddSingleton<Game>()
    .BuildServiceProvider();

var game = serviceProvider.GetRequiredService<Game>();
SetupPlayers(game);
void SetupPlayers(Game game)
{
    Console.WriteLine("How many players are playing?");

    if (int.TryParse(Console.ReadLine(), out int amountOfPlayers))
    {
        game.PlayGame(amountOfPlayers);
    }
    else
    {
        Console.WriteLine("Invalid number. Please try again");
        SetupPlayers(game);
    }
}
